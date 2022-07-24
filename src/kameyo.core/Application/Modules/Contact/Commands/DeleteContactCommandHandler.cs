using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Contact.Dtos.Request;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kameyo.Core.Application.Modules.Contact.Commands
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteContactCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<string>> Handle(DeleteContactCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var contact = await _context.Companies.FirstOrDefaultAsync(z => z.Id == request.Id && z.Active, cancellationToken);
                contact.Active = false;

                await _context.SaveChangesAsync(cancellationToken);
                return Result<string>.Success(new List<string> { contact.Id.ToString() }, HttpStatusCode.NoContent);

            }
            catch (Exception )
            {
                var errors = new List<ResultValidationFailure>(){ new () {Message = "Se genero una exception"}};                
                return Result<string>.PreconditionFailure(errors);
            }            
        }
    }
}
