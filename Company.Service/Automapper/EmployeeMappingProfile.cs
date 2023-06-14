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
    public class EmployeeMappingProfile :Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeGetDto>();
            CreateMap<EmployeePostPutDto, Employee>();
        }
    }
}
