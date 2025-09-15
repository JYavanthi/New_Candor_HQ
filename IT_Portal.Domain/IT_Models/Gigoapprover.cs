namespace IT_Portal.Domain.IT_Models;

public partial class Gigoapprover
{
    public int Id { get; set; }

    public string? KeyValue { get; set; }

    public bool? IsActive { get; set; }

    public string? Plant { get; set; }

    public string? Department { get; set; }

    public string? MaterialType { get; set; }

    public string? Gotype { get; set; }

    public int? Stage { get; set; }

    public string? Role { get; set; }

    public string? MainApprover { get; set; }

    public string? ParallelApprover1 { get; set; }

    public bool? Pa1emailEnabled { get; set; }

    public string? ParallelApprover2 { get; set; }

    public bool? Pa2emailEnabled { get; set; }

    public string? ParallelApprover3 { get; set; }

    public bool? Pa3emailEnabled { get; set; }

    public string? ParallelApprover4 { get; set; }

    public bool? Pa4emailEnabled { get; set; }

    public string? ParallelApprover5 { get; set; }

    public bool? Pa5emailEnabled { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }
}
