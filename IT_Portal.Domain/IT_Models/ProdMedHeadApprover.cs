namespace IT_Portal.Domain.IT_Models;

public partial class ProdMedHeadApprover
{
    public int Id { get; set; }

    public string? Location { get; set; }

    public string? EmployeeId { get; set; }

    public string? Name { get; set; }

    public string? Role { get; set; }

    public int? Priority { get; set; }

    public bool? IsActive { get; set; }
}
