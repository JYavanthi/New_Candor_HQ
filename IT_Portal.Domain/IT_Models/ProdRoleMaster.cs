namespace IT_Portal.Domain.IT_Models;

public partial class ProdRoleMaster
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public string? RoleStxt { get; set; }

    public string? RoleLtxt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsActive { get; set; }
}
