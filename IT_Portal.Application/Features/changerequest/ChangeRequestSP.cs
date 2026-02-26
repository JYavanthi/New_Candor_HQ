namespace IT_Portal.Application.Features.changerequest
{
    public class ChangeRequestSP
    {
        public string? Type { get; set; }

        public int ITCRID { get; set; }

        public int SupportId { get; set; }

        public int ClassificationId { get; set; }

        public int CategoryId { get; set; }

        public int CategoryTypeId { get; set; }

        public int Crowner { get; set; }

        public DateTime? Crdate { get; set; }

        public int? CrrequestedBy { get; set; }

        public bool? CRREmailNotification { get; set; }

        public DateTime? CrrequestedDt { get; set; }

        public int? CrinitiatedFor { get; set; }

        public string Status { get; set; }

        public int? ReferenceId { get; set; }

        public int? ReferenceTyp { get; set; }

        public int? NatureOfChange { get; set; }

        public int? PriorityType { get; set; }

        public int? PlantId { get; set; }

        public string? SysLandscapeID { get; set; }

        public bool? Gxpclassification { get; set; }

        public int? GxpplantId { get; set; }

        public string? ChangeControlNo { get; set; }

        public DateOnly? ChangeControlDt { get; set; }

        public bool? ChangeControlAttach { get; set; }

        public string? ChangeDesc { get; set; }

        public string? ReasonForChange { get; set; }

        public string? AlternateConsidetation { get; set; }

        public string? ImpactNotDoing { get; set; }

        public string? BusinessImpact { get; set; }

        public string? TriggeredBy { get; set; }

        public string? Benefits { get; set; }

        public decimal? EstimatedCost { get; set; }

        public string? EstimatedCostCurr { get; set; }

        public int? EstimatedEffort { get; set; }

        public string? EstimatedEffortUnit { get; set; }

        public DateOnly? EstimatedDateCompletion { get; set; }

        public string? RollbackPlan { get; set; }

        public string? BackoutPlan { get; set; }

        public bool? DownTimeRequired { get; set; }

        public DateTime? DownTimeFromDate { get; set; }

        public DateTime? DownTimeToDate { get; set; }

        public string? ImpactedLocation { get; set; }

        public string? ImpactedDept { get; set; }

        public string? ImactedFunc { get; set; }

        public bool? isSubmitted { get; set; }

        public bool? isApproved { get; set; }

        public bool? isImplemented { get; set; }

        public bool? isReleased { get; set; }

        public int? CreatedBy { get; set; }

        public string? Attachment { get; set; }
        public List<int> AttachmentIds { get; set; } = new List<int>();

    }
}