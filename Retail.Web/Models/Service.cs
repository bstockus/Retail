using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Retail.Web.Models {
    public class Service {

        [Key, Display(Name = "ID")]
        public int Id { get; set; }

        [Required, Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required, Display(Name = "Customer"), InverseProperty("Services")]
        public virtual Customer Customer { get; set; }

        [Required, Display(Name = "Employee"), InverseProperty("Services")]
        public virtual Employee Employee { get; set; }

        [Required, Display(Name = "Product"), InverseProperty("Services")]
        public virtual Product Product { get; set; }

        [Required, Display(Name = "Open")]
        public bool IsOpen { get; set; }

        [StringLength(1000), Display(Name = "Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

    }
}