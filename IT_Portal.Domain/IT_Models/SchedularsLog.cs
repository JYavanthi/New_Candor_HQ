namespace IT_Portal.Domain.IT_Models;

public partial class SchedularsLog
{
    public int Id { get; set; }

    public string? Module { get; set; }

    public DateTime? TriggeredOn { get; set; }

    public string? Plant { get; set; }

    public string? SchedularLocation { get; set; }

    public string? Shifts { get; set; }

    public int? Count { get; set; }
}
