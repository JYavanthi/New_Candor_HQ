namespace IT_Portal.Domain.IT_Models;

public partial class TdTypeOfEvent
{
    public int Id { get; set; }

    public string TypeOfEvent { get; set; } = null!;

    public bool IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }
}
