namespace IT_Portal.Domain.IT_Models;

public partial class TdVendorMaster
{
    public int Id { get; set; }

    public string? Sapid { get; set; }

    public string? VendorCode { get; set; }

    public string Name { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public bool? IsActive { get; set; }
}
