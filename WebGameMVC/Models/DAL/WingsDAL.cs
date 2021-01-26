using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGameMVC.Models.EF;

namespace WebGameMVC.Models.DAL
{
    public class WingsDAL
    {
        WebGameDbContext db = null;
        public WingsDAL()
        {
            db = new WebGameDbContext();
        }
        public List<Wing> getListWings()
        {
            return db.Wings.Where(x => x.CategoryID == 2).ToList();
        }
    }
}