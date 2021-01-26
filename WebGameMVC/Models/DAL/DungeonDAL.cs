using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGameMVC.Models.EF;

namespace WebGameMVC.Models.DAL
{
    public class DungeonDAL
    {
        WebGameDbContext db = null;
        public DungeonDAL()
        {
            db = new WebGameDbContext();
        }
        public bool changeStatus(long dungeonID)
        {
            var model = db.Dungeons.SingleOrDefault(x => x.ID == dungeonID);
            model.Status = !model.Status;
            db.SaveChanges();
            return true;
        }
        public Dungeon getDung(long dungeonID)
        {
            return db.Dungeons.SingleOrDefault(x => x.ID == dungeonID);
        }
        public List<Dungeon> getAllDungeon()
        {
            return db.Dungeons.Where(x => x.ID >= 1).ToList();
        }
        public Dungeon getDungByID(long dungeonID, ref int totalDung)
        {
            totalDung = db.Dungeons.Where(x => x.Status == true).Count();
            return db.Dungeons.SingleOrDefault(x => x.ID == dungeonID && x.Status == true);
        }
        public List<Dungeon> getListDungeon()
        {
            return db.Dungeons.Where(x => x.Status == true).ToList();
        }
    }
}