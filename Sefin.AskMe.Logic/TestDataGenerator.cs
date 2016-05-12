using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.AskMe.Logic
{
    public static class TestDataGenerator 
    {
        static Random _random = new Random();

        public static void GenerateIfEmpty() {
            var service = new SurveyServices();
            if (!service.ListSurveys().Any()) {
                var surveys = GenerateData();
                foreach (var survey in surveys) {
                    //try
                    //{
                        service.SaveSurvey(survey);
                    //}
                    //catch (Exception ex) {
                    //    ex.ToString();
                    //}
                }
            }


        }

        private static List<SurveyInfo> GenerateData()
        {
            var segments = _nameSegments.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var questionList = _questions.Split(new string[] { Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            
            var names = _names.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            int numSurveys = 100;

            List<SurveyInfo> surveys = new List<SurveyInfo>();

            while (surveys.Count < numSurveys)
            {
                var segs = GetRandomString(segments, 2);
                var surveyName = String.Format("Survey {0} {1}", segs[0], segs[1]);

                if (surveys.Any(s => s.Name == surveyName)) continue;

                var survey = new SurveyInfo
                {
                    Active = _random.Next(2) == 0,
                    Name = surveyName,
                    Description = "Description for " + surveyName,
                    NumberOfQuestions = 1 + _random.Next(3)
                };

                surveys.Add(survey);

                var questions = GetRandomString(questionList, survey.NumberOfQuestions);

                var questionInfo = ParseQuestion(questions[0]);

                survey.Question1 = questionInfo[0];
                survey.Answer1A = questionInfo[1];
                survey.Answer1B = questionInfo[2];
                survey.Answer1C = questionInfo[3];

                if (questions.Count > 1)
                {
                    questionInfo = ParseQuestion(questions[1]);

                    survey.Question2 = questionInfo[0];
                    survey.Answer2A = questionInfo[1];
                    survey.Answer2B = questionInfo[2];
                    survey.Answer2C = questionInfo[3];
                }

                if (questions.Count > 2)
                {
                    questionInfo = ParseQuestion(questions[2]);

                    survey.Question3 = questionInfo[0];
                    survey.Answer3A = questionInfo[1];
                    survey.Answer3B = questionInfo[2];
                    survey.Answer3C = questionInfo[3];
                }

                if (survey.Active)
                {
                    var numAswers = 2 + _random.Next(40);

                    var questionNames = GetRandomString(names, numAswers);

                    for (int i = 0; i < numAswers; i++)
                    {
                        var answer = new Answer()
                        {
                            Answer1 = 1 + _random.Next(3),
                            CompilationDate = new DateTime(2016, 01, 01).AddDays(_random.Next(120)),
                            UserName = questionNames[i]
                        };

                        if (survey.NumberOfQuestions > 1)
                            answer.Answer2 = 1 + _random.Next(3);

                        if (survey.NumberOfQuestions > 2)
                            answer.Answer3 = 1 + _random.Next(3);
                        

                        survey.Answers.Add(answer);
                    };
                }

            }

            return surveys;
        }

        private static string[] ParseQuestion(string questionData)
        {
            return questionData.Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries);
        }

        private static List<string> GetRandomString(string[] values, int num)
        {
            var allValues = values.ToList();
            var result = new List<string>();

            while (result.Count < num) {
                var idx = _random.Next(allValues.Count);
                var val = values[idx];
                allValues.RemoveAt(idx);
                result.Add(val);
            }

            return result;
        }







        static string _nameSegments = "salty early game blink highway garden poet fate fancy divine sunny actuality bright vision smart axe family airport";
        static string _questions = @"What is one thing that you can not live without?,mobile phone,hat,shoes
If you could have one super power what would it be?,x-rays,smell sweets,eat without getting fat
What was the last book you read?,I don't read,Divina Commedia,Romeo and Juliet
What is your favorite dish?,Spaghetti,Pizza,Hamburgher
If you could be any celebrity, who would it be?,Superman,Lady Oscar,Pollyanna
What was your worst restaurant experience?,Eating bugs in Corea,Chinese pizza,Donkey meat
Are you an indoor or outdoor person?,Indoor,Outdoor,I really don't know
What's better having high expectations or having low expectations?,High,Low,What is expectation?
What is the longest that you've gone without doing laundry?,1 week,1 month,What is 'laundry'?
If you could live anywhere on earth, where would you live?,Hawaii,Bermuda,Cortina
Are you a giver or taker?,Giver,Taker,It depends
Do you prefer to eat at home or eat out?,I eat as little as possible,At home,At restaurant
What do you carry in your purse/wallet?,Picture of my cat/dog,only coins,Picture of younger me";

        static string _names = @"Ernestine Watkins
Alan Terry
Israel Dunn
Victoria Kelley
Lee Boone
Leo Alvarado
Doreen Munoz
Omar Wise
Vincent Morrison
Seth Mullins
Ernestine Watkins
Alan Terry
Israel Dunn
Victoria Kelley
Lee Boone
Leo Alvarado
Doreen Munoz
Omar Wise
Vincent Morrison
Seth Mullins
Ernestine Watkins
Alan Terry
Israel Dunn
Victoria Kelley
Lee Boone
Leo Alvarado
Doreen Munoz
Omar Wise
Vincent Morrison
Seth Mullins
Jessica Caldwell
Gertrude Mathis
Eloise Maldonado
Sonya Russell
Juana Wallace
Loren Bowman
Julie Lawson
Edna Hayes
Ruth Baker
Geoffrey Douglas
Jessica Caldwell
Gertrude Mathis
Eloise Maldonado
Sonya Russell
Juana Wallace
Loren Bowman
Julie Lawson
Edna Hayes
Ruth Baker
Geoffrey Douglas
Jessica Caldwell
Gertrude Mathis
Eloise Maldonado
Sonya Russell
Juana Wallace
Loren Bowman
Julie Lawson
Edna Hayes
Ruth Baker
Geoffrey Douglas
Bernice	Colon
Duane	Berry
Jimmie	Lawson
Ray	Mason
Cody	Robbins
Arlene	Fields
Laurie	Jacobs
Gilbert	Cole
Katherine	Holland
Vickie	Bell";
    }
}
