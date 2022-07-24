
namespace Kameyo.Infrastructure.Identity.User.Dtos
{
    public class RoleClaimDto
    {
        public int Id { get; set; }
        public string RoleId { get; set; } = string.Empty;
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }
    }
}
