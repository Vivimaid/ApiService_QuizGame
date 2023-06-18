using FIA41_HoeffkenV_ApiService_QuizGame.DataAccessLayer;
using FIA41_HoeffkenV_ApiService_QuizGame.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FIA41_HoeffkenV_ApiService_QuizGame.Models;
using FIA41_HoeffkenV_ApiService_QuizGame.TempData;

namespace FIA41_HoeffkenV_ApiService_QuizGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighScoreController : ControllerBase
    {
        #region Constructor -> HighscoreController -> HighscoreService
        private HighScoreService highScoreService;

        public HighScoreController()
        {
            this.highScoreService = new HighScoreService();
        }

        #endregion

        [HttpGet]
        public JsonResult GetHighScores() 
        {
            
            
            return new JsonResult(highScoreService.getHighscores());   
        }


        [HttpPost]
        public void SetHighScore([FromBody] Highscore highscore) 
        {
            highScoreService.SetHighscore(highscore);
            
        }

    }

    
}
