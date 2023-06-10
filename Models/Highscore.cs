using System;
using System.Collections.Generic;

namespace FIA41_HoeffkenV_ApiService_QuizGame.Models;

public partial class Highscore
{
    public long Id { get; set; }

    public string Player { get; set; } = null!;

    public long Score { get; set; }

    public string AquiredOn { get; set; } = null!;
}
