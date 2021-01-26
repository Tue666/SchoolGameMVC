using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGameMVC.Models.DAL;

namespace WebGameMVC.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShopAvatar()
        {
            var listAvatar = new AvatarDAL().getListAvatar();
            return View(listAvatar);
        }
        public ActionResult ShopWings()
        {
            var listWings = new WingsDAL().getListWings();
            return View(listWings);
        }
        public ActionResult ShopPet()
        {
            var listPet = new PetDAL().getListPet();
            return View(listPet);
        }
    }
}