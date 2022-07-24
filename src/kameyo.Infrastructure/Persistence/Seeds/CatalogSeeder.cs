using Kameyo.Core.Application.Common.Enums;
using Kameyo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kameyo.Infrastructure.Persistence.Seeds
{
    public class CatalogSeeder : IEntityTypeConfiguration<Catalog>
    {
        public void Configure(EntityTypeBuilder<Catalog> builder)
        {
            var dataSource = new List<Catalog>() { };

            #region Catalog IDENTIFICATIONTYPE

            dataSource.Add(new Catalog { Id = new Guid("22874dde-3ef1-4875-bc02-88c7863444f1"), ParentId = null, Name = CatalogsEnum.IDENTIFICATIONTYPE.Name, Value = "Ruc", Description = "Tipo de identificacion ruc", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = new Guid("9b09536a-ec98-4303-8506-b4ba43f67812"), ParentId = null, Name = CatalogsEnum.IDENTIFICATIONTYPE.Name, Value = "Cedula", Description = "Tipo de identificacion cedula", Order = 1, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = new Guid("baa8773a-9f1d-40d5-ae96-44dbf5993656"), ParentId = null, Name = CatalogsEnum.IDENTIFICATIONTYPE.Name, Value = "DNI", Description = "Tipo de identificacion DNI", Order = 2, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            #endregion

            #region Catalog Regions

            #region Catalog Regions - Ecuador
            dataSource.Add(new Catalog { Id = new Guid("f504e9d9-edd3-475f-8452-e5fc899fa033"), ParentId = null, Name = CatalogsEnum.COUNTRIES.Name, Value = "ECUADOR", Description = "Pais Ecuador", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });

            dataSource.Add(new Catalog { Id = new Guid("d7e2a0ba-f955-4717-bf72-26c72ad4305b"), ParentId = new Guid("f504e9d9-edd3-475f-8452-e5fc899fa033"), Name = CatalogsEnum.STATES.Name, Value = "MANABI", Description = "Provincia MANABI", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = new Guid("5cbdbb13-b93d-46a3-852e-9ec0a5083a83"), ParentId = new Guid("f504e9d9-edd3-475f-8452-e5fc899fa033"), Name = CatalogsEnum.STATES.Name, Value = "PICHINCHA", Description = "Provincia PICHINCHA", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = new Guid("5afe07a2-fd5e-478c-93ad-cc6c8aee7e8e"), ParentId = new Guid("f504e9d9-edd3-475f-8452-e5fc899fa033"), Name = CatalogsEnum.STATES.Name, Value = "GUAYAS", Description = "Provincia GUAYAS", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });

            dataSource.Add(new Catalog { Id = new Guid("f9d2e8b0-5309-479a-a9a0-e5272002a68c"), ParentId = new Guid("d7e2a0ba-f955-4717-bf72-26c72ad4305b"), Name = CatalogsEnum.CITY.Name, Value = "PORTOVIEJO", Description = "Ciudad PORTOVIEJO", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = new Guid("2a9977da-8282-46ce-a944-9897b13ba477"), ParentId = new Guid("d7e2a0ba-f955-4717-bf72-26c72ad4305b"), Name = CatalogsEnum.CITY.Name, Value = "MANTA", Description = "Ciudad MANTA", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });

            dataSource.Add(new Catalog { Id = new Guid("eae6dd86-2c18-4a8b-be0a-751e533c8ce9"), ParentId = new Guid("5cbdbb13-b93d-46a3-852e-9ec0a5083a83"), Name = CatalogsEnum.CITY.Name, Value = "QUITO", Description = "Ciudad QUITO", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = new Guid("fa6f37f1-7b11-44fe-be08-7004f1f2bd99"), ParentId = new Guid("5cbdbb13-b93d-46a3-852e-9ec0a5083a83"), Name = CatalogsEnum.CITY.Name, Value = "SANGOLQUI", Description = "Ciudad SANGOLQUI", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });

            dataSource.Add(new Catalog { Id = new Guid("9e07bed6-eee4-4fd6-afc1-bcb13b0ea7cc"), ParentId = new Guid("5afe07a2-fd5e-478c-93ad-cc6c8aee7e8e"), Name = CatalogsEnum.CITY.Name, Value = "GUAYAQUIL", Description = "Ciudad GUAYAQUIL", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = new Guid("064cdae7-d711-4b3f-ae64-35447988825c"), ParentId = new Guid("5afe07a2-fd5e-478c-93ad-cc6c8aee7e8e"), Name = CatalogsEnum.CITY.Name, Value = "DURAN", Description = "Ciudad DURAN", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = new Guid("bda11fce-1441-4818-9db1-8743c0c1e8ba"), ParentId = new Guid("5afe07a2-fd5e-478c-93ad-cc6c8aee7e8e"), Name = CatalogsEnum.CITY.Name, Value = "DAULE", Description = "Ciudad DAULE", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });

            #endregion

            #region Catalog Regions - Colombia
            dataSource.Add(new Catalog { Id = new Guid("5286a15e-2883-4165-b1df-3896319fa80d"), ParentId = null, Name = CatalogsEnum.COUNTRIES.Name, Value = "COLOMBIA", Description = "Pais COLOMBIA", Order = 1, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });

            #endregion

            #region Catalog Regions - San Salvador
            dataSource.Add(new Catalog { Id = new Guid("cf546c4c-bf37-46a7-b96c-a8091972cd03"), ParentId = null, Name = CatalogsEnum.COUNTRIES.Name, Value = "SAN SALVADOR", Description = "Pais SAN SALVADOR", Order = 2, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });

            #endregion

            #endregion

            #region Catalog Industries

            #region Catalog Industry type - Comercio
            dataSource.Add(new Catalog { Id = new Guid("1bcf3c7b-2e0e-4401-aa5f-d1460363b885"), ParentId = null, Name = CatalogsEnum.INDUSTRYTYPE.Name, Value = "COMERCIO", Description = "Tipo de industria - COMERCIO", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });

            #region Catalog Sub Type Industry 
            dataSource.Add(new Catalog { Id = new Guid("0576c349-ce1e-4761-a4ec-7ef228f426f5"), ParentId = null, Name = CatalogsEnum.INDUSTRYSUBTYPE.Name, Value = "CONFITERIA", Description = "Sub Tipo de industria - CONFITERIA", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });

            #endregion
            #endregion

            #endregion

            #region Catalog CURRENCY
            dataSource.Add(new Catalog { Id = new Guid("f124a4c3-b3e2-4e6b-96d4-26d4712be343"), ParentId = null, Name = CatalogsEnum.CURRENCY.Name, Value = "DOLAR", Description = "DOLAR", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = new Guid("1d49a30e-921e-4e9b-b1ca-d4bdce4cf431"), ParentId = null, Name = CatalogsEnum.CURRENCY.Name, Value = "PESO COLOMBIANO", Description = "Peso colombiano", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            #endregion

            #region Catalog Area
            dataSource.Add(new Catalog { Id = new Guid("b7571cdb-50bb-4c0d-ae2e-f854f5fddc24"), ParentId = null, Name = CatalogsEnum.AREA.Name, Value = "AREA1", Description = "DOLAR", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            #endregion

            #region Catalog Departmen
            dataSource.Add(new Catalog { Id = new Guid("e1cf4d2a-de84-4f11-a480-e4acad0a689d"), ParentId = null, Name = CatalogsEnum.DEPARTMEN.Name, Value = "DEPARTMEN1", Description = "DOLAR", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            #endregion

            #region Catalog CostCenter
            dataSource.Add(new Catalog { Id = new Guid("33220a02-5ae9-46b9-9f3e-664cfe140320"), ParentId = null, Name = CatalogsEnum.COSTCENTER.Name, Value = "COSTCENTER1", Description = "DOLAR", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            #endregion

            #region Catalog Position
            dataSource.Add(new Catalog { Id = new Guid("c7d0f2c1-8039-4171-b4a2-e67defafd387"), ParentId = null, Name = CatalogsEnum.POSITION.Name, Value = "POSITION1", Description = "DOLAR", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            #endregion

            #region Catalog EmployeeType
            dataSource.Add(new Catalog { Id = new Guid("5fadbd15-2505-44f9-b197-8c8b255cb3e6"), ParentId = null, Name = CatalogsEnum.EMPLOYEETYPE.Name, Value = "CONSULTOR", Description = "CONSULTOR", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            #endregion

            #region Catalog Project
            #region Catalog Project Type
            dataSource.Add(new Catalog { Id = new Guid("32855971-ebcd-49ab-ad62-6150d5e7695b"), ParentId = null, Name = CatalogsEnum.PROJECTTYPE.Name, Value = "TIPO DE PROYECTO 1", Description = "TIPO DE PROYECTO", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = new Guid("c072e641-926b-4b31-8f3f-9d0c156fc101"), ParentId = null, Name = CatalogsEnum.PROJECTTYPE.Name, Value = "TIPO DE PROYECTO 2", Description = "TIPO DE PROYECTO", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = new Guid("d40e4b16-77d9-4bdc-bed3-2a57628ac33f"), ParentId = null, Name = CatalogsEnum.PROJECTTYPE.Name, Value = "TIPO DE PROYECTO 3", Description = "TIPO DE PROYECTO", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            #endregion

            #region Catalog Project Categories
            dataSource.Add(new Catalog { Id = new Guid("b0df1134-a322-4a26-8a48-26d3376aecdd"), ParentId = null, Name = CatalogsEnum.PROJECTCATEGORY.Name, Value = "CATEGORIA DE PROYECTO 1", Description = "CATEGORIA DE PROYECTO", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = new Guid("112f1c62-e1bd-47c0-8056-82e51afeb5d0"), ParentId = null, Name = CatalogsEnum.PROJECTCATEGORY.Name, Value = "CATEGORIA DE PROYECTO 2", Description = "CATEGORIA DE PROYECTO", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = new Guid("24f884da-f77e-4f92-bef7-c594c9099cd3"), ParentId = null, Name = CatalogsEnum.PROJECTCATEGORY.Name, Value = "CATEGORIA DE PROYECTO 3", Description = "CATEGORIA DE PROYECTO", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            #endregion

            #region Catalog Project State
            dataSource.Add(new Catalog { Id = new Guid("0c0d36bd-b065-40e8-aa03-a7e11ab5be37"), ParentId = null, Name = CatalogsEnum.PROJECTSTATE.Name, Value = "ESTADO DE PROYECTO 1", Description = "ESTADO DE PROYECTO", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = new Guid("fa1fc274-168b-4485-ad16-00ea5f172ffa"), ParentId = null, Name = CatalogsEnum.PROJECTSTATE.Name, Value = "ESTADO DE PROYECTO 2", Description = "ESTADO DE PROYECTO", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = new Guid("bf2f0e91-3a1c-4843-a148-c9c053ab1bed"), ParentId = null, Name = CatalogsEnum.PROJECTSTATE.Name, Value = "ESTADO DE PROYECTO 3", Description = "ESTADO DE PROYECTO", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            #endregion

            #region Catalog Project Task Type

            dataSource.Add(new Catalog { Id = new Guid("edc0e8f7-47a3-40c4-ad3f-bac12f653c02"), ParentId = null, Name = CatalogsEnum.PROJECTTASKTYPE.Name, Value = "TIPO DE TAREA DE PROYECTO 1", Description = "TIPO DE TAREA DE PROYECTO  01", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = new Guid("d42cc742-599a-452f-a26f-bb9fb04766f8"), ParentId = null, Name = CatalogsEnum.PROJECTTASKTYPE.Name, Value = "TIPO DE TAREA DE PROYECTO 2", Description = "TIPO DE TAREA DE PROYECTO  02", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = new Guid("ed2fb04f-dcd9-4351-868c-88447e128e70"), ParentId = null, Name = CatalogsEnum.PROJECTTASKTYPE.Name, Value = "TIPO DE TAREA DE PROYECTO 3", Description = "TIPO DE TAREA DE PROYECTO  03", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });

            #endregion

            #region Catalog Project Task State

            dataSource.Add(new Catalog { Id = new Guid("c3908d96-19a5-40cf-a870-c3d34e96ac1b"), ParentId = null, Name = CatalogsEnum.PROJECTTASKSTATE.Name, Value = "ESTADO DE TAREA DE PROYECTO 1", Description = "ESTADO DE TAREA DE PROYECTO  01", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = new Guid("c73fe620-e152-4b29-87ad-9ae2004cdfbf"), ParentId = null, Name = CatalogsEnum.PROJECTTASKSTATE.Name, Value = "ESTADO DE TAREA DE PROYECTO 2", Description = "ESTADO DE TAREA DE PROYECTO  02", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = new Guid("d81648db-ef11-4e71-b33b-5b47f5344bdd"), ParentId = null, Name = CatalogsEnum.PROJECTTASKSTATE.Name, Value = "ESTADO DE TAREA DE PROYECTO 3", Description = "ESTADO DE TAREA DE PROYECTO  03", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });

            #endregion

            #endregion

            #region Catalog Product Type
            dataSource.Add(new Catalog { Id = new Guid("d574f93d-f75f-469d-aed6-d5b294f73911"), ParentId = null, Name = CatalogsEnum.PRODUCTTYPE.Name, Value = "TIPO DE PRODUCTO 1", Description = "TIPO DE PRODUCTO 01", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = new Guid("1003026b-9d77-4032-b23c-d0a1e603ce18"), ParentId = null, Name = CatalogsEnum.PRODUCTTYPE.Name, Value = "TIPO DE PRODUCTO 2", Description = "TIPO DE PRODUCTO 02", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = new Guid("20ec3f22-9ab7-4b29-bc15-d6359ac16e29"), ParentId = null, Name = CatalogsEnum.PRODUCTTYPE.Name, Value = "TIPO DE PRODUCTO 3", Description = "TIPO DE PRODUCTO 03", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            #endregion

            #region Catalog Employee Rol
            dataSource.Add(new Catalog { Id = new Guid("8fcee89a-2264-4d49-89ef-e97cb37f39ce"), ParentId = null, Name = CatalogsEnum.EMPLOYEEROL.Name, Value = "ROL DEL EMPLEADO 1", Description = "ROL DEL EMPLEADO  01", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = new Guid("5359a438-abcd-4e21-9a7c-9f0107059b3e"), ParentId = null, Name = CatalogsEnum.EMPLOYEEROL.Name, Value = "ROL DEL EMPLEADO 2", Description = "ROL DEL EMPLEADO  02", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = new Guid("30f9eaa1-9029-495d-866a-2b6b5f41c2b6"), ParentId = null, Name = CatalogsEnum.EMPLOYEEROL.Name, Value = "ROL DEL EMPLEADO 3", Description = "ROL DEL EMPLEADO  03", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            #endregion

            #region Catalog UsersType

            dataSource.Add(new Catalog { Id = UsersTypeEnum.User.Id, ParentId = null, Name = CatalogsEnum.USERSTYPE.Name, Value = UsersTypeEnum.User.Name, Description = "Usuario tipo Usuario", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = UsersTypeEnum.Contact.Id, ParentId = null, Name = CatalogsEnum.USERSTYPE.Name, Value = UsersTypeEnum.Contact.Name, Description = "Usuario tipo Contacto", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = UsersTypeEnum.Employee.Id, ParentId = null, Name = CatalogsEnum.USERSTYPE.Name, Value = UsersTypeEnum.Employee.Name, Description = "Usuario tipo Empleado", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = UsersTypeEnum.Manager.Id, ParentId = null, Name = CatalogsEnum.USERSTYPE.Name, Value = UsersTypeEnum.Manager.Name, Description = "Usuario tipo Gerente", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = UsersTypeEnum.Administrator.Id, ParentId = null, Name = CatalogsEnum.USERSTYPE.Name, Value = UsersTypeEnum.Administrator.Name, Description = "Usuario tipo Administrador", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });

            #endregion

            #region Catalog Menus

            foreach (var itemParent in MenusEnum.Menus().Where(x => x.ParentId == null).OrderBy(x => x.Order))
            {
                dataSource.Add(new Catalog { Id = itemParent.Id, ParentId = null, Name = CatalogsEnum.MENUS.Name, Description = itemParent.Description, Value = itemParent.Name, Value2 = itemParent.Icon, Order = itemParent.Order, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });

                foreach (var menu in MenusEnum.Menus().Where(x => x.ParentId == itemParent.Id).OrderBy(x => x.Order))
                {
                    dataSource.Add(new Catalog { Id = menu.Id, ParentId = menu.ParentId, Name = CatalogsEnum.MENUS.Name, Description = menu.Description, Value = menu.Name, Value1 = menu.Url, Order = menu.Order, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
                }
            }

            #endregion

            #region DISCRETIONARYTYPE
            dataSource.Add(new Catalog { Id = new Guid("c051f36c-5c8d-4aae-8c82-57a284c6929e"), ParentId = null, Name = CatalogsEnum.DISCRETIONARYTYPE.Name, Value = "CULMINACIÓN DE PROYECTO", Description = "CULMINACIÓN DE PROYECTO", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });
            dataSource.Add(new Catalog { Id = new Guid("f601b318-b0f9-4940-b5eb-bcb33ae7f5ea"), ParentId = null, Name = CatalogsEnum.DISCRETIONARYTYPE.Name, Value = "PREMIO", Description = "PREMIO", Order = 0, IsSystemOwner = true, Created = DateTime.UtcNow, CreatedBy = "System", Active = true });

            #endregion

            builder.HasData(dataSource);
        }
    }
}
