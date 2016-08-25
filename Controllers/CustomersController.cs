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
using Orchard.ContentManagement;



namespace Dcmg.CustomerDB.Controllers
{
    public class CustomersController:Controller
    {
        public IOrchardServices _services { get; set; }
        private readonly IRepository<CustomersPartRecord> _customerRepo;
        WorkContext _workContext;
        private readonly IContentManager _contentManager;

        public CustomersController(IContentManager contentManager,IOrchardServices services, IRepository<CustomersPartRecord> customerRepo, WorkContext workContext)
        {
            _services = services;
            _customerRepo = customerRepo;
            _workContext = workContext;
            _contentManager = contentManager;
        }

        [Themed]
        public ActionResult Index()
        {
            //List<CustomersViewModel> cvml = new List<CustomersViewModel>();
            //List<CustomersPartRecord> cpl = new List<CustomersPartRecord>();
            CustomersViewModel cvm = new CustomersViewModel();
            cvm.Name = "TEST NAME";
            try
            {
                cvm.CVML = _customerRepo.Table.ToList();
            }
            catch(Exception ex)
            {
                cvm.Name = ex.Message +Environment.NewLine + "//End Of Message//";
            }
            
            
            
            //cvm = cpl.CastClass<CustomersViewModel>();
            
            // cvm.CVML = cpl;
            return View(cvm);
        }

        [Themed]
        [HttpPost]
        public ActionResult Add(string txtName)
        {
            CustomersViewModel cvm = new CustomersViewModel();
            cvm.Name = txtName;
            return View("Index",cvm);
        }

        [Themed]
        [HttpGet]
        public ActionResult Add()
        {           
            return View();
        }
    }
}