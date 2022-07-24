using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Mappings;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Contact.Commands.Validators;
using Kameyo.Core.Application.Modules.Contact.Dtos.Request;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kameyo.Core.Application.Modules.Contact.Commands
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommandRequest, Result<string>>
    {
        private readonly IApplicationDbContext _context;
        public UpdateContactCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<string>> Handle(UpdateContactCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var contact = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == request.Id && x.Active, cancellationToken);

                /*var validationResult = await new UpdateContactCommandValidator()
                    .ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                {
                    return Result<string>.PreconditionFailure(validationResult.Errors.MapToResultValidationFailure());
                }*/


                if(request.ParentId!=null)
                   contact.ParentId = request.ParentId;
                if (request.CustomerId != null)
                    contact.CustomerId = request.CustomerId;
                if (request.Names != null)
                    contact.Names = request.Names;
                if (request.LastName != null)
                    contact.LastName = request.LastName;
                if (request.Area != null)
                    contact.Area = request.Area;
                if (request.Department != null) 
                    contact.Department = request.Department;
                if (request.Position != null)
                    contact.Position = request.Position;
                if (request.Email != null)
                    contact.Email = request.Email;
                if (request.PhoneOffice != null) 
                    contact.PhoneOffice = request.PhoneOffice;
                if (request.PhoneOfficeExt != null) 
                    contact.PhoneOfficeExt = request.PhoneOfficeExt;
                if (request.PhoneMobile != null)
                    contact.PhoneMobile = request.PhoneMobile;

                await _context.SaveChangesAsync(cancellationToken);
                return Result<string>.Success(new List<string> { contact.Id.ToString() }, HttpStatusCode.OK);

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
