using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    /// <summary>
    /// Question Table - Code First
    /// </summary>
    public class Question
    {
        /// <summary>
        /// Question Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionID { get; set; }
        
        /// <summary>
        /// Question Description
        /// </summary>
        [Required]
        public string Description { get; set; }
        
        /// <summary>
        /// Answer List
        /// </summary>
        public virtual ICollection<Answer> Answers { get;}
        
        /// <summary>
        /// Tags List
        /// </summary>
        public virtual ICollection<QuestionTag> Tags { get; }


    }
}
