namespace IT_Portal.Domain.IT_Models;

public partial class CompOtRule
{
    public int Id { get; set; }

    public int Plant { get; set; }

    public int Paygroup { get; set; }

    public int Staffcategory { get; set; }

    public int Grade { get; set; }

    public int WorkType { get; set; }

    public string Type { get; set; } = null!;

    public int? CompOffLapsDays { get; set; }

    public bool? CompOffAccumulation { get; set; }

    public int? CMinHours { get; set; }

    public int? CMaxHours { get; set; }

    public bool? ProvideOtforCo { get; set; }

    public int? OMinHours { get; set; }

    public int? OMaxHours { get; set; }

    public bool? ProvideCoforOt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsActive { get; set; }

    public virtual Grade GradeNavigation { get; set; } = null!;

    public virtual PaygroupMaster PaygroupNavigation { get; set; } = null!;

    public virtual PlantMaster PlantNavigation { get; set; } = null!;

    public virtual EmpCategoryMaster StaffcategoryNavigation { get; set; } = null!;
}
