using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGameMVC.Models.DAL;

namespace WebGameMVC.Controllers
{
    public class WarController : Controller
    {
        // GET: War
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PVE(long dungeonID, long stageID)
        {
            ViewBag.dungeonID = dungeonID;
            ViewBag.stageID = stageID;
            var user = (WebGameMVC.Commons.Login.UserModel)Session[WebGameMVC.Commons.Login.UserSession.USER_SESSION];
            ViewBag.User = new AccountDAL().getUserByName(user.userName);
            ViewBag.Stage = new StageDAL().getStageByID(stageID);
            var question = new QuestionDAL().listQuestByStageID(stageID);
            return View(question);
        }
        public ActionResult CalPoint(string listAnswer, long stageID)
        {
            var stage = new StageDAL().getStageByID(stageID);
            var count = 0;
            var anserAjax = listAnswer.Split(' ');
            var answerLinQ = new QuestionDAL().listQuestByStageID(stageID).ToArray();
            for (var i = 0; i < answerLinQ.Length; i++)
            {
                if (anserAjax[i] == answerLinQ[i].Right_Answer)
                {
                    count = count + 1;
                }
            }
            var user = new AccountDAL().getUserByName(((WebGameMVC.Commons.Login.UserModel)Session[WebGameMVC.Commons.Login.UserSession.USER_SESSION]).userName);
            var avatarID = new AvatarDAL().getIDByImage(stage.AvatarMonster);
            int? totalBattle = user.TotalBattle + 1;
            int? winBattle = user.WinBattle;
            int? exp = 0;
            if (count == answerLinQ.Length)
            {
                exp = user.Exp + stage.Exp;
                var collection = new CollectionDAL();
                if (!collection.checkExistAvatar(user.ID, avatarID))
                {
                    new CollectionDAL().insertAvatar(user.ID, avatarID);
                }
                winBattle += 1;
            }
            else
            {
                exp = user.Exp + ((stage.Exp * count) / answerLinQ.Length);
            }
            var money = user.Money + stage.Money;
            var level = user.Level;
            if (exp >= 100)
            {
                level = level + (exp / 100);
                exp = exp % 100;
            }
            var stamina = user.Stamina - stage.Stamina;
            if (stamina < 0)
            {
                stamina = 0;
            }
            if (level > 100)
            {
                level = 100;
            }
            new AccountDAL().UpdateByID(user.ID, exp, money, level, stamina, totalBattle, winBattle);
            return Json(new
            {
                status = true,
                countRA = count
            });
        }
        public ActionResult Result(long dungeonID, long stageID, int countRA)
        {
            ViewBag.Stage = new StageDAL().getStageByID(stageID);
            ViewBag.TotalQues = new QuestionDAL().listQuestByStageID(stageID).Count();
            ViewBag.CountRA = countRA;
            ViewBag.DungeonID = dungeonID;
            return View();
        }
    }
}