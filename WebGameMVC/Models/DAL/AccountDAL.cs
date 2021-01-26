using WebGameMVC.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGameMVC.Models.DAL
{
    public class AccountDAL
    {
        WebGameDbContext db = null;
        public AccountDAL()
        {
            db = new WebGameDbContext();
        }
        public bool UpdateAccount(long accountID, string passWord, int? sex, string avatar, string wings, int? type, string schoolName, int? grade, string Class, int? level, int? stamina, int? rank, double? money)
        {
            var model = db.Accounts.SingleOrDefault(x => x.ID == accountID);
            model.PassWord = passWord;
            model.Sex = sex;
            model.Avatar = avatar;
            model.Wings = wings;
            model.Type = type;
            model.SchoolName = schoolName;
            model.Grade = grade;
            model.Class = Class;
            model.Level = level;
            model.Stamina = stamina;
            model.Rank = rank;
            model.Money = money;
            db.SaveChanges();
            return true;
        }
        public bool changeStatus(long accountID)
        {
            var model = db.Accounts.SingleOrDefault(x => x.ID == accountID);
            model.Status = !model.Status;
            db.SaveChanges();
            return true;
        }
        public List<Account> getAccount()
        {
            return db.Accounts.Where(x => x.ID >= 1).ToList();
        }
        public List<Account> getTopAccount(int type,int take)
        {
            var model = db.Accounts;
            if (type == 1)
            {
                return model.OrderByDescending(x => x.Level).Where(x=>x.Status == true).Take(take).ToList();
            }
            return model.OrderByDescending(x => x.Rank).Where(x=>x.Status == true).Take(take).ToList();
        }
        public bool UpdateRank(long userID, int? rank, int? rankExp)
        {
            var model = db.Accounts.SingleOrDefault(x => x.ID == userID);
            model.Rank = rank;
            model.RankExp = rankExp;
            db.SaveChanges();
            return true;
        }
        public bool UpdateAvatar(long userID, string avatar)
        {
            var model = db.Accounts.SingleOrDefault(x => x.ID == userID);
            model.Avatar = avatar;
            db.SaveChanges();
            return true;
        }
        public bool UpdateByID(long userID, int? exp, double? money, int? level, int? stamina, int? totalBattle, int? winBattle)
        {
            var model = db.Accounts.SingleOrDefault(x => x.ID == userID);
            model.Exp = exp;
            model.Money = money;
            model.Level = level;
            model.Stamina = stamina;
            model.TotalBattle = totalBattle;
            model.WinBattle = winBattle;
            db.SaveChanges();
            return true;
        }
        public bool Login(string userName, string passWord)
        {
            return (db.Accounts.Where(x => x.UserName == userName && x.PassWord == passWord && x.Status == true).Count()) == 1;
        }
        public Account getUserByID(long userID)
        {
            return db.Accounts.SingleOrDefault(x => x.ID == userID);
        }
        public Account getUserByName(string userName)
        {
            return db.Accounts.SingleOrDefault(x => x.UserName == userName);
        }
        public bool Insert(Account user)
        {
            if (db.Accounts.Count(x=>x.UserName == user.UserName) > 0)
            {
                return false;
            }
            db.Accounts.Add(user);
            db.SaveChanges();
            return user.ID > 0;
        }
    }
}