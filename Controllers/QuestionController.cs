using FIA41_HoeffkenV_ApiService_QuizGame.Models;
using FIA41_HoeffkenV_ApiService_QuizGame.Services;
using FIA41_HoeffkenV_ApiService_QuizGame.TempData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FIA41_HoeffkenV_ApiService_QuizGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private QuestionService questionService;
        
        public QuestionController()
        {
            this.questionService = new QuestionService();
        }
       
        [HttpGet("{id}")]
        public List<Question> GetRandomQuestion(int id)
        {
            
            return new List<Question>();
        }



        [HttpPost]
        public void Post([FromBody] Question question) {
        
            questionService.SetQuestion(question);
        }





    }
}
