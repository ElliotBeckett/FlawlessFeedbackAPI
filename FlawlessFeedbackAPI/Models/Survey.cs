using System;
using System.Collections.Generic;

namespace FlawlessFeedbackAPI.Models
{
    public class Survey
    {
        public int SurveyID { get; set; }
        public string SurveyTitle { get; set; }
        public string SurveyTopic { get; set; }
        public string SurveyAuthor { get; set; }
        public DateTime SurveyDateCreated { get; set; }

        public string SurveyComments { get; set; }


        public string SurveyImageURL { get; set; }

        //Navigation Properties

        public virtual ICollection<Question> Questions { get; set; }
    }
}