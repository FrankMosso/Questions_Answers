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
    /// User Table - Code First
    /// </summary>
    public class User 
    {
        /// <summary>
        /// User Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        /// <summary>
        /// User Name
        /// </summary>
        public string UserName { get; set; }
    }
}
