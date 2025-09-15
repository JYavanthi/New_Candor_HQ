namespace IT_Portal.Domain.IT_Models;

public partial class PrintingLog
{
    public int Id { get; set; }

    public string? Process { get; set; }

    public string? PrintingReason { get; set; }

    public string? PrintedBy { get; set; }

    public DateTime? PrintedOn { get; set; }

    public string? RequestNo { get; set; }
}
