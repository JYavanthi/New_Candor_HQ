namespace IT_Portal.Domain.IT_Models;

public partial class ServiceCitrix
{
    public int ServiceCitrixId { get; set; }

    public string? ServiceCode { get; set; }

    public int RaisedBy { get; set; }

    public DateTime Srdate { get; set; }

    public string ShotDesc { get; set; } = null!;

    public string Srdesc { get; set; } = null!;

    public int? SrraiseFor { get; set; }

    public int? PlantId { get; set; }

    public int? AssetId { get; set; }

    public int? CategoryId { get; set; }

    public int? CategoryTypId { get; set; }

    public int? Priority { get; set; }

    public string? Source { get; set; }

    public string? Service { get; set; }

    public string? Attachment { get; set; }

    public string? Status { get; set; }

    public int? ApprovedLevel1 { get; set; }

    public int? ApprovedLevel1By { get; set; }

    public DateTime? ApprovedLevel1On { get; set; }

    public int? ApprovedLevel2 { get; set; }

    public int? ApprovedLevel2By { get; set; }

    public DateTime? ApprovedLevel2On { get; set; }

    public int? ApprovedLevel3 { get; set; }

    public int? ApprovedLevel3By { get; set; }

    public DateTime? ApprovedLevel3On { get; set; }

    public int? AssignedTo { get; set; }

    public int? AssignedBy { get; set; }

    public DateTime? AssignedOn { get; set; }

    public DateTime? ProposedResolutionOn { get; set; }

    public DateTime? ResolutionDt { get; set; }

    public string? ResolutionRemarks { get; set; }

    public string? Remarks { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
