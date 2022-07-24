using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Customer.Dtos.Request;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kameyo.Core.Application.Modules.Customer.Commands
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCustomerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<string>> Handle(DeleteCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var company = await _context.Customers.FirstOrDefaultAsync(z => z.Id == request.Id && z.Active, cancellationToken);
                company.Active = false;

                await _context.SaveChangesAsync(cancellationToken);
                return Result<string>.Success(new List<string> { company.Id.ToString() }, HttpStatusCode.OK);

            }
            catch (Exception )
            {
                var errors = new List<ResultValidationFailure>() { new() { Message = "Se genero una exception" } };
                return Result<string>.PreconditionFailure(errors);
            }
        }
    }
}