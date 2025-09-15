namespace IT_Portal.Domain.IT_Models;

public partial class RequiredUserRole
{
    public int Id { get; set; }

    public int Uid { get; set; }

    public int RoleId { get; set; }

    public virtual SoftwaresRole Role { get; set; } = null!;

    public virtual UserIdRequestOld UidNavigation { get; set; } = null!;
}
