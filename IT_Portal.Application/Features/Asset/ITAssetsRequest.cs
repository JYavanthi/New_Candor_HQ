namespace IT_Portal.Application.Features.Asset
{
    public class ITAssetsRequest
    {
        public char? Flag { get; set; }
        public int ITAssetID { get; set; }

        public string? Requesttype { get; set; }

        public int? RequestedBY { get; set; }

        public int? RequestedFor { get; set; }

        public string? SelectedFor { get; set; }
        public int? PlantID { get; set; }
        public int? SupportID { get; set; }

        public string? EmpType { get; set; }

        public int? Guest_Id { get; set; }

        public string? Guest_Name { get; set; }

        public string? Guest_Email { get; set; }

        public int? Guest_RManagerId { get; set; }

        public int? Guest_ContactNo { get; set; }

        public string? Assettype { get; set; }

        public int? Emp_Id { get; set; }

        public string? GxpReq { get; set; }

        public string? ExistingAsset { get; set; }

        public string? AssetModel { get; set; }

        public string? AssetSerialNo { get; set; }

        public DateTime? AssetsWarranty_EndDt { get; set; }

        public string? SuggModel { get; set; }

        public string? Specs_Requirements { get; set; }

        public int? ApproximateINR { get; set; }

        public string? Justification { get; set; }

        public string? HOD_Approval { get; set; }

        public bool? IsActive { get; set; }
        public string? Status { get; set; }

        public int? CreatedBy { get; set; }
    }
}
