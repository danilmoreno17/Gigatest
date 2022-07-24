using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Catalog.Dtos.Request;
using MediatR;
using System.Net;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Modules.Catalog.Commands.Validators;

namespace Kameyo.Core.Application.Modules.Catalog.Commands
{
    public class CreateCatalogCommandHandler : IRequestHandler<CreateCatalogCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _context;

        public CreateCatalogCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<string>> Handle(CreateCatalogCommandRequest request, CancellationToken cancellationToken)
        {

            var CatalogExits = _context.Catalogs.All(z => z.Name == request.Name && z.Active);
            //if (CatalogExits)
            //{
            //    return Result<string>.PreconditionFailure(new List<ResultValidationFailure>()
            //    {
            //        new ResultValidationFailure() {
            //            Code="",
            //            Message="La empresa ya existe",
            //            Name=""
            //        }
            //    });
            //}

            var validationResult = await new CreateCatalogCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }


            var newCatalog = new Domain.Entities.Catalog()
            {
                ParentId = request.ParentId,
                Name = request.Name,
                Value = request.Value,
                Description = request.Description,                
                Order = request.Order,
                IsSystemOwner = request.IsSystemOwner,
                Status = request.Status
            };

            _context.Catalogs.Add(newCatalog);
            await _context.SaveChangesAsync(cancellationToken);

            var data = new List<string>() { newCatalog.Id.ToString() };

            return Result<string>.Success(data, HttpStatusCode.Created);
        }
    }
}
