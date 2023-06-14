using AutoMapper;
using Company.Domain.Models;
using Company.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Automapper
{
    public class CompanyMappingProfile :Profile
    {
        public CompanyMappingProfile()
        {
            CreateMap<Companyy, CompanyGetDto>();
            CreateMap<CompanyPostPutDto, Companyy>();
        }
    }
}
