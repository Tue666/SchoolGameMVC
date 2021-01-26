using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGameMVC.Models.DAL;

namespace WebGameMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session[WebGameMVC.Commons.Login.UserSession.USER_SESSION] != null)
            {
                var user = new AccountDAL().getUserByName(((WebGameMVC.Commons.Login.UserModel)Session[WebGameMVC.Commons.Login.UserSession.USER_SESSION]).userName);
                ViewBag.User = user;
                var quantityAvatar = new CollectionDAL().getQuantityAvatar(user.ID);
                var point = (quantityAvatar * 50) + 100;
                if (point > 800)
                {
                    point = 800;
                }
                new AccountDAL().UpdateRank(user.ID, point / 100, point % 100);
            }
            return View();
        }
        public ActionResult UserPanel()
        {
            var userSession = (WebGameMVC.Commons.Login.UserModel)Session[WebGameMVC.Commons.Login.UserSession.USER_SESSION];
            var user = new AccountDAL().getUserByName(userSession.userName);
            ViewBag.User = user;
            ViewBag.Ranking = new RankingDAL().getRankingByID(user.Rank);
            return PartialView();
        }
        [HttpPost]
        public JsonResult CheckLogin()
        {
            var user = Session[WebGameMVC.Commons.Login.UserSession.USER_SESSION];
            if (user != null)
            {
                return Json(new
                {
                    status = true
                });
            }
            return Json(new
            {
                status = false
            }); ;
        }
    }
}