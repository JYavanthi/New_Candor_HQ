namespace IT_Portal.Domain.IT_Models;

public partial class ItapprovedVendor
{
    public int Id { get; set; }

    public string? Plant { get; set; }

    public string? VendorName { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? TypeOfVendor { get; set; }

    public string? Details { get; set; }

    public string? Website { get; set; }

    public string? NdaCdaSigned { get; set; }

    public string? CustomerClientDetails { get; set; }

    public string? SourcedFrom { get; set; }

    public string? ReferredBy { get; set; }

    public string? AdditionalNotes { get; set; }

    public bool? AreWeWorkingWithThisVendor { get; set; }

    public string? SapVendorCode { get; set; }

    public string? Attachments { get; set; }

    public string? CreatedBy { get; set; }

    public DateOnly? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateOnly? ModifiedOn { get; set; }

    public string? ServiceSupplies { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<ItvendorPersonContactDetail> ItvendorPersonContactDetails { get; set; } = new List<ItvendorPersonContactDetail>();
}
