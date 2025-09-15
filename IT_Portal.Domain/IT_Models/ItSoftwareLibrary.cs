namespace IT_Portal.Domain.IT_Models;

public partial class ItSoftwareLibrary
{
    public string? SoftwareName { get; set; }

    public bool? IsActive { get; set; }

    public int? ModifiedBy { get; set; }

    public DateOnly? ModifiedDate { get; set; }

    public int? CreatedBy { get; set; }

    public int? SoftwareId { get; set; }

    public DateOnly? CreatedDate { get; set; }
}
