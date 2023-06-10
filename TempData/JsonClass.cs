namespace FIA41_HoeffkenV_ApiService_QuizGame.TempData
{
    public class JsonClass
    {
        public List<string> category { get; set; }
        public string type { get; set; }
        public string difficulty { get; set; }
        public string question { get; set; }
        public string correct_answer { get; set; }
        public List<string> incorrect_answers { get; set; }

    }
}
