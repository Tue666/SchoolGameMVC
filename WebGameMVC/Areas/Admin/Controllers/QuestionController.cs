using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGameMVC.Areas.Admin.Data.DTO;
using WebGameMVC.Models.DAL;
using WebGameMVC.Models.EF;

namespace WebGameMVC.Areas.Admin.Controllers
{
    public class QuestionController : BaseController
    {
        // GET: Admin/Question
        public ActionResult Index()
        {
            var dungeon = new DungeonDAL().getAllDungeon();
            return View(dungeon);
        }
        public ActionResult DetailDung(long dungeonID)
        {
            var dungeon = new DungeonDAL().getDung(dungeonID);
            return PartialView(dungeon);
        }
        public ActionResult ListStage(long dungeonID)
        {
            var stageByDungID = new StageDAL().listStage(dungeonID);
            return PartialView(stageByDungID);
        }
        public ActionResult DetailStage(long stageID)
        {
            ViewBag.StageId = stageID;
            var question = new QuestionDAL().listQuest(stageID);
            return View(question);
        }
        public ActionResult addQuestion(long stageID)
        {
            ViewBag.StageID = stageID;
            return PartialView();
        }
        [HttpPost]
        public ActionResult InsertQuestion(long stageID, QuestionModel model)
        {
            var questionModel = new QuestionDAL();
            var subID = (model.subID == "Toán") ? 1 : 1;
            var gradeID = (model.gradeID == "10") ? 1 : (model.gradeID == "11") ? 2 : 3;
            var question = model.Question;
            var answerA = model.answerA;
            var answerB = model.answerB;
            var answerC = model.answerC;
            var answerD = model.answerD;
            var rightAnswer = model.rightAnswer;
            var level = stageID;
            var status = true;
            if (questionModel.InsertQuestion(subID, gradeID, question, answerA, answerB, answerC, answerD, rightAnswer, level, status))
            {
                return Redirect("/Admin/Question/DetailStage?stageID=" + stageID);
            }
            return Redirect("/Admin/Question/DetailStage?stageID=" + stageID);
        }
        public ActionResult editQuestion(long questionID, long stageID)
        {
            ViewBag.QuestionID = questionID;
            ViewBag.StageID = stageID;
            ViewBag.Question = new QuestionDAL().questionByStageID(questionID, stageID);
            return PartialView();
        }
        [HttpPost]
        public ActionResult UpdateQuestion(long questionID, long stageID, QuestionModel model)
        {
            var questionModel = new QuestionDAL();
            var subID = (model.subID == "Toán") ? 1 : 1;
            var gradeID = (model.gradeID == "10") ? 1 : (model.gradeID == "11") ? 2 : 3;
            var question = model.Question;
            var answerA = model.answerA;
            var answerB = model.answerB;
            var answerC = model.answerC;
            var answerD = model.answerD;
            var rightAnswer = model.rightAnswer;
            if (questionModel.UpdateQuestion(questionID, subID, gradeID, question, answerA, answerB, answerC, answerD, rightAnswer))
            {
                return Redirect("/Admin/Question/DetailStage?stageID=" + stageID);
            }
            return Redirect("/Admin/Question/DetailStage?stageID=" + stageID);
        }

        public JsonResult ChangeStatusQuestion(long questionID)
        {
            new QuestionDAL().changeStatus(questionID);
            return Json(new
            {
                status = true
            });
        }

        public JsonResult ChangeStatusDungeon(long dungeonID)
        {
            new DungeonDAL().changeStatus(dungeonID);
            return Json(new
            {
                status = true
            });
        }

        public JsonResult ChangeStatusStage(long stageID)
        {
            new StageDAL().changeStatus(stageID);
            return Json(new
            {
                status = true
            });
        }

        public ActionResult editStage(long stageID)
        {
            ViewBag.Stage = new StageDAL().getStage(stageID);
            return PartialView();
        }
        [HttpPost]
        public ActionResult UpdateStage(long stageID, Stage model)
        {
            var avatarMonster = "/Assets/images/collection/" + model.AvatarMonster + ".png";
            new StageDAL().UpdateStage(stageID, model.Location_X, model.Location_Y, model.DungeonID, model.Exp, model.Type, avatarMonster, model.NameStage, model.Time, model.Money, model.Stamina, model.Level);
            return Redirect("/Admin/Question/Index");
        }
    }
}