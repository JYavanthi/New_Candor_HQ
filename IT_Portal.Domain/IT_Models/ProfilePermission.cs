namespace IT_Portal.Domain.IT_Models;

public partial class ProfilePermission
{
    public int ProfilePermissionId { get; set; }

    public int ProfileId { get; set; }

    public int PermissionId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedById { get; set; }

    public DateTime ModifiedDate { get; set; }

    public int ModifiedById { get; set; }

    public virtual PermissionMasterItportal ProfilePermissionNavigation { get; set; } = null!;
}
