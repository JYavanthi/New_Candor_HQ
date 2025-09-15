namespace IT_Portal.Domain.IT_Models;

public partial class VwAsset
{
    public int AssetId { get; set; }

    public string? Category { get; set; }

    public string? AssetNo { get; set; }

    public string? HostName { get; set; }

    public string? Location { get; set; }

    public string? BarCode { get; set; }

    public string? Model { get; set; }

    public string? Manufacturer { get; set; }

    public string? PartNo { get; set; }

    public string? SerialNo { get; set; }

    public string? Processor { get; set; }

    public string? Ram { get; set; }

    public string? Hdd { get; set; }

    public string? Config { get; set; }

    public string? IpAddress { get; set; }

    public string? MonitorType { get; set; }

    public string? Make { get; set; }

    public string? Size { get; set; }

    public string? Keyboard { get; set; }

    public string? Mouse { get; set; }

    public string? GxPApplicable { get; set; }

    public DateOnly? SystemRevalidationDate { get; set; }

    public string? UsageType { get; set; }

    public string? InstName { get; set; }

    public string? InstType { get; set; }

    public string? Version { get; set; }

    public string? Software { get; set; }

    public string? EmpNo { get; set; }

    public string? OperatingSystem { get; set; }

    public string? SwVersion { get; set; }

    public string? ProductKey { get; set; }

    public string? AssetState { get; set; }

    public string? NatureofActivities { get; set; }

    public string? Ponumber { get; set; }

    public DateOnly? Podate { get; set; }

    public string? InvoiceNumber { get; set; }

    public DateOnly? InvoiceDate { get; set; }

    public string? SupplierName { get; set; }

    public string? Value { get; set; }

    public DateOnly? WarrantyExpiration { get; set; }

    public DateOnly? PreventiveMaintenace { get; set; }

    public DateOnly? InstallationDate { get; set; }

    public string? InstallationType { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? OtherSoftwareName { get; set; }

    public string? OtherVersion { get; set; }

    public string? OtherProductKey { get; set; }

    public DateOnly? OtherExpiryOn { get; set; }

    public string? Remarks { get; set; }

    public DateOnly? DateOfIssue { get; set; }

    public string? Ppm { get; set; }

    public string? MachineLife { get; set; }

    public string? Cpp { get; set; }

    public string? AssetType { get; set; }

    public string? EmpAd { get; set; }

    public string? SizeType { get; set; }

    public string? RamSize { get; set; }

    public string? ComDept { get; set; }

    public string? ComFloor { get; set; }

    public string? ReplacementType { get; set; }

    public string? ViewStatusApprover { get; set; }

    public DateTime? StatusApprovedDate { get; set; }

    public int? ReportViewStatus { get; set; }
}
