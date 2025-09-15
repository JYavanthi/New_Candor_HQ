namespace IT_Portal.Domain.IT_Models;

public partial class BellCurveMaster
{
    public int Id { get; set; }

    public int? FkCalanderId { get; set; }

    public string? Description { get; set; }

    public string Name { get; set; } = null!;

    public int Percentage { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsActive { get; set; }
}
