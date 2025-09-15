namespace IT_Portal.Domain.IT_Models;

public partial class AuditLog
{
    public Guid Id { get; set; }

    public DateTime AuditDateTime { get; set; }

    public string AuditType { get; set; } = null!;

    public string AduitUser { get; set; } = null!;

    public string? MasterName { get; set; }

    public int? TableId { get; set; }

    public string? KeyValue { get; set; }

    public string? Changes { get; set; }

    public string? OldValues { get; set; }

    public string? NewValues { get; set; }

    public string? Purpose { get; set; }
}
