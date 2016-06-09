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

        SurveyServices _services = new SurveyServices();

        public ActionResult Index(SurveyListModel model)
        {
            List<SurveyInfo> surveyList = _services.ListSurveys(model.Search)
                                                    .ToList();

            model.Surveys = surveyList;

            return View(model);
        }

        //public ActionResult Index(string search)
        //{
        //    List<SurveyInfo> surveyList = _services.ListSurveys(search)
        //                                            .ToList();

        //    var model = new SurveyListModel
        //    {
        //        Search = search,
        //        Surveys = surveyList
        //    };

        //    return View(model);
        //}
    }
}