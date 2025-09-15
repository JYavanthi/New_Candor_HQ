namespace IT_Portal.Domain.IT_Models;

public partial class TblAwardAchivement
{
    public int Id { get; set; }

    public string Award { get; set; } = null!;

    public string? PhotoPath { get; set; }

    public string? Description { get; set; }

    public string? AwardedTo { get; set; }

    public string? AwardedBy { get; set; }

    public DateTime? AwardDate { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModificationOn { get; set; }

    public string? ModifiedBy { get; set; }
}
