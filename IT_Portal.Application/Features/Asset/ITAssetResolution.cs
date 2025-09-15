namespace IT_Portal.Application.Features.Asset
{
    public class ITAssetResolution
    {
        public string Flag { get; set; }
        public int? ITAssetID { get; set; }
        public int? ITSpareID { get; set; }
        public string? UserRemarks { get; set; }
        public DateTime? ProposedResolDt { get; set; }
        public DateTime? ResolDt { get; set; }
        public string? Description { get; set; }
        public int? OnHoldReason { get; set; }
        public string? Remarks { get; set; }
        public int? AssignedTo { get; set; }
        public int? AssignedBy { get; set; }
        public string? Status { get; set; }
        public int? CreatedBy { get; set; }
    }
}
