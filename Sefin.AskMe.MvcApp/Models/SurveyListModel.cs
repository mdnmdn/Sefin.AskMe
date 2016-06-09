using Sefin.AskMe.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sefin.AskMe.MvcApp.Models
{
    public class SurveyListModel
    {
        public string Search { get; set; }

        public List<SurveyInfo> Surveys { get; set; }
    }
}