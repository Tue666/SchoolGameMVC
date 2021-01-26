using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGameMVC.Models.DAL;
using WebGameMVC.Models.DTO;

namespace WebGameMVC.Controllers
{
    public class DungeonController : Controller
    {
        // GET: Dungeon
        public ActionResult Index(long dungeonID)
        {
            var totalDung = 0;
            var dungeon = new DungeonDAL().getDungByID(dungeonID, ref totalDung);
            ViewBag.TotalDung = totalDung;
            var dungandstage = new DungandStageModel();
            dungandstage.idDung = dungeon.ID;
            dungandstage.bgDung = dungeon.Background;
            dungandstage.quantityStage = dungeon.QuantityStage;
            dungandstage.nameDung = dungeon.NameDungeon;
            var listStage = new StageDAL().listStageByIDDung(dungeon.ID);
            dungandstage.listStage = listStage;
            var user = new AccountDAL().getUserByName(((WebGameMVC.Commons.Login.UserModel)Session[WebGameMVC.Commons.Login.UserSession.USER_SESSION]).userName);
            ViewBag.UserStamina = user.Stamina;
            return View(dungandstage);
        }
    }
}