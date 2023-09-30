using DB;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Question.Business.Interface;
using Question.Business;
using Question.Model.Entities;
using QuestionsCodeFirstApi.Utility;
using System.Transactions;

namespace QuestionsCodeFirstApi.Controllers
{
    /// <summary>
    /// Import Data Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ImportDataController: ControllerBase
    {
        private readonly QuestionContext _context;
        private readonly IDataMigrationLogic _serviceLogic;
        public ImportDataController(QuestionContext context)
        {
            _context = context;
            _serviceLogic = new DataMigrationLogic(context);
        }
        
        /// <summary>
        /// EndPoint to migrate the Data to DB
        /// You can either generate sample questions and answers programmatically or provide an approach to import them from file
        /// </summary>
        /// <param name="questions">Question List to Migrate</param>
        /// <returns>string</returns>
        [HttpPost]
        [Route("MigrateData")]
        public IActionResult MigrateQuestionsAnswers(List<QuestionEntity> questions)
        {
            var result = _serviceLogic.MigrateQuestionsAnswers(questions);
            return Ok(result);
        }
    }
}
