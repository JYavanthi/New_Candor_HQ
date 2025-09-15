namespace IT_Portal.Domain.IT_Models;

public partial class MultiLoginExceptionUser
{
    public int Id { get; set; }

    public string? EmployeeId { get; set; }

    public int? FkDepartmentId { get; set; }

    public int? FkDesignationId { get; set; }

    public string? FullName { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
