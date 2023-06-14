using Company.Domain.Models;
using Company.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Interfaces
{
    public interface ICompanyService
    {
        Task<List<CompanyGetDto>> GetCompanyAsync();
        Task<CompanyGetDto> GetCompanyByIdAsync(int companyId);
        Task<CompanyGetDto> CreateCompanyAsync(CompanyPostPutDto company);
        Task<CompanyGetDto> UpdateCompanyAsync(CompanyPostPutDto updatedCompany, int id);
        void DeleteCompanyAsync(int companyId);


        Task<List<EmployeeGetDto>> GetAllEmployeesAsync(int companyId);
        Task<EmployeeGetDto> GetEmployeeByIdAsync(int companyId, int employeeId);
        Task<EmployeeGetDto> CreateEmployeeAsync(EmployeePostPutDto newEmployee, int companyId);
        Task<EmployeeGetDto> UpdateEmployeeAsync(EmployeePostPutDto updatedEmployee, int companyId, int employeeId);
        void DeleteEmployee(int companyId, int employeeId);
    }
}
