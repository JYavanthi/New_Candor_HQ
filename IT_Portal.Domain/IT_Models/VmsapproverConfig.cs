namespace IT_Portal.Domain.IT_Models;

public partial class VmsapproverConfig
{
    public int Id { get; set; }

    public string? Plant { get; set; }

    public string? Department { get; set; }

    public string? ApprovalType { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }
}
