namespace IT_Portal.Domain.IT_Models;

public partial class NpdMasterDetail
{
    public int Id { get; set; }

    public string? RequestNo { get; set; }

    public string? RequestedBy { get; set; }

    public DateTime? RequestDate { get; set; }

    public string? Location { get; set; }

    public string? Division { get; set; }

    public string? GenericName { get; set; }

    public string? Composition { get; set; }

    public string? DosageForm { get; set; }

    public string? DosageDetails { get; set; }

    public string? BrandName { get; set; }

    public string? BrandSearch { get; set; }

    public string? BrandValue { get; set; }

    public string? Strength { get; set; }

    public string? ProposedPacking { get; set; }

    public string? PackingConfig { get; set; }

    public string? SalePack { get; set; }

    public string? SaleunitPackSize { get; set; }

    public string? SaleunitPerCarton { get; set; }

    public string? SaleunitsPerShipper { get; set; }

    public string? PhysicianSample { get; set; }

    public string? PhysicianSampleQuantity { get; set; }

    public string? CompititorSample { get; set; }

    public string? SpecificFormulationDevelopmentRequirement { get; set; }

    public string? LaunchReq { get; set; }

    public string? PostLaunchReq { get; set; }

    public string? MarketShare { get; set; }

    public string? SalesForecastUnitsMonth1 { get; set; }

    public string? SalesForecastUnitsMonth2 { get; set; }

    public string? SalesForecastUnitsMonth3 { get; set; }

    public string? SalesForecastUnitsQtr2 { get; set; }

    public string? SalesForecastUnitsQtr3 { get; set; }

    public string? SalesForecastUnitsQtr4 { get; set; }

    public string? SalesForecastUnitsYear1 { get; set; }

    public string? SalesForecastUnitsYear2 { get; set; }

    public string? SalesForecastUnitsYear3 { get; set; }

    public string? SalesForecastValueYear1 { get; set; }

    public string? SalesForecastValueYear2 { get; set; }

    public string? SalesForecastValueYear3 { get; set; }

    public string? MarketInfoIndia { get; set; }

    public string? MarketInfoGlobal { get; set; }

    public string? CompititorBrand { get; set; }

    public string? Growth { get; set; }

    public string? TotalMarketDrug { get; set; }

    public string? CompititorBrandsCount { get; set; }

    public string? ProposedmicroPrice { get; set; }

    public string? ExpectedMarketShareYear1 { get; set; }

    public string? ExpectedMarketShareYear2 { get; set; }

    public string? ExpectedMarketShareYear3 { get; set; }

    public string? JustificationLaunch { get; set; }

    public string? AdditionalInformationIfRequired { get; set; }

    public string? OriginatorBrandSales { get; set; }

    public string? Attachments { get; set; }

    public DateTime? SubmitedDate { get; set; }

    public string? FinalDocNo { get; set; }

    public DateTime? FinalDocDate { get; set; }

    public string? FinalSerialNo { get; set; }

    public string? ApprvrStatus { get; set; }

    public string? ApproveType { get; set; }

    public string? Stage { get; set; }

    public int? NpdHodInitialstageSubmitFlag { get; set; }

    public int? NpdMedicalDeptDetailsSubmitFlag { get; set; }

    public int? NpdIprDeptDetailsSubmitFlag { get; set; }

    public int? NpdCqaDeptDetailsSubmitFlag { get; set; }

    public int? NpdSupplychainDeptDetailsSubmitFlag { get; set; }

    public int? NpdRndDeptDetailsSubmitFlag { get; set; }

    public int? NpdStrategicDeptDetailsSubmitFlag { get; set; }

    public int? NpdDistributionDeptDetailsSubmitFlag { get; set; }

    public int? NpdOtherDeptDetailsSubmitFlag { get; set; }

    public int? NpdHodFinalstageSubmitFlag { get; set; }

    public int? NpdCmdDetailsSubmitFlag { get; set; }
}
