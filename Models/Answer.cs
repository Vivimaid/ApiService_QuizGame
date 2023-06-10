using System;
using System.Collections.Generic;

namespace FIA41_HoeffkenV_ApiService_QuizGame.Models;

public partial class Answer
{
    public long Id { get; set; }

    public string Text { get; set; } = null!;

    public long IsCorrect { get; set; }

    public long QuestionId { get; set; }

    public virtual Question Question { get; set; } = null!;
}
