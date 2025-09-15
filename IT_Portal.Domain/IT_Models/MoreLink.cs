namespace IT_Portal.Domain.IT_Models;

public partial class MoreLink
{
    public int MoreLinkId { get; set; }

    public string LinkText { get; set; } = null!;

    public string LinkUrl { get; set; } = null!;

    public string? Description { get; set; }

    public bool OpenInNewWindow { get; set; }

    public bool IsSocialMediaLink { get; set; }

    public bool IsActive { get; set; }

    public int Order { get; set; }

    public string Icon { get; set; } = null!;

    public int CreatedById { get; set; }

    public DateTime CreatedDate { get; set; }

    public int ModifiedById { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual EmployeeMaster CreatedBy { get; set; } = null!;

    public virtual EmployeeMaster ModifiedBy { get; set; } = null!;
}
