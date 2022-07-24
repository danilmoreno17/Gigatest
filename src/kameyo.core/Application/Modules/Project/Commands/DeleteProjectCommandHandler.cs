using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Project.Dtos.Request;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kameyo.Core.Application.Modules.Project.Commands
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProjectCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<string>> Handle(DeleteProjectCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var project = _context.Projects.Where(b => b.Id == request.Id)
                     .FirstOrDefault();
                
                project.Active = false;

                await _context.SaveChangesAsync(cancellationToken);
                return Result<string>.Success(new List<string> { project.Id.ToString() }, HttpStatusCode.OK);

            }
            catch (Exception )
            {
                var errors = new List<ResultValidationFailure>(){ new () {Message = "Se genero una exception"}};                
                return Result<string>.PreconditionFailure(errors);
            }            
        }
    }
}
