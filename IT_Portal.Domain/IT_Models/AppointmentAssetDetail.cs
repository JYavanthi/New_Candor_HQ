namespace IT_Portal.Domain.IT_Models;

public partial class AppointmentAssetDetail
{
    public int AppointmentAssetId { get; set; }

    public int AssetTypeId { get; set; }

    public string? AssetNo { get; set; }

    public decimal? AssetValue { get; set; }

    public decimal? PerquisitesOn { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public string? Remarks { get; set; }

    public string AttachmentFileName { get; set; } = null!;

    public string AttachmentFilePath { get; set; } = null!;

    public int AppointmentId { get; set; }

    public int? EmployeeId { get; set; }

    public virtual AppointmentPersonalDetail Appointment { get; set; } = null!;

    public virtual AssetTypeMaster AssetType { get; set; } = null!;

    public virtual Employee? Employee { get; set; }
}
