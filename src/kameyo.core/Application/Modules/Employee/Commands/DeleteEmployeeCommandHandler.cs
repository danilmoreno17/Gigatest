using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Employee.Dtos.Request;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kameyo.Core.Application.Modules.Employee.Commands
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteEmployeeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<string>> Handle(DeleteEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var Employee = await _context.Employees.FirstOrDefaultAsync(z => z.Id == request.Id && z.Active, cancellationToken);
                Employee.Active = false;

                await _context.SaveChangesAsync(cancellationToken);
                return Result<string>.Success(new List<string> { Employee.Id.ToString() }, HttpStatusCode.OK);

            }
            catch (Exception )
            {
                var errors = new List<ResultValidationFailure>(){ new () {Message = "Se genero una exception"}};                
                return Result<string>.PreconditionFailure(errors);
            }            
        }
    }
}
