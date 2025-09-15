namespace IT_Portal.Domain.IT_Models;

public partial class UidrequestTypeConfig
{
    public int Id { get; set; }

    public int Sid { get; set; }

    public int RequestTypeId { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
}
