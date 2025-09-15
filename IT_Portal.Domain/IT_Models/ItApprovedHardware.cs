namespace IT_Portal.Domain.IT_Models;

public partial class ItApprovedHardware
{
    public int Id { get; set; }

    public string? Plant { get; set; }

    public string? AssetType { get; set; }

    public string? MakeModelNo { get; set; }

    public string? ManufacturerOemname { get; set; }

    public string? Configuration { get; set; }

    public string? UsageDetails { get; set; }

    public string? ProcessOfHavingHardware { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsActive { get; set; }
}
