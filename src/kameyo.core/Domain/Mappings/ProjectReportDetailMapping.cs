using Kameyo.Core.Application.Modules.Customer.Mapping;
using Kameyo.Core.Application.Modules.Project.Mapping;
using Kameyo.Core.Application.Modules.ProjectReport.Dtos.Response;
using Kameyo.Core.Application.Modules.ProjectReportDetail.Dtos.Response;
using Kameyo.Core.Domain.Entities;
using Kameyo.Core.Domain.Mappings;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Domain.Mappings
{
    public class ProjectReportDetailMapping
    {
        public ProjectReportDetailMapping() { }

        public static ProjectReportDetailDtoResponse MapToProjectReportDetailDTO(Domain.Entities.ProjectReportDetail entity)
        {
            return new ProjectReportDetailDtoResponse
            {
                Id = entity.Id,
                ProjectReportId = entity.ProjectReportId,
                TaskActivityId = entity.TaskActivityId,
                TaskActivity = TaskActivityMapping.MapToTaskActivitiesDTO(entity.TaskActivity),
                ProjectReport = new ProjectReportDtoResponse
                {
                    Id = entity.Id,
                    ProjectId = entity.ProjectReport.ProjectId,
                    CustomerApproved = entity.ProjectReport.CustomerApproved,
                    CustomerApprovedDate = entity.ProjectReport.CustomerApprovedDate,
                    Invoiced = entity.ProjectReport.Invoiced,
                    InvoicedDate = entity.ProjectReport.InvoicedDate,
                    Paid = entity.ProjectReport.Paid,
                    PaidDate = entity.ProjectReport.PaidDate,
                    ProjectReportDate = entity.ProjectReport.ProjectReportDate,
                    State = entity.ProjectReport.State,
                    Project= ProjectMapping.MapToProjectDTO(entity.ProjectReport.Project),
                    CustomerName = entity.ProjectReport.Project.Customer.Name

                }
            };
        }
        public static List<ProjectReportDetailDtoResponse> MapToProjectReportDetailDTO(ICollection<Domain.Entities.ProjectReportDetail> projectDetailEntity)
        {
            var list = new List<ProjectReportDetailDtoResponse>();
            foreach (var entity in projectDetailEntity)
            {
                list.Add(MapToProjectReportDetailDTO(entity));
            }
            return list;
        }

    }
}
