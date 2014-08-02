using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Retail.Web.Models {
    public class Product {

        [Key, Display(Name = "ID")]
        public int Id { get; set; }

        [Required, StringLength(100), Index, Display(Name = "Name")]
        public string Name { get; set; }

        [Required, Index, Display(Name = "Category"), InverseProperty("Products"), UIHint("Category")]
        public virtual Category Category { get; set; }

        [Required, Index, Display(Name = "Vendor"), InverseProperty("Products")]
        public virtual Vendor Vendor { get; set; }

        [InverseProperty("Product")]
        public virtual List<SaleItem> SaleItems { get; set; }

        [InverseProperty("Product")]
        public virtual List<Service> Services { get; set; }

        [StringLength(1000), Display(Name = "Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required, Display(Name = "Price"), Column(TypeName = "Money"), UIHint("Money")]
        public decimal Price { get; set; }

    }
}