using DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using Question.Business;
using Question.Business.Interface;
using Question.Model;
using Question.Model.Entities;
using QuestionsCodeFirstApi.Utility;
using System.Transactions;

namespace QuestionsCodeFirstApi.Controllers
{
    /// <summary>
    /// Controller Question Logic
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly QuestionContext _context;
        private readonly IQuestionLogic _serviceLogic;
        public QuestionController(QuestionContext context)
        {
            _context = context;
            _serviceLogic = new QuestionLogic(context);
        }
        /// <summary>
        /// Endpoint to Add a new Question to DB
        /// Posting new questions with specified tags (tags are free text, not predefined list).
        /// </summary>
        /// <param name="question">Question Object</param>
        /// <returns>boolean</returns>
        [HttpPost]
        [Route("NewQuestion")]
        public IActionResult Add(QuestionEntity question)
        {
            var result = _serviceLogic.Add(question);
            return Ok(result);
        }
        /// <summary>
        /// Endpoint to add a new Answer to an existing Question
        /// Posting answers to existing questions.
        /// </summary>
        /// <param name="answer">Answer Object</param>
        /// <returns>boolean</returns>
        [HttpPost]
        [Route("AddAnswer")]
        public IActionResult AddAnswer(AnswerEntity answer)
        {
            var result = _serviceLogic.AddAnswer(answer);
            return Ok(result);
        }
        /// <summary>
        /// Endpoint to retrive questions data By Criterial
        /// Querying questions by tags.
        /// Retrieving question details along with answers.
        /// </summary>
        /// <param name="searchCriterial">Criteria</param>
        /// <returns>List<QuestionEntity></returns>
        [HttpPost]
        [Route("QuestionsByCriteria")]
        public IActionResult GetQuestionByCriterial(SearchCriterial searchCriterial)
        {
            var result = _serviceLogic.GetQuestionByCriterial(searchCriterial);
            return Ok(result);
        }

    }
}