namespace IT_Portal.Domain.IT_Models;

public partial class NatureofChange
{
    public int NatureofChangeId { get; set; }

    public int? CategoryId { get; set; }

    public string? NatureofChange1 { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
