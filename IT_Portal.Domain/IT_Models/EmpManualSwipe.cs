namespace IT_Portal.Domain.IT_Models;

public partial class EmpManualSwipe
{
    public int Id { get; set; }

    public int? PayGrp { get; set; }

    public string? Pernr { get; set; }

    public DateOnly? StartDate { get; set; }

    public string? InOut { get; set; }

    public TimeOnly? Start { get; set; }

    public string? LostEntryReasonType { get; set; }

    public string? SwipeStatus { get; set; }

    public string? Remarks { get; set; }

    public string? ShiftCode { get; set; }

    public DateOnly? Date { get; set; }

    public TimeOnly? Time { get; set; }

    public string? Username { get; set; }

    public DateOnly? ChangedOn { get; set; }

    public string? ChangedBy { get; set; }

    public int? LateFlag { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? StatusFlag { get; set; }

    public TimeOnly? PrevTime { get; set; }

    public string? IpAddr { get; set; }
}
