namespace IT_Portal.Domain.IT_Models;

public partial class VendorMasterChange
{
    public int Id { get; set; }

    public string? RequestedBy { get; set; }

    public DateTime? RequestedDate { get; set; }

    public string? VendorCode { get; set; }

    public string? VendorName { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? Reason { get; set; }

    public string? Attachments { get; set; }

    public string? PendingApprover { get; set; }

    public string? LastApprover { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public string? Plant { get; set; }

    public string? Status { get; set; }
}
