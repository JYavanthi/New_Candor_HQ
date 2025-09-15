namespace IT_Portal.Domain.IT_Models;

public partial class PaymentTermM
{
    public int PaymentTermId { get; set; }

    public string? PaymentTermCode { get; set; }

    public string? PaymentTermName { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }
}
