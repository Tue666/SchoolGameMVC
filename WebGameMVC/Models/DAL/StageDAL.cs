using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGameMVC.Models.EF;

namespace WebGameMVC.Models.DAL
{
    public class StageDAL
    {
        WebGameDbContext db = null;
        public StageDAL()
        {
            db = new WebGameDbContext();
        }
        public bool UpdateStage(long stageID, int? locationX, int? locationY, long? dungeonID, int? exp, int? type, string avatarMonster, string nameStage, string time, double? money, int? stamina, long? level)
        {
            var model = db.Stages.SingleOrDefault(x => x.ID == stageID);
            model.Location_X = locationX;
            model.Location_Y = locationY;
            model.DungeonID = dungeonID;
            model.Exp = exp;
            model.Type = type;
            model.AvatarMonster = avatarMonster;
            model.NameStage = nameStage;
            model.Time = time;
            model.Money = money;
            model.Stamina = stamina;
            model.Level = level;
            db.SaveChanges();
            return true;
        }
        public Stage getStage(long stageID)
        {
            return db.Stages.SingleOrDefault(x => x.ID == stageID);
        }
        public bool changeStatus(long stageID)
        {
            var model = db.Stages.SingleOrDefault(x => x.ID == stageID);
            model.Status = !model.Status;
            db.SaveChanges();
            return true;
        }
        public List<Stage> listStage(long dungeonID)
        {
            return db.Stages.Where(x => x.DungeonID == dungeonID).ToList();
        }
        public Stage getStageByID(long stageID)
        {
            return db.Stages.SingleOrDefault(x => x.ID == stageID && x.Status == true);
        }
        public List<Stage> listStageByIDDung(long idDungeon)
        {
            return db.Stages.Where(x => x.DungeonID == idDungeon && x.Status == true).ToList();
        }
    }
}