using DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using Question.Model;
using Question.Model.Entities;
using QuestionsCodeFirstApi.Utility;
using System.Transactions;

namespace QuestionsCodeFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly QuestionContext _context;
        public QuestionController(QuestionContext context)
        {
            _context = context;
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

            if (string.IsNullOrEmpty(question.Description))
                return BadRequest("The Question Description is required.");
            if (!question.Tags.Any())
                return BadRequest("The Question object needs at leats one Tag. Please check the parameter and try again.");

            using (TransactionScope scope = new TransactionScope())
            {
                _context.Questions.Add(Mapper.Map(question, new DB.Question()));
                _context.SaveChanges();
                var questionID = _context.Questions.OrderBy(p => p.QuestionID).Last().QuestionID;

                foreach (var tag in question.Tags)
                {
                    tag.QuestionID = questionID;
                    _context.QuestionTags.Add(Mapper.Map(tag, new DB.QuestionTag()));
                }
                _context.SaveChanges();
                scope.Complete();
            }
            return Ok(true);
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
            if (_context.Questions.Any(p => p.QuestionID == answer.QuestionID))
                if (!string.IsNullOrEmpty(answer.Description))
                    _context.Answers.Add(Mapper.Map(answer, new DB.Answer()));
                else
                    return BadRequest("The Answer could not be blank.");
            else
                return BadRequest("The question does not exist in the DB.");
            _context.SaveChanges();
            return Ok(true);
        }
        /// <summary>
        /// Endpoint to retrive questions data By Criteri
        /// Querying questions by tags.
        /// Retrieving question details along with answers.
        /// </summary>
        /// <param name="searchCriterial">Criteria</param>
        /// <returns>List<QuestionEntity></returns>
        [HttpPost]
        [Route("QuestionByTags")]
        public IActionResult GetQuestionByCriterial(SearchCriterial searchCriterial)
        {
            try
            {
                List<QuestionEntity> result = new List<QuestionEntity>();
                var resultdb = _context.Questions.Include(a => a.Answers).Include(t => t.Tags)
                        .ToList();

                if (searchCriterial.Tags != null)
                {
                    if (searchCriterial.Tags.Count > 0)
                    {
                        resultdb = resultdb
                            .Where(q =>
                            q.Tags.Any(t =>
                                searchCriterial.Tags.Any(p => p.Description?.ToUpper() == t.Description?.ToUpper()))).ToList();
                    }
                }

                result = resultdb.Select(o => new QuestionEntity()
                {
                    QuestionID = o.QuestionID,
                    Description = o.Description,
                    Answers = o.Answers.Select(a => Mapper.Map(a, new AnswerEntity())).ToList(),
                    Tags = o.Tags.Select(tag => Mapper.Map(tag, new TagEntity())).ToList(),
                }).ToList();

                return Ok(result);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

    }
}