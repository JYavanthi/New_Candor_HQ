namespace IT_Portal.Domain.IT_Models;

public partial class VmsApprovalM
{
    public int Id { get; set; }

    public string? ApproverId { get; set; }

    public string? Plant { get; set; }

    public string? ApprovalType { get; set; }

    public int? Sequence { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Dept { get; set; }
}
