using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class Prlesson
{
    public int PrlessonsId { get; set; }

    public int? ProjectId { get; set; }

    public int? TemplateId { get; set; }

    public int? TaskId { get; set; }

    public int? MilestoneId { get; set; }

    public string? Category { get; set; }

    public string? LessonsType { get; set; }

    public string? Description { get; set; }

    public string? Impact { get; set; }

    public string? Recommendation { get; set; }

    public string? ProjCloserAccept { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
