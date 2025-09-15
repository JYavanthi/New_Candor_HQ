namespace IT_Portal.Domain.IT_Models;

public partial class MaterialPricingGroup
{
    public int Id { get; set; }

    public string? MatPriceGrp { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }
}
