using Sefin.AskMe.Logic;
using Sefin.AskMe.MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sefin.AskMe.MvcApp.Controllers
{
    public class SurveyManagerController : Controller
    {

        SurveyServices _serivices = new SurveyServices();

        public ActionResult Index(string search)
        {
            List<SurveyInfo> surveyList = _serivices.ListSurveys(search)
                                                    .ToList();

            return View(surveyList);
        }
    }
}