using Question.Model;
using Question.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question.Business.Interface
{
    public interface IQuestionLogic
    {
        List<QuestionEntity> GetQuestionByTags(SearchCriterial searchCriterial);
    }
}
