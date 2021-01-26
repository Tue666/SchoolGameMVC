using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGameMVC.Models.EF;

namespace WebGameMVC.Models.DAL
{
    public class QuestionDAL
    {
        WebGameDbContext db = null;
        public QuestionDAL()
        {
            db = new WebGameDbContext();
        }
        public bool changeStatus(long questionID)
        {
            var model = db.Questions.SingleOrDefault(x => x.ID == questionID);
            model.Status = !model.Status;
            db.SaveChanges();
            return true;
        }
        public Question questionByStageID(long questionID, long stageID)
        {
            return db.Questions.SingleOrDefault(x => x.ID == questionID && x.Level == stageID);
        }
        public bool UpdateQuestion(long questionID, long subID, long gradeID, string question, string answerA, string answerB, string answerC, string answerD, string rightAnswer)
        {
            var model = db.Questions.SingleOrDefault(x => x.ID == questionID);
            model.SubID = subID;
            model.GradeID = gradeID;
            model.Question1 = question;
            model.Answer_A = answerA;
            model.Answer_B = answerB;
            model.Answer_C = answerC;
            model.Answer_D = answerD;
            model.Right_Answer = rightAnswer;
            db.SaveChanges();
            return true;
        }
        public bool InsertQuestion(long subID, long gradeID, string question, string answerA, string answerB, string answerC, string answerD, string rightAnswer, long level, bool status)
        {
            var model = new Question();
            model.SubID = subID;
            model.GradeID = gradeID;
            model.Question1 = question;
            model.Answer_A = answerA;
            model.Answer_B = answerB;
            model.Answer_C = answerC;
            model.Answer_D = answerD;
            model.Right_Answer = rightAnswer;
            model.Level = level;
            model.Status = status;
            db.Questions.Add(model);
            db.SaveChanges();
            return true;
        }
        public List<Question> listQuest(long stageID)
        {
            return db.Questions.Where(x => x.Level == stageID).ToList();
        }
        public List<Question> listQuestByStageID(long stageID)
        {
            return db.Questions.Where(x => x.Level == stageID && x.Status == true).ToList();
        }
    }
}