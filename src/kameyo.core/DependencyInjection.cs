using FluentValidation;
/*
using Kameyo.Core.Application.Modules.Company.Commands;
using Kameyo.Core.Application.Modules.Company.Queries;
using Kameyo.Core.Application.Modules.Customer.Commands;
using Kameyo.Core.Application.Modules.Customer.Queries;
*/
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

/*
using Kameyo.Core.Application.Modules.Catalog.Commands;
using Kameyo.Core.Application.Modules.Catalog.Queries;
using Kameyo.Core.Application.Modules.Contact.Commands;
using Kameyo.Core.Application.Modules.Contact.Queries;
using Kameyo.Core.Application.Modules.Employee.Commands;
using Kameyo.Core.Application.Modules.Employee.Queries;
using Kameyo.Core.Application.Modules.Project.Commands;
using Kameyo.Core.Application.Modules.Project.Queries;
*/

namespace Kameyo.Core
{
    public static class DependencyInjection
    {
        
        public static IServiceCollection AddApplicationCore(this IServiceCollection services)
        {           
            
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());            
            services.AddMediatR(Assembly.GetExecutingAssembly());

            /*services.AddMediatR(typeof(GetCompanyQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateCompanyCommandHandler).GetTypeInfo().Assembly);
            
            services.AddMediatR(typeof(GetCustomerQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateCustomerCommandHandler).GetTypeInfo().Assembly);
            
            services.AddMediatR(typeof(GetCatalogQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateCatalogCommandHandler).GetTypeInfo().Assembly);

            services.AddMediatR(typeof(GetContactQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateContactCommandHandler).GetTypeInfo().Assembly);

            services.AddMediatR(typeof(GetEmployeeQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateEmployeeCommandHandler).GetTypeInfo().Assembly);

            services.AddMediatR(typeof(GetProjectQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateProjectCommandHandler).GetTypeInfo().Assembly);*/
            return services;
        }

    }
}
