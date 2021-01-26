using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGameMVC.Models.DAL;

namespace WebGameMVC.Controllers
{
    public class RankController : Controller
    {
        // GET: Rank
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TopRank(int type)
        {
            ViewBag.Type = type;
            var take = 10;
            var listAccount = new AccountDAL().getTopAccount(type, take);
            return View(listAccount);
        }
        public ActionResult AvatarRank(long userID)
        {
            var user = new AccountDAL().getUserByID(userID);
            ViewBag.Rank = new RankingDAL().getRankingByID(user.Rank);
            return PartialView(user);
        }
    }
}