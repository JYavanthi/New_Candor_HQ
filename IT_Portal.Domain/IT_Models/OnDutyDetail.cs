namespace IT_Portal.Domain.IT_Models;

public partial class OnDutyDetail
{
    public int Id { get; set; }

    public int? RequestNo { get; set; }

    public string? UserId { get; set; }

    public string? OnDutyType { get; set; }

    public string? Duration { get; set; }

    public string? EndDuration { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? NoOfDays { get; set; }

    public string? OnDutyStatus { get; set; }

    public string? RecordStatus { get; set; }

    public string? Documents { get; set; }

    public DateTime? SubmitDate { get; set; }

    public string? Reason { get; set; }

    public string? Firstname { get; set; }

    public string? ApproverId { get; set; }

    public string? ApproverStatus { get; set; }

    public string? ForwardedEmpId { get; set; }

    public string? LastApprover { get; set; }

    public string? PendingApprover { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public DateTime? RejectedDate { get; set; }

    public string? Comments { get; set; }

    public string? Location { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public string? InTime { get; set; }

    public string? OutTime { get; set; }

    public string? SecurityId { get; set; }

    public int? HrId { get; set; }

    public int? SecurityStatus { get; set; }

    public string? SapStatus { get; set; }

    public DateTime? SapApprovedDate { get; set; }

    public string? SapMessage { get; set; }

    public int? Cancelflag { get; set; }

    public int? TravelNo { get; set; }

    public string? PersonResponsible { get; set; }

    public string? AddressDuringLeave { get; set; }

    public string? ContactNo { get; set; }

    public string? Area { get; set; }
}
