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

namespace Question.Business
{
    public class UserLogic : IUserLogic
    {
        private readonly QuestionContext _context;
        public UserLogic(QuestionContext context)
        {
            _context = context;
        }
        public ResponseEntity<UserEntity> Add(UserEntity user)
        {
			try
			{
                if (string.IsNullOrEmpty(user.UserName))
                    throw new Exception("The User Name is required.");

                _context.Users.Add(Mapper.Map(user, new DB.User()));
                _context.SaveChanges();

                var newuser = _context.Users.OrderBy(u => u.UserID).Last();
                user.UserID = newuser.UserID;

                return new ResponseEntity<UserEntity>(user, false);
            }
			catch (Exception Ex)
			{

                return new ResponseEntity<UserEntity>(null, true, Ex.StackTrace, Ex.Message);
            }
        }
    }
}
