using Company.Dal.Interfaces;
using Company.Service.Dtos;
using Company.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Company.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {        
        private readonly ICompanyService _companyService;

        public CompanyController( ICompanyService companyService)
        {            
            _companyService = companyService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {           
            var companies = await _companyService.GetCompanyAsync();
            return Ok(companies);
        }
        [HttpGet]
        [Route("{companyId}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            
            var company = await _companyService.GetCompanyByIdAsync(id);
            if (company == null)
                return NotFound("Item not found");

            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyPostPutDto company)
        {
            
            if (company == null)
                return BadRequest(ModelState);

            var companyPost = await _companyService.CreateCompanyAsync(company);

            return CreatedAtAction(nameof(CreateCompany), new { id = companyPost.Id }, companyPost);
        }

        [HttpPut]
        [Route("{companyId}")]
        public async Task<IActionResult> UpdateCompany([FromBody] CompanyPostPutDto updatedCompany, int id)
        {
            

            var update = await _companyService.UpdateCompanyAsync(updatedCompany, id);

            return NoContent();
        }

        [HttpDelete]
        [Route("{companyId}")]
        public void DeleteCompany(int id)
        {
            
            _companyService.DeleteCompanyAsync(id);
        }

        [HttpGet]
        [Route("{companyId}/employees")]
        public async Task<IActionResult> GetAllEmployees(int companyId)
        {
            var employees = await _companyService.GetAllEmployeesAsync(companyId);

            return Ok(employees);
        }

        [HttpGet]
        [Route("{companyId}/employees/{employeeId}")]
        public async Task<IActionResult> GetEmployeeById(int companyId, int employeeId)
        {
            var employee = await _companyService.GetEmployeeByIdAsync(companyId, employeeId);
            if (employee == null)
                return NotFound("employee not found");

            return Ok(employee);
        }

        [HttpPost]
        [Route("{companyId}/employees")]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeePostPutDto newEmployee, int companyId)
        {
            if (newEmployee == null)
                return BadRequest(ModelState);


            var employee = await _companyService.CreateEmployeeAsync(newEmployee, companyId);

            return CreatedAtAction(nameof(CreateEmployee),
                       new { companyId = companyId, employeeId = employee.Id }, employee);
        }

        [HttpPut]
        [Route("{companyId}/employees/{employeeId}")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeePostPutDto updatedEmployee, int companyId, int employeeId)
        {

            var update = await _companyService.UpdateEmployeeAsync(updatedEmployee, companyId, employeeId);

            return NoContent();
        }

        [HttpDelete]
        [Route("{companyId}/employees/{employeeId}")]
        public void DeleteEmployee(int companyId, int employeeId)
        {
            _companyService.DeleteEmployee(companyId, employeeId);
        }




    }
}
