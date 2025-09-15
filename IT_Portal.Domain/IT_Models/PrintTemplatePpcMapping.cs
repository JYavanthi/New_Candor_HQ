namespace IT_Portal.Domain.IT_Models;

public partial class PrintTemplatePpcMapping
{
    public int PrintTemplatePpcmappingId { get; set; }

    public int PrintTemplateId { get; set; }

    public int PlantId { get; set; }

    public int PayGroupId { get; set; }

    public int EmployeeCategoryId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedById { get; set; }

    public DateTime ModifiedDate { get; set; }

    public int ModifiedById { get; set; }

    public virtual EmployeeMaster CreatedBy { get; set; } = null!;

    public virtual EmpCategoryMaster EmployeeCategory { get; set; } = null!;

    public virtual EmployeeMaster ModifiedBy { get; set; } = null!;

    public virtual PaygroupMaster PayGroup { get; set; } = null!;

    public virtual PlantMaster Plant { get; set; } = null!;

    public virtual PrintTemplate PrintTemplate { get; set; } = null!;
}
