namespace IT_Portal.Domain.IT_Models;

public partial class Role
{
    public int Id { get; set; }

    public int? RoleId { get; set; }

    public string? Role1 { get; set; }

    public string? Description { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }
}
