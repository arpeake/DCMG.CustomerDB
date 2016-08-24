using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;

namespace Dcmg.CustomerDB.Models
{
    public class CustomersPart : ContentPart<CustomersPartRecord>
    {
        public new int Id
        {
            get { return Record.Id; }
        }

        public string Name
        {
            get { return Record.Name; }
            set { Record.Name = value; }
        }

        public string Address
        {
            get { return Record.Address; }
            set { Record.Address = value; }
        }

        public string PhoneNumber
        {
            get { return Record.PhoneNumber; }
            set { Record.PhoneNumber = value; }
        }

        public string PrimaryPOC
        {
            get { return Record.PrimaryPOC; }
            set { Record.PrimaryPOC = value; }
        }

        public string SecondaryPOC
        {
            get { return Record.SecondaryPOC; }
            set { Record.SecondaryPOC = value; }
        }

        public string PrimaryPOCEmail
        {
            get { return Record.PrimaryPOCEmail; }
            set { Record.PrimaryPOCEmail = value; }
        }

        public string SecondaryPOCEmail
        {
            get { return Record.SecondaryPOCEmail; }
            set { Record.SecondaryPOCEmail = value; }
        }

        public string EmailAlias
        {
            get { return Record.EmailAlias; }
            set { Record.EmailAlias = value; }
        }

        public string Notes
        {
            get { return Record.Notes; }
            set { Record.Notes = value; }
        }
    }
}