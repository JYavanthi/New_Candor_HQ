namespace IT_Portal.Domain.IT_Models;

public partial class AccountGroupM
{
    public int AccountGroupId { get; set; }

    public string AccountGroupName { get; set; } = null!;

    public string? MaterialTypeId { get; set; }

    public bool IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }
}
