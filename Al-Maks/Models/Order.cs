using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Al_Maks.Models
{
    public enum OrderStatus
    {
        CREATED,
        CANCELED,
        PENDING_PAYMENT,
        PAID,
        DELIVERING,
        DELIVERED
    }
    public enum PaymentType
    {
        CASH,
        INVOICE
    }
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public virtual IDictionary<Article, int> Articles { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public PaymentType PaymentType { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; }

        public Order() { }
    }
}