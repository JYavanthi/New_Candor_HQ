namespace IT_Portal.Application.Features
{
    public class EbulkIssueStatusChange
    {
        public List<int> issueId { get; set; }
        public string status { get; set; }
        public string Message { get; set; }
        public int ModifiedBy { get; set; }
        public int assignTo { get; set; }
        public int reasonID { get; set; }
    }
}
