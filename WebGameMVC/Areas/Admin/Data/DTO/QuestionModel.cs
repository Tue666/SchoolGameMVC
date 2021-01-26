using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGameMVC.Areas.Admin.Data.DTO
{
    public class QuestionModel
    {
        public string subID { set; get; }
        public string gradeID { set; get; }
        public string Question { set; get; }
        public string answerA { set; get; }
        public string answerB { set; get; }
        public string answerC { set; get; }
        public string answerD { set; get; }
        public string rightAnswer { set; get; }
        public long level { set; get; }
        public bool status { set; get; }
    }
}