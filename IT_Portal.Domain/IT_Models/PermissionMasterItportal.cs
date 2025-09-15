namespace IT_Portal.Domain.IT_Models;

public partial class PermissionMasterItportal
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ProfilePermission? ProfilePermission { get; set; }
}
