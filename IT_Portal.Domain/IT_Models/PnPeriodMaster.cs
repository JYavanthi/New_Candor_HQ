namespace IT_Portal.Domain.IT_Models;

public partial class PnPeriodMaster
{
    public int Id { get; set; }

    public int? PlantId { get; set; }

    public int? PayGroupId { get; set; }

    public int? EmployeeCategoryId { get; set; }

    public int? DepartmentId { get; set; }

    public int? GradeId { get; set; }

    public int? ProbationPeriod { get; set; }

    public int? NoticePeriod { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
