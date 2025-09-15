namespace IT_Portal.Domain.IT_Models;

public partial class PlantHeadCompOt
{
    public int Id { get; set; }

    public string? Plant { get; set; }

    public string? Pernr { get; set; }

    public string? Head { get; set; }

    public int? PayGrp { get; set; }

    public string? EmailId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsActive { get; set; }
}
