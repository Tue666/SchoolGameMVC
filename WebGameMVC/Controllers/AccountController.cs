using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGameMVC.Models.DAL;
using WebGameMVC.Models.DTO;

namespace WebGameMVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserInfor(long userID)
        {
            var model = new AccountDAL().getUserByID(userID);
            ViewBag.Ranking = new RankingDAL().getRankingByID(model.Rank);
            return View(model);
        }
        [HttpGet]
        public ActionResult UpdatePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdatePassword(UpdatePassModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AccountDAL().getUserByID(((WebGameMVC.Commons.Login.UserModel)Session[WebGameMVC.Commons.Login.UserSession.USER_SESSION]).id);
                if (model.oldPass == user.PassWord)
                {
                    if (model.newPass1 == model.newPass2)
                    {
                        new AccountDAL().UpdatePassword(user.ID, model.newPass1);
                        return Redirect("/Home/Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Mật khẩu mới khác nhau");
                        return View("UpdatePassword");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Mật khẩu cũ không đúng!");
                    return View("UpdatePassword");
                }
            }
            return View("UpdatePassword");
        }
    }
}