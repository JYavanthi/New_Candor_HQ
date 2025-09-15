namespace IT_Portal.Domain.IT_Models;

public partial class FlexibleTimingsMaster
{
    public int Id { get; set; }

    public string Plant { get; set; } = null!;

    public string? Shift { get; set; }

    public TimeOnly ShiftStartTime { get; set; }

    public TimeOnly FlexiInPunch { get; set; }

    public string TotalWorkingHours { get; set; } = null!;

    public TimeOnly? ShiftEndTime { get; set; }

    public DateTime? EffectiveFrom { get; set; }

    public int IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }
}
