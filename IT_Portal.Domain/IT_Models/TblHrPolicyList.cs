namespace IT_Portal.Domain.IT_Models;

public partial class TblHrPolicyList
{
    public int Id { get; set; }

    public string? HrPolicyName { get; set; }

    public string? Createdby { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? Modifiedby { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
