﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kameyo.Core.Application.Modules.EmployeeSkillAbility.Dtos.Response
{
    public class EmployeeSkillAbilitiesDtoResponse
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string Description { get; set; }
    }
}
