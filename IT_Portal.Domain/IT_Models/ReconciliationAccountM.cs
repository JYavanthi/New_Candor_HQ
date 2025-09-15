namespace IT_Portal.Domain.IT_Models;

public partial class ReconciliationAccountM
{
    public int Id { get; set; }

    public string ReconciliationAccountId { get; set; } = null!;

    public string? ReconciliationAccountName { get; set; }

    public int? MasterTypeId { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }
}
