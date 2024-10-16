﻿using DataServices.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataServices.Models
{
    public class Technology : TechnologyDTO
    {
        [Required]
        public string? DepartmentId { get; set; }
        public ICollection<ProjectTechnology> ProjectTechnology { get; set; }
        public ICollection<EmployeeTechnology> EmployeeTechnology { get; set; }
        public ICollection<SOWRequirementTechnology> SOWRequirementTechnology { get; set; }
        public ICollection<POCTechnology> POCTechnology { get; set; }
        public ICollection<NewLeadEnquiryTechnology> NewLeadEnquiryTechnology { get; set; }


        [NotMapped] // Add this attribute to ignore in EF Core
        [JsonIgnore] // Add this attribute to ignore during JSON deserialization
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }
    }
    public class TechnologyDTO : AuditData
    {
        [Required(ErrorMessage = "The Name field is required.")]
        [MinLength(3)]
        [MaxLength(50)]
        [StringLength(50, ErrorMessage = "The Name cannot exceed 50 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Special characters and Digits are not allowed.")]
        public string Name { get; set; }
        public string? Department { get; set; }
    }
}