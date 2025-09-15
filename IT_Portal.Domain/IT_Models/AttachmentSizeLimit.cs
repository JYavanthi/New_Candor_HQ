namespace IT_Portal.Domain.IT_Models;

public partial class AttachmentSizeLimit
{
    public int Id { get; set; }

    public string Module { get; set; } = null!;

    public int MaxFileSize { get; set; }

    public string MaxFileSizeText { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
