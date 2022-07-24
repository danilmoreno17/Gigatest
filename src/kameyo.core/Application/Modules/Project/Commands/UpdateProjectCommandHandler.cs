using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Project.Dtos.Request;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kameyo.Core.Application.Modules.Project.Commands
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _context;
        public UpdateProjectCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<string>> Handle(UpdateProjectCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var project = _context.Projects
                    .Include(x => x.ProjectTasks.Where(z => z.Active))
                    .ThenInclude(x => x.TaskActivities.Where(z => z.Active))
                    .Include(x => x.ProjectResources.Where(z => z.Active))
                    .ThenInclude(x => x.Employee)
                    .Include(x => x.ProjectHourBanks.Where(z => z.Active))
                    .Include(x => x.ProjectManagers.Where(z => z.Active))
                    .Include(x => x.Customer)
                    .Where(x => x.Id == request.Id)
                    .FirstOrDefault();

                /*var validationResult = await new UpdateProjectCommandValidator()
                    .ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                {
                    return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
                }*/


                project.CustomerId = request.CustomerId ?? project.CustomerId;
                project.Name = request.Name ?? project.Name;
                project.Description = request.Description ?? project.Description;
                project.CatalogProjectTypeId = request.CatalogProjectTypeId ?? project.CatalogProjectTypeId;
                project.CatalogProjectCategoryId = request.CatalogProjectCategoryId ?? project.CatalogProjectCategoryId;
                project.CatalogProjectStateId = request.CatalogProjectStateId ?? project.CatalogProjectStateId;
                project.MainContactId = request.MainContactId ?? project.MainContactId;
                project.StartDate = request.StartDate ?? project.StartDate;
                project.EndDate = request.EndDate ?? project.EndDate;
                project.DurationHour = request.DurationHour ?? project.DurationHour;
                project.CloseDate = request.CloseDate ?? project.CloseDate;
                project.CostHourMenCustomer = request.CostHourMenCustomer;
                project.CostHourMenProject = request.CostHourMenProject;
                /*
                #region ProjectTask

                foreach (var deleteProjectTask in project.ProjectTasks)
                {
                    var deleteProjectTaskExists = request.ProjectTasks.Exists(x => x.Id == deleteProjectTask.Id);
                    if (!deleteProjectTaskExists)
                    {
                        deleteProjectTask.Active = false;
                    }
                }

                foreach (var projectTaskRequest in request.ProjectTasks)
                {
                    var projectTask = _context.ProjectTasks.FirstOrDefault(x => x.Id == projectTaskRequest.Id);
                    if (projectTask != null)
                    {
                        projectTask.Name = projectTaskRequest.Name ?? projectTask.Name;
                        projectTask.Description = projectTaskRequest.Description ?? projectTask.Description;
                        projectTask.CatalogTaskTypeId = projectTaskRequest.CatalogTaskTypeId ?? projectTask.CatalogTaskTypeId;
                        projectTask.Order = projectTaskRequest.Order ?? projectTask.Order;
                        projectTask.StartDate = projectTaskRequest.StartDate ?? projectTask.StartDate;
                        projectTask.EndDate = projectTaskRequest.EndDate ?? projectTask.EndDate;
                        projectTask.CloseDate = projectTaskRequest.CloseDate ?? projectTask.CloseDate;
                        projectTask.DurationHour = projectTaskRequest.DurationHour ?? projectTask.DurationHour;
                        projectTask.Progress = projectTaskRequest.Progress ?? projectTask.Progress;
                        projectTask.CatalogTaskStateId = projectTaskRequest.CatalogTaskStateId ?? projectTask.CatalogTaskStateId;

                    }
                    else
                    {
                        var projectTaskExists = false;
                        if (_context.ProjectTasks.Count() > 0)
                        {
                            projectTaskExists = _context.ProjectTasks.All(u => u.ProjectId == projectTaskRequest.ProjectId && u.Name == projectTaskRequest.Name && u.Active);
                        }
                        if (projectTaskExists)
                        {
                            return Result<string>.PreconditionFailure(new List<ResultValidationFailure>()
                            {
                                new ResultValidationFailure() {
                                    Code="",
                                    Message="El nombre de la tarea ya existe",
                                    Name=""
                                }
                            });
                        }
                        projectTask = new Domain.Entities.ProjectTask
                        {
                            ProjectId = projectTaskRequest.ProjectId ?? projectTask.ProjectId,
                            Name = projectTaskRequest.Name ?? projectTask.Name,
                            Description = projectTaskRequest.Description ?? projectTask.Description,
                            CatalogTaskTypeId = projectTaskRequest.CatalogTaskTypeId,
                            Order = projectTaskRequest.Order ?? projectTask.Order,
                            StartDate = projectTaskRequest.StartDate ?? projectTask.StartDate,
                            EndDate = projectTaskRequest.EndDate ?? projectTask.EndDate,
                            CloseDate = projectTaskRequest.CloseDate ?? projectTask.CloseDate,
                            DurationHour = projectTaskRequest.DurationHour ?? projectTask.DurationHour,
                            Progress = projectTaskRequest.Progress ?? projectTask.Progress,
                            CatalogTaskStateId = projectTaskRequest.CatalogTaskStateId,
                        };
                    }

                    var projectTaskDelete = project.ProjectTasks.Where(x => x.Id == projectTaskRequest.Id).FirstOrDefault();
                    if (projectTaskDelete != null) {
                        foreach (var deleteTaskActivity in projectTaskDelete.TaskActivities)
                        {
                            var deleteTaskActivityExists = projectTaskRequest.TaskActivities.Exists(x => x.Id == deleteTaskActivity.Id);
                            if (!deleteTaskActivityExists)
                            {
                                deleteTaskActivity.Active = false;
                            }
                        }
                    }

                    foreach (var taskActivityRequest in projectTaskRequest.TaskActivities)
                    {
                        var taskActivity = _context.TaskActivities.FirstOrDefault(a => a.Id == taskActivityRequest.Id);
                        if (taskActivity != null)
                        {
                            taskActivity.EmployeId = taskActivityRequest.EmployeeId.Value;
                            taskActivity.Description = taskActivityRequest.Description;
                            taskActivity.StartDate = taskActivityRequest.StartDate.Value;
                            taskActivity.EndDate = taskActivityRequest.EndDate.Value;
                            taskActivity.TotalTimeHour = taskActivityRequest.TotalTimeHour.Value;
                            taskActivity.TotalTimeHourApproved = taskActivityRequest.TotalTimeHourApproved.Value;
                            taskActivity.IsBillable = taskActivityRequest.IsBillable.Value;
                            taskActivity.EmployeId = taskActivityRequest.EmployeeId.Value;
                        }
                        else
                        {
                            var taskActivityExists = false;
                            if (_context.TaskActivities.Count() > 0)
                            {
                                taskActivityExists = _context.TaskActivities.All(u => u.ProjectTaskId == taskActivityRequest.ProjectTaskId && u.EmployeId == taskActivityRequest.EmployeeId && u.Description == request.Description && u.Active);
                            }
                            if (taskActivityExists)
                            {
                                return Result<string>.PreconditionFailure(new List<ResultValidationFailure>()
                                {
                                    new ResultValidationFailure() {
                                        Code="",
                                        Message="La tarea ya existe",
                                        Name=""
                                    }
                                });
                            }
                            taskActivity = new Domain.Entities.TaskActivity
                            {
                                EmployeId = taskActivityRequest.EmployeeId.Value,
                                Description = taskActivityRequest.Description,
                                StartDate = taskActivityRequest.StartDate.Value,
                                EndDate = taskActivityRequest.EndDate.Value,
                                TotalTimeHour = taskActivityRequest.TotalTimeHour.Value,
                                TotalTimeHourApproved = taskActivityRequest.TotalTimeHourApproved.Value,
                                IsBillable = taskActivityRequest.IsBillable.Value,
                            
                        };
                        }
                        projectTask.TaskActivities.Add(taskActivity);
                    }

                    project.ProjectTasks.Add(projectTask);
                }


                #endregion

                #region ProjectResource
                foreach (var deleteProjectResource in project.ProjectResources)
                {
                    var deleteProjectResouceExists = request.ProjectResources.Exists(x => x.Id == deleteProjectResource.Id);
                    if (!deleteProjectResouceExists)
                    {
                        deleteProjectResource.Active = false;
                    }
                }

                foreach (var projectResourceRequest in request.ProjectResources)
                {
                    var projectResource = _context.ProjectResources.FirstOrDefault(r => r.Id == projectResourceRequest.Id);
                    if (projectResource != null)
                    {
                        projectResource.EmployeeId = projectResourceRequest.EmployeeId;
                        projectResource.CatalogEmployeeRolId = projectResourceRequest.CatalogEmployeeRolId ?? projectResource.CatalogEmployeeRolId;
                        projectResource.CalculateFactorProject = projectResourceRequest.CalculateFactorProject;
                        projectResource.CalculateFactorEmployee = projectResourceRequest.CalculateFactorEmployee;
                    }
                    else
                    {
                        var projectResourceExists = false;
                        if (_context.ProjectResources.Count() > 0)
                        {
                            projectResourceExists = _context.ProjectResources.All(r => r.ProjectId == projectResourceRequest.ProjectId && r.EmployeeId == projectResourceRequest.EmployeeId && r.Active);
                        }
                        if (projectResourceExists)
                        {
                            return Result<string>.PreconditionFailure(new List<ResultValidationFailure>()
                            {
                                new ResultValidationFailure() {
                                    Code="",
                                    Message="El empleado ya fue asignado al proyecto",
                                    Name=""
                                }
                            });
                        }
                        projectResource = new Domain.Entities.ProjectResource
                        {
                            EmployeeId = projectResourceRequest.EmployeeId,
                            CatalogEmployeeRolId = projectResourceRequest.CatalogEmployeeRolId,
                            CalculateFactorProject = projectResourceRequest.CalculateFactorProject,
                            CalculateFactorEmployee = projectResourceRequest.CalculateFactorEmployee,
                            ProjectId = projectResourceRequest.ProjectId,
                        };

                    }
                    project.ProjectResources.Add(projectResource);
                }

                #endregion

                #region ProjectHourBank
                foreach (var deleteProjectHourBank in project.ProjectHourBanks)
                {
                    var deleteProjectHourBankExists = request.ProjectHourBanks.Exists(x => x.Id == deleteProjectHourBank.Id);
                    if (!deleteProjectHourBankExists)
                    {
                        deleteProjectHourBank.Active = false;
                    }
                }

                foreach (var projectHourBankRequest in request.ProjectHourBanks)
                {
                    var projectHourBank = _context.ProjectHourBanks.FirstOrDefault(x => x.Id == projectHourBankRequest.Id);
                    if (projectHourBank != null)
                    {
                        projectHourBank.HourBankId = projectHourBankRequest.HourBankId;
                    }
                    else
                    {
                        var projectHourBankExists = false;
                        if (_context.ProjectHourBanks.Count() > 0)
                        {
                            projectHourBankExists = _context.ProjectHourBanks.All(x => x.ProjectId == projectHourBankRequest.ProjectId && x.HourBankId == projectHourBankRequest.HourBankId && x.Active);
                        }
                        if (projectHourBankExists)
                        {
                            return Result<string>.PreconditionFailure(new List<ResultValidationFailure>()
                            {
                                new ResultValidationFailure() {
                                    Code="",
                                    Message="La bolsa de hora ya fue asignada al proyecto",
                                    Name=""
                                }
                            });
                        }
                        projectHourBank = new Domain.Entities.ProjectHourBank
                        {
                            ProjectId = projectHourBankRequest.ProjectId,
                            HourBankId = projectHourBankRequest.HourBankId,
                        };
                    }
                    project.ProjectHourBanks.Add(projectHourBank);
                }


                #endregion

                #region ProjectManager
                foreach (var deleteProjectManager in project.ProjectManagers)
                {
                    var deleteProjectManagerExists = request.ProjectManagers.Exists(x => x.Id == deleteProjectManager.Id);
                    if (!deleteProjectManagerExists)
                    {
                        deleteProjectManager.Active = false;
                    }
                }

                foreach (var projectManagerRequest in request.ProjectManagers)
                {
                    var projectManager = _context.ProjectManagers.FirstOrDefault(x => x.Id == projectManagerRequest.Id);
                    if (projectManager != null)
                    {
                        projectManager.EmployeeId = projectManagerRequest.EmployeeId;
                        projectManager.StartDate = projectManagerRequest.StartDate;
                        projectManager.EndDate = projectManagerRequest.EndDate;
                    }
                    else
                    {
                        var projectManagerExists = false;
                        if (_context.ProjectManagers.Count() > 0)
                        {
                            projectManagerExists = _context.ProjectManagers.All(x => x.ProjectId == projectManagerRequest.ProjectId && x.EmployeeId == projectManagerRequest.EmployeeId && x.Active);
                        }
                        if (projectManagerExists)
                        {
                            return Result<string>.PreconditionFailure(new List<ResultValidationFailure>()
                            {
                                new ResultValidationFailure() {
                                    Code="",
                                    Message="El administrador ya fue asignado al proyecto",
                                    Name=""
                                }
                            });
                        }
                        projectManager = new Domain.Entities.ProjectManager
                        {
                            ProjectId = projectManagerRequest.ProjectId,
                            EmployeeId = projectManagerRequest.EmployeeId,
                            StartDate = projectManagerRequest.StartDate,
                            EndDate = projectManagerRequest.EndDate,
                        };
                    }
                    project.ProjectManagers.Add(projectManager);
                }

                
                #endregion
                */
                await _context.SaveChangesAsync(cancellationToken);
                return Result<string>.Success(new List<string> { project.Id.ToString() }, HttpStatusCode.OK);

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
