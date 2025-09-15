namespace IT_Portal.Domain.IT_Models;

public partial class PriceList
{
    public int Id { get; set; }

    public string? PListId { get; set; }

    public string? PListName { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }
}
