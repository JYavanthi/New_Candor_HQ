namespace IT_Portal.Domain.IT_Models;

public partial class EmpPaygroupMapping
{
    public int Id { get; set; }

    public int? FkPaygroupId { get; set; }

    public int? FkEmpId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsActive { get; set; }

    public virtual EmployeeMaster? FkEmp { get; set; }

    public virtual PaygroupMaster? FkPaygroup { get; set; }
}
