namespace IT_Portal.Domain.IT_Models;

public partial class PurposeTravel
{
    public int Id { get; set; }

    public string Purpose { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }
}
