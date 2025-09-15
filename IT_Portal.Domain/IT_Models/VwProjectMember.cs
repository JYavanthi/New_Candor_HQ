namespace IT_Portal.Domain.IT_Models;

public partial class VwProjectMember
{
    public int PrMemberId { get; set; }

    public int ProjectMgmtId { get; set; }

    public int EmpId { get; set; }

    public string? Role { get; set; }

    public string? Type { get; set; }

    public bool? Responsible { get; set; }

    public bool? Accountable { get; set; }

    public bool? Consulted { get; set; }

    public bool? Informed { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public string MemberName { get; set; } = null!;

    public string? Department { get; set; }

    public string? Designation { get; set; }
}
