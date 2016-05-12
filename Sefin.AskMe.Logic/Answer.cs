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
    public class Answer
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string SurveyId { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public DateTime CompilationDate { get; set; }

        [DataMember]
        public int? Answer1 { get; set; }

        [DataMember]
        public int? Answer2 { get; set; }

        [DataMember]
        public int? Answer3 { get; set; }

    }
}
