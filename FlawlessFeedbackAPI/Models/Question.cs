using System.Collections.Generic;

namespace FlawlessFeedbackAPI.Models
{
    public class Question
    {
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public int SurveyID { get; set; }

        //Navigation Variables
        public virtual ICollection<Option> Options { get; set; }
    }
}