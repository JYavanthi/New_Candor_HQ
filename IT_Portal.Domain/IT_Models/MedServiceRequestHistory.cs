namespace IT_Portal.Domain.IT_Models;

public partial class MedServiceRequestHistory
{
    public int Id { get; set; }

    public string? RequestNo { get; set; }

    public string? ProcessType { get; set; }

    public string? TransactionType { get; set; }

    public int? ApprovalPriority { get; set; }

    public string? Role { get; set; }

    public string? Comments { get; set; }

    public string? ApproverName { get; set; }

    public string? Department { get; set; }

    public string? Designation { get; set; }

    public string? RevertVersion { get; set; }

    public string? DoneBy { get; set; }

    public DateTime? DoneOn { get; set; }
}
