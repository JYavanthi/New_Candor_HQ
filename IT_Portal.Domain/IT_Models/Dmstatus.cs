namespace IT_Portal.Domain.IT_Models;

public partial class Dmstatus
{
    public int Id { get; set; }

    public string? StatusText { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? SortOrder { get; set; }
}
