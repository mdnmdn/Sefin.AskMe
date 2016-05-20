using Sefin.AskMe.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sefin.AskMe.WebFormApp.Management
{
    public partial class EditSurvey : System.Web.UI.Page
    {
        SurveyServices _surveyService = new SurveyServices();

        SurveyInfo CurrentSurvey {
            get { return ViewState["Survey"] as SurveyInfo; }
            set { ViewState["Survey"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitData();
                PrepareControls();
            }
        }

        private void InitData()
        {
            var id = Request["id"];
            if (!String.IsNullOrEmpty(id)) {
                CurrentSurvey = _surveyService.GetSurvey(id);
            }
        }

        private void PrepareControls()
        {
            if (CurrentSurvey == null)
            {
                LblTitle.Text = "New Survey";
            }
            else {
                LblTitle.Text = String.Format("{0} ({1})",
                    CurrentSurvey.Name, CurrentSurvey.Id);

                //LblTitle.Text = $"{CurrentSurvey.Name} ({CurrentSurvey.Id})";
            }
        }

        public SurveyInfo FormSurvey_GetItem()
        {
            var survey = CurrentSurvey;
            
            if (survey == null) survey = new SurveyInfo();

            return survey;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void FormSurvey_UpdateItem(SurveyInfo item)
        {
            //_surveyService.SaveSurvey(item);
        }
    }
}