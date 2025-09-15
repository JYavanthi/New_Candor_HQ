namespace IT_Portal.Application.Features
{
    public class SPProjectChecklist
    {
        public string Flag { get; set; }
        public int checkListId { get; set; }
        public string checkListTital { get; set; }
        public int TaskId { get; set; }
        public int ProjectMgmtID { get; set; }
        public int SubTaskId { get; set; }
        public int MileStoneId { get; set; }
        public string ProjectLevel { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDt { get; set; }
        public List<int> AttachmentIds { get; set; } = new List<int>();
    }
}
