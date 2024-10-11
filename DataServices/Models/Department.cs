using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.Models
{
    public class Department : DepartmentDTO
    {
        public ICollection<Employee> Employee { get; set; }
        public ICollection<Technology> Technology { get; set; }

    }

    public class DepartmentDTO : AuditData
    {
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Special characters and Digits are not allowed.")]
        public string Name { get; set; }        
    }
}