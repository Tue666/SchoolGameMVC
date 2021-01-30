using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebGameMVC.Models.DTO
{
    public class RegisModel
    {
        [Required(ErrorMessage = "Không được bỏ trống !")]
        public string userName { set; get; }
        [Required(ErrorMessage = "Không được bỏ trống !")]
        public string passWord { set; get; }
        public string userSchool { set; get; }
        public string userGrade { set; get; }
        public string sex { set; get; }
    }
}