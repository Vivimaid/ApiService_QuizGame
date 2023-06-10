using System;
using System.Collections.Generic;

namespace FIA41_HoeffkenV_ApiService_QuizGame.Models;

public partial class KpQuestionsCategoery
{
    public long Id { get; set; }

    public long QuestionId { get; set; }

    public long CategoriesId { get; set; }

    public virtual Category Categories { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;
}
