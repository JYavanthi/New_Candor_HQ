namespace IT_Portal.Domain.IT_Models;

public partial class GenericName
{
    public int Id { get; set; }

    public string GenNameCode { get; set; } = null!;

    public string? GenNameDesc { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public bool? IsActive { get; set; }
}
