using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Al_Maks.Models
{
    public class Delivery
    {
        [Key]
        public int DeliveryId { get; set; }
        [Required]
        public DateTime DeliveryDate { get; set; }
        public int DistributorId { get; set; }
        public Distributor Distributor { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<City> DeliveryCities { get; set; }

        public Delivery()
        {
            Orders = new List<Order>();
            DeliveryCities = new List<City>();
        }
    }
}