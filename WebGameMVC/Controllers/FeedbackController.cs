using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGameMVC.Models.DAL;
using WebGameMVC.Models.EF;

namespace WebGameMVC.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Feedback
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addFeedBack(Feedback model)
        {
            model.UserName = ((WebGameMVC.Commons.Login.UserModel)Session[WebGameMVC.Commons.Login.UserSession.USER_SESSION]).userName;
            model.Status = false;
            new FeedbackDAL().insertFeedback(model);
            return View("Index");
        }
        public ActionResult HistoryFeedBack()
        {
            var userName = ((WebGameMVC.Commons.Login.UserModel)Session[WebGameMVC.Commons.Login.UserSession.USER_SESSION]).userName;
            var model = new FeedbackDAL().listFeedbackByUserName(userName);
            return View(model);
        }
    }
}