using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGameMVC.Models.EF;

namespace WebGameMVC.Models.DAL
{
    public class FeedbackDAL
    {
        WebGameDbContext db = null;
        public FeedbackDAL()
        {
            db = new WebGameDbContext();
        }
        public List<Feedback> listFeedbackByUserName(string userName)
        {
            return db.Feedbacks.Where(x => x.UserName == userName).ToList();
        }
        public bool changeStatus(long feedbackID)
        {
            var model = db.Feedbacks.SingleOrDefault(x => x.ID == feedbackID);
            model.Status = !model.Status;
            db.SaveChanges();
            return true;
        }
        public Feedback getFeedbackByID(long feedbackID)
        {
            return db.Feedbacks.SingleOrDefault(x => x.ID == feedbackID);
        }
        public List<Feedback> listFeedBack()
        {
            return db.Feedbacks.Where(x => x.ID >= 1).ToList();
        }
        public bool insertFeedback(Feedback model)
        {
            db.Feedbacks.Add(model);
            db.SaveChanges();
            return true;
        }
    }
}