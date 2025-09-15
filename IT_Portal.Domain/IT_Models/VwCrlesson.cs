namespace IT_Portal.Domain.IT_Models;

public partial class VwCrlesson
{
    public int CrlessonId { get; set; }

    public int Itcrid { get; set; }

    public string Lessons { get; set; } = null!;

    public string Attachment { get; set; } = null!;

    public DateTime? LessonDt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
