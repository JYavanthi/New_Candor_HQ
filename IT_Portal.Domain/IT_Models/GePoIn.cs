namespace IT_Portal.Domain.IT_Models;

public partial class GePoIn
{
    public int Id { get; set; }

    public int FkgateNoId { get; set; }

    public bool? WithPo { get; set; }

    public string? PoNo { get; set; }

    public string? DcNo { get; set; }

    public DateOnly? DcDate { get; set; }

    public DateTime? Date { get; set; }

    public string? Fy { get; set; }

    public string? SupplierCode { get; set; }

    public string? SupplierName { get; set; }

    public string? SupplierPlace { get; set; }

    public string? SupplierCountry { get; set; }

    public string? VehicleNo { get; set; }

    public DateOnly? InDate { get; set; }

    public TimeOnly? InTime { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public string? PersonName { get; set; }

    public virtual LocationGateMaster FkgateNo { get; set; } = null!;

    public virtual ICollection<GePoMaterialIn> GePoMaterialIns { get; set; } = new List<GePoMaterialIn>();
}
