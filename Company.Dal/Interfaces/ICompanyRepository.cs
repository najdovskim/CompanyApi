using Company.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Dal.Interfaces
{
    public interface ICompanyRepository
    {
        Task<List<Companyy>> GetCompanyAsync();
        Task<Companyy> GetCompanyByIdAsync(int companyId);
        Task<Companyy> CreateCompanyAsync(Companyy company);
        Task<Companyy> UpdateCompanyAsync(Companyy updatedCompany);
        void DeleteCompanyAsync(int companyId);


        Task<List<Employee>> GetAllEmployeesAsync(int companyId);
        Task<Employee> GetEmployeeByIdAsync(int companyId, int employeeId);
        Task<Employee> CreateEmployeeAsync(Employee employee, int companyId);
        Task<Employee> UpdateEmployeeAsync(Employee updatedEmployee, int companyId);
        void DeleteEmployee(int companyId, int employeeId);
    }
}
