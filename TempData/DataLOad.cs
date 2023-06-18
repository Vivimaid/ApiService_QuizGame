using FIA41_HoeffkenV_ApiService_QuizGame.DataAccessLayer;
using System.Text.Json;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using FIA41_HoeffkenV_ApiService_QuizGame.Models;
using System.Runtime.InteropServices;

namespace FIA41_HoeffkenV_ApiService_QuizGame.TempData
{
    public class DataLOad
    {
        private QuizDataBaseContext context;
        public DataLOad() {
            this.context = new QuizDataBaseContext();

            
            

        }
        

        public List<JsonClass> DataInputIntoDataBase()
        {
            using StreamReader reader = new("D:\\Projekte\\FIA41_HoeffkenV_ApiService_QuizGame\\TempData\\output.json");
            var json = reader.ReadToEnd();
            var jarray = JArray.Parse(json);
            List<JsonClass> jsonClasses = new();

            foreach (var item in jarray)
            {
                JsonClass jsonClass = item.ToObject<JsonClass>();


                List<string> incorrectanswer = jsonClass.incorrect_answers.ToList();
                List<string> categories = jsonClass.category.ToList();
                //List<Answer> answers = 
                jsonClasses.Add(jsonClass);
            }
            foreach (var item in jsonClasses) 
            {
                Question q = new Question();
                q.Text = item.question.ToString();
                q.Shown = 0l;
                q.WasCorrect = 0l;

                context.Questions.Add(q);
                context.SaveChanges();

                long QuestionId = long.Parse(q.Id.ToString());
                
                List<Answer> allAnsers = new List<Answer>();
                allAnsers.Add(createAnswer(QuestionId,1,item.correct_answer));
                foreach (var wrongawnser in item.incorrect_answers)
                {
                    allAnsers.Add(createAnswer(QuestionId,0,wrongawnser));
                }
                
                context.AddRange(allAnsers);
                context.SaveChanges();

                foreach(var Categories in item.category)
                {
                    Category c = new Category();
                    long CategoriesId = new long();
                    CategoriesId = createOrGetCateGoriesId(Categories);
                    




                    KpQuestionsCategoery kp = new KpQuestionsCategoery();
                    kp.QuestionId = QuestionId;
                    kp.CategoriesId = CategoriesId;

                    context.KpQuestionsCategoeries.Add(kp);
                    context.SaveChanges();

                    


                }
                
                


                

                
                






                


            }

            return jsonClasses;
        
        }

        public long createOrGetCateGoriesId(string CategorieText)
        {

            long result;

            try
            {
                 result = context.Categories.First(c => c.Text == CategorieText).Id;
            }
            catch (Exception e)
            {
                Category c = new Category();
                c.Text = CategorieText;

                context.Categories.Add(c);
                context.SaveChanges();

                result = c.Id;
                
            }


            return result;
            
            
        }   

        public Answer createAnswer(long QId,int IsCorrect, string Text)
        {
            Answer a = new Answer();
            a.QuestionId = QId;
            a.Text = Text;
            a.IsCorrect = IsCorrect;
            return a;
        }
        public long GetId(Question q) 
        {
            context.Questions.Add(q);
            context.SaveChanges();
            Question qreturn = context.Questions.Find(q);
            long qid = long.Parse(qreturn.Id.ToString());

            return qid;
        }
    


    }
    
}
