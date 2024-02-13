using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Al_Maks.Models
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }
        [Required]
        public string StoreName { get; set; }
        [Required]
        public string StoreAddress { get; set; }
        public virtual IDictionary<Article, int> Articles { get; set; }
        public virtual ICollection<Distributor> Distributors { get; set; }
        public Store()
        {
            //Article smallOne = new Article("0.905 литри");
            //Article one = new Article("1 литро");
            //Article five = new Article("4.75 литри");
            //Article ten = new Article("10 литри");
            Distributors = new List<Distributor>();
            Articles = new Dictionary<Article, int>();
        }
    }
}