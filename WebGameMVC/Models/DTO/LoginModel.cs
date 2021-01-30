using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebGameMVC.Models.DTO
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Không được bỏ trống !")]
        public string userName { set; get; }
        [Required(ErrorMessage = "Không được bỏ trống !")]
        public string passWord { set; get; }
    }
}