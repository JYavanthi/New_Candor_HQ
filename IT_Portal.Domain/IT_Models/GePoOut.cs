namespace IT_Portal.Domain.IT_Models;

public partial class GePoOut
{
    public int Id { get; set; }

    public int FkgateNoId { get; set; }

    public bool WithPo { get; set; }

    public string? PoNo { get; set; }

    public string? Department { get; set; }

    public string? MaterialType { get; set; }

    public string? DcNo { get; set; }

    public DateOnly? DcDate { get; set; }

    public DateTime? Date { get; set; }

    public string? Fy { get; set; }

    public string? SendingPerson { get; set; }

    public string? Destination { get; set; }

    public TimeOnly? ExptOutTime { get; set; }

    public DateOnly? OutDate { get; set; }

    public TimeOnly? OutTime { get; set; }

    public string? PersonName { get; set; }

    public string? VehicleNo { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual LocationGateMaster FkgateNo { get; set; } = null!;

    public virtual ICollection<GePoMaterialOut> GePoMaterialOuts { get; set; } = new List<GePoMaterialOut>();
}
