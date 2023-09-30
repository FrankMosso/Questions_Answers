using DB;
using Microsoft.AspNetCore.Mvc;
using Question.Model.Entities;
using QuestionsCodeFirstApi.Utility;
using System.Transactions;

namespace QuestionsCodeFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly QuestionContext _context;
        public UserController(QuestionContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("NewUser")]
        public IActionResult Add(UserEntity user)
        {
            if (string.IsNullOrEmpty(user.UserName))
                return BadRequest("The User Name is required.");
            
            _context.Users.Add(Mapper.Map(user, new DB.User()));
            _context.SaveChanges();

            var newuser = _context.Users.OrderBy(u => u.UserID).Last();

            return Ok(newuser);
        }
    }
}
