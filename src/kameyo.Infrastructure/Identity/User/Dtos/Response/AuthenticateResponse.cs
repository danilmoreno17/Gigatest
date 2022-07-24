namespace Kameyo.Infrastructure.Identity.User.Dtos.Response
{
    public class AuthenticateResponse
    {
        public AuthenticateUser? User { get; set; }

        public string? AccessToken { get; set; } = string.Empty;

    }



}
