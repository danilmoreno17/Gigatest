using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kameyo.Core.Application.Common.Models
{
    public class ResultPaginated<T> : ResultBase<T>
    {
        public ResultPaginated(HttpStatusCode status, List<T> items, int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            Data = items;
            Succeeded = true;
            Errors = new List<ResultValidationFailure>();
            Status = status;
        }

        public ResultPaginated(HttpStatusCode status, List<ResultValidationFailure> errors)
        {
            PageNumber = 0;
            TotalPages = 0;
            TotalCount = 0;
            Data = new List<T>();
            Succeeded = false;
            Errors = errors;
            Status = status;
        }

        public int PageNumber { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;

        public static ResultPaginated<T> Failure(List<ResultValidationFailure> errors) => new(HttpStatusCode.BadRequest, errors);
        public static ResultPaginated<T> PreconditionFailure(List<ResultValidationFailure> errors) => new(HttpStatusCode.PreconditionFailed, errors);


        public static async Task<ResultPaginated<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new ResultPaginated<T>(HttpStatusCode.OK, items, count, pageNumber, pageSize);
        }
    }
}
