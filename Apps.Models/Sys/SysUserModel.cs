﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Models.Sys
{
    public partial class SysUserModel
    {
        public string Flag { get; set; }
        public string Name { get { return this.UserName; } }
    }
}
