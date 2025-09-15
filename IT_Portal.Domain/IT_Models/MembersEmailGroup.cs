namespace IT_Portal.Domain.IT_Models;

public partial class MembersEmailGroup
{
    public int? Id { get; set; }

    public string? EmailGroupId { get; set; }

    public int? EmpNo { get; set; }

    public string? ModifiedBy { get; set; }

    public string? MidifiedDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateOnly? CreatedDate { get; set; }
}
