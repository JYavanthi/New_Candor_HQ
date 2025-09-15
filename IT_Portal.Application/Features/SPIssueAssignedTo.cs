namespace IT_Portal.Application.Features
{
    public class SPIssueAssignedTo
    {
        public string Flag { get; set; }

        public int IssueId { get; set; }

        public int? AssignedTo { get; set; }

        public int? AssignedBy { get; set; }
        public string Status { get; set; }

    }
}
