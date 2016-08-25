using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;
using Orchard.ContentManagement;


namespace Dcmg.CustomerDB.Models
{
    public class CustomersPartRecord: ContentPartRecord
    {           
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string PrimaryPOC { get; set; }
        public virtual string SecondaryPOC { get; set; }
        public virtual string PrimaryPOCEmail { get; set; }
        public virtual string SecondaryPOCEmail { get; set; }
        public virtual string EmailAlias { get; set; }
        public virtual string Notes { get; set; }
    }
    
}