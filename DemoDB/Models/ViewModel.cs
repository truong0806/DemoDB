using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoDB.Models
{
    public class ViewModel
    {
        public string Namepro { get; set; }
        public string DesPro { get; set; }
        [System.ComponentModel.DataAnnotations.Key]
        public string NameCate { get; set; }
        public int IDPro { get; set; }
        public decimal Total_Money { get; set; }
        public Product product { get; set; }
        public Category category { get; set; }
        public OrderDetail orderDetail { get; set; }
        public IEnumerable<Product> ListProduct { get; set; }
    }
}