using FluentValidation.Results;
using Kameyo.Core.Application.Common.Enums;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Catalog.Dtos.Response;
using Kameyo.Core.Application.Modules.Company.Dtos.Response;
using Kameyo.Core.Application.Modules.Contact.Dtos.Response;
using Kameyo.Core.Application.Modules.Contact.Mapping;
using Kameyo.Core.Application.Modules.Customer.Dtos;
using Kameyo.Core.Application.Modules.Customer.Mapping;
using Kameyo.Core.Application.Modules.Employee.Dtos.Response;
using Kameyo.Core.Application.Modules.Employee.Mapping;
using Kameyo.Core.Application.Modules.FinancialParticipation.Dtos.Response;
using Kameyo.Core.Application.Modules.HourBank.Dtos.Response;
using Kameyo.Core.Application.Modules.MenuUserType.Dtos.Response;
using Kameyo.Core.Application.Modules.Project.Dtos.Response;
using Kameyo.Core.Application.Modules.Project.Mapping;
using Kameyo.Core.Application.Modules.ProjectHourBank.Dtos.Response;
using Kameyo.Core.Application.Modules.ProjectManager.Dtos.Response;
using Kameyo.Core.Application.Modules.ProjectReport.Dtos.Response;
using Kameyo.Core.Application.Modules.ProjectReportDetail.Dtos.Response;
using Kameyo.Core.Application.Modules.ProjectResource.Dtos.Response;
using Kameyo.Core.Application.Modules.ProjectTask.Dtos.Response;
using Kameyo.Core.Application.Modules.Subsidiary.Dtos.Response;
using Kameyo.Core.Application.Modules.TaskActivity.Dtos.Response;
using Kameyo.Core.Domain.Entities;
using Kameyo.Core.Domain.Mappings;
using Microsoft.AspNetCore.Identity;

namespace Kameyo.Core.Application.Common.Mappings
{
    public static class MappingExtensions
    {
        public static Task<ResultPaginated<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize)
            => ResultPaginated<TDestination>.CreateAsync(queryable, pageNumber, pageSize);

        public static List<CompanyDtoResponse> MapToCompaniesDTO(this IEnumerable<Domain.Entities.Company> entities)
        {
            var result = new List<CompanyDtoResponse>();
            foreach (var entity in entities)
            {
                result.Add(CompanyMapping.MapToCompanyDTO(entity));
            }
            return result;
        }

        public static List<ProjectDtoResponse> MapToProjectsDTO(this IEnumerable<Domain.Entities.Project> entities)
        {
            var result = new List<ProjectDtoResponse>();
            foreach (var entity in entities)
            {
                result.Add(ProjectMapping.MapToProjectDTO(entity));
            }
            return result;
        }


        public static List<ProjectReportDtoResponse> MapToProjectReportsDTO(this IEnumerable<Domain.Entities.ProjectReport> entities)
        {
            var result = new List<ProjectReportDtoResponse>();
            foreach (var entity in entities)
            {
                result.Add(ProjectReportMapping.MapToProjectReportDTO(entity));
            }
            return result;
        }

        public static List<ProjectReportDetailDtoResponse> MapToProjectReportsDetailDTO(this IEnumerable<Domain.Entities.ProjectReportDetail> entities)
        {
            var result = new List<ProjectReportDetailDtoResponse>();
            foreach (var entity in entities)
            {
                result.Add(ProjectReportDetailMapping.MapToProjectReportDetailDTO(entity));
            }
            return result;
        }


        public static List<ProjectTasksDtoResponse> MapToProjectTasksDTO(this IEnumerable<Domain.Entities.ProjectTask> entities)
        {
            var result = new List<ProjectTasksDtoResponse>();
            foreach (var entity in entities)
            {
                result.Add(ProjectTaskMapping.MapToProjectTasksDTO(entity));
            }
            return result;
        }

        public static List<ProjectResourcesDtoResponse> MapToProjectResourcesDTO(this IEnumerable<Domain.Entities.ProjectResource> entities)
        {
            var result = new List<ProjectResourcesDtoResponse>();
            foreach (var entity in entities)
            {
                result.Add(ProjectResourceMapping.MapToProjectResourceDTO(entity));
            }
            return result;
        }

        public static List<ProjectHourBanksDtoResponse> MapToProjectHourBanksDTO(this IEnumerable<Domain.Entities.ProjectHourBank> entities)
        {
            var result = new List<ProjectHourBanksDtoResponse>();
            foreach (var entity in entities)
            {
                result.Add(ProjectHourBankMapping.MapToProjectHourBankDTO(entity));
            }
            return result;
        }

        public static List<ProjectManagersDtoResponse> MapToProjectManagersDTO(this IEnumerable<Domain.Entities.ProjectManager> entities)
        {
            var result = new List<ProjectManagersDtoResponse>();
            foreach (var entity in entities)
            {
                result.Add(ProjectManagerMapping.MapToProjectManagerDTO(entity));
            }
            return result;
        }

        public static List<TaskActivitiesDtoResponse> MapToTaskActivitiesDTO(this IEnumerable<Domain.Entities.TaskActivity> entities)
        {
            var result = new List<TaskActivitiesDtoResponse>();
            foreach (var entity in entities)
            {
                result.Add(TaskActivityMapping.MapToTaskActivitiesDTO(entity));
            }
            return result;
        }

        public static List<FinancialParticipationDtoResponse> MapToFinancialParticipationDTO(this IEnumerable<Domain.Entities.FinancialParticipation> entities)
        {
            var result = new List<FinancialParticipationDtoResponse>();
            foreach (var entity in entities)
            {
                result.Add(FinancialParticipationMapping.MapToFinancialParticipationDTO(entity));
            }
            return result;
        }

        public static List<SubsidiariesDtoResponse> MapToSubsidiariesDTO(this IEnumerable<Domain.Entities.Subsidiary> entities)
        {
            var result = new List<SubsidiariesDtoResponse>();
            foreach (var entity in entities)
            {
                result.Add(SubsidiaryMapping.MapToSubsidiaryDTO(entity));
            }
            return result;
        }

        public static List<HourBanksDtoResponse> MapToHourBanksDTO(this IEnumerable<Domain.Entities.HourBank> entities)
        {
            var result = new List<HourBanksDtoResponse>();
            foreach (var entity in entities)
            {
                result.Add(HourBankMapping.MapToHourBanksDtoResponse(entity));
            }
            return result;
        }

        public static List<CatalogsDtoResponse> MapToCatalogsDTO(this IEnumerable<Domain.Entities.Catalog> entities)
        {
            var result = new List<CatalogsDtoResponse>();
            foreach (var entity in entities)
            {
                result.Add(CatalogMapping.MapToCatalogDTO(entity));
            }
            return result;
        }



        public static List<EmployeeDtoResponse> MapToEmployeesDTO(this IEnumerable<Domain.Entities.Employee> entities)
        {
            var result = new List<EmployeeDtoResponse>();
            foreach (var entity in entities)
            {
                result.Add(EmployeeMapping.MapToEmployeeDTO(entity));
            }
            return result;
        }

        public static List<CustomerDtoResponse> MapToCustomersDTO(this IEnumerable<Domain.Entities.Customer> entities)
        {
            var result = new List<CustomerDtoResponse>();
            foreach (var entity in entities)
            {
                result.Add(CustomerMapping.MapToCustomerDTO(entity));
            }
            return result;
        }


        public static List<ContactDtoResponse> MapToContactsDTO(this IEnumerable<Domain.Entities.Contact> entities)
        {
            var result = new List<ContactDtoResponse>();
            foreach (var entity in entities)
            {
                result.Add(ContactMapping.MapToContactDTO(entity));
            }
            return result;
        }

        public static List<ResultValidationFailure> MapToResultValidationFailure(this List<ValidationFailure> validationFailure)
        {
            var result = new List<ResultValidationFailure>();

            foreach (var item in validationFailure)
            {
                result.Add(new ResultValidationFailure()
                {
                    Code = item.ErrorCode,
                    Name = item.PropertyName,
                    Message = item.ErrorMessage
                });
            }
            return result;
        }

        public static List<ResultValidationFailure> MapToResultValidationFailure(this IEnumerable<IdentityError> validationFailure)
        {
            var result = new List<ResultValidationFailure>();

            foreach (var item in validationFailure)
            {
                result.Add(new ResultValidationFailure()
                {
                    Code = item.Code,
                    Name = "IdentityError",
                    Message = item.Description
                });
            }
            return result;
        }


        public static List<GetMenuUserTypeQueryResponse> MapToMenuUserTypeDto(this List<Catalog> menus, IEnumerable<MenuRole> menuUserType, Guid roleId)
        {
            var response = new List<GetMenuUserTypeQueryResponse>();
            var userTypeName = UsersTypeEnum.UserTypes().FirstOrDefault(x => x.Id == roleId)?.Name ?? string.Empty;

            foreach (var menu in menus.Where(x => x.ParentId == null).OrderBy(x => x.Order))
            {
                //response.Add(new GetMenuUserTypeQueryResponse()
                //{
                //    Id = null,
                //    CatalogMenuId = menu.Id,
                //    MenuName = menu.Value,
                //    UserTypeId = userTypeId,
                //    UserTypeName = userTypeName,
                //    MenuSelected = false
                //});

                foreach (var subMenu in menus.Where(x => x.ParentId == menu.Id))
                {
                    var menuUserTypeSelected = menuUserType.FirstOrDefault(x => x.RoleId == roleId && x.CatalogMenuId == subMenu.Id);
                    response.Add(new GetMenuUserTypeQueryResponse()
                    {
                        Id = menuUserTypeSelected != null ? menuUserTypeSelected.Id : Guid.NewGuid(),
                        CatalogMenuId = subMenu.Id,
                        RoleId = roleId,
                        MenuName = menu.Value,
                        SubMenuName = subMenu.Value,
                        UserTypeName = userTypeName,
                        MenuSelected = menuUserTypeSelected != null
                    });
                }
            }

            return response;
        }
    }
}
