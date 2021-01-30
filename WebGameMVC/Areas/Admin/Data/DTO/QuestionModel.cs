using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebGameMVC.Areas.Admin.Data.DTO
{
    public class QuestionModel
    {
        public string subID { set; get; }
        public string gradeID { set; get; }
        [AllowHtml]
        public string Question { set; get; }
        [AllowHtml]
        public string answerA { set; get; }
        [AllowHtml]
        public string answerB { set; get; }
        [AllowHtml]
        public string answerC { set; get; }
        [AllowHtml]
        public string answerD { set; get; }
        public string rightAnswer { set; get; }
        public long level { set; get; }
        public bool status { set; get; }
    }
}