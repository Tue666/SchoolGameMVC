using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGameMVC.Models.DAL;

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
    }
}