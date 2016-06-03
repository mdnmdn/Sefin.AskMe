using Sefin.AskMe.Logic;
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

        public ActionResult Index()
        {
            List<SurveyInfo> surveyList = _serivices.ListSurveys()
                                                    .ToList();

            ViewBag.MioSaluto = "Ciao";

            return View(surveyList);
        }
    }
}