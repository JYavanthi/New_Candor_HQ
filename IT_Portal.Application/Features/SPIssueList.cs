namespace IT_Portal.Application.Features
{
    public class SPIssueList
    {
        public string Flag { get; set; }

        public int IssueId { get; set; }
        public String? IssueSelectedfor { get; set; }

        public int? IssueRaisedBy { get; set; }

        public DateTime IssueDate { get; set; }

        public string IssueShotDesc { get; set; } = null!;

        public string IssueDesc { get; set; } = null!;

        public int? IssueRaiseFor { get; set; }

        public string? IssueForGuest { get; set; }

        public int? GuestEmployeeId { get; set; }
        public string? GuestName { get; set; }
        public string? GuestEmail { get; set; }
        public string? GuestContactNo { get; set; }
        public string? GuestReportingManagerEmployeeId { get; set; }
        public string? Type { get; set; }

        public string? GuestCompany { get; set; }

        public int? PlantId { get; set; }

        public int? AssetId { get; set; }

        public int? CategoryId { get; set; }

        public int? CategoryTypId { get; set; }

        public int? Priority { get; set; }

        public string? Source { get; set; }

        public string? Attachment { get; set; }

        public string? Status { get; set; }

        public int? AssignedTo { get; set; }

        public int? AssignedBy { get; set; }

        public DateTime? AssignedOn { get; set; }

        public string? Remarks { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedDt { get; set; }

        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }

        public DateTime? ProposedResolutionOn { get; set; }
        public DateTime? ResolutionDt { get; set; }
        public List<int> AttachmentIds { get; set; } = new List<int>();
        public int? reasonID { get; set; }

    }
}
