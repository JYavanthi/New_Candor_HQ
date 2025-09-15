namespace IT_Portal.Domain.IT_Models;

public partial class AssetTypeMaster
{
    public int Id { get; set; }

    public string? AssetType { get; set; }

    public double? PerquisiteRate { get; set; }

    public int? PerquisiteId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<AppointmentAssetDetail> AppointmentAssetDetails { get; set; } = new List<AppointmentAssetDetail>();
}
