using Sefin.AskMe.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sefin.AskMe.MvcApp.Models
{
    public class AnswerListModel
    {

        public string Id { get; set; }

        public string Search { get; set; }

        public SurveyInfo Survey { get; set; }

        public List<Answer> Answers { get; set; }
    }
}