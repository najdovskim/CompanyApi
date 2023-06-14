using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Dtos
{
    public class EmployeeGetDto
    {
        public int Id { get; set; }        
        public string FirstName { get; set; }      
        public string LastName { get; set; }        
        public DateTime DateOfBirth { get; set; }      
        public DateTime SigningDate { get; set; }      
        public decimal Salary { get; set; }
    }
}
