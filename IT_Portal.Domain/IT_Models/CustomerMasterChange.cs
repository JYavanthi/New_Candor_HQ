namespace IT_Portal.Domain.IT_Models;

public partial class CustomerMasterChange
{
    public int Id { get; set; }

    public string? Address { get; set; }

    public string? Attachments { get; set; }

    public string? CustomerCode { get; set; }

    public string? CustomerName { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public DateTime? FromDate { get; set; }

    public string? GstinNumber { get; set; }

    public string? ModifiedBy { get; set; }

    public string? Plant { get; set; }

    public string? PendingApprover { get; set; }

    public string? Reason { get; set; }

    public string? RequestedBy { get; set; }

    public DateTime? RequestedDate { get; set; }

    public string? State { get; set; }

    public string? Status { get; set; }

    public DateTime? ToDate { get; set; }

    public string? CustomerType { get; set; }
}
