namespace IT_Portal.Domain.IT_Models;

public partial class ChecklistConfig
{
    public int ChecklistConfigId { get; set; }

    public string ChecklistType { get; set; } = null!;

    public int PlantId { get; set; }

    public int PayGroupId { get; set; }

    public int EmployeeCategoryId { get; set; }

    public int GradeId { get; set; }

    public string Title { get; set; } = null!;

    public int DepartmentId { get; set; }

    public int SpocemployeeId { get; set; }

    public virtual DepartmentMaster Department { get; set; } = null!;

    public virtual EmpCategoryMaster EmployeeCategory { get; set; } = null!;

    public virtual Grade Grade { get; set; } = null!;

    public virtual PaygroupMaster PayGroup { get; set; } = null!;

    public virtual PlantMaster Plant { get; set; } = null!;

    public virtual EmployeeMaster Spocemployee { get; set; } = null!;
}
