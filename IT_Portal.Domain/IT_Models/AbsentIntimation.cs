namespace IT_Portal.Domain.IT_Models;

public partial class AbsentIntimation
{
    public int Id { get; set; }

    public string? EmpId { get; set; }

    public string? IntimationType { get; set; }

    public string? IntimationOver { get; set; }

    public string? Reason { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public string? Duration { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
}
