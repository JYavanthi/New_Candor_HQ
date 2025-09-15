namespace IT_Portal.Domain.IT_Models;

public partial class MessageBoard
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public string? Url { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }
}
