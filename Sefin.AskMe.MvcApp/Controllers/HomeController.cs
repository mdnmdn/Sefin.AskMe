using Sefin.AskMe.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sefin.AskMe.MvcApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public DateTime Adesso() {
            return DateTime.Now;
        }

        public SurveyInfo Questionario()
        {
            var svc = new SurveyServices();
            var survey = svc.ListSurveys().First();
            return survey;
        }

        public ActionResult JsonQuestionario()
        {
            var svc = new SurveyServices();
            var survey = svc.ListSurveys().First();

            return Json(survey,JsonRequestBehavior.AllowGet);
        }

    }
}