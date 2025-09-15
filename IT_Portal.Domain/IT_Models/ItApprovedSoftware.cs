namespace IT_Portal.Domain.IT_Models;

public partial class ItApprovedSoftware
{
    public int Id { get; set; }

    public string? Plant { get; set; }

    public string? SoftwareCategory { get; set; }

    public string? DescriptionOfSoftware { get; set; }

    public string Version { get; set; } = null!;

    public string? Provider { get; set; }

    public string? LicenseType { get; set; }

    public string? LicenseMode { get; set; }

    public string? PatchLevel { get; set; }

    public string? UsageDetails { get; set; }

    public string? ProcessOfHavingSoftware { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsActive { get; set; }
}
