using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGameMVC.Models.DAL;

namespace WebGameMVC.Areas.Admin.Controllers
{
    public class FeedbackController : BaseController
    {
        // GET: Admin/Feedback
        public ActionResult Index()
        {
            var model = new FeedbackDAL().listFeedBack();
            return View(model);
        }
        public ActionResult readFeedback(long feedbackID)
        {
            var model = new FeedbackDAL().getFeedbackByID(feedbackID);
            ViewBag.FeedbackID = feedbackID;
            return PartialView(model);
        }
        public JsonResult ChangeStatusFeedback(long feedbackID)
        {
            new FeedbackDAL().changeStatus(feedbackID);
            return Json(new
            {
                status = true
            });
        }
    }
}