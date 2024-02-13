using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Al_Maks.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int DistributorId { get; set; }
        public Distributor Distributor { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public Invoice() { }
    }
}