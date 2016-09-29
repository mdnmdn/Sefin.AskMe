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


        public ActionResult Edit(string id) {

            SurveyInfo survey = _services.GetSurvey(id);

            return View(survey);
        }


        [HttpPost]
        public ActionResult Edit(SurveyInfo model)
        {
            if (ModelState.IsValid)
            {

                if (model.Name[0] != 'A')
                {
                    ModelState.AddModelError("", "Deve inizare per A");

                }

                if (ModelState.IsValid)
                {

                    // fai il salvataggio
                    // redirect verso altra pagina
                }
            }
            return View(model);
        }


        public ActionResult ShowAnswers(string id, string search) {

            var model = new AnswerListModel
            {
                Id = id,
                Search = search,
                Survey = _services.GetSurvey(id),
                Answers =_services.ListAnswers(id).ToList()
            };

            return View(model);
        }

        public ActionResult ShowAnswers(AnswerListModel model)
        {
            var answers = _services.ListAnswers(model.Id);

            model.Survey = _services.GetSurvey(model.Id);
            model.Answers = _services.ListAnswers(model.Id).ToList();

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