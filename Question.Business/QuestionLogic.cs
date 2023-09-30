using DB;
using Question.Business.Interface;
using Question.Model;
using Question.Model.Entities;

namespace Question.Business
{
    public class QuestionLogic : IQuestionLogic
    {
        public List<QuestionEntity> GetQuestionByTags(SearchCriterial searchCriterial)
        {
			try
			{
				using (var context = new QuestionContext()) 
				{
					var result = context.QuestionTags.ToList();
					return new List<QuestionEntity>();
                }
			}
			catch (Exception Ex)
			{
				throw Ex;
			}
        }
    }
}