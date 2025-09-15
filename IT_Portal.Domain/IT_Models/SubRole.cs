namespace IT_Portal.Domain.IT_Models;

public partial class SubRole
{
    public int Id { get; set; }

    public int? FkSuperRoleId { get; set; }

    public string? Role { get; set; }

    public string? Description { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<EmployeeMaster> EmployeeMasters { get; set; } = new List<EmployeeMaster>();

    public virtual ICollection<SoftSkillMaster> SoftSkillMasters { get; set; } = new List<SoftSkillMaster>();
}
