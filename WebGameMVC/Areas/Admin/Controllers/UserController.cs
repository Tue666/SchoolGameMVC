using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGameMVC.Models.DAL;
using WebGameMVC.Models.EF;

namespace WebGameMVC.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            var model = new AccountDAL().getAccount();
            return View(model);
        }
        public JsonResult ChangeStatusAccount(long accountID)
        {
            new AccountDAL().changeStatus(accountID);
            return Json(new
            {
                status = true
            });
        }
        public ActionResult editAccount(long accountID)
        {
            ViewBag.AccountID = accountID;
            ViewBag.Account = new AccountDAL().getUserByID(accountID);
            return PartialView();
        }
        [HttpPost]
        public ActionResult UpdateAccount(long accountID, Account model)
        {
            var avatar = "/Assets/images/collection/" + model.Avatar + ".png";
            new AccountDAL().UpdateAccount(accountID, model.PassWord, model.Sex, avatar, "", model.Type, model.SchoolName, model.Grade, model.Class, model.Level, model.Stamina, model.Rank, model.Money);
            return Redirect("/Admin/User/Index");
        }
        public ActionResult showImage()
        {
            var avatar = new AvatarDAL().getListAvatar();
            return PartialView(avatar);
        }
    }
}