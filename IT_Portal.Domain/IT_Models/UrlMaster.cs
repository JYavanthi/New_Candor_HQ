namespace IT_Portal.Domain.IT_Models;

public partial class UrlMaster
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? UrlPath { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }
}
