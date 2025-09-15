namespace IT_Portal.Application.Features
{
    public class SPIssueResolution
    {
        public string Flag { get; set; }

        public int IssueId { get; set; }
        public string Status { get; set; }

        public DateTime? ProposedResolutionOn { get; set; }

        public DateTime? ResolutionDt { get; set; }

        public string? ResolutionRemarks { get; set; }
    }
}
