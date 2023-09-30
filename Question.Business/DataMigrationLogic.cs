using DB;
using Microsoft.EntityFrameworkCore;
using Question.Business.Interface;
using Question.Business.Utility;
using Question.Model;
using Question.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Question.Business
{
    public class DataMigrationLogic : IDataMigrationLogic
    {
        private readonly QuestionContext _context;
        public DataMigrationLogic(QuestionContext context)
        {
            _context = context;
        }

        public ResponseEntity<string> MigrateQuestionsAnswers(List<QuestionEntity> questions)
        {
			try
			{
                //Lines to generate the Json string to migrate
                //Develop bulk import logic to facilitate the addition of questions and answers.

                //List<TagEntity> Tags = new List<TagEntity>()
                //{
                //    new TagEntity(){ Description = "Personal" },
                //    new TagEntity(){ Description = "Business" },
                //    new TagEntity(){ Description = "Travel" },
                //    new TagEntity(){ Description = "Healt" },
                //    new TagEntity(){ Description = "Contact" },
                //    new TagEntity(){ Description = "Education" },
                //    new TagEntity(){ Description = "Home" },
                //    new TagEntity(){ Description = "Hobbies" } };

                //for (int i = 1; i <= 300; i++)
                //{
                //    var temp = new QuestionEntity()
                //    {
                //        Description = string.Format("Question {0}", i),
                //    };

                //    Random rnd = new Random();
                //    int answercount = rnd.Next(1, 6);

                //    for (int j = 1; j < answercount; j++)
                //    {
                //        temp.Answers.Add(new AnswerEntity()
                //        {
                //            Description = string.Format("Answer {0}", j)
                //        });
                //    }

                //    int tagcount = rnd.Next(1, 8);

                //    temp.Tags = Tags.OrderBy(x => rnd.Next()).Take(tagcount).ToList();

                //    questions.Add(temp);
                //}


                //var json = JsonConvert.SerializeObject(questions);

                int _index = 0;
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (var question in questions)
                    {
                        if (string.IsNullOrEmpty(question.Description))
                            throw new Exception("The Question is required.");

                        _context.Questions.Add(Mapper.Map(question, new DB.Question()));
                        _context.SaveChanges();
                        _index = _context.Questions.OrderBy(p => p.QuestionID).Last().QuestionID;

                        foreach (var tag in question.Tags)
                        {
                            tag.QuestionID = _index;
                            _context.QuestionTags.Add(Mapper.Map(tag, new DB.QuestionTag()));
                        }

                        foreach (var answer in question.Answers)
                        {
                            answer.QuestionID = _index;
                            _context.Answers.Add(Mapper.Map(answer, new DB.Answer()));
                        }

                        _context.SaveChanges();
                    }
                    scope.Complete();
                }
                return new ResponseEntity<string>("Migration Success!", false);
            }
			catch (Exception Ex)
			{
                return new ResponseEntity<string>("Something went wrong.", true, Ex.StackTrace, Ex.Message);
            }
        }
    }
}
