using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Catalog.Commands.Validators;
using Kameyo.Core.Application.Modules.Catalog.Dtos.Request;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kameyo.Core.Application.Modules.Catalog.Commands
{
    public class UpdateCatalogCommandHandler : IRequestHandler<UpdateCatalogCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _context;
        public UpdateCatalogCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<string>> Handle(UpdateCatalogCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var catalog = _context.Catalogs.Where(x => x.Id == request.Id).FirstOrDefault();

                var validationResult = await new UpdateCatalogCommandValidator()
                    .ValidateAsync(request, cancellationToken);

                /*if (!validationResult.IsValid)
                {
                    return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
                }*/
                if(request.ParentId!=null)
                    catalog.ParentId = request.ParentId;
                if (request.Name != null)
                    catalog.Name = request.Name;
                if (request.Value != null)
                    catalog.Value = request.Value;
                if (request.Description != null)
                    catalog.Description = request.Description;
                if (request.Order != null)
                    catalog.Order = (int)request.Order;
                if (request.IsSystemOwner != null)
                    catalog.IsSystemOwner = (bool)request.IsSystemOwner;
                if (request.Status != null)
                    catalog.Status = request.Status;


                await _context.SaveChangesAsync(cancellationToken);
                return Result<string>.Success(new List<string> { catalog.Id.ToString() }, HttpStatusCode.OK);

            }
            catch (Exception )
            {
                var errors = new List<ResultValidationFailure>()
                    {new () {Message = "Se genero una exception"}};
                return Result<string>.PreconditionFailure(errors);
            }
        }
    }
}
