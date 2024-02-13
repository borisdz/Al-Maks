using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Al_Maks.Models
{
    public class Distributor
    {
        [Key]
        public int DistributorId { get; set; }

        [Required]
        public string DistributorName { get; set; }

        [Required]
        public string DistributorDescription { get; set; }

        [Required(ErrorMessage = "Задолжително внесете телефонски број")]
        [Display(Name = "Телефонски број")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?[0-9]{3}\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Телефонскиот број е невалиден")]
        public string TelephoneNo { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }

        public Distributor()
        {
            Stores = new List<Store>();
            Deliveries = new List<Delivery>();
            Invoices = new List<Invoice>();
        }
    }
}