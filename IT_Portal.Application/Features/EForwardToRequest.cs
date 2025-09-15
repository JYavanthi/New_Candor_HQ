namespace IT_Portal.Application.Features
{
    public class EForwardToRequest
    {
        public string Flag { get; set; }
        public int IssueId { get; set; }
        public int? AssignedTo { get; set; }
        public int? AssignedBy { get; set; }
        public DateTime? AssignedOn { get; set; }
        public string Status { get; set; }
        public string resolutionReamrk { get; set; }
    }
}
