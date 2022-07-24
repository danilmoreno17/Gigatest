using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Catalog.Dtos.Request;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kameyo.Core.Application.Modules.Catalog.Commands
{
    public class DeleteCatalogCommandHandler : IRequestHandler<DeleteCatalogCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCatalogCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<string>> Handle(DeleteCatalogCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var catalog = await _context.Companies.FirstOrDefaultAsync(z => z.Id == request.Id && z.Active, cancellationToken);
                catalog.Active = false;

                await _context.SaveChangesAsync(cancellationToken);
                return Result<string>.Success(new List<string> { catalog.Id.ToString() }, HttpStatusCode.OK);

            }
            catch (Exception )
            {
                var errors = new List<ResultValidationFailure>(){ new () {Message = "Se genero una exception"}};                
                return Result<string>.PreconditionFailure(errors);
            }            
        }
    }
}
