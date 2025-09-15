namespace IT_Portal.Domain.IT_Models;

public partial class Sraccess
{
    public int? Srid { get; set; }

    public int? SupportId { get; set; }

    public string? RequestType { get; set; }

    public int SraccessId { get; set; }

    public string? SoftName { get; set; }

    public string? SoftVersion { get; set; }

    public string? ReferDocument { get; set; }

    public DateTime? DoremovalAccess { get; set; }

    public bool? Swremoved { get; set; }

    public bool? ServerAccess { get; set; }

    public string? KindAccess { get; set; }

    public string? DowntimeRequired { get; set; }

    public string? TypeServerAccess { get; set; }

    public string? Ipdetails { get; set; }

    public string? VenderName { get; set; }

    public string? VenderFocalName { get; set; }

    public string? VenderFocalEmailId { get; set; }

    public DateTime? AccessStartTime { get; set; }

    public DateTime? AccessEndTime { get; set; }

    public string? Justification { get; set; }

    public string? ReferenceDocument { get; set; }

    public DateTime? DoremoteAccess { get; set; }

    public string? Attachment { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
