using Kameyo.Core.Application.Common.Models;

namespace Kameyo.Core.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);
        Task<List<RolModel>> GetRoleByUser(string userEmail);
        Task<bool> IsInRoleAsync(string userId, string role);
        Task<bool> AuthorizeAsync(string userId, string policyName);
        Task<(ResultIdentity Result, string UserId)> CreateUserAsync(string userName, string password);
        Task<ResultIdentity> DeleteUserAsync(string userId);        
    }
}
