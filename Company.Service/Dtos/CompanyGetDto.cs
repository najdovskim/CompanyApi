﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Dtos
{
    public class CompanyGetDto
    {
        public int Id { get; set; }        
        public string Name { get; set; }        
        public string Owner { get; set; }        
        public string City { get; set; }        
        public string Country { get; set; }
    }
}
