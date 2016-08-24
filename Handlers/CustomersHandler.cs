using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace Dcmg.CustomerDB.Handlers
{
    public class CustomersHandler:ContentHandler
    {
        public CustomersHandler(IRepository<Models.CustomersPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));            
        }
    }
}