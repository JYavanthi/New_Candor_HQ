namespace IT_Portal.Domain.IT_Models;

public partial class ItSoftwareLibararyHistroy
{
    public int SoftLibraryHistoryId { get; set; }

    public int SoftwareLibraryId { get; set; }

    public string? SoftwareName { get; set; }

    public bool IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateOnly? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateOnly? ModifiedDt { get; set; }
}
