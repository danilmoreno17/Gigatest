namespace Kameyo.Core.Application.Common.Models
{
    public class ResultIdentity
    {
        internal ResultIdentity(bool succeeded, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
        }        

        public bool Succeeded { get; set; }

        public string[] Errors { get; set; }

        public static ResultIdentity Success()
        {
            return new ResultIdentity(true, Array.Empty<string>());
        }
        public static ResultIdentity Failure(IEnumerable<string> errors)
        {
            return new ResultIdentity(false, errors);
        }
    }
}
