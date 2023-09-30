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
        ResponseEntity<List<QuestionEntity>> GetQuestionByCriterial(SearchCriterial searchCriterial);
        ResponseEntity<bool> Add(QuestionEntity question);
        ResponseEntity<bool> AddAnswer(AnswerEntity answer);

    }
}
