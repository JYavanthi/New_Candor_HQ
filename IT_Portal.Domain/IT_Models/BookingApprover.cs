namespace IT_Portal.Domain.IT_Models;

public partial class BookingApprover
{
    public int Id { get; set; }

    public string? PlantId { get; set; }

    public int? DeptId { get; set; }

    public string? ApprovalLevel { get; set; }

    public string? MainApprover { get; set; }

    public string? ParallelApprover1 { get; set; }

    public string? ParallelApprover2 { get; set; }

    public string? ParallelApprover3 { get; set; }

    public string? ParallelApprover4 { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsActive { get; set; }
}
