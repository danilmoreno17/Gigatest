//using kameyo.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Kameyo.Infrastructure.Identity.Entities;
using Kameyo.Core.Application.Common.Enums;

namespace Kameyo.Infrastructure.Persistence.Seeds
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            var roles = await AddRole(roleManager);
            if (roles.Count > 0)
            {
                await AddUsers(userManager, roleManager, roles);
            }
        }

        private static async Task<Dictionary<string, ApplicationRole>> AddRole(RoleManager<ApplicationRole> roleManager)
        {
            var result = new Dictionary<string, ApplicationRole>();

            foreach (var item in RoleEnum.Role())
            {
                if (roleManager.Roles.All(r => r.Name != item.Name))
                {
                    var rol = new ApplicationRole() { Id = item.Id.ToString(), Name = item.Name, NormalizedName = item.NormalizedName };
                    result.Add(item.Name, rol);
                    await roleManager.CreateAsync(rol);
                }
            }

            return result;
        }

        private static async Task AddUsers(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, Dictionary<string, ApplicationRole> roles)
        {
            // User administrator
            var user = new ApplicationUser
            {
                Id = "2863ae38-9aba-4551-a4b2-7cd8b6e4d2cf",
                UserName = "administrator@localhost.com",
                Email = "administrator@localhost.com",
                Active = true,
                PersonTypeId = UsersTypeEnum.Administrator.Id
            };
            await AddUser(userManager, roleManager, new[] { roles[RoleEnum.Administrator.Name].Name }, user, "Administrator1!");


            // User Manager
            var userRoles = new[] { roles[RoleEnum.Manager.Name].Name, roles[RoleEnum.User.Name].Name };
            user = new ApplicationUser
            {
                Id = "f2e0a43d-c03f-44f8-bba8-32a75b73eadd",
                UserName = "manager@localhost.com",
                Email = "manager@localhost.com",
                Active = true,
                PersonTypeId = UsersTypeEnum.Manager.Id
            };
            await AddUser(userManager, roleManager, userRoles, user, "Manager1!");

            // User Customer
            user = new ApplicationUser
            {
                Id = "a3780e6a-e15b-4fcf-b8f8-76cfeed3497b",
                UserName = "customer@localhost.com",
                Email = "customer@localhost.com",
                Active = true,
                PersonTypeId = UsersTypeEnum.Contact.Id
            };
            await AddUser(userManager, roleManager, new[] { roles[RoleEnum.Customer.Name].Name }, user, "Customer1!");

            // User consultant
            user = new ApplicationUser
            {
                Id = "6df81bb2-b12e-45c6-b7fb-3d5ccd134d66",
                UserName = "consultant@localhost.com",
                Email = "consultant@localhost.com",
                Active = true,
                PersonTypeId = UsersTypeEnum.Employee.Id
            };
            await AddUser(userManager, roleManager, new[] { roles[RoleEnum.Consultant.Name].Name }, user, "Consultant1!");

            // User user
            user = new ApplicationUser
            {
                Id = "bb1ef828-5659-4df8-ae88-fe54177fff92",
                UserName = "user@localhost.com",
                Email = "user@localhost.com",
                Active = true,
                PersonTypeId = UsersTypeEnum.User.Id
            };
            await AddUser(userManager, roleManager, new[] { roles[RoleEnum.User.Name].Name }, user, "User1!");
        }
        private static async Task AddUser(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            string[] roles,
            ApplicationUser user,
            string password)
        {
            if (userManager.Users.All(u => u.UserName != user.UserName))
            {
                await userManager.CreateAsync(user, password);
                await userManager.AddToRolesAsync(user, roles);
            }
        }
    }
}