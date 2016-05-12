using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sefin.AskMe.Logic;

namespace Sefin.AskMe.WebFormApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var service = new SurveyServices();

            var survey = new SurveyInfo
            {
                Name = "survey 1",
                Description = "survey description",
                NumberOfQuestions = 2,
                Question1 = "Quest 1",
                Answer1A = "A",
                Answer1B = "B",
                Answer1C = "C",
                Question2 = "Quest 2",
                Answer2A = "A2",
                Answer2B = "B2",
                Answer2C = "C2",
                Answers = new List<Answer>
                {
                    new Answer
                    {
                        Id = "11111",
                        Answer1 = 1,
                        Answer2 = 3,
                        UserName = "pippo",
                        CompilationDate = DateTime.Now
                    },
                    new Answer
                    {
                        Id = "121211",
                        Answer1 = 1,
                        Answer2 = 3,
                        UserName = "pippo",
                        CompilationDate = DateTime.Now
                    }
                }
            };


            Logic.TestDataGenerator.GenerateIfEmpty();

            // service.SaveSurvey(survey);
        }
    }

    
}