namespace IT_Portal.Application.Features
{
    public class EcrExecutionPlanHistory
    {

        public int ItcrexecHistoryId { get; set; }

        public DateTime? CrhistoryDt { get; set; }

        public int? ItcrexecId { get; set; }

        public int? Itcrid { get; set; }

        public int? SysLandscape { get; set; }

        public string? ExecutionStepName { get; set; }

        public string? ExecutionStepDesc { get; set; }

        public int? AssignedTo { get; set; }

        public DateTime? StartDt { get; set; }

        public DateTime? EndDt { get; set; }

        public string? Attachments { get; set; }

        public string? Status { get; set; }

        public string? ForwardStatus { get; set; }

        public int? ForwardedTo { get; set; }

        public DateTime? ForwardedDt { get; set; }

        public string? ReasonForwarded { get; set; }

        public string? Remarks { get; set; }

        public string? PickedStatus { get; set; }

        public DateTime? PickedDt { get; set; }

        public DateTime? ActualStartDt { get; set; }

        public DateTime? ActualEndDt { get; set; }

        public int? DependSysLandscape { get; set; }

        public int? DependTaskId { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDt { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDt { get; set; }
        public string ModifiedByName { get; set; }

        public string CreatedByName { get; set; }
        public string AssignedToName { get; set; }
        public string ForwardedToName { get; set; }
    }
}
