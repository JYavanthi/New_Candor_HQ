namespace IT_Portal.Domain.IT_Models;

public partial class AllertApplicable
{
    public int AllertApplicableId { get; set; }

    public int AllertId { get; set; }

    public int? PlantId { get; set; }

    public int? PaygroupId { get; set; }

    public int? EmployeeCategoryid { get; set; }

    public int? DepartmentId { get; set; }

    public int? StateId { get; set; }

    public virtual Allertbox Allert { get; set; } = null!;
}
