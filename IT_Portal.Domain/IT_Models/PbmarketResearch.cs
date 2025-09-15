namespace IT_Portal.Domain.IT_Models;

public partial class PbmarketResearch
{
    public int Id { get; set; }

    public string Pbnumber { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string ResponsibleEmployee { get; set; } = null!;

    public DateTime Tcd { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? CreatorComments { get; set; }

    public string? Comments { get; set; }

    public string? Attachments { get; set; }
}
