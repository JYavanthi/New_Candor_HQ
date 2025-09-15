namespace IT_Portal.Domain.IT_Models;

public partial class StorageCondition
{
    public int Id { get; set; }

    public string? StoCondCode { get; set; }

    public string? Stxt { get; set; }

    public string? Ltxt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public bool? IsActive { get; set; }
}
