namespace IT_Portal.Domain.IT_Models;

public partial class SoftwareLibraryHistory
{
    public int SoftwareLibraryHistoryId { get; set; }

    public int SoftwareLibraryId { get; set; }

    public string SoftwareName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
