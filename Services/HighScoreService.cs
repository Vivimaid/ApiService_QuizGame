using FIA41_HoeffkenV_ApiService_QuizGame.DataAccessLayer;
using FIA41_HoeffkenV_ApiService_QuizGame.Models;

namespace FIA41_HoeffkenV_ApiService_QuizGame.Services
{
    public class HighScoreService
    {
        private QuizDataBaseContext context;

        public HighScoreService() {

            this.context = new QuizDataBaseContext();      
        }

        public List<Highscore> getHighscores() 
        {
            return context.Highscores.ToList();
        }

        
        public void SetHighscore(Highscore highscore)
        {
            try
            {
                context.Highscores.Add(highscore);
                context.SaveChanges();

            }
            catch (Exception e)
            {
                
                throw e;
            }

        }



    }
}
