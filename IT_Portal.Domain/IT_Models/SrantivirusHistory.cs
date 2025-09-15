namespace IT_Portal.Domain.IT_Models;

public partial class SrantivirusHistory
{
    public int SravhistoryId { get; set; }

    public int? Sravid { get; set; }

    public int Srid { get; set; }

    public int? SupportId { get; set; }

    public string? RequestType { get; set; }

    public string? InstallDts { get; set; }

    public string? UninstallDts { get; set; }

    public string? ExcDts { get; set; }

    public string? IncDts { get; set; }

    public string? Attachment { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
