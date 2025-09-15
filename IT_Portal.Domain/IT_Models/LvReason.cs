namespace IT_Portal.Domain.IT_Models;

public partial class LvReason
{
    public int LeavId { get; set; }

    public string? LeavType { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
