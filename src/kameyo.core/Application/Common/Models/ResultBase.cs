using System.Net;

namespace Kameyo.Core.Application.Common.Models
{
    public abstract class ResultBase<T>
    {
        public List<T> Data { get; internal set; } = new List<T>();
        public bool Succeeded { get; set; }
        public HttpStatusCode Status
        {
            get;
            internal set;
        }
        public List<ResultValidationFailure> Errors { get; set; }= new List<ResultValidationFailure>();

    }
}
