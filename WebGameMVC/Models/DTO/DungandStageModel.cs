using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGameMVC.Models.EF;

namespace WebGameMVC.Models.DTO
{
    public class DungandStageModel
    {
        public long idDung { set; get; }
        public string bgDung { set; get; }
        public long? quantityStage { set; get; }
        public string nameDung { set; get; }
        public List<Stage> listStage { set; get; }
    }
}