namespace IT_Portal.Domain.IT_Models;

public partial class EmployeeApproval
{
    public int Id { get; set; }

    public int? FkEmpId { get; set; }

    public string? EmployeeId { get; set; }

    public int? FkReviewerEmployeeId { get; set; }

    public int? FkManagerId { get; set; }

    public int? FkCompetencyId { get; set; }

    public int? FkSbuId { get; set; }

    public int? FkHrManagerId { get; set; }

    public int? FkParentEmployeeId { get; set; }

    public int? FkDesignation { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }
}
