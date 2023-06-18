using FIA41_HoeffkenV_ApiService_QuizGame.DataAccessLayer;
using FIA41_HoeffkenV_ApiService_QuizGame.Models;
using Microsoft.EntityFrameworkCore;
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
            var quetionList = context.Questions.ToList();
            var randomQuestionList = quetionList.OrderBy(q => Guid.NewGuid());
            return randomQuestionList.Take(id).ToList();
        }

        public void SetQuestion(Question question)
        {
            
        }

        public List<Question> GetRandomQuestionsByCategories(List<int> ListofTheCategories)
        {
            List<KpQuestionsCategoery> allKPEntitysWithContainedIds = new List<KpQuestionsCategoery>();
            foreach(int Entry in ListofTheCategories)
            {

                var input1 = context.KpQuestionsCategoeries.Where(r => r.CategoriesId == Entry).ToList();

                allKPEntitysWithContainedIds.AddRange(input1);
            }

            List<Question> allFoundedQuestions = new List<Question>();
            var ListOfChosenCategories = allKPEntitysWithContainedIds.OrderBy(q => Guid.NewGuid()).Take(15).ToList();

            foreach(var entry2 in allKPEntitysWithContainedIds)
            {
                var Question = context.Questions
                .Single(q => q.Id == entry2.QuestionId);
                allFoundedQuestions.Add(Question);
            }
            
            //List<Question> allMatchingQuestion = context.Questions.Where(r => r.Id == ) 
            return allFoundedQuestions;
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

