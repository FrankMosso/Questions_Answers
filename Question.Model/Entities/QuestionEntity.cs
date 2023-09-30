using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question.Model.Entities
{
    /// <summary>
    /// QuestionEntity - Entity or Dto to retrive the data to the UI Side
    /// </summary>
    public class QuestionEntity : Base
    {
        /// <summary>
        /// Constructor to Ini the Objects
        /// </summary>
        public QuestionEntity()
        {
            Answers = new List<AnswerEntity>();
            Tags = new List<TagEntity>();
        }
        /// <summary>
        /// Question Id 
        /// </summary>
        public int QuestionID { get; set; }
        /// <summary>
        /// Answer List
        /// </summary>
        public List<AnswerEntity> Answers { get; set; }
        /// <summary>
        /// Tag List
        /// </summary>
        public List<TagEntity> Tags { get; set; }
    }
}
