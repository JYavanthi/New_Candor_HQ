namespace IT_Portal.Domain.IT_Models;

public partial class UnlockPasswordResetHistory
{
    public int Id { get; set; }

    public string? EmployeeId { get; set; }

    public string? ActivityType { get; set; }

    public string? Remarks { get; set; }

    public string? DoneBy { get; set; }

    public DateTime? DoneOn { get; set; }
}
