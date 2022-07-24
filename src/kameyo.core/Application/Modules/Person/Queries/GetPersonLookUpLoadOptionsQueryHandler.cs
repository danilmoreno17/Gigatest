using DevExtreme.AspNet.Data;
using Kameyo.Core.Application.Common.Enums;
using Kameyo.Core.Application.Common.Interfaces;
using Kameyo.Core.Application.Common.Models;
using Kameyo.Core.Application.Modules.Person.Dtos.Request;
using Kameyo.Core.Application.Modules.Person.Dtos.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Kameyo.Core.Application.Modules.Person.Queries
{
    public class GetPersonLookUpLoadOptionsQueryHandler : IRequestHandler<GetPersonLookUpLoadOptionsQueryRequest, LoadResultModel>
    {
        private readonly IApplicationDbContext _context;
        public GetPersonLookUpLoadOptionsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<LoadResultModel> Handle(GetPersonLookUpLoadOptionsQueryRequest request, CancellationToken cancellationToken)
        {
            var persons = await GetPersonByTypeAsync(request);

            var loadResultResponse = DataSourceLoader.Load(persons, request.LoadOptions);
            return LoadResultModel.Success(loadResultResponse, HttpStatusCode.OK);
        }

        private async Task<List<PersonLookUpResponse>> GetPersonByTypeAsync(GetPersonLookUpLoadOptionsQueryRequest request)
        {
             var contactsResult = await _context.Contacts
                    .Where(x => x.Active)
                    .Select(x => new PersonLookUpResponse() { Id = x.Id, PersonTypeId = UsersTypeEnum.Contact.Id, Name = x.Names, FullName = $"{x.Names} {x.LastName}" })
                    .ToListAsync();
                        
            var employeesResult = await _context.Employees
                    .Where(x => x.Active)
                    .Select(x => new PersonLookUpResponse() { Id = x.Id, PersonTypeId = UsersTypeEnum.Employee.Id, Name = x.Names, FullName = $"{x.Names} {x.LastName}" })
                    .ToListAsync();


            return contactsResult.Union(employeesResult).ToList();


        }
    }
}
