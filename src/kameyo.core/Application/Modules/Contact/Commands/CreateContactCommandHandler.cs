using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Contact.Dtos.Request;
using MediatR;
using System.Net;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Modules.Contact.Commands.Validators;

namespace Kameyo.Core.Application.Modules.Contact.Commands
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _context;

        public CreateContactCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<string>> Handle(CreateContactCommandRequest request, CancellationToken cancellationToken)
        {

            var contactExits = _context.Contacts.All(z => z.Names == request.Names && z.Active);
            if (contactExits)
            {
                return Result<string>.PreconditionFailure(new List<ResultValidationFailure>()
                {
                    new ResultValidationFailure() {
                        Code="",
                        Message="El contacto ya existe",
                        Name=""
                    }
                });
            }

            /*var validationResult = await new CreateContactCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
            }*/


            var newContact = new Domain.Entities.Contact()
            {
                ParentId = request.ParentId,
                CustomerId = request.CustomerId,
                Names = request.Names,
                LastName = request.LastName,
                Area = request.Area,
                Department = request.Department,
                Position = request.Position,
                Email = request.Email,
                PhoneOffice = request.PhoneOffice,
                PhoneOfficeExt = request.PhoneOfficeExt,
                PhoneMobile = request.PhoneMobile,
            };

            _context.Contacts.Add(newContact);
            await _context.SaveChangesAsync(cancellationToken);

            var data = new List<string>() { newContact.Id.ToString() };

            return Result<string>.Success(data, HttpStatusCode.Created);
        }
    }
}
