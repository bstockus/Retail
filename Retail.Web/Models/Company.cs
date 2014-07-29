using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Retail.Web.Models {
    public class Company {

        [Key, Display(Name = "ID")]
        public int Id { get; set; }

        [Required, StringLength(100), Index, Display(Name = "Name")]
        public string Name { get; set; }

        [Required, Display(Name = "Tax Rate")]
        public decimal TaxRate { get; set; }

    }
}