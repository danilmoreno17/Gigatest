using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.ProjectReport.Specifications
{
    public class GetProjectReportByIdSepec : Specification<Kameyo.Core.Domain.Entities.ProjectReport>
    {
        public GetProjectReportByIdSepec(string projectReportId)
        {
            Query
                //.Include(x => x.Project) 
                .Where(x => x.Id.ToString() == projectReportId);
        }
    }

}
