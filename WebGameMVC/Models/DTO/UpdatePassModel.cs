using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebGameMVC.Models.DTO
{
    public class UpdatePassModel
    {
        [Required(ErrorMessage = "Không được bỏ trống !")]
        public string oldPass { set; get; }
        [Required(ErrorMessage = "Không được bỏ trống !")]
        public string newPass1 { set; get; }
        [Required(ErrorMessage = "Không được bỏ trống !")]
        public string newPass2 { set; get; }
    }
}