using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Al_Maks.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerEmail { get; set; }
        [Required(ErrorMessage = "Задолжително внесете телефонски број")]
        [Display(Name = "phoneNo")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?[0-9]{3}\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Телефонскиот број е невалиден")]
        public string CustomerPhone { get; set; }
        [Required]
        public string CustomerAddress { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        [Required]
        public DateTime CustomerDOB { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
            Invoices = new List<Invoice>();
        }
    }
}