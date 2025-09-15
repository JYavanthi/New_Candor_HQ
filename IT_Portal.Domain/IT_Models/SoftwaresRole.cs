namespace IT_Portal.Domain.IT_Models;

public partial class SoftwaresRole
{
    public int Id { get; set; }

    public int Sid { get; set; }

    public string? Role { get; set; }

    public int SequenceNo { get; set; }

    public bool IsBold { get; set; }

    public bool IsActive { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public string? Location { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<RequiredUserRole> RequiredUserRoles { get; set; } = new List<RequiredUserRole>();

    public virtual Software SidNavigation { get; set; } = null!;
}
