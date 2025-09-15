namespace IT_Portal.Application.Features
{
    public class SPCrapprove
    {
        public string? Flag { get; set; }

        public int CRApproverID { get; set; }

        public int PlantID { get; set; }

        public int SupportID { get; set; }
        public int ApproverLevel { get; set; }

        public int CRID { get; set; }

        public string? Stage { get; set; }

        public int ApproverID { get; set; }

        public DateTime ApprovedDt { get; set; }

        public string? Remarks { get; set; }

        public string? Comments { get; set; }

        public string? Status { get; set; }

        public string? Attachment { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDt { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedDt { get; set; }
    }
}
