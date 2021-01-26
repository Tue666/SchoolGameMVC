using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGameMVC.Models.EF;

namespace WebGameMVC.Models.DAL
{
    public class AvatarDAL
    {
        WebGameDbContext db = null;
        public AvatarDAL()
        {
            db = new WebGameDbContext();
        }
        public List<Avatar> getListAvatar()
        {
            return db.Avatars.Where(x => x.CategoryID == 1).ToList();
        }
        public string getImageByID(long avatarID, long cateID)
        {
            var model = db.Avatars.SingleOrDefault(x => x.ID == avatarID && x.CategoryID == cateID);
            return model.Image;
        }
        public long getIDByImage(string image)
        {
            return db.Avatars.SingleOrDefault(x => x.Image == image).ID;
        }
    }
}