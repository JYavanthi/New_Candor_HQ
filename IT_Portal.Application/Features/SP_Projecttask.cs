namespace IT_Portal.Application.Features
{
    public class SP_Projecttask
    {
        public char Flag { get; set; }
        public int? TaskID { get; set; }
        public int? MilestoneID { get; set; }
        public int? ProjectID { get; set; }
        public int? Owner { get; set; }
        public int? EmpID { get; set; }
        public int? AssignTo { get; set; }
        public int? Duration { get; set; }
        public bool? Responsible { get; set; }
        public bool? Accountable { get; set; }
        public bool? Consulted { get; set; }
        public bool? Informed { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDesc { get; set; }
        public string Priority { get; set; }
        public string WorkHours { get; set; }
        public string Status { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? StartDt { get; set; }
        public DateTime? EndDt { get; set; }
        public DateTime? ActualStartDt { get; set; }
        public DateTime? ActualEndDt { get; set; }
        public decimal? PlannedCost { get; set; }
        public decimal? ActualCost { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsSubtask { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? parentTaskId { get; set; }
        public string Projectphase { get; set; }
        public string dependency { get; set; }
        public string addditionalNotes { get; set; }
        public List<int> AttachmentIds { get; set; } = new List<int>();
    }
}
