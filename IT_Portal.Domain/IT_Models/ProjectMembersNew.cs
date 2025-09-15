namespace IT_Portal.Domain.IT_Models;

public partial class ProjectMembersNew
{
    public int PrMemberId { get; set; }

    public int ProjectMgmtId { get; set; }

    public int EmpId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
