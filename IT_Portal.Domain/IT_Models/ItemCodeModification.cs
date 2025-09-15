namespace IT_Portal.Domain.IT_Models;

public partial class ItemCodeModification
{
    public int Id { get; set; }

    public string? RequestNo { get; set; }

    public DateTime? RequestDate { get; set; }

    public string? RequestedBy { get; set; }

    public string? ItemCode { get; set; }

    public string? Subject { get; set; }

    public string? Description { get; set; }

    public string? LastApprover { get; set; }

    public string? PendingApprover { get; set; }

    public string? Status { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? Attachments { get; set; }
}
