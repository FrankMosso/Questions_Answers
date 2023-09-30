using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Question.Model.Entities;

namespace Question.Model
{
    /// <summary>
    /// Search Criterial - For now only Tag List Filter
    /// </summary>
    public class SearchCriterial
    {
        /// <summary>
        /// Tag List Filter
        /// </summary>
        public List<TagEntity> Tags { get; set; }
    }
}
