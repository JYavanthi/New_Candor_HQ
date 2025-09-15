namespace IT_Portal.Domain.IT_Models;

public partial class EmailNotificationMapping
{
    public int Id { get; set; }

    public int? Plant { get; set; }

    public int? EmployeeId { get; set; }

    public int? Dept { get; set; }

    public string? EmailId { get; set; }

    public string? Type { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual DepartmentMaster? DeptNavigation { get; set; }

    public virtual EmployeeMaster? Employee { get; set; }

    public virtual LocationMaster? PlantNavigation { get; set; }
}
