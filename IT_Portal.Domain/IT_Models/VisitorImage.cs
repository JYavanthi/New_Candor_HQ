namespace IT_Portal.Domain.IT_Models;

public partial class VisitorImage
{
    public int Id { get; set; }

    public int FkVisitorId { get; set; }

    public byte[]? VisitorImage1 { get; set; }

    public virtual Visitor FkVisitor { get; set; } = null!;
}
