using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question.Model.Entities
{
    /// <summary>
    /// UserEntity - Entity or Dto to retrive the data to the UI Side
    /// </summary>
    public class UserEntity
    {
        /// <summary>
        /// Contructor to Init the objects
        /// </summary>
        public UserEntity()
        {
            Questions = new List<QuestionEntity>();
        }
        /// <summary>
        /// User Id
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// User Name
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Question List
        /// </summary>
        public List<QuestionEntity> Questions { get; set; }
    }
}
