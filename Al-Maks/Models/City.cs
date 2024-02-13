using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Al_Maks.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Customer> cityCustomers { get; set; }
        public virtual ICollection<Store> cityStores { get; set; }
        public virtual ICollection<Delivery> cityDeliveries { get; set; }

        public City()
        {
            cityCustomers = new List<Customer>();
            cityStores = new List<Store>();
            cityDeliveries = new List<Delivery>();
        }
    }
}