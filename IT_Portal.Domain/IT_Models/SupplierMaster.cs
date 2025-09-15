namespace IT_Portal.Domain.IT_Models;

public partial class SupplierMaster
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Place { get; set; } = null!;

    public string Country { get; set; } = null!;

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string PlaceCode { get; set; } = null!;

    public bool? IsActive { get; set; }
}
