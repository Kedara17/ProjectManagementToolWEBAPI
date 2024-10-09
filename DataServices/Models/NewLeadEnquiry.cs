using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace DataServices.Models
{
    public class NewLeadEnquiry : NewLeadEnquiryDTO
    {
        [Required]
        [StringLength(50)]
        public string? CompanyName { get; set; }
        [Required]
        [StringLength(50)]
        public string? CompanyRepresentative { get; set; }
        [Required]
        [StringLength(50)]
        public string? RepresentativeDesignation { get; set; }
        [Required]
        [StringLength(50)]
        public string? Requirement { get; set; }
        public DateTime? EnquiryDate { get; set; }
        public string? EmployeeID { get; set; }
        public string? Status { get; set; }
        public string? Comments { get; set; }
        public new Employee? AssignTo { get; set; }
        public new Employee? Employee { get; set; }

    }

    public class NewLeadEnquiryDTO : AuditData
    {
        public string? Employee { get; set; }
        public string? AssignTo { get; set; }
        

    }
}
