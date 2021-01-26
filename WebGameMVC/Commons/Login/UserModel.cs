using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGameMVC.Commons.Login
{
    public class UserModel
    {
        public long id { set; get; }
        public string userName { set; get; }
        public int? type { set; get; }
    }
}