using Kameyo.Core.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectHourBank.Dtos.Request
{
    public class CreateProjectHourBankCommandRequest : IRequest<Result<string>>
    {
        public Guid ProjectId { get; set; }
        public Guid HourBankId { get; set; }
    }
}
