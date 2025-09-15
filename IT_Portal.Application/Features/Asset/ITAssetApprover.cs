namespace IT_Portal.Application.Features.Asset
{
    public class ITAssetApprover
    {
        public string Flag { get; set; }
        public int? ITAssetID { get; set; }
        public int? ITSpareID { get; set; }
        public bool? ISHOD { get; set; }
        public bool? ISRPM { get; set; }
        public int? HOD_ApproverID { get; set; }
        public string? HOD_ApproverRemarks { get; set; }
        public int? RPM_ApproverID { get; set; }
        public string? RPM_ApproverRemarks { get; set; }
        public string? Status { get; set; }
        public int? CreatedBy { get; set; }
    }
}
