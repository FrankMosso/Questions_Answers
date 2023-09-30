using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question.Model.Entities
{
    /// <summary>
    /// TagEntity - Entity or Dto to retrive the data to the UI Side
    /// </summary>
    public class TagEntity : Base
    {
        /// <summary>
        /// Tag Id
        /// </summary>
        public int QuestionTagID { get; set; }
        /// <summary>
        /// Question Id
        /// </summary>
        public int QuestionID { get; set; }
    }
}
