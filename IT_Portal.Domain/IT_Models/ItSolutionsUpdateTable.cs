namespace IT_Portal.Domain.IT_Models;

public partial class ItSolutionsUpdateTable
{
    public int Id { get; set; }

    public decimal? Version { get; set; }

    public string? Category { get; set; }

    public string? Title { get; set; }

    public string? Topic { get; set; }

    public string? Solution { get; set; }

    public string? Keywords { get; set; }

    public string? Attachments { get; set; }

    public string? PostedBy { get; set; }

    public DateOnly? PostedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateOnly? ModifiedOn { get; set; }

    public bool? IsActive { get; set; }
}
