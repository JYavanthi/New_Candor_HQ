namespace IT_Portal.Domain.IT_Models;

public partial class VisitorBelonging
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? Checked { get; set; }
}
