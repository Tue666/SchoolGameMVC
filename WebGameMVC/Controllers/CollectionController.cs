using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGameMVC.Models.DAL;

namespace WebGameMVC.Controllers
{
    public class CollectionController : Controller
    {
        // GET: Collection
        public ActionResult Index(long userID, long categoryID)
        {
            ViewBag.UserID = ((WebGameMVC.Commons.Login.UserModel)Session[WebGameMVC.Commons.Login.UserSession.USER_SESSION]).id;
            var model = new CollectionDAL().getListAvatar(userID, categoryID);
            return View(model);
        }
        public ActionResult ViewItem(long itemID, long itemCateID)
        {
            ViewBag.UserID = ((WebGameMVC.Commons.Login.UserModel)Session[WebGameMVC.Commons.Login.UserSession.USER_SESSION]).id;
            ViewBag.CateID = itemCateID;
            ViewBag.Item = new AvatarDAL().getImageByID(itemID, itemCateID);
            return View();
        }
        public ActionResult UpdateImage(long itemID, long itemCateID)
        {
            var userID = ((WebGameMVC.Commons.Login.UserModel)Session[WebGameMVC.Commons.Login.UserSession.USER_SESSION]).id;
            var avatar = new AvatarDAL().getImageByID(itemID, itemCateID);
            new AccountDAL().UpdateAvatar(((WebGameMVC.Commons.Login.UserModel)Session[WebGameMVC.Commons.Login.UserSession.USER_SESSION]).id, avatar);
            return Redirect("/Collection/Index?userID=" + userID + "&categoryID=1");
        }
    }
}