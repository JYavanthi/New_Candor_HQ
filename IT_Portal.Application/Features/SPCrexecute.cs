namespace IT_Portal.Application.Features
{
    public class SPCrexecute
    {
        public string Flag { get; set; }

        public int ITCRExecID { get; set; }

        public int ITCRID { get; set; }

        public int SysLandscape { get; set; }

        public string ExecutionStepName { get; set; }

        public string ExecutionStepDesc { get; set; }

        public int? AssignedTo { get; set; }

        public DateTime? StartDt { get; set; }

        public DateTime? EndDT { get; set; }

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
    }
}
