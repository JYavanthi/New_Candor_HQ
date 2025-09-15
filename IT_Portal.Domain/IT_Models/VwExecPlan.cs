namespace IT_Portal.Domain.IT_Models;

public partial class VwExecPlan
{
    public int ItcrexecId { get; set; }

    public int Itcrid { get; set; }

    public int SysLandscapeid { get; set; }

    public string? Sylandscape { get; set; }

    public string? ExecutionStepName { get; set; }

    public string? ExecutionStepDesc { get; set; }

    public int? Assignedtoid { get; set; }

    public int? Forwardedtoid { get; set; }

    public string AssignedTo { get; set; } = null!;

    public string ForwardedTo { get; set; } = null!;

    public DateTime? StartDt { get; set; }

    public DateTime? EndDt { get; set; }

    public string? Attachments { get; set; }

    public string? Status { get; set; }

    public DateTime? ForwardedDt { get; set; }

    public string? ReasonForwarded { get; set; }

    public string? Remarks { get; set; }

    public string? PickedStatus { get; set; }

    public DateTime? PickedDt { get; set; }

    public DateTime? ActualStartDt { get; set; }

    public DateTime? ActualEndDt { get; set; }

    public string? DependSyelanscape { get; set; }

    public int? DependSysLandscapeid { get; set; }

    public int? DependTaskId { get; set; }

    public string? Depndtask { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
