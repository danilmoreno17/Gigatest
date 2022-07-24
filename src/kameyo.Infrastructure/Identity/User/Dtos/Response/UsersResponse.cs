namespace Kameyo.Infrastructure.Identity.User.Dtos.Response;
public class UsersResponse
{
    public string Id { get; set; } = default!;    
    public string Email { get; set; } = default!;
    public Guid? PersonTypeId { get; set; } = null;
    public Guid? PersonId { get; set; } = null;    
    public bool EmailConfirmed { get; set; } = default!;   
    public List<UserRolesDto> UserRoles { get; set; } = new List<UserRolesDto>();

}

