using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.Models
{
    public class NewLeadEnquiryDocuments : NewLeadEnquiryDocumentsDTO
    {
        [ForeignKey("NewLeadEnquiryID")]
        public NewLeadEnquiry NewLeadEnquiry { get; set; }
    }
    public class NewLeadEnquiryDocumentsDTO : AuditData
    {
        public string NewLeadEnquiryID { get; set; }
        public string FileName { get; set; }
    }
}
