namespace IT_Portal.Domain.IT_Models;

public partial class EmployeeResignationDetail
{
    public int ResignationId { get; set; }

    public int EmployeeId { get; set; }

    public DateOnly ResignationDate { get; set; }

    public DateOnly JoiningDate { get; set; }

    public DateOnly LastWorkingdate { get; set; }

    public string Reason { get; set; } = null!;

    public string? ReasonDetail { get; set; }

    public DateOnly? ExpectedLastWorkingDate { get; set; }

    public string? ReasonExpectedDateChange { get; set; }

    public string? Status { get; set; }

    public int CreatedById { get; set; }

    public DateOnly CreatedDate { get; set; }

    public int? Hod { get; set; }

    public int? ReportingManagerId { get; set; }

    public int? ExitInterviewTemplateId { get; set; }

    public string? ExitInterviewAnswers { get; set; }

    public DateTime? ExitInterviewSubmittedDate { get; set; }

    public bool? ExitInterviewRequired { get; set; }

    public string? ReasonForNoExitInterview { get; set; }

    public DateTime? ActualLastWorkingDate { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual PrintTemplate? ExitInterviewTemplate { get; set; }
}
