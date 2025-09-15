namespace IT_Portal.Domain.IT_Models;

public partial class LeaveReason
{
    public int Id { get; set; }

    public string? LeavType { get; set; }

    public string? Reason { get; set; }

    public string? DetailedReason { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
