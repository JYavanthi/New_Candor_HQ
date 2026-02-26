namespace IT_Portal.Application.Features
{
    public class SPProjectMaster
    {
        public string Flag { get; set; }
        public int? ProjectMgmtID { get; set; }
        public int? SupportID { get; set; }
        public string ProjectName { get; set; }
        public string Status { get; set; }
        public string ProjectDesc { get; set; }
        public int? ProjectOwner { get; set; }
        public DateTime? StartDt { get; set; }
        public DateTime? EndDt { get; set; }
        public DateTime? ActualStartDt { get; set; }
        public DateTime? ActualEndDt { get; set; }
        public bool? IsActive { get; set; }
        public int? EstimateHrs { get; set; }
        public decimal? EstimateCost { get; set; }
        public int? ActualHrs { get; set; }
        public decimal? ActualCost { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? PlantId { get; set; }
        public int? Sponser { get; set; }
        public int ProjectGroupId { get; set; }
        public string ProjectAccess { get; set; }
        public string Deliverables { get; set; }
        public string AdditionalNotes { get; set; }
        public string Approver1Remark { get; set; }
        public string Approver2Remark { get; set; }
        public List<int> AttachmentIds { get; set; } = new List<int>();
        public List<string> Delivarables { get; set; } = new List<string>();

    }
}
