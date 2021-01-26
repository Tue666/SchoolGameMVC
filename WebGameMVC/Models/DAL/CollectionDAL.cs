using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGameMVC.Models.EF;

namespace WebGameMVC.Models.DAL
{
    public class CollectionDAL
    {
        WebGameDbContext db = null;
        public CollectionDAL()
        {
            db = new WebGameDbContext();
        }
        public int getQuantityAvatar(long userID)
        {
            return db.Collections.Where(x => x.UserID == userID).Count();
        }
        public List<Avatar> getListAvatar(long userID, long categoryID)
        {
            var model = from a in db.Avatars
                        join b in db.Collections
                        on a.ID equals b.ThingID
                        where b.UserID == userID && b.CategoryID == categoryID
                        select a;
            return model.ToList();
        }
        public bool checkExistAvatar(long userID, long thingID)
        {
            return db.Collections.Where(x => x.UserID == userID && x.ThingID == thingID).Count() > 1;
        }
        public bool insertAvatar(long userID, long thingID)
        {
            var model = new Collection();
            model.UserID = userID;
            model.CategoryID = 1;
            model.ThingID = thingID;
            model.ImageThing = null;
            model.CreateDay = DateTime.Now;
            db.Collections.Add(model);
            db.SaveChanges();
            return true;
        }
    }
}