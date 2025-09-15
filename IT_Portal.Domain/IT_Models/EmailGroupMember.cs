namespace IT_Portal.Domain.IT_Models;

public partial class EmailGroupMember
{
    public int EmailGroupMemberId { get; set; }

    public int EmailGroupId { get; set; }

    public string? EmailGroupName { get; set; }

    public int? EmpNo { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? MidifiedDt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }
}
