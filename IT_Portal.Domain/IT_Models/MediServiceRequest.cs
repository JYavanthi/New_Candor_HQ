namespace IT_Portal.Domain.IT_Models;

public partial class MediServiceRequest
{
    public int Id { get; set; }

    public int? RequestNo { get; set; }

    public DateTime? RequestDate { get; set; }

    public string? Location { get; set; }

    public string? Division { get; set; }

    public string? Category { get; set; }

    public string? Brand { get; set; }

    public string? Product { get; set; }

    public string? Details { get; set; }

    public string? Attachements { get; set; }

    public DateTime? SubmitedDate { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public string? FinalDocNo { get; set; }

    public DateTime? FinalDocDate { get; set; }

    public string? FinalSerialNo { get; set; }

    public string? ApprvrStatus { get; set; }

    public string? ApproveType { get; set; }

    public string? Stage { get; set; }

    public DateTime? ApproveDate { get; set; }

    public string? LastApprover { get; set; }

    public string? PendingApprover { get; set; }

    public string? RejectedFlag { get; set; }

    public int? RevertVersion { get; set; }

    public int? ReviewerAssignFlag { get; set; }

    public string? InputType { get; set; }

    public int? RepeatFlag { get; set; }
}
