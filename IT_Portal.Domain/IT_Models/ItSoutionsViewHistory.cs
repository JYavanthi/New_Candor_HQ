namespace IT_Portal.Domain.IT_Models;

public partial class ItSoutionsViewHistory
{
    public int Id { get; set; }

    public string? SolutionId { get; set; }

    public string? ViewedBy { get; set; }

    public DateOnly? ViewedOn { get; set; }

    public string? VersionNo { get; set; }

    public bool? IsHelpful { get; set; }

    public string? Comments { get; set; }
}
