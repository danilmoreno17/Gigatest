using DevExtreme.AspNet.Data.ResponseModel;
using System.Net;

namespace Kameyo.Core.Application.Common.Models
{
    public class LoadResultModel
    {
        internal LoadResultModel(HttpStatusCode status)
        {
            Status = status;
            Data = new LoadResult();
            Succeeded = true;
            Errors = new List<ResultValidationFailure>();
        }
        internal LoadResultModel(HttpStatusCode status, bool succeeded, List<ResultValidationFailure> errors)
        {
            Data = new LoadResult();
            Succeeded = succeeded;
            Errors = errors;
            Status = status;
        }

        internal LoadResultModel(HttpStatusCode status, LoadResult data, bool succeeded, List<ResultValidationFailure> errors)
        {
            Status = status;
            Data = data;
            Succeeded = succeeded;
            Errors = errors;
        }


        public LoadResult Data { get; internal set; } = new LoadResult();
        public bool Succeeded { get; set; }
        public HttpStatusCode Status
        {
            get;
            internal set;
        }
        public List<ResultValidationFailure> Errors { get; set; } = new List<ResultValidationFailure>();

        public static LoadResultModel Success() => new(HttpStatusCode.OK, new LoadResult(), true, new List<ResultValidationFailure>());
        public static LoadResultModel Success(LoadResult data) => new(HttpStatusCode.OK, data, true, new List<ResultValidationFailure>());
        public static LoadResultModel Success(LoadResult data, HttpStatusCode satusCode) => new(satusCode, data, true, new List<ResultValidationFailure>());
        public static LoadResultModel Failure(List<ResultValidationFailure> errors) => new(HttpStatusCode.BadRequest, false, errors);
        public static LoadResultModel NotFound() => new(HttpStatusCode.NotFound);
        public static LoadResultModel PreconditionFailure(List<ResultValidationFailure> errors) => new(HttpStatusCode.PreconditionFailed, false, errors);

    }
}
