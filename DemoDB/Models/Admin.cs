using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DemoDB.Models
{
    public class Admin
    {

        public int ID { get; set; }

        [Required(ErrorMessage = "Name not empty....!")]
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "Ten user")]
        public string NameUser { get; set; }

        [DisplayName("Vi tri")]
        public string RoleUser { get; set; }

        [Required(ErrorMessage = "Pass not empty....!")]
        [DisplayName("Mat khau")]
        [DataType(DataType.Password)]
        public string PasswordUser { get; set; }

        [NotMapped]
        [Compare("PasswordUser")]
        [DisplayName("Nhap lai mat khau")]
        [DataType(DataType.Password)]
        public string ConfirmPass { get; set; }
    }
}