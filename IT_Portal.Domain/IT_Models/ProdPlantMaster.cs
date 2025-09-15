namespace IT_Portal.Domain.IT_Models;

public partial class ProdPlantMaster
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? ToMail { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? OutwardMail { get; set; }

    public string? VisitorMail { get; set; }

    public bool? IsActive { get; set; }

    public int? PlantType { get; set; }

    public int? Locid { get; set; }

    public string? LocHead { get; set; }

    public string? LocGroup { get; set; }
}
