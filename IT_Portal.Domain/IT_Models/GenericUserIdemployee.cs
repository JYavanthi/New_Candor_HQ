namespace IT_Portal.Domain.IT_Models;

public partial class GenericUserIdemployee
{
    public int Id { get; set; }

    public int GenericId { get; set; }

    public string EmployeeId { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string Status { get; set; } = null!;
}
