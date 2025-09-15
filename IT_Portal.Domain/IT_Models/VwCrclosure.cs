namespace IT_Portal.Domain.IT_Models;

public partial class VwCrclosure
{
    public int Itcrid { get; set; }

    public string? ClosedStatus { get; set; }

    public string? ClosureRemarks { get; set; }

    public int? ClosedBy { get; set; }

    public DateTime? ClosedDt { get; set; }

    public string? Feedback { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
