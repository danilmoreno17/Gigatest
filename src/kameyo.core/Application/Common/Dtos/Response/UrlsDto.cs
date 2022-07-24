using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Common.Dtos.Response
{
    public class UrlsDto
    {
        public ICollection<string> Urls { get; }

        public UrlsDto(ICollection<string> urls)
        {
            Urls = urls;
        }
    }
}
