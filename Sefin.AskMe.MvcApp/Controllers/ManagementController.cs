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

        SurveyServices _service = new SurveyServices();

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List(string searchText)
        {
            var model = new SearchSurveyModel {
                SearchText = searchText
            };

            model.SurveyList = _service.ListSurveys(searchText).ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(string id) {

            var model = _service.GetSurvey(id);

            return View(model);
        }


        [HttpPost ]
        public ActionResult Edit(SurveyInfo model)
        {
            if (model.Name != null && model.Name[0] == 's')
            {
                ModelState.AddModelError("", "il nome non deve iniziare per 's'");
            }

            if (ModelState.IsValid) {
                var survey = _service.GetSurvey(model.Id);

                survey.Name = model.Name;
                survey.Description = model.Description;

                _service.SaveSurvey(survey);

                return RedirectToAction("Edit",new { model.Id });
            }

            return View("Edit", model);
        }


    }
}