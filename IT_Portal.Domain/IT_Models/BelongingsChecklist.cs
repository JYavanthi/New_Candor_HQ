namespace IT_Portal.Domain.IT_Models;

public partial class BelongingsChecklist
{
    public int Id { get; set; }

    public int? FkVisitorId { get; set; }

    public string? VisitorName { get; set; }

    public string? MobileNo { get; set; }

    public string? Belongings { get; set; }

    public string? Type { get; set; }

    public DateTime? CheckInDate { get; set; }

    public DateTime? CheckoutDate { get; set; }

    public string? Remarks { get; set; }

    public string? ModelNo { get; set; }

    public string? SerialNo { get; set; }

    public string? Details { get; set; }

    public virtual Visitor? FkVisitor { get; set; }
}
