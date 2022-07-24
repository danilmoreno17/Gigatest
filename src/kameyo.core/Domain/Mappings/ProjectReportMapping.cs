using Kameyo.Core.Application.Modules.Project.Dtos.Response;
using Kameyo.Core.Application.Modules.Project.Mapping;
using Kameyo.Core.Application.Modules.ProjectReport.Dtos.Response;



namespace Kameyo.Core.Domain.Mappings
{
    public class ProjectReportMapping
    {
        public ProjectReportMapping()
        {

        }

        public static ProjectReportDtoResponse MapToProjectReportDTO(Domain.Entities.ProjectReport entity)
        {
            return new ProjectReportDtoResponse
            {
                Id = entity.Id,
                ProjectId = entity.ProjectId,
                CustomerApproved = entity.CustomerApproved,
                CustomerApprovedDate = entity.CustomerApprovedDate,
                Invoiced = entity.Invoiced,
                InvoicedDate = entity.InvoicedDate,
                Paid = entity.Paid,
                PaidDate = entity.PaidDate,
                ProjectReportDate = entity.ProjectReportDate,
                State = entity.State,
                ProjectReportDetails = ProjectReportDetailMapping.MapToProjectReportDetailDTO(entity.ProjectReportDetails),
                Project = ProjectMapping.MapToProjectDTO(entity.Project)
               
                 //ProjectReport.MapListToProjectResourcesDTO(entity.ProjectReportDetails),


            };
        }



        //public void UpdateUserEntity(Domain.Entities.Project entity, ProjectUpdateDtoRequest dto)
        //{            
        //    entity.FirstName = dto.FirstName;
        //    entity.LastName = dto.LastName;
        //}
    }
}
