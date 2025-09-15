namespace IT_Portal.Domain.IT_Models;

public partial class DepartmentMaster
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? FkParentId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public int? Dptid { get; set; }

    public virtual ICollection<ChecklistConfig> ChecklistConfigs { get; set; } = new List<ChecklistConfig>();

    public virtual ICollection<ChecklistItem> ChecklistItems { get; set; } = new List<ChecklistItem>();

    public virtual ICollection<EmailNotificationMapping> EmailNotificationMappings { get; set; } = new List<EmailNotificationMapping>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<SubDeptMaster> SubDeptMasters { get; set; } = new List<SubDeptMaster>();

    public virtual ICollection<UserDeptMaintenance> UserDeptMaintenances { get; set; } = new List<UserDeptMaintenance>();
}
