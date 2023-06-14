using AutoMapper;
using Company.Dal.Interfaces;
using Company.Domain.Models;
using Company.Service.Dtos;
using Company.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<CompanyGetDto> CreateCompanyAsync(CompanyPostPutDto company)
        {
            var domainCompany = _mapper.Map<Companyy>(company);
            await _companyRepository.CreateCompanyAsync(domainCompany);

            var mapped = _mapper.Map<CompanyGetDto>(domainCompany);

            return mapped;
        }        

        public async Task<EmployeeGetDto> CreateEmployeeAsync(EmployeePostPutDto newEmployee, int companyId)
        {
            var employee = _mapper.Map<Employee>(newEmployee);            
            await _companyRepository.CreateEmployeeAsync(employee, companyId);

            var mapped = _mapper.Map<EmployeeGetDto>(employee);

            return mapped;
        }

        public void DeleteCompanyAsync(int companyId)
        {
            _companyRepository.DeleteCompanyAsync(companyId);
            Console.WriteLine("Company deleted");
        }

        public void DeleteEmployee(int companyId, int employeeId)
        {
            _companyRepository.DeleteEmployee(companyId, employeeId);
            Console.WriteLine("Employee deleted");
        }

        public async Task<List<EmployeeGetDto>> GetAllEmployeesAsync(int companyId)
        {
            var employees = await _companyRepository.GetAllEmployeesAsync(companyId);
            var employeesGet = _mapper.Map<List<EmployeeGetDto>>(employees);

            return employeesGet;
        }

        public async Task<List<CompanyGetDto>> GetCompanyAsync()
        {
            var companies = await _companyRepository.GetCompanyAsync();
            var companiesGet = _mapper.Map<List<CompanyGetDto>>(companies);

            return companiesGet;
        }

        public async Task<CompanyGetDto> GetCompanyByIdAsync(int companyId)
        {
            var company = await _companyRepository.GetCompanyByIdAsync(companyId);

            if (company == null)
                return null;

            var mapped = _mapper.Map<CompanyGetDto>(company);
            return mapped;
        }

        public async Task<EmployeeGetDto> GetEmployeeByIdAsync(int companyId, int employeeId)
        {
            var employee = await _companyRepository.GetEmployeeByIdAsync(companyId, employeeId);

            var mapped = _mapper.Map<EmployeeGetDto>(employee);

            return mapped;
        }

        public async Task<CompanyGetDto> UpdateCompanyAsync(CompanyPostPutDto updatedCompany, int id)
        {
            var toUpdate = _mapper.Map<Companyy>(updatedCompany);
            toUpdate.Id = id;

            await _companyRepository.UpdateCompanyAsync(toUpdate);

            var mapped = _mapper.Map<CompanyGetDto>(toUpdate);

            return mapped;
        }
        

        public async Task<EmployeeGetDto> UpdateEmployeeAsync(EmployeePostPutDto updatedEmployee, int companyId, int employeeId)
        {
            var toUpdate = _mapper.Map<Employee>(updatedEmployee);
            toUpdate.Id = employeeId;
            toUpdate.CompanyId = companyId;

            await _companyRepository.UpdateEmployeeAsync(toUpdate, companyId);

            var mapped = _mapper.Map<EmployeeGetDto>(toUpdate);

            return mapped;
        }
    }
}
