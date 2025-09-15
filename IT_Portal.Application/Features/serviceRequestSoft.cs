namespace IT_Portal.Application.Features
{
    public class serviceRequestSoft
    {
        public int SRID { get; set; }
        public string SRCode { get; set; }
        public int SupportID { get; set; }
        public string SRSelectedfor { get; set; }
        public int? SRRaisedBy { get; set; }
        public DateTime SRDate { get; set; }
        public string SRShotDesc { get; set; }
        public string SRDesc { get; set; }
        public int? SRRaiseFor { get; set; }
        public string GuestEmployeeId { get; set; }
        public string GuestName { get; set; }
        public string GuestEmail { get; set; }
        public string GuestContactNo { get; set; }
        public string GuestReportingManagerEmployeeId { get; set; }
        public string Type { get; set; }
        public string GuestCompany { get; set; }
        public int? PlantID { get; set; }
        public int? AssetID { get; set; }
        public int? CategoryID { get; set; }
        public int? CategoryTypID { get; set; }
        public int? Priority { get; set; }
        public string Source { get; set; }
        public string Attachment { get; set; }
        public string Status { get; set; }
        public int? AssignedTo { get; set; }
        public int? AssignedBy { get; set; }
        public DateTime? AssignedOn { get; set; }
        public string Remarks { get; set; }
        public DateTime? ProposedResolutionOn { get; set; }
        public int? CreatedBy { get; set; }

    }
}
