namespace IT_Portal.Domain.IT_Models;

public partial class Pbattachment
{
    public int Id { get; set; }

    public string RequestNumber { get; set; } = null!;

    public string? FolderName { get; set; }

    public string? FileName { get; set; }

    public string? Status { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
