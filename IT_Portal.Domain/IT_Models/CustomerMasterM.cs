namespace IT_Portal.Domain.IT_Models;

public partial class CustomerMasterM
{
    public int Id { get; set; }

    public string? RequestNo { get; set; }

    public DateTime? RequestDate { get; set; }

    public string? PlantCode { get; set; }

    public string? AccountGroupId { get; set; }

    public string? ViewType { get; set; }

    public string? CustomerType { get; set; }

    public string? Name { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? Address3 { get; set; }

    public string? Address4 { get; set; }

    public string? City { get; set; }

    public string? Pincode { get; set; }

    public string? CountryId { get; set; }

    public string? State { get; set; }

    public string? LandlineNo { get; set; }

    public string? MobileNo { get; set; }

    public string? FaxNo { get; set; }

    public string? EmailId { get; set; }

    public string? CustomerGroup { get; set; }

    public string? PriceGroup { get; set; }

    public string? PriceList { get; set; }

    public string? TaxType { get; set; }

    public string? CurrencyId { get; set; }

    public bool? IsRegdExciseCustomer { get; set; }

    public string? TdsCode { get; set; }

    public string? LstNo { get; set; }

    public string? TinNo { get; set; }

    public string? CstNo { get; set; }

    public string? PanNo { get; set; }

    public string? ServiceTaxRegistrationNo { get; set; }

    public bool? IsRegdExciseVendor { get; set; }

    public string? EccNo { get; set; }

    public string? ExciseRegNo { get; set; }

    public string? ExciseRange { get; set; }

    public string? ExciseDivision { get; set; }

    public string? Dlno1 { get; set; }

    public string? Dlno2 { get; set; }

    public string? PaymentTermId { get; set; }

    public string? AccountClerkId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Attachments { get; set; }

    public string? ModifiedBy { get; set; }

    public string? ApproveStatus { get; set; }

    public string? SapCodeNo { get; set; }

    public string? SapCodeExists { get; set; }

    public DateTime? SapCreationDate { get; set; }

    public string? SapCreatedBy { get; set; }

    public string? RequestedBy { get; set; }

    public DateTime? ApproveDate { get; set; }

    public string? LastApprover { get; set; }

    public string? PendingApprover { get; set; }

    public string? CutomerCode { get; set; }

    public string? RejectedFlag { get; set; }

    public string? GstinNumber { get; set; }

    public bool? IsEligibleForTds { get; set; }
}
