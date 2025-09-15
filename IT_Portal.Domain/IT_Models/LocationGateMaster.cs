namespace IT_Portal.Domain.IT_Models;

public partial class LocationGateMaster
{
    public int Id { get; set; }

    public string GateNo { get; set; } = null!;

    public int FklocationId { get; set; }

    public string? Description { get; set; }

    public string? Temp1 { get; set; }

    public string? Temp2 { get; set; }

    public string? Temp3 { get; set; }

    public string? Temp4 { get; set; }

    public string? Temp5 { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual PlantMaster Fklocation { get; set; } = null!;

    public virtual ICollection<GePoIn> GePoIns { get; set; } = new List<GePoIn>();

    public virtual ICollection<GePoOut> GePoOuts { get; set; } = new List<GePoOut>();

    public virtual ICollection<GeStoIn> GeStoIns { get; set; } = new List<GeStoIn>();
}
