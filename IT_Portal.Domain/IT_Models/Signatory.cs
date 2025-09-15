namespace IT_Portal.Domain.IT_Models;

public partial class Signatory
{
    public int SignatoryId { get; set; }

    public int PlantId { get; set; }

    public int PayGroupId { get; set; }

    public int EmployeeCategoryId { get; set; }

    public string SignatoryType { get; set; } = null!;

    public int EmployeeId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public virtual EmployeeMaster Employee { get; set; } = null!;
}
