using DB;
using Microsoft.AspNetCore.Mvc;
using Question.Business;
using Question.Business.Interface;
using Question.Model.Entities;
using QuestionsCodeFirstApi.Utility;
using System.Transactions;

namespace QuestionsCodeFirstApi.Controllers
{
    /// <summary>
    /// User Controller - Logic
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly QuestionContext _context;
        private readonly IUserLogic _serviceLogic;
        public UserController(QuestionContext context)
        {
            _context = context;
            _serviceLogic = new UserLogic(context);
        }
        /// <summary>
        /// Endpoint to add New User
        /// </summary>
        /// <param name="user">User object</param>
        /// <returns>UserEntity</returns>
        [HttpPost]
        [Route("NewUser")]
        public IActionResult Add(UserEntity user)
        {
            var result = _serviceLogic.Add(user);
            return Ok(result);
        }
    }
}
