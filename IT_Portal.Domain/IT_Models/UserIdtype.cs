namespace IT_Portal.Domain.IT_Models;

public partial class UserIdtype
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
}
