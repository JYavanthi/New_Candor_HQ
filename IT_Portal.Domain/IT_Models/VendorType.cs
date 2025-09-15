namespace IT_Portal.Domain.IT_Models;

public partial class VendorType
{
    public int Id { get; set; }

    public string? VCode { get; set; }

    public string? VDescription { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }
}
