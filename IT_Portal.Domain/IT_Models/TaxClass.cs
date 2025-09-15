namespace IT_Portal.Domain.IT_Models;

public partial class TaxClass
{
    public int TClassId { get; set; }

    public string? TClassName { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }
}
