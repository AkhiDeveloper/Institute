﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Settings
{
    public class NativeUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string[] Roles { get; set; }
        public string Phone { get; set; }
    }
}
