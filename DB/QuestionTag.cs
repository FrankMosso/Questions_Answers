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
    /// Tag Table - Code Fisrt
    /// </summary>
    public class QuestionTag
    {
        /// <summary>
        /// Tag Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionTagID { get; set; }
        /// <summary>
        /// Tag Description
        /// </summary>
        [Required]
        public string Description { get; set; }
        /// <summary>
        /// Question Id - Foreign Key 
        /// </summary>
        public int QuestionID { get; set; }
        /// <summary>
        /// Question Object
        /// </summary>
        [ForeignKey("QuestionID")]
        public virtual Question Question { get; set; }
    }
}
