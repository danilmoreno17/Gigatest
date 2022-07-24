using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Company.Dtos.Request;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kameyo.Core.Application.Modules.Company.Commands
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCompanyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<string>> Handle(DeleteCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var company = _context.Companies.Where(z => z.Id == request.Id)
                    .FirstOrDefault();
                company.Active = false;

                await _context.SaveChangesAsync(cancellationToken);
                return Result<string>.Success(new List<string> { company.Id.ToString() }, HttpStatusCode.OK);

            }
            catch (Exception )
            {
                var errors = new List<ResultValidationFailure>(){ new () {Message = "Se genero una exception"}};                
                return Result<string>.PreconditionFailure(errors);
            }            
        }
    }
}
