namespace IT_Portal.Domain.IT_Models;

public partial class RaRequest
{
    public int Id { get; set; }

    public string? RequestNo { get; set; }

    public DateTime? RequestDate { get; set; }

    public string? RequestedBy { get; set; }

    public string? ApiName { get; set; }

    public string? Grade { get; set; }

    public string? ApiManufacturer { get; set; }

    public string? ManufacturingSite { get; set; }

    public string? DocumentRequired { get; set; }

    public string? Product { get; set; }

    public string? Country { get; set; }

    public string? Purpose { get; set; }

    public string? DocumentPath { get; set; }

    public string? DmfVersion { get; set; }

    public string? DmfQueryDoc { get; set; }

    public string? DocumentShared { get; set; }

    public DateTime? SharedOn { get; set; }

    public string? Remarks { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? RequiredBy { get; set; }

    public string? AdditionalDoc { get; set; }

    public string? LastApprover { get; set; }

    public string? PendingWith { get; set; }

    public string? SharedBy { get; set; }

    public string? Comments { get; set; }

    public string? Attachments { get; set; }

    public string? InitiatorComments { get; set; }
}
