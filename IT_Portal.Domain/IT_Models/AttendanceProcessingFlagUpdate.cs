namespace IT_Portal.Domain.IT_Models;

public partial class AttendanceProcessingFlagUpdate
{
    public int Id { get; set; }

    public string? Plant { get; set; }

    public bool? ProcessingFlag { get; set; }

    public DateTime? ProcessedOn { get; set; }

    public DateTime? ProcessedEndOn { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public string? ExceptionIfAny { get; set; }

    public DateTime? ExceptionOn { get; set; }
}
