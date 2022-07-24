using Kameyo.Core.Application.Common.Enums;
using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kameyo.Infrastructure.Persistence.Seeds
{
    public class MenuRoleSeeder : IEntityTypeConfiguration<MenuRole>
    {
        public void Configure(EntityTypeBuilder<MenuRole> builder)
        {
            var dataSource = new List<MenuRole>();

            #region Menu for user type RoleEnum.User
            dataSource.Add(new MenuRole { Id = Guid.NewGuid(), RoleId = RoleEnum.User.Id, CatalogMenuId = MenusEnum.Dashboard.Id, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new MenuRole { Id = Guid.NewGuid(), RoleId = RoleEnum.User.Id, CatalogMenuId = MenusEnum.DashboardAnalytical.Id, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });

            dataSource.Add(new MenuRole { Id = Guid.NewGuid(), RoleId = RoleEnum.User.Id, CatalogMenuId = MenusEnum.Reports.Id, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new MenuRole { Id = Guid.NewGuid(), RoleId = RoleEnum.User.Id, CatalogMenuId = MenusEnum.ReportsProjectsActivities.Id, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new MenuRole { Id = Guid.NewGuid(), RoleId = RoleEnum.User.Id, CatalogMenuId = MenusEnum.ReportsBillingActivities.Id, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new MenuRole { Id = Guid.NewGuid(), RoleId = RoleEnum.User.Id, CatalogMenuId = MenusEnum.ReportsUnifiedClientStates.Id, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });

            #endregion

            #region Menu for user type RoleEnum.Customer

            dataSource.Add(new MenuRole { Id = Guid.NewGuid(), RoleId = RoleEnum.Customer.Id, CatalogMenuId = MenusEnum.Movements.Id, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new MenuRole { Id = Guid.NewGuid(), RoleId = RoleEnum.Customer.Id, CatalogMenuId = MenusEnum.MovementsProjectReport.Id, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });

            dataSource.Add(new MenuRole { Id = Guid.NewGuid(), RoleId = RoleEnum.Customer.Id, CatalogMenuId = MenusEnum.Reports.Id, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new MenuRole { Id = Guid.NewGuid(), RoleId = RoleEnum.Customer.Id, CatalogMenuId = MenusEnum.ReportsProjectsActivities.Id, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new MenuRole { Id = Guid.NewGuid(), RoleId = RoleEnum.Customer.Id, CatalogMenuId = MenusEnum.ReportsBillingActivities.Id, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new MenuRole { Id = Guid.NewGuid(), RoleId = RoleEnum.Customer.Id, CatalogMenuId = MenusEnum.ReportsUnifiedClientStates.Id, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });

            #endregion

            #region Menu for user type RoleEnum.Consultant

            dataSource.Add(new MenuRole { Id = Guid.NewGuid(), RoleId = RoleEnum.Consultant.Id, CatalogMenuId = MenusEnum.Dashboard.Id, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new MenuRole { Id = Guid.NewGuid(), RoleId = RoleEnum.Consultant.Id, CatalogMenuId = MenusEnum.DashboardAnalytical.Id, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });

            dataSource.Add(new MenuRole { Id = Guid.NewGuid(), RoleId = RoleEnum.Consultant.Id, CatalogMenuId = MenusEnum.Reports.Id, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new MenuRole { Id = Guid.NewGuid(), RoleId = RoleEnum.Consultant.Id, CatalogMenuId = MenusEnum.ReportsProjectsActivities.Id, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new MenuRole { Id = Guid.NewGuid(), RoleId = RoleEnum.Consultant.Id, CatalogMenuId = MenusEnum.ReportsBillingActivities.Id, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new MenuRole { Id = Guid.NewGuid(), RoleId = RoleEnum.Consultant.Id, CatalogMenuId = MenusEnum.ReportsUnifiedClientStates.Id, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });

            #endregion

            #region Menu for user type RoleEnum.Manager

            foreach (var itemParent in MenusEnum.Menus().Where(x => x.ParentId == null).OrderBy(x => x.Order))
            {
                dataSource.Add(new MenuRole { Id = Guid.NewGuid(), RoleId = RoleEnum.Manager.Id, CatalogMenuId = itemParent.Id, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });

                foreach (var menu in MenusEnum.Menus().Where(x => x.ParentId == itemParent.Id).OrderBy(x => x.Order))
                {
                    dataSource.Add(new MenuRole { Id = Guid.NewGuid(), RoleId = RoleEnum.Manager.Id, CatalogMenuId = menu.Id, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
                }
            }

            #endregion

            #region Menu for user type UsersTypeEnum.Administrator
            foreach (var itemParent in MenusEnum.Menus().Where(x => x.ParentId == null).OrderBy(x => x.Order))
            {
                dataSource.Add(new MenuRole { Id = Guid.NewGuid(), RoleId = RoleEnum.Administrator.Id, CatalogMenuId = itemParent.Id, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });

                foreach (var menu in MenusEnum.Menus().Where(x => x.ParentId == itemParent.Id).OrderBy(x => x.Order))
                {
                    dataSource.Add(new MenuRole { Id = Guid.NewGuid(), RoleId = RoleEnum.Administrator.Id, CatalogMenuId = menu.Id, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
                }
            }
            #endregion            

            builder.HasData(dataSource);
        }
    }
}
