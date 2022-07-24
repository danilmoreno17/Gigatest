namespace Kameyo.Infrastructure.Identity.User.Dtos.Response
{
    public class UserRolesSelectResponse
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool RoleSelected { get; set; }
    }
}
