using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices.Models
{
    public class ContactType : ContactTypeDTO
    {
        public ICollection<ClientContact> ClientContact { get; set; }
    }
        public class ContactTypeDTO :AuditData
    {
        public string TypeName { get; set; }
        
    }

}
