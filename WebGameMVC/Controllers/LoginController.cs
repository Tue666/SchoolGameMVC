using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGameMVC.Commons.Login;
using WebGameMVC.Models.DAL;
using WebGameMVC.Models.DTO;
using WebGameMVC.Models.EF;

namespace WebGameMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AccountDAL();
                if (user.Login(model.userName, model.passWord))
                {
                    var userSession = new UserModel();
                    userSession.id = new AccountDAL().getUserByName(model.userName).ID;
                    userSession.userName = model.userName;
                    UserSession.USER_SESSION = model.userName;
                    userSession.type = new AccountDAL().getUserByName(model.userName).Type;
                    Session.Add(UserSession.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");
                }
            }
            return View("Index");
        }
        public ActionResult LogOut()
        {
            Session[WebGameMVC.Commons.Login.UserSession.USER_SESSION] = null;
            return Redirect("/Home/Index");
        }
        [HttpGet]
        public ActionResult Regis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Regis(RegisModel user)
        {
            if (ModelState.IsValid)
            {
                var account = new Account();
                account.UserName = user.userName;
                account.PassWord = user.passWord;
                account.Sex = Convert.ToInt32(user.sex);
                var urlAvatar = "";
                if (user.sex == "1")
                {
                    urlAvatar = "/Assets/images/collection/basicMale.png";
                }
                else
                {
                    urlAvatar = "/Assets/images/collection/basicFemale.png";
                }
                account.Avatar = urlAvatar;
                account.Wings = "";
                account.Type = 0;
                account.SchoolName = user.userSchool;
                if (user.userGrade == "10" || user.userGrade == "11" || user.userGrade == "12")
                {
                    account.Grade = Convert.ToInt32(user.userGrade);
                }
                else
                {
                    ModelState.AddModelError("", "Sai khối");
                    return View("Regis");
                }
                account.Level = 1;
                account.Exp = 0;
                account.Title = "<span style=color:#fff;>Không<span/>";
                account.Stamina = 100;
                account.Rank = 1;
                account.CreateDay = DateTime.Now;
                account.Money = 1000;
                account.Status = true;
                account.RankExp = 0;
                account.TotalBattle = 0;
                account.WinBattle = 0;
                var model = new AccountDAL();
                if (model.Insert(account))
                {
                    if (account.Sex == 1)
                    {
                        new CollectionDAL().insertAvatar(account.ID, 1);
                    }
                    else
                    {
                        new CollectionDAL().insertAvatar(account.ID, 2);
                    }
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ModelState.AddModelError("", "Tên tài khoản tồn tại !");
                }
            }
            return View("Regis");
        }
    }
}