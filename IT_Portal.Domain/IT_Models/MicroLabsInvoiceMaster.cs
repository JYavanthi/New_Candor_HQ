namespace IT_Portal.Domain.IT_Models;

public partial class MicroLabsInvoiceMaster
{
    public int Id { get; set; }

    public string InvoiceNo { get; set; } = null!;

    public DateTime InvoiceDate { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerCode { get; set; }

    public string? MaterialCode { get; set; }

    public string? MaterialDescription { get; set; }

    public string? Uom { get; set; }

    public int? Qty { get; set; }

    public int? NoCases { get; set; }

    public bool? IsActive { get; set; }
}
