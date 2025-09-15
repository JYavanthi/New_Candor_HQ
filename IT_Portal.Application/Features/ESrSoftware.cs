namespace IT_Portal.Application.Features
{
    public class ESrSoftwareResolution
    {
        public char Flag { get; set; }
        public int? SRResolID { get; set; }
        public int SRID { get; set; }
        public string ResolRemarks { get; set; }
        public string UserRemarks { get; set; }
        public DateTime? ProposedResolDt { get; set; }
        public DateTime? ResolDt { get; set; }
        public string Description { get; set; }
        public int OnHoldReason { get; set; }
        public string Status { get; set; }
        public string? empNo { get; set; }
        public int supportId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }

    }



    public class SRApprover
    {
        public string Flag { get; set; }
        public int SRApproverID { get; set; }
        public int PlantID { get; set; }
        public int SupportID { get; set; }
        public int SRID { get; set; }
        public int ApproverLevel { get; set; }
        public int Stage { get; set; }
        public int ApproverID { get; set; }
        public DateTime? ApprovedDt { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public string Attachment { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDt { get; set; } // Nullable if not always provided
    }


    public class ESRAssignTo
    {
        public int SRID { get; set; }
        public string AssignedBy { get; set; }
        public string AssignedTo { get; set; }
        public string ModifiedBy { get; set; }
        public string Status { get; set; }
    }

}
