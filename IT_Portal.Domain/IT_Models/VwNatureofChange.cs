namespace IT_Portal.Domain.IT_Models;

public partial class VwNatureofChange
{
    public int NatureofChangeId { get; set; }

    public int? CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public string? NatureofChange { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
