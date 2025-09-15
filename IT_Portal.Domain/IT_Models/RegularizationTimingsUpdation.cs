namespace IT_Portal.Domain.IT_Models;

public partial class RegularizationTimingsUpdation
{
    public int Id { get; set; }

    public string? RequestNo { get; set; }

    public string? EmployeeNo { get; set; }

    public DateOnly? Date { get; set; }

    public string? PreviousTime { get; set; }

    public string? UpdatedTime { get; set; }

    public string? Reason { get; set; }

    public string? DoneBy { get; set; }

    public DateTime? DoneOn { get; set; }
}
