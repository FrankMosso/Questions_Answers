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
    /// User's Answer Table - Code First
    /// </summary>
    public class UserAnswer
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserAnswerID { get; set; }
        /// <summary>
        /// User Id - Foreign Key
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// User Object
        /// </summary>
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
        /// <summary>
        /// Answer Id - Foreign Key
        /// </summary>
        public int AnswerID{ get; set; }
        /// <summary>
        /// Answer object 
        /// </summary>
        [ForeignKey("AnswerID")]
        public virtual Answer Answer { get; set; }
    }
}
