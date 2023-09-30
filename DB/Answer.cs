using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    /// <summary>
    /// Answer Table - Code First
    /// </summary>
    public class Answer
    {
        
        /// <summary>
        /// Answer ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerID { get; set; }
        
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Question ID - ForeignKey
        /// </summary>
        public int QuestionID { get; set; }
        
        /// <summary>
        /// Question Object
        /// </summary>
        [ForeignKey("QuestionID")]
        public virtual Question Question { get; set; }
    }
}
