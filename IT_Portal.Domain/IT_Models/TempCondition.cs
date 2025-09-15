namespace IT_Portal.Domain.IT_Models;

public partial class TempCondition
{
    public int TempConId { get; set; }

    public string? TempConDesc { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public bool? IsActive { get; set; }
}
