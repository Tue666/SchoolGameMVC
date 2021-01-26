using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGameMVC.Models.EF;

namespace WebGameMVC.Models.DAL
{
    public class RankingDAL
    {
        WebGameDbContext db = null;
        public RankingDAL()
        {
            db = new WebGameDbContext();
        }
        public Ranking getRankingByID(int? rankingID)
        {
            return db.Rankings.SingleOrDefault(x => x.ID == rankingID);
        }
    }
}