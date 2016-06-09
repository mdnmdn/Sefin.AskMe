using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.AskMe.Logic
{
    [Serializable]
    [DataContract]
    public class SurveyInfo
    {
        public SurveyInfo()
        {
            NumberOfQuestions = 1;
            Answers = new List<Answer>();
        }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool Active { get; set; }

        [DataMember]
        public int NumberOfQuestions { get; set; }

        [DataMember]
        public string Question1 { get; set; }

        [DataMember]
        public string Answer1A { get; set; }

        [DataMember]
        public string Answer1B { get; set; }

        [DataMember]
        public string Answer1C { get; set; }

        [DataMember]
        public string Question2 { get; set; }

        [DataMember]
        public string Answer2A { get; set; }

        [DataMember]
        public string Answer2B { get; set; }

        [DataMember]
        public string Answer2C { get; set; }

        [DataMember]
        public string Question3 { get; set; }

        [DataMember]
        public string Answer3A { get; set; }

        [DataMember]
        public string Answer3B { get; set; }

        [DataMember]
        public string Answer3C { get; set; }

        [DataMember]
        public List<Answer> Answers { get; set; }


        public override string ToString()
        {
            return this.Id + " - " + this.Name;
        }
    }
}
