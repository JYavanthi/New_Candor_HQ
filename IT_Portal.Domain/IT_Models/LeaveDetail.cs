namespace IT_Portal.Domain.IT_Models;

public partial class LeaveDetail
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public string? LeaveType { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? StartDuration { get; set; }

    public string? EndDuration { get; set; }

    public string? NoOfDays { get; set; }

    public string? LeaveStatus { get; set; }

    public string? RecordStatus { get; set; }

    public int? DepartmentId { get; set; }

    public int? CountryId { get; set; }

    public int? StateId { get; set; }

    public int? PlantId { get; set; }

    public int? DesignationId { get; set; }

    public string? Documents { get; set; }

    public string? SubmitDate { get; set; }

    public string? ReasonType { get; set; }

    public string? Reason { get; set; }

    public string? Firstname { get; set; }

    public string? ApproverId { get; set; }

    public string? ApprovelStatus { get; set; }

    public string? ForwardedEmpId { get; set; }

    public string? LastApprover { get; set; }

    public string? PendingApprover { get; set; }

    public string? ReqId { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public DateTime? RejectedDate { get; set; }

    public decimal? LvBalence { get; set; }

    public int? HrId { get; set; }

    public string? SapStatus { get; set; }

    public DateTime? SapApprovedDate { get; set; }

    public string? SapMessage { get; set; }

    public string? SapAppStatus { get; set; }

    public int? Cancelflag { get; set; }

    public string? PersonResponsible { get; set; }

    public string? AddressDuringLeave { get; set; }

    public string? ContactNo { get; set; }

    public string? AppliedBy { get; set; }

    public string? RequestedBy { get; set; }

    public DateTime? RequestedDate { get; set; }
}
