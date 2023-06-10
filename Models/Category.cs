using System;
using System.Collections.Generic;

namespace FIA41_HoeffkenV_ApiService_QuizGame.Models;

public partial class Category
{
    public long Id { get; set; }

    public string Text { get; set; } = null!;

    public virtual ICollection<KpQuestionsCategoery> KpQuestionsCategoeries { get; set; } = new List<KpQuestionsCategoery>();
}
