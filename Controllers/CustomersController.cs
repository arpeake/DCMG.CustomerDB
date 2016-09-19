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
            
            if(cvm.CVML.Count() < 1)
            {
                CustomersPartRecord cvm2 = new CustomersPartRecord();

                cvm2.Name = "Add 1st Customer";
                cvm.CVML.Add(cvm2);
            }
            
            //cvm = cpl.CastClass<CustomersViewModel>();
            
            // cvm.CVML = cpl;
            return View(cvm);
        }

        [Themed]
        [HttpPost]
        public ActionResult Add(string txtName,string txtAddress, string txtPhoneNumber
            ,string txtPrimaryPOC, string txtPrimaryPOCEmail, string txtSecondaryPOC
            ,string txtSecondaryPOCEmail, string txtEmailAlias, string txtNotes)
        {
            //Create the record
            _services.ContentManager.Create<CustomersPart>("CustomersPartRecord", x =>
            {
                x.Name = txtName;
                x.Address = txtAddress;
                x.PhoneNumber = txtPhoneNumber;
                x.PrimaryPOC = txtPrimaryPOC;
                x.PrimaryPOCEmail = txtPrimaryPOCEmail;
                x.SecondaryPOC = txtSecondaryPOC;
                x.SecondaryPOCEmail = txtSecondaryPOCEmail;
                x.EmailAlias = txtEmailAlias;
                x.Notes = txtNotes;
            });
            
            
            return RedirectToAction("Index");
        }

        [Themed]
        [HttpGet]
        public ActionResult Add()
        {           
            return View();
        }

        [Themed]
        [HttpGet]
        public ActionResult Edit(int rid)
        {
            //get record of the ID to populate fields
            var record = _customerRepo.Table.Where(x => x.Id == rid).FirstOrDefault();
            
            return View(record);
        }

        [Themed]
        [HttpPost]
        public ActionResult Edit(int Id,string txtName, string txtAddress, string txtPhoneNumber
            , string txtPrimaryPOC, string txtPrimaryPOCEmail, string txtSecondaryPOC
            , string txtSecondaryPOCEmail, string txtEmailAlias, string txtNotes)
        {
            //get record of the ID to populate fields
            CustomersPartRecord cpr = new CustomersPartRecord();
            cpr.Id = Id;
            cpr.Name = txtName;
            cpr.Address = txtAddress;
            cpr.PhoneNumber = txtPhoneNumber;
            cpr.PrimaryPOC = txtPrimaryPOC;
            cpr.PrimaryPOCEmail = txtPrimaryPOCEmail;
            cpr.SecondaryPOC = txtSecondaryPOC;
            cpr.SecondaryPOCEmail = txtSecondaryPOCEmail;
            cpr.EmailAlias = txtEmailAlias;
            cpr.Notes = txtNotes;

            try
            {
                _customerRepo.Update(cpr);
            }
            catch(NullReferenceException)
            {
                
            }

            return RedirectToAction("Index");
        }

        
        [Themed]
        [HttpGet]
        public ActionResult Delete(int rid)
        {
            try
            {
                var record = _customerRepo.Get(r => r.Id == rid);
                return View(record);

            }
            catch (NullReferenceException)
            {
                return View("Index");
            }

            
        }

        
        [Themed]
        [HttpPost]
        public ActionResult Delete(CustomersPartRecord cpr,string btnSubmit)
        {
            if(btnSubmit.ToUpper() == "DELETE")
            {
                try
                {
                    var record = _customerRepo.Get(r => r.Id == cpr.Id);
                    _customerRepo.Delete(record);
                }
                catch (NullReferenceException) { }
            }
            

            return RedirectToAction("Index");
        }

    }
}