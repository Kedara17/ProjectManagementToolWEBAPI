using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.Models
{
    public class NewLeadEnquiryFollowup : NewLeadEnquiryFollowupDTO
    {
        [ForeignKey("NewLeadEnquiryID")]
        public NewLeadEnquiry NewLeadEnquiry { get; set; }
        [ForeignKey("AssignTo")]
        public Employee Employee { get; set; }
    }

    public class NewLeadEnquiryFollowupDTO : AuditData
    {
        public string? NewLeadEnquiryID { get; set; }
        public string? AssignTo { get; set; }
        public DateTime? NewFollowupDate { get; set; }
        public string? Comments { get; set; }
    }
}
