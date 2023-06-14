using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.Models
{
    public class Companyy
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Owner { get; set; }
        [Required]
        [MaxLength(200)]
        public string City { get; set; }
        [Required]
        [MaxLength(200)]
        public string Country { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
