namespace IT_Portal.Domain.IT_Models;

public partial class PurchaseGroup
{
    public int Id { get; set; }

    public string? PurchaseGroupId { get; set; }

    public string? PurchaseGroupDesc { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public bool? IsActive { get; set; }
}
