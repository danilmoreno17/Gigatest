
using Kameyo.Core.Application.Common.Models;
using MediatR;

namespace Kameyo.Core.Application.Modules.Company.Dtos.Request
{
    public  class DeleteCompanyCommandRequest : IRequest<Result<string>>
    {
        public Guid Id { get; set; } = default!;
    }
}
