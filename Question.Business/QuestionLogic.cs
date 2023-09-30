using DB;
using Microsoft.EntityFrameworkCore;
using Question.Business.Interface;
using Question.Business.Utility;
using Question.Model;
using Question.Model.Entities;
using System.Transactions;

namespace Question.Business
{
    public class QuestionLogic : IQuestionLogic
    {
        private readonly QuestionContext _context;
        public QuestionLogic(QuestionContext context)
        {
            _context = context;
        }

        public ResponseEntity<bool> Add(QuestionEntity question)
        {
            try
            {
                if (string.IsNullOrEmpty(question.Description))
                    throw new Exception("The Question Description is required.");
                if (!question.Tags.Any())
                    throw new Exception("The Question object needs at leats one Tag. Please check the parameter and try again.");

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
                return new ResponseEntity<bool>(true, false);
            }
            catch (Exception Ex)
            {
                return new ResponseEntity<bool>(false, true, Ex.StackTrace, Ex.Message);
            }
        }

        public ResponseEntity<bool> AddAnswer(AnswerEntity answer)
        {
            
            try
            {
                if (_context.Questions.Any(p => p.QuestionID == answer.QuestionID))
                    if (!string.IsNullOrEmpty(answer.Description))
                        _context.Answers.Add(Mapper.Map(answer, new DB.Answer()));
                    else
                        throw new Exception("The Answer could not be blank.");
                else
                    throw new Exception("The question does not exist in the DB.");
                _context.SaveChanges();
                return new ResponseEntity<bool>(true, false); ;
            }
            catch (Exception Ex)
            {
                return new ResponseEntity<bool>(false, true, Ex.StackTrace, Ex.Message);
            }
        }

        public ResponseEntity<List<QuestionEntity>> GetQuestionByCriterial(SearchCriterial searchCriterial)
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
                return new ResponseEntity<List<QuestionEntity>>(result, false);
            }
            catch (Exception Ex)
            {
                return new ResponseEntity<List<QuestionEntity>>(null, true, Ex.StackTrace, Ex.Message);
            }
        }
    }
}