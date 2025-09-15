namespace IT_Portal.Domain.IT_Models;

public partial class ItvendorPersonContactDetail
{
    public int Id { get; set; }

    public int VendorId { get; set; }

    public string? ContactPersonName { get; set; }

    public string? MobileNo { get; set; }

    public string? EmailId { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ItapprovedVendor Vendor { get; set; } = null!;
}
