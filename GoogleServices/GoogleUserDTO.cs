﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sombrero.GoogleServices
{
    public class GoogleUserDTO
    {
        public string TokenId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public dynamic otros {  get; set; }


    }
}
