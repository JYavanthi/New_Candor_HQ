namespace IT_Portal.Domain.IT_Models;

public partial class UserDeptMaintenance
{
    public int Id { get; set; }

    public int? FkDeptId { get; set; }

    public int? FkEmpId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsActive { get; set; }

    public virtual DepartmentMaster? FkDept { get; set; }

    public virtual EmployeeMaster? FkEmp { get; set; }
}
