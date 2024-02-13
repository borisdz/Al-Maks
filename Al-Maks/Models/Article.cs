using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Al_Maks.Models
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }
        [Required]
        public string ArticleName { get; set; }
        [Required]
        public double ArticlePrice { get; set; }
        [Required]
        public string ArticleImgUrl { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }

        public Article() { }
    }
}