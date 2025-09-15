namespace IT_Portal.Domain.IT_Models;

public partial class BackupSupport
{
    public int SupportId { get; set; }

    public string SupportName { get; set; } = null!;

    public int? ParentId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsVisible { get; set; }

    public bool? IsRpmreq { get; set; }

    public bool? IsHodreq { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? Image { get; set; }

    public string? Url { get; set; }
}
