using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Retail.Web.Models {
    public class Sale {

        [Key, Display(Name = "ID")]
        public int Id { get; set; }

        [Required, Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required, Display(Name = "SubTotal"), Column(TypeName = "Money"), UIHint("Money")]
        public decimal SubTotal { get; set; }

        [Required, Display(Name = "Discount"), Column(TypeName = "Money"), UIHint("Money")]
        public decimal Discount { get; set; }

        [Required, Display(Name = "Tax"), Column(TypeName = "Money"), UIHint("Money")]
        public decimal Tax { get; set; }

        [Required, Display(Name = "Total"), Column(TypeName = "Money"), UIHint("Money")]
        public decimal Total { get; set; }

        [Required, Display(Name = "Customer"), InverseProperty("Sales"), UIHint("Customer")]
        public virtual Customer Customer { get; set; }

        [Required, Display(Name = "Employee"), InverseProperty("Sales"), UIHint("Employee")]
        public virtual Employee Employee { get; set; }

        [InverseProperty("Sale")]
        public virtual List<SaleItem> SaleItems { get; set; }

    }
}