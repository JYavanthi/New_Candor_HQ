namespace IT_Portal.Domain.IT_Models;

public partial class AuditLogContractor
{
    public int Id { get; set; }

    public string? AuditUser { get; set; }

    public DateTime? AuditDate { get; set; }

    public int? ContractId { get; set; }

    public string? OldValues { get; set; }

    public string? NewValues { get; set; }

    public string? Reason { get; set; }

    public virtual ContractEmployeeM? Contract { get; set; }
}
