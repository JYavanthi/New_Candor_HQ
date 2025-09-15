namespace IT_Portal.Domain.IT_Models;

public partial class UidrequestType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public int UserIdtype { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
}
