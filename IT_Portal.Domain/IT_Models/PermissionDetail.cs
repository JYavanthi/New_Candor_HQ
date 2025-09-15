namespace IT_Portal.Domain.IT_Models;

public partial class PermissionDetail
{
    public int Id { get; set; }

    public int? RequestNo { get; set; }

    public string? UserId { get; set; }

    public DateOnly? Date { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

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

    public string? InTime { get; set; }

    public string? OutTime { get; set; }

    public string? SecurityId { get; set; }

    public int? HrId { get; set; }

    public int? SecurityStatus { get; set; }

    public DateTime? SubmitDate { get; set; }

    public string? Type { get; set; }

    public int? Cancelflag { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? SwipeType { get; set; }

    public int? AvailMinutes { get; set; }

    public bool? AttendanceStatus { get; set; }
}
