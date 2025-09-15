namespace IT_Portal.Application.Features
{
    public class ProjectClosure
    {
        public string Flag { get; set; }
        public int ClosureID { get; set; }
        public int ProjectID { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public string Attachment { get; set; }
        public string LessonsLearnt { get; set; }
        public string Task { get; set; }
        public string Category { get; set; }
        public string ProblemsStatement { get; set; }
        public string Impact { get; set; }
        public string Recommendation { get; set; }
        public string Feedback { get; set; }
        public bool IsSponsor { get; set; }
        public int CreatedBy { get; set; }
        public List<int> AttachmentIds { get; set; } = new List<int>();
    }
}
