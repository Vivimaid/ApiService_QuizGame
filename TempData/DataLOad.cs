using FIA41_HoeffkenV_ApiService_QuizGame.DataAccessLayer;
using System.Text.Json;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using FIA41_HoeffkenV_ApiService_QuizGame.Models;

namespace FIA41_HoeffkenV_ApiService_QuizGame.TempData
{
    public class DataLOad
    {
    
        public DataLOad() {
            QuizDataBaseContext context = new QuizDataBaseContext();

            
            

        }
        

        public List<JsonClass> UseJArrayParseInNewtjdfsdfsd()
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
                List<Answer> answers = 
                jsonClasses.Add(jsonClass);
            }


            return jsonClasses;
        
        }
    


    }
    
}
