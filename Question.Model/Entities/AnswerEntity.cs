using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question.Model.Entities
{
    /// <summary>
    /// AnswerEntity - Entity or Dto to retrive the data to the UI Side
    /// </summary>
    public class AnswerEntity : Base
    {
        /// <summary>
        /// Answer ID
        /// </summary>
        public int AnswerID { get; set; }
        /// <summary>
        /// Question ID
        /// </summary>
        public int QuestionID { get; set; }
      
    }
}
