namespace IT_Portal.Domain.IT_Models;

public partial class PartnerDetail
{
    public int Id { get; set; }

    public string? Vccode { get; set; }

    public string? Vcname { get; set; }

    public string? Pan { get; set; }

    public int? CategoryOfPerson { get; set; }

    public int? RelationWithMicroLabs { get; set; }

    public string? ItrfiledPre2YearsStatus { get; set; }

    public string? ItrackYearForP1 { get; set; }

    public string? ItrackNumForP1 { get; set; }

    public DateOnly? ItrfillingDateForP1 { get; set; }

    public string? UploadProofPathForP1 { get; set; }

    public string? ItrackYearForP2 { get; set; }

    public string? ItrackNumForP2 { get; set; }

    public DateOnly? ItrfillingDateForP2 { get; set; }

    public string? UploadProofPathForP2 { get; set; }

    public double? TdslimitP1 { get; set; }

    public string? TdslimitStatusP1 { get; set; }

    public double? TdslimitP2 { get; set; }

    public string? TdslimitStatusP2 { get; set; }

    public double? CurrentYearturnOverLimit { get; set; }

    public string? CurrentYearturnOverStatus { get; set; }

    public string? TurnOverproofPath { get; set; }

    public string? AadharPanLinkStatus { get; set; }

    public string? AuthorisedBy { get; set; }

    public string? AuthDesignation { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? LastModifiedOn { get; set; }

    public int? DelFlag { get; set; }

    public int? UpdateFlag { get; set; }

    public string? Remarks { get; set; }
}
