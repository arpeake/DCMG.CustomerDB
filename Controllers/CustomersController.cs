using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard.Themes;
using Orchard;
using Orchard.Data;
using Dcmg.CustomerDB.Models;
using Dcmg.CustomerDB.ViewModels;
using System.Collections;



namespace Dcmg.CustomerDB.Controllers
{
    public class CustomersController:Controller
    {
        public IOrchardServices _services { get; set; }
        private readonly IRepository<CustomersPartRecord> _customerRepo;
        WorkContext _workContext;

        public CustomersController(IOrchardServices services, IRepository<CustomersPartRecord> customerRepo, WorkContext workContext)
        {
            _services = services;
            _customerRepo = customerRepo;
            _workContext = workContext;
        }

        [Themed]
        public ActionResult Index()
        {
            List<CustomersViewModel> cvml = new List<CustomersViewModel>();
            List<CustomersPartRecord> cpl = new List<CustomersPartRecord>();
            cpl = _customerRepo.Table.ToList();
            
            CustomersViewModel cvm = new CustomersViewModel();
            cvm = cpl.CastClass<CustomersViewModel>();
            //cvm.Name = "TEST NAME";
            return View(cvm);
        }
    }
}