using FIA41_HoeffkenV_ApiService_QuizGame.DataAccessLayer;
using FIA41_HoeffkenV_ApiService_QuizGame.Models;
using Newtonsoft.Json.Linq;

namespace FIA41_HoeffkenV_ApiService_QuizGame.Services
{
    public class QuestionService
    {
        private QuizDataBaseContext context;

        public QuestionService()
        {
            this.context = new QuizDataBaseContext();
        }

        public List<Question> GetRandomQuestions(int id)
        {
            return context.Questions.OrderBy(r => Guid.NewGuid()).Take(id).ToList();
        }

        public void SetQuestion(Question question)
        {
            
        }

        public List<Question> GetRandomQuestionsByCategories(List<int> CategorieIds)
        {
            List<KpQuestionsCategoery> allKPEntitysWithContainedIds = new List<KpQuestionsCategoery>();
            foreach(int Entry in CategorieIds)
            {

                var input1 = context.KpQuestionsCategoeries.Where(r => r.CategoriesId == Entry).OrderBy(r => Guid.NewGuid()).Take(15).ToList();

                allKPEntitysWithContainedIds.AddRange(input1);




            }
            

            List<Question> allMatchingQuestion = context.Questions.Where(r => r.Id == ) 
        
        }



        //public List<Question> GetQuestionsBasedOnCategorie(List<int> categorieIds)
        //{
          //  var result =
            //    from question in context.Questions
              //  join kp in context.KpQuestionsCategoeries
                //on question.Id equals kp.QuestionId into joined
                //from j in joined.Where(j => categorieIds.Contains(j.CategoriesId))
               // select new Question()
                //{
                  //  Answers = question.Answers,
                    //Text = question.Text,
                    //Shown = question.Shown,
                    //WasCorrect = question.WasCorrect
                //};
            //return result.ToList();


            //return context.Questions.Where(q =>q.KpQuestionsCategoeries.Contains(kp => categorieIds.Contains(kp.CategoriesId)).Any()).ToList();  



        }
    }

