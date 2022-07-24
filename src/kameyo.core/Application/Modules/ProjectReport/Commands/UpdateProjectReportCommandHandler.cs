using Kameyo.Core.Application.Common.Extensions;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.ProjectReport.Dtos.Request;
using Kameyo.Core.Domain.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectReport.Commands
{
    public class UpdateProjectReportCommandHandler : IRequestHandler<UpdateProjectReportCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdateProjectReportCommandHandler(IApplicationDbContext context)
        {
            _dbContext = context;
        }


        public async Task<Result<string>> Handle(UpdateProjectReportCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var projectReport = await _dbContext.ProjectReport.FindAsync(request.Id);
                if (projectReport != null)
                {
                    if (request.State != null)
                    {
                        projectReport.State = request.State.Value; //Aprobado por el cliente
                        if (projectReport.State == 'A')
                        {
                            projectReport.CustomerApproved = true;
                            projectReport.CustomerApprovedDate = DateTime.Now;
                        }
                        else if (projectReport.State == 'F')//Facturado
                        {

                            decimal ValBySubsidiary = 5m;
                            projectReport.Invoiced = true;
                            projectReport.InvoicedDate = DateTime.Now;


                            var projectReportDetail = await _dbContext.ProjectReportDetail
                                .Include(x => x.TaskActivity)
                                .Include(x => x.ProjectReport)
                                .ThenInclude(x => x.Project)
                                .ThenInclude(x => x.Customer)
                                .Where(x => x.ProjectReportId == projectReport.Id)
                            .Select(x => ProjectReportDetailMapping.MapToProjectReportDetailDTO(x))
                            .ToListAsync();



                            Dictionary<Guid, decimal> acumulador = new Dictionary<Guid, decimal>();

                            foreach (var taskActivity in projectReportDetail)
                            {
                                var acumuladorHorasAprobadas = 0m;

                                if (acumulador.TryGetValue(taskActivity.TaskActivity.EmployeeId, out acumuladorHorasAprobadas))
                                {
                                    acumulador[taskActivity.TaskActivity.EmployeeId] += acumuladorHorasAprobadas;

                                }
                                else
                                {
                                    acumuladorHorasAprobadas = 0m;
                                    //if (taskActivity.TaskActivity.TotalCost != null)
                                    acumuladorHorasAprobadas = taskActivity.TaskActivity.TotalTimeHourApproved;
                                    acumulador.Add(taskActivity.TaskActivity.EmployeeId, acumuladorHorasAprobadas);
                                }

                            }

                            foreach (KeyValuePair<Guid, decimal> entry in acumulador)
                            {
                                // CALCULO Y REGISTRO DE COMISION DIRECTA
                                var financialParticipation = new Domain.Entities.FinancialParticipation
                                {
                                    EmployeeId = entry.Key,
                                    Description = "Participación de Productividad Mensual " + projectReport.Year + StringExtensions.Right("0" + projectReport.Month, 2),
                                    CatalogDiscretionaryTypeId = new Guid("F601B318-B0F9-4940-B5EB-BCB33AE7F5EA"),
                                    Status = 'A',
                                    Month = projectReport.Month,
                                    Year = projectReport.Year,
                                    Type = 'D',
                                    Value = entry.Value * ValBySubsidiary//tabla de porcentajes de comision
                                };

                                _dbContext.FinancialParticipation.Add(financialParticipation);

                                var projectReportDetailResult = await _dbContext.ProjectReportDetail
                                    .Include(x => x.TaskActivity)
                                    .Where(x => x.ProjectReportId == projectReport.Id && x.TaskActivity.EmployeeId == entry.Key)
                                    .ToListAsync();

                                foreach (var report in projectReportDetailResult)
                                {
                                    report.FinancialParticipationId = financialParticipation.Id;
                                    _dbContext.ProjectReportDetail.Update(report);
                                }


                                //CALCULO DE COMISIÓN INDIRECTA AL JEFE
                                var employee = await _dbContext.Employees.FindAsync(entry.Key);

                                if (employee != null && employee.ParentId != null)
                                {

                                    var financialParticipationIndirect = new Domain.Entities.FinancialParticipation
                                    {
                                        EmployeeId = employee.ParentId.Value,
                                        Description = String.Format("Participación Indirecta ({0} {1})", employee.LastName, employee.Names),
                                        CatalogDiscretionaryTypeId = null,
                                        Status = 'A',
                                        Month = projectReport.Month,
                                        Year = projectReport.Year,
                                        Type = 'I',
                                        Value = financialParticipation.Value * 0.05m
                                    };

                                    _dbContext.FinancialParticipation.Add(financialParticipationIndirect);
                                }


                                //Calculo de Participación por Productividad

                                var listPercent = await _dbContext.PercentageParticipationTable
                                    .Where(x => x.SubsidiaryId == projectReport.Project.Customer.SubsidiaryId)
                                    .OrderBy(x => x.MaxValue)
                                    .ToListAsync();

                                var participationProductivity = await _dbContext.FinancialParticipation
                                    .Where(x => x.EmployeeId == entry.Key && x.Type == 'P' &&
                                    x.Year == projectReport.Year &&
                                    x.Month == projectReport.Month)
                                    .FirstOrDefaultAsync();

                                var totalHoursByEmployee = await _dbContext.ProjectReportDetail
                                    .Where(x => x.TaskActivity.EmployeeId == entry.Key && x.ProjectReport.Year == projectReport.Year
                                    && x.ProjectReport.Month == projectReport.Month
                                        && x.ProjectReport.State == 'A'
                                    ).SumAsync(e=> e.TaskActivity.TotalTimeHourApproved);


                                var percentParticipationProductivity = 0m;

                                foreach (var percent in listPercent)
                                    if (percent.MaxValue > totalHoursByEmployee)
                                    {
                                        percentParticipationProductivity = percent.Percent;
                                        break;
                                    }



                                if (participationProductivity == null)
                                {

                                    var financialParticipationProductivity = new Domain.Entities.FinancialParticipation
                                    {
                                        EmployeeId = entry.Key,
                                        Description = String.Format("Participación por Productividad {0}%", percentParticipationProductivity * 100m),
                                        CatalogDiscretionaryTypeId = null,
                                        Status = 'A',
                                        Month = projectReport.Month,
                                        Year = projectReport.Year,
                                        Type = 'P',
                                        Value = financialParticipation.Value * percentParticipationProductivity
                                    };

                                    _dbContext.FinancialParticipation.Add(financialParticipationProductivity);
                                }
                                else
                                {

                                    participationProductivity.Description = String.Format("Participación por Productividad {0}%", percentParticipationProductivity * 100m);
                                    participationProductivity.Value = totalHoursByEmployee * percentParticipationProductivity;

                                    _dbContext.FinancialParticipation.Update(participationProductivity);
                                }
                            }






                        }
                        else if (projectReport.State == 'P')//Pagado
                        {
                            projectReport.Paid = true;
                            projectReport.PaidDate = DateTime.Now;
                        }
                    }

                    if (request.RealInvoiceDate != null)
                        projectReport.RealInvoiceDate = request.RealInvoiceDate;
                    if (request.InvoiceComment != null)
                        projectReport.InvoiceComment = request.InvoiceComment;
                    //projectReport.Paid = true;
                    //projectReport.PaidDate = DateTime.Now;

                    int createResultProjectReportDetail;
                    _dbContext.ProjectReport.Update(projectReport);
                    createResultProjectReportDetail = await _dbContext.SaveChangesAsync(cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return Result<string>.Success(new List<string> { projectReport.Id.ToString() }, HttpStatusCode.OK);
                }
                else
                {
                    return Result<string>.NotFound();
                }
            }
            catch (Exception ex)
            {
                var errors = new List<ResultValidationFailure>()
                    {new () {Message = "Se genero una exception"}};
                return Result<string>.PreconditionFailure(errors);
            }
        }
    }
}
