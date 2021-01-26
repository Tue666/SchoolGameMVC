using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGameMVC.Models.EF;

namespace WebGameMVC.Models.DAL
{
    public class PetDAL
    {
        WebGameDbContext db = null;
        public PetDAL()
        {
            db = new WebGameDbContext();
        }
        public List<Pet> getListPet()
        {
            return db.Pets.Where(x => x.CategoryID == 3).ToList();
        }
    }
}