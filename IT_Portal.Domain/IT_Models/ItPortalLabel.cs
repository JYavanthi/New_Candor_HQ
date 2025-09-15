namespace IT_Portal.Domain.IT_Models;

public partial class ItPortalLabel
{
    public int Id { get; set; }

    public int? ItLabelId { get; set; }

    public int? ContactLabelId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public string? Itname { get; set; }
}
