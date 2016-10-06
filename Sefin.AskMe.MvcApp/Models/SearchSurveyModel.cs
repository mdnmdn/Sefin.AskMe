using Sefin.AskMe.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sefin.AskMe.MvcApp.Models
{
    public class SearchSurveyModel
    {
        public string SearchText { get; set; }

        public List<SurveyInfo> SurveyList { get; set; }
    }
}