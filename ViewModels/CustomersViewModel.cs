using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Dcmg.CustomerDB.ViewModels
{
    public class CustomersViewModel
    {        
        public new int Id { get; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string PrimaryPOC { get; set; }
        public string SecondaryPOC { get; set; }
        public string PrimaryPOCEmail { get; set; }
        public string SecondaryPOCEmail { get; set; }
        public string EmailAlias { get; set; }
        public string Notes { get; set; }
    }
    
}