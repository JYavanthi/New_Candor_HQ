namespace IT_Portal.Domain.IT_Models;

public partial class Pbuser
{
    public int Id { get; set; }

    public string? Section { get; set; }

    public string EmployeeId { get; set; } = null!;

    public int Role { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
