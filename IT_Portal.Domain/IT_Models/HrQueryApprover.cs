namespace IT_Portal.Domain.IT_Models;

public partial class HrQueryApprover
{
    public int Id { get; set; }

    public int? HrId { get; set; }

    public string Location { get; set; } = null!;

    public string? Role { get; set; }

    public string? Category { get; set; }
}
