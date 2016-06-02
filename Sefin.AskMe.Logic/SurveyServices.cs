using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.AskMe.Logic
{
    public class SurveyServices
    {

        static object _lock = new object();
        static Random _random = new Random();

        static List<SurveyInfo> _data;

        public SurveyServices()
        {
            Init();
        }


        #region surveys
        public IQueryable<SurveyInfo> ListSurveys()
        {
            return _data.AsQueryable();
        }


        public IQueryable<SurveyInfo> ListSurveys(string search)
        {
            var result = _data.AsQueryable();
            if (!String.IsNullOrEmpty(search)) {
                result = result.Where(s => s.Id == search 
                        || s.Name.IndexOf(search, StringComparison.CurrentCultureIgnoreCase) >=0
                        || s.Description.IndexOf(search, StringComparison.CurrentCultureIgnoreCase) >= 0);
            }
            return result;
        }

        public SurveyInfo GetSurvey(string surveyId)
        {
            return _data.FirstOrDefault(s => s.Id == surveyId);
        }

        public SurveyInfo SaveSurvey(SurveyInfo survey)
        {
            if (String.IsNullOrEmpty(survey.Id))
            {
                survey.Id = _random.Next(Int32.MaxValue).ToString();
            }

            var oldSurvey = _data.FirstOrDefault(s => s.Id == survey.Id);
            if (oldSurvey != null)
            {
                oldSurvey.Name = survey.Name;
                oldSurvey.Description = survey.Description;
                oldSurvey.Active = survey.Active;
                oldSurvey.NumberOfQuestions = survey.NumberOfQuestions;
                oldSurvey.Question1 = survey.Question1;
                oldSurvey.Answer1A = survey.Answer1A;
                oldSurvey.Answer1B = survey.Answer1B;
                oldSurvey.Answer1C = survey.Answer1C;
                oldSurvey.Question2 = survey.Question2;
                oldSurvey.Answer2A = survey.Answer2A;
                oldSurvey.Answer2B = survey.Answer2B;
                oldSurvey.Answer2C = survey.Answer2C;
                oldSurvey.Question3 = survey.Question3;
                oldSurvey.Answer3A = survey.Answer3A;
                oldSurvey.Answer3B = survey.Answer3B;
                oldSurvey.Answer3C = survey.Answer3C;

                survey = oldSurvey;
            }
            else
            {
                _data.Add(survey);
            }

            foreach (var answer in survey.Answers)
            {
                answer.SurveyId = survey.Id;
                if (String.IsNullOrEmpty(answer.Id))
                    answer.Id = _random.Next(Int32.MaxValue).ToString();
            }

            SaveData();
            return survey;
        }

        public void DeleteSurvey(string id)
        {
            var survey = _data.FirstOrDefault(s => s.Id == id);
            if (survey != null)
            {
                _data.Remove(survey);
                SaveData();
            }
        }

        #endregion

        #region answers

        public IQueryable<Answer> ListAnswers(string surveyId)
        {
            var survey = _data.FirstOrDefault(s => s.Id == surveyId);
            if (survey == null) return new List<Answer>().AsQueryable();

            return survey.Answers.AsQueryable();
        }

        public Answer GetAnswer(string surveyId,string answerId)
        {
            var survey = _data.FirstOrDefault(s => s.Id == surveyId);
            if (survey == null) throw new Exception("Survey non found for id: " + surveyId);

            return survey.Answers.FirstOrDefault(s => s.Id == answerId);
        }

        public Answer SaveAnswer(Answer answer)
        {
            var survey = _data.FirstOrDefault(s => s.Id == answer.SurveyId);

            if (survey == null) throw new Exception("Survey non found for id: " + answer.SurveyId);

            if (String.IsNullOrEmpty(answer.Id))
            {
                answer.Id = _random.Next(Int32.MaxValue).ToString();
            }

            if (answer.CompilationDate == default(DateTime))
                answer.CompilationDate = DateTime.Now;

            var oldAnswer =  survey.Answers.FirstOrDefault(s => s.Id == answer.Id);
            if (oldAnswer != null) {
                oldAnswer.Answer1 = answer.Answer1;
                oldAnswer.Answer2 = answer.Answer2;
                oldAnswer.Answer3 = answer.Answer3;
                oldAnswer.CompilationDate = answer.CompilationDate;
                oldAnswer.UserName = answer.UserName;

                answer = oldAnswer;
            }
            else
            {
                survey.Answers.Add(answer);
            }
            SaveData();

            return answer;
        }

        public void DeleteAnswer(string surveyId,string answerId)
        {

            var survey = _data.FirstOrDefault(s => s.Id == surveyId);
            if (survey == null) throw new Exception("Survey non found for id: " + surveyId);

            var answer = survey.Answers.FirstOrDefault(s => s.Id == answerId);
            if (answer != null)
            {
                survey.Answers.Remove(answer);
                SaveData();
            }
        }

        #endregion

        private static void Init()
        {
            lock (_lock)
            {
                if (_data != null) return;
                string fileName = GetFileName();
                if (!File.Exists(fileName))
                {
                    Logic.TestDataGenerator.GenerateIfEmpty();
                    //_data = new List<SurveyInfo>();
                    //return;
                }
                using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    var serializer = new DataContractJsonSerializer(typeof(List<SurveyInfo>));
                    _data = (List<SurveyInfo>)serializer.ReadObject(stream);
                    stream.Close();
                }
            }
        }

       

        private static void SaveData()
        {
            lock (_lock)
            {
                if (_data == null) return;
                string fileName = GetFileName();
                using (var stream = new FileStream(fileName, FileMode.Create))
                {
                    var serializer = new DataContractJsonSerializer(typeof(List<SurveyInfo>));
                    serializer.WriteObject(stream, _data);
                    stream.Close();
                }
            }
        }

        private static string GetFileName()
        {
            var fileName = ConfigurationManager.AppSettings["DataFilePath"];
            return fileName.Replace("~", AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
