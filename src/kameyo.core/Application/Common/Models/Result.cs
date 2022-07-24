using System.Net;

namespace Kameyo.Core.Application.Common.Models
{
    public class Result<T> : ResultBase<T>
    {
        internal Result(HttpStatusCode status)
        {
            Status = status;
            Data = new List<T>();
            Succeeded = true;
            Errors = new List<ResultValidationFailure>();
        }
        internal Result(HttpStatusCode status, bool succeeded, List<ResultValidationFailure> errors)
        {
            Data = new List<T>();
            Succeeded = succeeded;
            Errors = errors;
        }

        internal Result(HttpStatusCode status, List<T> data, bool succeeded, List<ResultValidationFailure> errors)
        {
            Status = status;
            Data = data;
            Succeeded = succeeded;
            Errors = errors;
        }

        public static Result<T> Success() => new(HttpStatusCode.OK,new List<T>(), true, new List<ResultValidationFailure>());
        public static Result<T> Success(List<T> data) => new(HttpStatusCode.OK, data, true, new List<ResultValidationFailure>());
        public static Result<T> Success(List<T> data, HttpStatusCode satusCode) => new(satusCode, data, true, new List<ResultValidationFailure>());
        public static Result<T> Failure(List<ResultValidationFailure> errors) => new(HttpStatusCode.BadRequest, false, errors);
        public static Result<T> NotFound() => new(HttpStatusCode.NotFound);
        public static Result<T> PreconditionFailure(List<ResultValidationFailure> errors) => new(HttpStatusCode.PreconditionFailed, false, errors);
    }
}
