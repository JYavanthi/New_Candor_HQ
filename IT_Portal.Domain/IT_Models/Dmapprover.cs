namespace IT_Portal.Domain.IT_Models;

public partial class Dmapprover
{
    public int Id { get; set; }

    public string? KeyValue { get; set; }

    public string? ApproverId { get; set; }

    public int? SoftwareId { get; set; }

    public string? Department { get; set; }

    public int? PlantId { get; set; }

    public string? Role { get; set; }

    public string? ParallelApprover1 { get; set; }

    public string? ParallelApprover2 { get; set; }

    public string? ParallelApprover3 { get; set; }

    public string? ParallelApprover4 { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public bool? IsActive { get; set; }
}
