using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.HourBank.Specifications
{
    public class GetHourBanksByIdSpec : Specification<Kameyo.Core.Domain.Entities.HourBank>
    {
        public GetHourBanksByIdSpec(string hourBankId)
        {
            Query
                .Where(x => x.Id.ToString() == hourBankId);
        }
    }
}
