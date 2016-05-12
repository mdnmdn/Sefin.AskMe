using Sefin.AskMe.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sefin.AskMe.WebFormApp.Management
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<SurveyInfo> GridSurvey_GetData()
        {
            var search = TxtSearch.Text;

            var svc = new SurveyServices();
            IQueryable<SurveyInfo> data = svc.ListSurveys(search);


            //IQueryable<SurveyInfo> data = svc.ListSurveys();
            //if (!String.IsNullOrEmpty(search)) {
            //    data = data.Where(s => s.Name.ToLower().Contains(search));    
            //}

            return data;
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            GridSurvey.PageIndex = 0;
            GridSurvey.DataBind();
        }
    }
}