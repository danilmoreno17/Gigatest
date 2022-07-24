﻿using DevExtreme.AspNet.Data;
using Kameyo.Core.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.HourBank.Dtos.Request
{
    public class GetHourBanksLoadOptionsQueryRequest : IRequest<LoadResultModel>
    {
        public DataSourceLoadOptionsBase? LoadOptions { get; set; }
    }
}
