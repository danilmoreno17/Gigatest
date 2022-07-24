using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.FinancialParticipation.Specifications
{
    public class GetFinancialParticipationByIdSepec : Specification<Kameyo.Core.Domain.Entities.FinancialParticipation>
    {
        public GetFinancialParticipationByIdSepec(string financialParticipationByIdSepecId)
        {
            Query
                //.Include(x => x.Project) 
                .Where(x => x.Id.ToString() == financialParticipationByIdSepecId);
        }
    }

}
