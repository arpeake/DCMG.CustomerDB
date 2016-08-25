using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Dcmg.CustomerDB.Models;

namespace Dcmg.CustomerDB.Handlers
{
    public class CustomersPartHandler:ContentHandler
    {
        public CustomersPartHandler(IRepository<CustomersPartRecord> repository)
        {            
            Filters.Add(StorageFilter.For(repository));
            Filters.Add(new ActivatingFilter<CustomersPart>("CustomersPartRecord"));
        }
    }
}