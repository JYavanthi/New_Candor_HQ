namespace IT_Portal.Domain.IT_Models;

public partial class PackType
{
    public int Id { get; set; }

    public string? PTypeCode { get; set; }

    public string? PTypeDesc { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public bool? IsActive { get; set; }
}
