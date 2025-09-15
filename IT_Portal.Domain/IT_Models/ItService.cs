namespace IT_Portal.Domain.IT_Models;

public partial class ItService
{
    public int Id { get; set; }

    public string? Plant { get; set; }

    public string? DetailsOfService { get; set; }

    public string? SupportCategory { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsActive { get; set; }
}
