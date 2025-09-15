namespace IT_Portal.Domain.IT_Models;

public partial class ValuationClass
{
    public int Id { get; set; }

    public string? MatType { get; set; }

    public string? ValuationId { get; set; }

    public string? ValuationDesc { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public bool? IsActive { get; set; }
}
