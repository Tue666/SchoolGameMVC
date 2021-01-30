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
            ViewBag.DungeonID = dungeonID;
            var stageByDungID = new StageDAL().listStage(dungeonID);
            return View(stageByDungID);
        }
        public JsonResult ChangeStatusStage(long stageID)
        {
            new StageDAL().changeStatus(stageID);
            return Json(new
            {
                status = true
            });
        }
        public ActionResult editStage(long stageID, long dungeonID)
        {
            ViewBag.Stage = new StageDAL().getStage(stageID);
            ViewBag.DungeonID = dungeonID;
            return PartialView();
        }
        [HttpPost]
        public ActionResult UpdateStage(long stageID, long dungeonID, Stage model)
        {
            var avatarMonster = "/Assets/images/collection/" + model.AvatarMonster + ".png";
            new StageDAL().UpdateStage(stageID, model.Location_X, model.Location_Y, model.DungeonID, model.Exp, model.Type, avatarMonster, model.NameStage, model.Time, model.Money, model.Stamina, model.Level);
            return Redirect("/Admin/Question/ListStage?dungeonID=" + dungeonID);
        }

        public ActionResult DetailStage(long dungeonID, long stageID)
        {
            ViewBag.DungeonID = dungeonID;
            ViewBag.StageID = stageID;
            var question = new QuestionDAL().listQuest(stageID);
            return View(question);
        }
        [HttpGet]
        public ActionResult InsertQuestion(long dungeonID, long stageID)
        {
            ViewBag.DungeonID = dungeonID;
            ViewBag.StageID = stageID;
            return View();
        }
        [HttpPost]
        public ActionResult InsertQuestion(long dungeonID, long stageID, QuestionModel model)
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
                return Redirect("/Admin/Question/DetailStage?dungeonID=" + dungeonID + "&stageID=" + stageID);
            }
            return Redirect("/Admin/Question/DetailStage?dungeonID=" + dungeonID + "&stageID=" + stageID);
        }
        [HttpGet]
        public ActionResult UpdateQuestion(long dungeonID, long stageID, long questionID)
        {
            ViewBag.QuestionID = questionID;
            ViewBag.DungeonID = dungeonID;
            ViewBag.StageID = stageID;
            ViewBag.Question = new QuestionDAL().questionByStageID(questionID, stageID);
            return View();
        }
        [HttpPost]
        public ActionResult UpdateQuestion(long dungeonID, long stageID, long questionID, QuestionModel model)
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
                return Redirect("/Admin/Question/DetailStage?dungeonID=" + dungeonID + "&stageID=" + stageID);
            }
            return Redirect("/Admin/Question/DetailStage?dungeonID=" + dungeonID + "&stageID=" + stageID);
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
    }
}