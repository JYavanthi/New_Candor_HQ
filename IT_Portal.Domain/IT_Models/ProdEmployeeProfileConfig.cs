namespace IT_Portal.Domain.IT_Models;

public partial class ProdEmployeeProfileConfig
{
    public int Id { get; set; }

    public string EmployeeId { get; set; } = null!;

    public int ProfileId { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }
}
