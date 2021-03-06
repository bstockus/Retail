﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Retail.Web.Models {
    public class Customer {

        [Key, Display(Name = "ID")]
        public int Id { get; set; }

        [Required, StringLength(50), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(50), Index, Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(10, MinimumLength = 10), Index, Display(Name = "Phone Number"), UIHint("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [StringLength(100), Display(Name = "Street Address", ShortName = "Street", GroupName = "Address")]
        public string AddressStreet { get; set; }

        [StringLength(50), Display(Name = "City", ShortName = "City", GroupName = "Address")]
        public string AddressCity { get; set; }

        [StringLength(5, MinimumLength = 5), Index, Display(Name = "Zip Code", ShortName = "Zip", GroupName = "Address")]
        public string AddressZip { get; set; }

        [Index, Display(Name = "State", ShortName = "State", GroupName = "Address")]
        public State AddressState { get; set; }

        [StringLength(100), Display(Name = "Email"), EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Incidents"), InverseProperty("Customer")]
        public virtual List<Incident> Incidents { get; set; }

        [Display(Name = "Services"), InverseProperty("Customer")]
        public virtual List<Service> Services { get; set; }

        [Display(Name = "Sales"), InverseProperty("Customer")]
        public virtual List<Sale> Sales { get; set; }

        [Display(Name = "ContactLists"), InverseProperty("Customers")]
        public virtual List<ContactList> ContactLists { get; set; }

    }
}