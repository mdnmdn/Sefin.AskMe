using Sefin.AskMe.Logic;
using Sefin.AskMe.MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sefin.AskMe.MvcApp.Controllers
{
    public class ManagementController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List(string searchText)
        {
            var model = new SearchSurveyModel {
                SearchText = searchText
            };

            var svc = new SurveyServices();

            model.SurveyList = svc.ListSurveys(searchText).ToList();

            return View(model);
        }
    }
}