using Company.Dal.Interfaces;
using Company.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Dal.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataContext _ctx;
        public CompanyRepository(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Companyy> CreateCompanyAsync(Companyy company)
        {
            _ctx.Companies.Add(company);
            await _ctx.SaveChangesAsync();
            return company;
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee, int companyId)
        {
            var company = await _ctx.Companies.Include(c => c.Employees)
                .FirstOrDefaultAsync(c => c.Id == companyId);

            company.Employees.Add(employee);

            await _ctx.SaveChangesAsync();
            return employee;
        }

        public void DeleteCompanyAsync(int companyId)
        {
            var company = _ctx.Companies.FirstOrDefault(a => a.Id == companyId);

            _ctx.Companies.Remove(company);
            _ctx.SaveChanges();
        }

        public void DeleteEmployee(int companyId, int employeeId)
        {
            var employee = _ctx.Employees.FirstOrDefault(e => e.Id == employeeId && e.CompanyId == companyId);

            _ctx.Employees.Remove(employee);
            _ctx.SaveChanges();
        }

        public async Task<List<Employee>> GetAllEmployeesAsync(int companyId)
        {
            return await _ctx.Employees.Where(c => c.CompanyId == companyId).ToListAsync();
        }

        public async Task<List<Companyy>> GetCompanyAsync()
        {
            return await _ctx.Companies.ToListAsync();
        }

        public async Task<Companyy> GetCompanyByIdAsync(int companyId)
        {
            var company = await _ctx.Companies.FirstOrDefaultAsync(c => c.Id == companyId);

            if (company == null)
                return null;

            return company;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int companyId, int employeeId)
        {
            var employee = await _ctx.Employees.FirstOrDefaultAsync(e => e.CompanyId == companyId && e.Id == employeeId);

            if (employee == null)
                return null;

            return employee;
        }

        public async Task<Companyy> UpdateCompanyAsync(Companyy updatedCompany)
        {
            _ctx.Companies.Update(updatedCompany);
            await _ctx.SaveChangesAsync();

            return updatedCompany;
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee updatedEmployee, int companyId)
        {
            _ctx.Employees.Update(updatedEmployee);
            await _ctx.SaveChangesAsync();

            return updatedEmployee;
        }
    }
}
