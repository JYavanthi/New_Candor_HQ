namespace IT_Portal.Application.Features
{
    public class SPProjectMilestone
    {
        public char Flag { get; set; }
        public int? ProjMilestoneID { get; set; }
        public int ProjectID { get; set; }
        public string MilestoneTitle { get; set; }
        public string MilestoneDesc { get; set; }
        public string MilestoneStatus { get; set; }
        public int Owner { get; set; }
        public string Priority { get; set; }
        public DateTime? StartDt { get; set; }
        public DateTime? EndDt { get; set; }
        public DateTime? ActualStartDt { get; set; }
        public DateTime? ActualEndDt { get; set; }
        public DateTime? FinishStartDt { get; set; }
        public DateTime? FinishEndDt { get; set; }
        public DateTime? ActualFinishStartDt { get; set; }
        public DateTime? ActualFinishEndDt { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
    }


}
