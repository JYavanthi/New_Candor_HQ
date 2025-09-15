namespace IT_Portal.Domain.IT_Models;

public partial class ProdItemcodeExtenstionRequest
{
    public int Id { get; set; }

    public string? RequestNo { get; set; }

    public DateTime? RequestDate { get; set; }

    public string? Type { get; set; }

    public string? Plant1 { get; set; }

    public string? MaterialCode1 { get; set; }

    public string? ExtendedToPlant1 { get; set; }

    public string? StorageLocationId1 { get; set; }

    public string? ExtendedStorageLocation1 { get; set; }

    public string? MaterialTypeId { get; set; }

    public string? Plant2 { get; set; }

    public string? MaterialCode2 { get; set; }

    public string? FromStorageLocation { get; set; }

    public string? ToStorageLocation { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public string? ApproveType { get; set; }

    public DateTime? ApproveDate { get; set; }

    public string? LastApprover { get; set; }

    public string? PendingApprover { get; set; }

    public string? ExistingSapNo { get; set; }

    public string? RejectedFlag { get; set; }

    public string? MaterialShortName { get; set; }

    public string? HsnCode { get; set; }

    public string? SapcreaterFlag { get; set; }

    public string? Attachments { get; set; }

    public string? Reason { get; set; }

    public string? CodeExtendedBy { get; set; }

    public DateTime? CodeExtendedOn { get; set; }

    public string? EMicroRefReqNo { get; set; }
}
