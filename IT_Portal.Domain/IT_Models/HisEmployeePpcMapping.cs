namespace IT_Portal.Domain.IT_Models;

public partial class HisEmployeePpcMapping
{
    public int HisId { get; set; }

    public int EmployeePpcmappingId { get; set; }

    public int EmployeeId { get; set; }

    public string PlantId { get; set; } = null!;

    public string PayGroupId { get; set; } = null!;

    public string EmployeeCategoryId { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int CreatedById { get; set; }

    public DateTime ModifiedDate { get; set; }

    public int ModifiedById { get; set; }
}
