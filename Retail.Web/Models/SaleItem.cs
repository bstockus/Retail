﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Retail.Web.Models {
    public class SaleItem {

        [Key, Display(Name = "ID")]
        public int Id { get; set; }

        [Required, Display(Name = "Sale"), InverseProperty("SaleItems")]
        public virtual Sale Sale { get; set; }

        [Required, Display(Name = "Product"), InverseProperty("SaleItems"), UIHint("Product")]
        public virtual Product Product { get; set; }

        [Required, Display(Name = "Unit Price"), Column(TypeName = "Money"), UIHint("Money")]
        public decimal UnitPrice { get; set; }

        [Required, Display(Name = "Item Price"), Column(TypeName = "Money"), UIHint("Money")]
        public decimal ItemPrice { get; set; }

        [Required, Display(Name = "Quantity")]
        public uint Quantity { get; set; }

    }
}