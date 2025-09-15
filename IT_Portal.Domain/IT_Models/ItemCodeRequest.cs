namespace IT_Portal.Domain.IT_Models;

public partial class ItemCodeRequest
{
    public int Id { get; set; }

    public string? RequestNo { get; set; }

    public DateTime? RequestDate { get; set; }

    public string? LocationId { get; set; }

    public string? StorageLocationId { get; set; }

    public string? MaterialTypeId { get; set; }

    public string? MaterialShortName { get; set; }

    public string? MaterialLongName { get; set; }

    public string? MaterialGroupId { get; set; }

    public string? PharmacopName { get; set; }

    public string? PharmacopGrade { get; set; }

    public string? GenericName { get; set; }

    public string? Synonym { get; set; }

    public string? PharmacopSpecification { get; set; }

    public string? IsDmfMaterial { get; set; }

    public int? DmfGradeId { get; set; }

    public string? MaterialGrade { get; set; }

    public string? CosGradeAndNo { get; set; }

    public string? AdditionalTest { get; set; }

    public string? CountryId { get; set; }

    public string? CustomerName { get; set; }

    public string? ToBeUsedInProducts { get; set; }

    public string? IsVendorSpecificMaterial { get; set; }

    public string? MfgrName { get; set; }

    public string? SiteOfManufacture { get; set; }

    public string? TempCondition { get; set; }

    public string? StorageCondition { get; set; }

    public int? ShelfLife { get; set; }

    public string? ShelfLifeType { get; set; }

    public string? DutyElement { get; set; }

    public int? RetestDays { get; set; }

    public string? RetestDaysType { get; set; }

    public string? ValuationClass { get; set; }

    public string? ApproximateValue { get; set; }

    public string? UnitOfMeasId { get; set; }

    public string? SalesUnitOfMeasId { get; set; }

    public string? PurchaseGroupId { get; set; }

    public string? SapCodeNo { get; set; }

    public string? SapCodeExists { get; set; }

    public DateTime? SapCreationDate { get; set; }

    public string? SapCreatedBy { get; set; }

    public string? RequestedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public string? Attachements { get; set; }

    public string? Type { get; set; }

    public string? PackingMaterialGroup { get; set; }

    public string? TypeOfMaterial { get; set; }

    public string? ArtworkNo { get; set; }

    public string? IsArtworkRevision { get; set; }

    public string? ExistingSapItemCode { get; set; }

    public string? FgSapProductCode { get; set; }

    public double? StandardBatchSize { get; set; }

    public string? StdBatchSizeUom { get; set; }

    public string? BatchCode { get; set; }

    public string? MfrNo { get; set; }

    public DateTime? MfrDate { get; set; }

    public double? TargetWeight { get; set; }

    public string? SaleableOrSample { get; set; }

    public string? DomesticOrExports { get; set; }

    public string? SalesPackId { get; set; }

    public string? PackTypeId { get; set; }

    public string? DivisionId { get; set; }

    public string? TherapeuticSegmentId { get; set; }

    public string? BrandId { get; set; }

    public string? StrengthId { get; set; }

    public string? ProdInspMemo { get; set; }

    public double? GrossWeight { get; set; }

    public double? NetWeight { get; set; }

    public string? WeightUom { get; set; }

    public string? Dimension { get; set; }

    public string? MaterialUsedIn { get; set; }

    public string? IsEquipment { get; set; }

    public string? IsSpare { get; set; }

    public string? IsNew { get; set; }

    public string? IsNewEquipment { get; set; }

    public string? IsNewFurniture { get; set; }

    public string? IsNewFacility { get; set; }

    public string? IsSpareRequired { get; set; }

    public string? EquipmentName { get; set; }

    public string? EquipmentMake { get; set; }

    public string? ComponentMake { get; set; }

    public string? OemPartNo { get; set; }

    public string? PrNumber { get; set; }

    public string? PoNumber { get; set; }

    public string? UtilizingDept { get; set; }

    public string? DetailedJustification { get; set; }

    public int? PurposeId { get; set; }

    public string? IsSasFormAvailable { get; set; }

    public string? ServiceCateId { get; set; }

    public string? MachineName { get; set; }

    public string? ManufacturedAt { get; set; }

    public string? DetailedSpecification { get; set; }

    public string? ApproveType { get; set; }

    public string? Url { get; set; }

    public string? ReportUrl { get; set; }

    public string? ReasonType { get; set; }

    public string? ExistingItemCode { get; set; }

    public DateTime? ApproveDate { get; set; }

    public string? LastApprover { get; set; }

    public string? PendingApprover { get; set; }

    public string? TaxClassification { get; set; }

    public string? MaterialPricing { get; set; }

    public string? PackSize { get; set; }

    public string? IsAsset { get; set; }

    public string? Moc { get; set; }

    public string? Rating { get; set; }

    public string? Range { get; set; }

    public string? RejectedFlag { get; set; }

    public string? MessageType { get; set; }

    public string? RecordStatus { get; set; }

    public string? EquipIntended { get; set; }

    public string? Storage { get; set; }

    public string? SapStatus { get; set; }

    public DateTime? SapApprovedDate { get; set; }

    public string? SapMessage { get; set; }

    public string? SapAppStatus { get; set; }

    public string? Message { get; set; }

    public string? SapMaterialCodeLists { get; set; }

    public string? SapCosGradeNo { get; set; }

    public string? SapDutyElement { get; set; }

    public string? SapMfgrName { get; set; }

    public string? SapSiteOfManufacture { get; set; }

    public string? ItemAvailable { get; set; }

    public string? SpecificationNo { get; set; }

    public string? MatchSpecification { get; set; }

    public string? SpecificationAdditionalTest { get; set; }

    public string? ExistDmfno { get; set; }

    public string? AvailableDmf { get; set; }

    public string? ItemFromMultipleVendors { get; set; }

    public string? RequiredDmf { get; set; }

    public string? ItemspecificVendor { get; set; }

    public string? VendorReqMatch { get; set; }

    public string? ReqMeetVendorReq { get; set; }

    public string? ExistLegacyCode { get; set; }

    public string? NewLegacyCode { get; set; }

    public string? Company { get; set; }

    public string? QcSpecification { get; set; }

    public string? FirstAlphaRaw { get; set; }

    public string? ReasonForrequisition { get; set; }

    public string? HsnCode { get; set; }

    public string? SapMaterialTypeId { get; set; }

    public string? ReasonForRevision { get; set; }

    public string? ExistingSapDescription { get; set; }

    public string? RevisedArtworkCode { get; set; }

    public string? ApiName { get; set; }

    public string? ApiVendorName { get; set; }

    public string? ManufactureAddress { get; set; }

    public string? VendorSpecific { get; set; }

    public string? ExcepientsDetails { get; set; }

    public string? Market { get; set; }

    public string? ProductName { get; set; }

    public string? Qualitycomplyspecification { get; set; }

    public string? ItemCodeProposed { get; set; }

    public string? ItemCodeExisting { get; set; }

    public string? ExcipientsCheck { get; set; }

    public string? ImmediatePackMatCheck { get; set; }

    public string? ImmediatePackMat { get; set; }

    public string? ManufactMatch { get; set; }

    public string? ManufacturingFormula { get; set; }

    public string? PunchesOrDiesMatch { get; set; }

    public string? PunchesOrDies { get; set; }

    public string? TestingSpecMatch { get; set; }

    public string? TestingSpecification { get; set; }

    public string? SameMarCustCount { get; set; }

    public string? ProductMatch { get; set; }

    public string? MarketCustCount { get; set; }

    public string? FinishedProductCode { get; set; }

    public string? Role { get; set; }

    public string? SapCodeExistCore { get; set; }

    public string? SapCodeExistCoated { get; set; }

    public string? SapCodeCore { get; set; }

    public string? SapCodeCoated { get; set; }

    public string? TargetWeightCore { get; set; }

    public string? TargetWeightCoated { get; set; }

    public string? IsCoated { get; set; }

    public string? NewCustomerName { get; set; }

    public string? NewPackSize { get; set; }

    public string? SpecialApi { get; set; }

    public string? SerializationType { get; set; }

    public string? SerializedFromDate { get; set; }

    public string? GlobalSerReq { get; set; }

    public int? SapStatusFlag { get; set; }

    public string? Molecules { get; set; }

    public string? VendorDetails { get; set; }

    public DateTime? ArtWorkValidity { get; set; }

    public string? AppArtAttachment { get; set; }

    public string? ColArtAttachment { get; set; }

    public string? DiaAttachment { get; set; }

    public string? ShadeCardAttachment { get; set; }

    public string? TempConditionother { get; set; }

    public string? StorageConditionother { get; set; }

    public string? EMicroRefReqNo { get; set; }
}
