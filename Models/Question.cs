using System;
using System.Collections.Generic;

namespace FIA41_HoeffkenV_ApiService_QuizGame.Models;

public partial class Question
{
    public long Id { get; set; }

    public string Text { get; set; } = null!;

    public long Shown { get; set; }

    public long WasCorrect { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual ICollection<KpQuestionsCategoery> KpQuestionsCategoeries { get; set; } = new List<KpQuestionsCategoery>();
}
