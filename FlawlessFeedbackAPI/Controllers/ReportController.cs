using FlawlessFeedbackAPI.Models;
using FlawlessFeedbackAPI.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlawlessFeedbackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
        #region Setup + CTOR

        private readonly FFDBContext _context;

        public ReportController(FFDBContext context)
        {
            _context = context;
        }

        #endregion

      
        #region ReportMethods
        /// <summary>
        /// Generates a view model of Surveys and the number of questions attached to the survey.
        /// </summary>
        /// <returns>SurveyQuestionViewModel of survey name and number of attached questions</returns>
        [HttpGet("NumberOfQuestionsPerSurvey")]
        public ActionResult GenerateSurveyReport() 
        {

            // Retrieve a list of all Surveys
            // Retrieve a list of all Questions

            // Create an empty list of SurveyQuestionViewModel
            List<SurveyQuestionViewModel> sqViewModelList = new List<SurveyQuestionViewModel>();

            //For Each Survey in the list of surveys,
            foreach (var survey in _context.Surveys.ToList())
            {
             
                // Define a count integer - set to 0
                int surveyCount = 0;

                // For each Question in list of Surveys
                foreach (var question in _context.Questions.ToList().Where(c => c.SurveyID == survey.SurveyID))
                {
                    // If the question.SurveyID == survey.SurveyID
                    // Add 1 to count
                    surveyCount++;
                    // end if
                }
                //end for

                // Create a new sqViewModel
                var sqViewModel = new SurveyQuestionViewModel
                {   // Add the count value to the view model
                    SurveyTitle = survey.SurveyTitle,
                    // Add the teacher name to the view model
                    NumberOfQuestions = surveyCount
                };


                // Add the viewmodel to the list of viewmodels
                sqViewModelList.Add(sqViewModel);

                // End for
            }

            // return list of viewmodels
            if (sqViewModelList.Count > 0)
            {
                return Ok(sqViewModelList);
            }
            else
            {
                return NotFound();
            }

        }

        #endregion
    }
}
