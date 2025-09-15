using System;
using System.Collections.Generic;
using IT_Portal.Persistence.IT_Models;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.Persistence.DatabaseContext;

public partial class MicroLabsDevContext : DbContext
{
    public MicroLabsDevContext()
    {
    }

    public MicroLabsDevContext(DbContextOptions<MicroLabsDevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AboutCompanydetail> AboutCompanydetails { get; set; }

    public virtual DbSet<AbsentIntimation> AbsentIntimations { get; set; }

    public virtual DbSet<AccClerkM> AccClerkMs { get; set; }

    public virtual DbSet<AccountGroupM> AccountGroupMs { get; set; }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<ActivityType> ActivityTypes { get; set; }

    public virtual DbSet<AdditionalVisitor> AdditionalVisitors { get; set; }

    public virtual DbSet<AddrTypM> AddrTypMs { get; set; }

    public virtual DbSet<AllRequest> AllRequests { get; set; }

    public virtual DbSet<AllRequestHistory> AllRequestHistories { get; set; }

    public virtual DbSet<AllertApplicable> AllertApplicables { get; set; }

    public virtual DbSet<Allertbox> Allertboxes { get; set; }

    public virtual DbSet<AllowanceMapping> AllowanceMappings { get; set; }

    public virtual DbSet<AllowanceMaster> AllowanceMasters { get; set; }

    public virtual DbSet<AmcvisitDetail> AmcvisitDetails { get; set; }

    public virtual DbSet<ApiManufacturer> ApiManufacturers { get; set; }

    public virtual DbSet<ApiMaster> ApiMasters { get; set; }

    public virtual DbSet<AppointmentAddressDetail> AppointmentAddressDetails { get; set; }

    public virtual DbSet<AppointmentAssetDetail> AppointmentAssetDetails { get; set; }

    public virtual DbSet<AppointmentAttachmentDetail> AppointmentAttachmentDetails { get; set; }

    public virtual DbSet<AppointmentEducationDetail> AppointmentEducationDetails { get; set; }

    public virtual DbSet<AppointmentFamilyDetail> AppointmentFamilyDetails { get; set; }

    public virtual DbSet<AppointmentLanguageDetail> AppointmentLanguageDetails { get; set; }

    public virtual DbSet<AppointmentNominationDetail> AppointmentNominationDetails { get; set; }

    public virtual DbSet<AppointmentOfficialDetail> AppointmentOfficialDetails { get; set; }

    public virtual DbSet<AppointmentPersonalDetail> AppointmentPersonalDetails { get; set; }

    public virtual DbSet<AppointmentSalaryDetail> AppointmentSalaryDetails { get; set; }

    public virtual DbSet<AppointmentSalaryHeadDetail> AppointmentSalaryHeadDetails { get; set; }

    public virtual DbSet<AppointmentSalaryHeadPayableDetail> AppointmentSalaryHeadPayableDetails { get; set; }

    public virtual DbSet<AppointmentStatutoryDetail> AppointmentStatutoryDetails { get; set; }

    public virtual DbSet<AppointmentWorkExperienceDetail> AppointmentWorkExperienceDetails { get; set; }

    public virtual DbSet<AppraisalDetail> AppraisalDetails { get; set; }

    public virtual DbSet<ApprovalTemplate> ApprovalTemplates { get; set; }

    public virtual DbSet<ApprovalTransaction> ApprovalTransactions { get; set; }

    public virtual DbSet<Approver> Approvers { get; set; }

    public virtual DbSet<AssesmentDetail> AssesmentDetails { get; set; }

    public virtual DbSet<AssesmentMaster> AssesmentMasters { get; set; }

    public virtual DbSet<AssetTypeMaster> AssetTypeMasters { get; set; }

    public virtual DbSet<AttendanceMaster> AttendanceMasters { get; set; }

    public virtual DbSet<AttendanceProcessLog> AttendanceProcessLogs { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<Band> Bands { get; set; }

    public virtual DbSet<BankAccType> BankAccTypes { get; set; }

    public virtual DbSet<BankTypeM> BankTypeMs { get; set; }

    public virtual DbSet<BellCurveMaster> BellCurveMasters { get; set; }

    public virtual DbSet<BelongingsChecklist> BelongingsChecklists { get; set; }

    public virtual DbSet<BookPurposeMaster> BookPurposeMasters { get; set; }

    public virtual DbSet<BookingParticipant> BookingParticipants { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<CabBooking> CabBookings { get; set; }

    public virtual DbSet<CalendarMaster> CalendarMasters { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryTyp> CategoryTyps { get; set; }

    public virtual DbSet<ChangeRequest> ChangeRequests { get; set; }

    public virtual DbSet<ChangeRequestHistory> ChangeRequestHistories { get; set; }

    public virtual DbSet<ChangeShiftLog> ChangeShiftLogs { get; set; }

    public virtual DbSet<Checklist> Checklists { get; set; }

    public virtual DbSet<ChecklistConfig> ChecklistConfigs { get; set; }

    public virtual DbSet<ChecklistItem> ChecklistItems { get; set; }

    public virtual DbSet<Classification> Classifications { get; set; }

    public virtual DbSet<CompOt> CompOts { get; set; }

    public virtual DbSet<CompOtRule> CompOtRules { get; set; }

    public virtual DbSet<CompOtSap> CompOtSaps { get; set; }

    public virtual DbSet<CompanyMaster> CompanyMasters { get; set; }

    public virtual DbSet<CompetencyMaster> CompetencyMasters { get; set; }

    public virtual DbSet<ContractEmpAttachment> ContractEmpAttachments { get; set; }

    public virtual DbSet<ContractEmployeeApprover> ContractEmployeeApprovers { get; set; }

    public virtual DbSet<ContractEmployeeM> ContractEmployeeMs { get; set; }

    public virtual DbSet<ContractManpowerPlanning> ContractManpowerPlannings { get; set; }

    public virtual DbSet<ContractorMaster> ContractorMasters { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Crapprover> Crapprovers { get; set; }

    public virtual DbSet<CrapproverHistory> CrapproverHistories { get; set; }

    public virtual DbSet<CrexecutionPlan> CrexecutionPlans { get; set; }

    public virtual DbSet<CrexecutionPlanHistory> CrexecutionPlanHistories { get; set; }

    public virtual DbSet<Crfollowup> Crfollowups { get; set; }

    public virtual DbSet<Crlesson> Crlessons { get; set; }

    public virtual DbSet<Crrelease> Crreleases { get; set; }

    public virtual DbSet<Crtemplate> Crtemplates { get; set; }

    public virtual DbSet<CrtemplateDtl> CrtemplateDtls { get; set; }

    public virtual DbSet<CtcFormula> CtcFormulas { get; set; }

    public virtual DbSet<CtcSlab> CtcSlabs { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<CustomerGroup> CustomerGroups { get; set; }

    public virtual DbSet<CustomerMasterChange> CustomerMasterChanges { get; set; }

    public virtual DbSet<CustomerMasterM> CustomerMasterMs { get; set; }

    public virtual DbSet<DepartmentMaster> DepartmentMasters { get; set; }

    public virtual DbSet<DesignationMaster> DesignationMasters { get; set; }

    public virtual DbSet<DetailStructureInput> DetailStructureInputs { get; set; }

    public virtual DbSet<DevAccount> DevAccounts { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<Device1> Devices1 { get; set; }

    public virtual DbSet<DeviceDetail> DeviceDetails { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Dmaction> Dmactions { get; set; }

    public virtual DbSet<DmactionItem> DmactionItems { get; set; }

    public virtual DbSet<Dmapprover> Dmapprovers { get; set; }

    public virtual DbSet<DmdiscrepancyCategory> DmdiscrepancyCategories { get; set; }

    public virtual DbSet<DmenvironmentValidation> DmenvironmentValidations { get; set; }

    public virtual DbSet<DmfGrade> DmfGrades { get; set; }

    public virtual DbSet<DmimpactOnCategory> DmimpactOnCategories { get; set; }

    public virtual DbSet<DmrequestType> DmrequestTypes { get; set; }

    public virtual DbSet<DmrequirementDetail> DmrequirementDetails { get; set; }

    public virtual DbSet<Dmstatus> Dmstatuses { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<DossierTypeOfRegistrationTable> DossierTypeOfRegistrationTables { get; set; }

    public virtual DbSet<EducationCM> EducationCMs { get; set; }

    public virtual DbSet<EducationLM> EducationLMs { get; set; }

    public virtual DbSet<Emactivity> Emactivities { get; set; }

    public virtual DbSet<EmailNotificationMapping> EmailNotificationMappings { get; set; }

    public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }

    public virtual DbSet<EmpCal> EmpCals { get; set; }

    public virtual DbSet<EmpCatMapping> EmpCatMappings { get; set; }

    public virtual DbSet<EmpCategoryMaster> EmpCategoryMasters { get; set; }

    public virtual DbSet<EmpHolidayCalendarMapping> EmpHolidayCalendarMappings { get; set; }

    public virtual DbSet<EmpInOut> EmpInOuts { get; set; }

    public virtual DbSet<EmpInOutStatus> EmpInOutStatuses { get; set; }

    public virtual DbSet<EmpManualSwipe> EmpManualSwipes { get; set; }

    public virtual DbSet<EmpOfficialInfo> EmpOfficialInfos { get; set; }

    public virtual DbSet<EmpPaygroupMapping> EmpPaygroupMappings { get; set; }

    public virtual DbSet<EmpShiftLateRule> EmpShiftLateRules { get; set; }

    public virtual DbSet<EmpShiftMaster> EmpShiftMasters { get; set; }

    public virtual DbSet<EmpShiftReference> EmpShiftReferences { get; set; }

    public virtual DbSet<EmpShiftRegister> EmpShiftRegisters { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeAddress> EmployeeAddresses { get; set; }

    public virtual DbSet<EmployeeAppraisal> EmployeeAppraisals { get; set; }

    public virtual DbSet<EmployeeAppraisalSalary> EmployeeAppraisalSalaries { get; set; }

    public virtual DbSet<EmployeeApproval> EmployeeApprovals { get; set; }

    public virtual DbSet<EmployeeAttachment> EmployeeAttachments { get; set; }

    public virtual DbSet<EmployeeConfirmation> EmployeeConfirmations { get; set; }

    public virtual DbSet<EmployeeDocument> EmployeeDocuments { get; set; }

    public virtual DbSet<EmployeeDummy> EmployeeDummies { get; set; }

    public virtual DbSet<EmployeeDummy1> EmployeeDummy1s { get; set; }

    public virtual DbSet<EmployeeInitialAppraisalDetail> EmployeeInitialAppraisalDetails { get; set; }

    public virtual DbSet<EmployeeMaster> EmployeeMasters { get; set; }

    public virtual DbSet<EmployeeMaster1> EmployeeMaster1s { get; set; }

    public virtual DbSet<EmployeeOtherDetail> EmployeeOtherDetails { get; set; }

    public virtual DbSet<EmployeePayroll> EmployeePayrolls { get; set; }

    public virtual DbSet<EmployeePpcMapping> EmployeePpcMappings { get; set; }

    public virtual DbSet<EmployeeResignationDetail> EmployeeResignationDetails { get; set; }

    public virtual DbSet<EmployeeRetirementDetail> EmployeeRetirementDetails { get; set; }

    public virtual DbSet<EmployeeSalaryDetail> EmployeeSalaryDetails { get; set; }

    public virtual DbSet<EmployeeSalaryHeadDetail> EmployeeSalaryHeadDetails { get; set; }

    public virtual DbSet<EmployeeSalaryHeadPayableDetail> EmployeeSalaryHeadPayableDetails { get; set; }

    public virtual DbSet<EmployeeSalaryHistory> EmployeeSalaryHistories { get; set; }

    public virtual DbSet<EmployeeTerminationDetail> EmployeeTerminationDetails { get; set; }

    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

    public virtual DbSet<ErrorMaster> ErrorMasters { get; set; }

    public virtual DbSet<EscalationCalendar> EscalationCalendars { get; set; }

    public virtual DbSet<EssApprover> EssApprovers { get; set; }

    public virtual DbSet<EssCancelAppr> EssCancelApprs { get; set; }

    public virtual DbSet<EssRestrictionRule> EssRestrictionRules { get; set; }

    public virtual DbSet<EssTemplate> EssTemplates { get; set; }

    public virtual DbSet<ExpVendordetail> ExpVendordetails { get; set; }

    public virtual DbSet<ExpenseCategory> ExpenseCategories { get; set; }

    public virtual DbSet<ExternalUserIdmaster> ExternalUserIdmasters { get; set; }

    public virtual DbSet<FeedbackMaster> FeedbackMasters { get; set; }

    public virtual DbSet<FileUpload> FileUploads { get; set; }

    public virtual DbSet<FlexibleTimingsMaster> FlexibleTimingsMasters { get; set; }

    public virtual DbSet<Flow> Flows { get; set; }

    public virtual DbSet<FlowApprover> FlowApprovers { get; set; }

    public virtual DbSet<FlowTask> FlowTasks { get; set; }

    public virtual DbSet<FlowTaskApprover> FlowTaskApprovers { get; set; }

    public virtual DbSet<FormMaster> FormMasters { get; set; }

    public virtual DbSet<GateEntryD> GateEntryDs { get; set; }

    public virtual DbSet<GateEntryM> GateEntryMs { get; set; }

    public virtual DbSet<GateOutwardD> GateOutwardDs { get; set; }

    public virtual DbSet<GateOutwardM> GateOutwardMs { get; set; }

    public virtual DbSet<GePoIn> GePoIns { get; set; }

    public virtual DbSet<GePoMaterialIn> GePoMaterialIns { get; set; }

    public virtual DbSet<GePoMaterialOut> GePoMaterialOuts { get; set; }

    public virtual DbSet<GePoOut> GePoOuts { get; set; }

    public virtual DbSet<GeStoIn> GeStoIns { get; set; }

    public virtual DbSet<GeStoMaterialIn> GeStoMaterialIns { get; set; }

    public virtual DbSet<GenericName> GenericNames { get; set; }

    public virtual DbSet<GenericUserIdemployee> GenericUserIdemployees { get; set; }

    public virtual DbSet<GenericUserIdmaster> GenericUserIdmasters { get; set; }

    public virtual DbSet<GetSlalist> GetSlalists { get; set; }

    public virtual DbSet<GetUserAccessForm> GetUserAccessForms { get; set; }

    public virtual DbSet<GigoapprovalTransaction> GigoapprovalTransactions { get; set; }

    public virtual DbSet<Gigoapprover> Gigoapprovers { get; set; }

    public virtual DbSet<GigoreasonMaster> GigoreasonMasters { get; set; }

    public virtual DbSet<GlobalSerialization> GlobalSerializations { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<GuestHouseBooking> GuestHouseBookings { get; set; }

    public virtual DbSet<GuestHouseBookingParticipant> GuestHouseBookingParticipants { get; set; }

    public virtual DbSet<GuestHouseFacility> GuestHouseFacilities { get; set; }

    public virtual DbSet<GuestHouseLocation> GuestHouseLocations { get; set; }

    public virtual DbSet<GuestHouseMaster> GuestHouseMasters { get; set; }

    public virtual DbSet<GuestHousePicture> GuestHousePictures { get; set; }

    public virtual DbSet<HeadQuarterDetail> HeadQuarterDetails { get; set; }

    public virtual DbSet<HisEmployeePpcMapping> HisEmployeePpcMappings { get; set; }

    public virtual DbSet<Holiday> Holidays { get; set; }

    public virtual DbSet<HrQuery> HrQueries { get; set; }

    public virtual DbSet<HrQueryApprover> HrQueryApprovers { get; set; }

    public virtual DbSet<HrQueryCategory> HrQueryCategories { get; set; }

    public virtual DbSet<IndustryM> IndustryMs { get; set; }

    public virtual DbSet<IssueList> IssueLists { get; set; }

    public virtual DbSet<IssueListHistory> IssueListHistories { get; set; }

    public virtual DbSet<ItApprovedHardware> ItApprovedHardwares { get; set; }

    public virtual DbSet<ItApprovedHardwareAsset> ItApprovedHardwareAssets { get; set; }

    public virtual DbSet<ItApprovedSoftware> ItApprovedSoftwares { get; set; }

    public virtual DbSet<ItContact> ItContacts { get; set; }

    public virtual DbSet<ItFaq> ItFaqs { get; set; }

    public virtual DbSet<ItPolicy> ItPolicies { get; set; }

    public virtual DbSet<ItPortalLabel> ItPortalLabels { get; set; }

    public virtual DbSet<ItService> ItServices { get; set; }

    public virtual DbSet<ItSolution> ItSolutions { get; set; }

    public virtual DbSet<ItSolutionCategory> ItSolutionCategories { get; set; }

    public virtual DbSet<ItSolutionCategoryTable> ItSolutionCategoryTables { get; set; }

    public virtual DbSet<ItSolutionsCommentsLikesAndDisLikesTable> ItSolutionsCommentsLikesAndDisLikesTables { get; set; }

    public virtual DbSet<ItSolutionsCommentsTable> ItSolutionsCommentsTables { get; set; }

    public virtual DbSet<ItSolutionsReplyTbl> ItSolutionsReplyTbls { get; set; }

    public virtual DbSet<ItSolutionsUpdateTable> ItSolutionsUpdateTables { get; set; }

    public virtual DbSet<ItSoutionsViewHistory> ItSoutionsViewHistories { get; set; }

    public virtual DbSet<ItTraining> ItTrainings { get; set; }

    public virtual DbSet<ItapprovedVendor> ItapprovedVendors { get; set; }

    public virtual DbSet<ItemCodeModification> ItemCodeModifications { get; set; }

    public virtual DbSet<ItemCodeRequest> ItemCodeRequests { get; set; }

    public virtual DbSet<ItemcodeExtenstionRequest> ItemcodeExtenstionRequests { get; set; }

    public virtual DbSet<ItportalAuthorisedUserTable> ItportalAuthorisedUserTables { get; set; }

    public virtual DbSet<ItportalContact> ItportalContacts { get; set; }

    public virtual DbSet<ItsolutionsLikesAndDisLikesTable> ItsolutionsLikesAndDisLikesTables { get; set; }

    public virtual DbSet<Itsop> Itsops { get; set; }

    public virtual DbSet<JobWorkD> JobWorkDs { get; set; }

    public virtual DbSet<JobWorkM> JobWorkMs { get; set; }

    public virtual DbSet<KraCurrentYear> KraCurrentYears { get; set; }

    public virtual DbSet<KraNextYear> KraNextYears { get; set; }

    public virtual DbSet<LaRulesM> LaRulesMs { get; set; }

    public virtual DbSet<LanguageM> LanguageMs { get; set; }

    public virtual DbSet<LeaveApplyRule> LeaveApplyRules { get; set; }

    public virtual DbSet<LeaveDetail> LeaveDetails { get; set; }

    public virtual DbSet<LeaveReason> LeaveReasons { get; set; }

    public virtual DbSet<LeaveStructure> LeaveStructures { get; set; }

    public virtual DbSet<LicenseTypeSoftware> LicenseTypeSoftwares { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<LocationGateMaster> LocationGateMasters { get; set; }

    public virtual DbSet<LocationMaster> LocationMasters { get; set; }

    public virtual DbSet<LockoutMaster> LockoutMasters { get; set; }

    public virtual DbSet<LopReimbursement> LopReimbursements { get; set; }

    public virtual DbSet<LvApplyRule> LvApplyRules { get; set; }

    public virtual DbSet<LvReason> LvReasons { get; set; }

    public virtual DbSet<LvTypeD> LvTypeDs { get; set; }

    public virtual DbSet<LvTypeM> LvTypeMs { get; set; }

    public virtual DbSet<MaritalM> MaritalMs { get; set; }

    public virtual DbSet<MastersStructureInput> MastersStructureInputs { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<MaterialGroup> MaterialGroups { get; set; }

    public virtual DbSet<MaterialMaster> MaterialMasters { get; set; }

    public virtual DbSet<MaterialPricingGroup> MaterialPricingGroups { get; set; }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<MedClaimContactDetail> MedClaimContactDetails { get; set; }

    public virtual DbSet<MedHeadApprover> MedHeadApprovers { get; set; }

    public virtual DbSet<MedInputCategory> MedInputCategories { get; set; }

    public virtual DbSet<MedServiceBrand> MedServiceBrands { get; set; }

    public virtual DbSet<MedServiceRequestHistory> MedServiceRequestHistories { get; set; }

    public virtual DbSet<MedclaimDependantDetail> MedclaimDependantDetails { get; set; }

    public virtual DbSet<MediServiceRequest> MediServiceRequests { get; set; }

    public virtual DbSet<MeetingParticipant> MeetingParticipants { get; set; }

    public virtual DbSet<MeetingSummary> MeetingSummaries { get; set; }

    public virtual DbSet<MessageBoard> MessageBoards { get; set; }

    public virtual DbSet<MicroLabsInvoiceMaster> MicroLabsInvoiceMasters { get; set; }

    public virtual DbSet<MicroLabsPoMaster> MicroLabsPoMasters { get; set; }

    public virtual DbSet<MinutesOfMeeting> MinutesOfMeetings { get; set; }

    public virtual DbSet<MomActionItem> MomActionItems { get; set; }

    public virtual DbSet<MomMeetingType> MomMeetingTypes { get; set; }

    public virtual DbSet<MomMode> MomModes { get; set; }

    public virtual DbSet<MoreLink> MoreLinks { get; set; }

    public virtual DbSet<MultiLoginExceptionUser> MultiLoginExceptionUsers { get; set; }

    public virtual DbSet<NationalityM> NationalityMs { get; set; }

    public virtual DbSet<NatureofChange> NatureofChanges { get; set; }

    public virtual DbSet<NewCandidate> NewCandidates { get; set; }

    public virtual DbSet<NewSalaryBreakup> NewSalaryBreakups { get; set; }

    public virtual DbSet<NewUserLogin> NewUserLogins { get; set; }

    public virtual DbSet<NpdApprover> NpdApprovers { get; set; }

    public virtual DbSet<NpdCmdDetail> NpdCmdDetails { get; set; }

    public virtual DbSet<NpdCompetitorBrand> NpdCompetitorBrands { get; set; }

    public virtual DbSet<NpdCqaDeptDetail> NpdCqaDeptDetails { get; set; }

    public virtual DbSet<NpdDistributionDeptDetail> NpdDistributionDeptDetails { get; set; }

    public virtual DbSet<NpdHodDetail> NpdHodDetails { get; set; }

    public virtual DbSet<NpdIprDeptDetail> NpdIprDeptDetails { get; set; }

    public virtual DbSet<NpdMasterDetail> NpdMasterDetails { get; set; }

    public virtual DbSet<NpdMedicalDeptDetail> NpdMedicalDeptDetails { get; set; }

    public virtual DbSet<NpdRndDeptDetail> NpdRndDeptDetails { get; set; }

    public virtual DbSet<NpdStrategicDeptDetail> NpdStrategicDeptDetails { get; set; }

    public virtual DbSet<NpdSupplychainDeptDetail> NpdSupplychainDeptDetails { get; set; }

    public virtual DbSet<OfferAttachment> OfferAttachments { get; set; }

    public virtual DbSet<OfferDetail> OfferDetails { get; set; }

    public virtual DbSet<OfferEmailNotification> OfferEmailNotifications { get; set; }

    public virtual DbSet<OfferSalaryDetail> OfferSalaryDetails { get; set; }

    public virtual DbSet<OfferSalaryHeadDetail> OfferSalaryHeadDetails { get; set; }

    public virtual DbSet<OnDutyDetail> OnDutyDetails { get; set; }

    public virtual DbSet<OnDutyEmpDocument> OnDutyEmpDocuments { get; set; }

    public virtual DbSet<OverTimeDetail> OverTimeDetails { get; set; }

    public virtual DbSet<OverallRatingDetail> OverallRatingDetails { get; set; }

    public virtual DbSet<OverallRatingMaster> OverallRatingMasters { get; set; }

    public virtual DbSet<PackSize> PackSizes { get; set; }

    public virtual DbSet<PackType> PackTypes { get; set; }

    public virtual DbSet<PackageMaterialGroup> PackageMaterialGroups { get; set; }

    public virtual DbSet<PartnerDetail> PartnerDetails { get; set; }

    public virtual DbSet<PartnerMasterDetail> PartnerMasterDetails { get; set; }

    public virtual DbSet<PasswordPolicyMaster> PasswordPolicyMasters { get; set; }

    public virtual DbSet<PaygroupMaster> PaygroupMasters { get; set; }

    public virtual DbSet<PaymentTermM> PaymentTermMs { get; set; }

    public virtual DbSet<PayslipRequest> PayslipRequests { get; set; }

    public virtual DbSet<PermissionDetail> PermissionDetails { get; set; }

    public virtual DbSet<PermissionMaster> PermissionMasters { get; set; }

    public virtual DbSet<PharmaGrade> PharmaGrades { get; set; }

    public virtual DbSet<PlantAddress> PlantAddresses { get; set; }

    public virtual DbSet<PlantHead> PlantHeads { get; set; }

    public virtual DbSet<PlantHeadCompOt> PlantHeadCompOts { get; set; }

    public virtual DbSet<PlantMaster> PlantMasters { get; set; }

    public virtual DbSet<PlantsAssignedForUserId> PlantsAssignedForUserIds { get; set; }

    public virtual DbSet<PnPeriodMaster> PnPeriodMasters { get; set; }

    public virtual DbSet<PriceGroup> PriceGroups { get; set; }

    public virtual DbSet<PriceList> PriceLists { get; set; }

    public virtual DbSet<PrintTemplate> PrintTemplates { get; set; }

    public virtual DbSet<PrintTemplatePpcMapping> PrintTemplatePpcMappings { get; set; }

    public virtual DbSet<PrintingLog> PrintingLogs { get; set; }

    public virtual DbSet<Priority> Priorities { get; set; }

    public virtual DbSet<ProcessMaster> ProcessMasters { get; set; }

    public virtual DbSet<ProdAllRequestHistory> ProdAllRequestHistories { get; set; }

    public virtual DbSet<ProdApprovalTransaction> ProdApprovalTransactions { get; set; }

    public virtual DbSet<ProdCustomerMasterM> ProdCustomerMasterMs { get; set; }

    public virtual DbSet<ProdDepartmentMaster> ProdDepartmentMasters { get; set; }

    public virtual DbSet<ProdDesignationMaster> ProdDesignationMasters { get; set; }

    public virtual DbSet<ProdEmployeeAddress> ProdEmployeeAddresses { get; set; }

    public virtual DbSet<ProdEmployeeMaster> ProdEmployeeMasters { get; set; }

    public virtual DbSet<ProdEmployeeOtherDetail> ProdEmployeeOtherDetails { get; set; }

    public virtual DbSet<ProdGateOutwardD> ProdGateOutwardDs { get; set; }

    public virtual DbSet<ProdGateOutwardM> ProdGateOutwardMs { get; set; }

    public virtual DbSet<ProdGigoapprovalTransaction> ProdGigoapprovalTransactions { get; set; }

    public virtual DbSet<ProdGigoapprover> ProdGigoapprovers { get; set; }

    public virtual DbSet<ProdItemCodeModification> ProdItemCodeModifications { get; set; }

    public virtual DbSet<ProdItemCodeRequest> ProdItemCodeRequests { get; set; }

    public virtual DbSet<ProdItemcodeExtenstionRequest> ProdItemcodeExtenstionRequests { get; set; }

    public virtual DbSet<ProdLockoutMaster> ProdLockoutMasters { get; set; }

    public virtual DbSet<ProdMaterial> ProdMaterials { get; set; }

    public virtual DbSet<ProdMaterialMaster> ProdMaterialMasters { get; set; }

    public virtual DbSet<ProdPlantMaster> ProdPlantMasters { get; set; }

    public virtual DbSet<ProdProfileFormMaintenance> ProdProfileFormMaintenances { get; set; }

    public virtual DbSet<ProdProfileMaster> ProdProfileMasters { get; set; }

    public virtual DbSet<ProdRoleMaster> ProdRoleMasters { get; set; }

    public virtual DbSet<ProdServiceMaster> ProdServiceMasters { get; set; }

    public virtual DbSet<ProdSoftware> ProdSoftwares { get; set; }

    public virtual DbSet<ProdSoftwaresRole> ProdSoftwaresRoles { get; set; }

    public virtual DbSet<ProdUserGroupsMaster> ProdUserGroupsMasters { get; set; }

    public virtual DbSet<ProdUserIdEquipmentDetail> ProdUserIdEquipmentDetails { get; set; }

    public virtual DbSet<ProdUserIdMasterDetail> ProdUserIdMasterDetails { get; set; }

    public virtual DbSet<ProdUserIdRequest> ProdUserIdRequests { get; set; }

    public virtual DbSet<ProdUserMaster> ProdUserMasters { get; set; }

    public virtual DbSet<ProdUserPlantMaintenance> ProdUserPlantMaintenances { get; set; }

    public virtual DbSet<ProdUserSubgroupsMaster> ProdUserSubgroupsMasters { get; set; }

    public virtual DbSet<ProdVendorMaster> ProdVendorMasters { get; set; }

    public virtual DbSet<ProdVendorMasterDetail> ProdVendorMasterDetails { get; set; }

    public virtual DbSet<ProdVmsApprovalM> ProdVmsApprovalMs { get; set; }

    public virtual DbSet<ProdWorkflowApprover> ProdWorkflowApprovers { get; set; }

    public virtual DbSet<ProdWorkflowApprovers1> ProdWorkflowApprovers1s { get; set; }

    public virtual DbSet<ProfileFormMaintenance> ProfileFormMaintenances { get; set; }

    public virtual DbSet<ProfileMaster> ProfileMasters { get; set; }

    public virtual DbSet<ProjMember> ProjMembers { get; set; }

    public virtual DbSet<ProjMilestone> ProjMilestones { get; set; }

    public virtual DbSet<ProjTask> ProjTasks { get; set; }

    public virtual DbSet<ProjectCategory> ProjectCategories { get; set; }

    public virtual DbSet<ProjectCode> ProjectCodes { get; set; }

    public virtual DbSet<ProjectMaster> ProjectMasters { get; set; }

    public virtual DbSet<ProjectMgmt> ProjectMgmts { get; set; }

    public virtual DbSet<ProposedAction> ProposedActions { get; set; }

    public virtual DbSet<PurchaseGroup> PurchaseGroups { get; set; }

    public virtual DbSet<PurposeTravel> PurposeTravels { get; set; }

    public virtual DbSet<RaGrade> RaGrades { get; set; }

    public virtual DbSet<RaRequest> RaRequests { get; set; }

    public virtual DbSet<RatingMaster> RatingMasters { get; set; }

    public virtual DbSet<ReconciliationAccountM> ReconciliationAccountMs { get; set; }

    public virtual DbSet<Reference> References { get; set; }

    public virtual DbSet<ReferenceTyp> ReferenceTyps { get; set; }

    public virtual DbSet<RegularizationRequest> RegularizationRequests { get; set; }

    public virtual DbSet<RelationshipM> RelationshipMs { get; set; }

    public virtual DbSet<ReligionM> ReligionMs { get; set; }

    public virtual DbSet<ReportDailyWise> ReportDailyWises { get; set; }

    public virtual DbSet<ReportingGroupM> ReportingGroupMs { get; set; }

    public virtual DbSet<RepositoryDomain> RepositoryDomains { get; set; }

    public virtual DbSet<RequiredUserRole> RequiredUserRoles { get; set; }

    public virtual DbSet<RiskPlan> RiskPlans { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleMaster> RoleMasters { get; set; }

    public virtual DbSet<RoomBooking> RoomBookings { get; set; }

    public virtual DbSet<RoomFacility> RoomFacilities { get; set; }

    public virtual DbSet<RoomFacilityMaster> RoomFacilityMasters { get; set; }

    public virtual DbSet<RoomMaster> RoomMasters { get; set; }

    public virtual DbSet<RoomPicture> RoomPictures { get; set; }

    public virtual DbSet<RoomTypeMaster> RoomTypeMasters { get; set; }

    public virtual DbSet<SalaryStructure> SalaryStructures { get; set; }

    public virtual DbSet<SbuMaster> SbuMasters { get; set; }

    public virtual DbSet<ServiceCategory> ServiceCategories { get; set; }

    public virtual DbSet<ServiceCitrix> ServiceCitrixes { get; set; }

    public virtual DbSet<ServiceGroup> ServiceGroups { get; set; }

    public virtual DbSet<ServiceMaster> ServiceMasters { get; set; }

    public virtual DbSet<ServiceMasterChange> ServiceMasterChanges { get; set; }

    public virtual DbSet<Signatory> Signatories { get; set; }

    public virtual DbSet<Sla> Slas { get; set; }

    public virtual DbSet<SoftSkillMaster> SoftSkillMasters { get; set; }

    public virtual DbSet<Software> Softwares { get; set; }

    public virtual DbSet<SoftwareCategoryMaster> SoftwareCategoryMasters { get; set; }

    public virtual DbSet<SoftwareModule> SoftwareModules { get; set; }

    public virtual DbSet<SoftwareUserProfile> SoftwareUserProfiles { get; set; }

    public virtual DbSet<SoftwaresRole> SoftwaresRoles { get; set; }

    public virtual DbSet<Stage10Emreview> Stage10Emreviews { get; set; }

    public virtual DbSet<Stage11Closure> Stage11Closures { get; set; }

    public virtual DbSet<Stage12ClosureVerification> Stage12ClosureVerifications { get; set; }

    public virtual DbSet<Stage1DiscrepancyRequest> Stage1DiscrepancyRequests { get; set; }

    public virtual DbSet<Stage2Spocassessment> Stage2Spocassessments { get; set; }

    public virtual DbSet<Stage3VendorAssessment> Stage3VendorAssessments { get; set; }

    public virtual DbSet<Stage4ImpactAssessment> Stage4ImpactAssessments { get; set; }

    public virtual DbSet<Stage5Qaapproval> Stage5Qaapprovals { get; set; }

    public virtual DbSet<Stage6Implementation> Stage6Implementations { get; set; }

    public virtual DbSet<Stage7Emproposal> Stage7Emproposals { get; set; }

    public virtual DbSet<Stage8QaheadApproval> Stage8QaheadApprovals { get; set; }

    public virtual DbSet<Stage9EffectivenessMonitoring> Stage9EffectivenessMonitorings { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<StateMaster> StateMasters { get; set; }

    public virtual DbSet<StorageCondition> StorageConditions { get; set; }

    public virtual DbSet<StorageLocation> StorageLocations { get; set; }

    public virtual DbSet<Strength> Strengths { get; set; }

    public virtual DbSet<SubDeptMaster> SubDeptMasters { get; set; }

    public virtual DbSet<SubRole> SubRoles { get; set; }

    public virtual DbSet<SupplierMaster> SupplierMasters { get; set; }

    public virtual DbSet<Support> Supports { get; set; }

    public virtual DbSet<SupportTeam> SupportTeams { get; set; }

    public virtual DbSet<SupportTeamAssgn> SupportTeamAssgns { get; set; }

    public virtual DbSet<SysLandscape> SysLandscapes { get; set; }

    public virtual DbSet<TaskAttachment> TaskAttachments { get; set; }

    public virtual DbSet<TaskManager> TaskManagers { get; set; }

    public virtual DbSet<TaxClass> TaxClasses { get; set; }

    public virtual DbSet<TblDepartmentHeadGroup> TblDepartmentHeadGroups { get; set; }

    public virtual DbSet<TblHrPolicyList> TblHrPolicyLists { get; set; }

    public virtual DbSet<TblInhouseMagizne> TblInhouseMagiznes { get; set; }

    public virtual DbSet<TblManagementDetail> TblManagementDetails { get; set; }

    public virtual DbSet<TblSeniorManagementDetail> TblSeniorManagementDetails { get; set; }

    public virtual DbSet<TblUserLog> TblUserLogs { get; set; }

    public virtual DbSet<TdTravelBalance> TdTravelBalances { get; set; }

    public virtual DbSet<TdTravelExpenseDetail> TdTravelExpenseDetails { get; set; }

    public virtual DbSet<TdTravelPaymentDetail> TdTravelPaymentDetails { get; set; }

    public virtual DbSet<TdTypeOfEvent> TdTypeOfEvents { get; set; }

    public virtual DbSet<TdVendorMaster> TdVendorMasters { get; set; }

    public virtual DbSet<TdsSectionM> TdsSectionMs { get; set; }

    public virtual DbSet<Temp1> Temp1s { get; set; }

    public virtual DbSet<TempCondition> TempConditions { get; set; }

    public virtual DbSet<TempEmpLeaveDocument> TempEmpLeaveDocuments { get; set; }

    public virtual DbSet<TempVendorMaster> TempVendorMasters { get; set; }

    public virtual DbSet<TestEmail> TestEmails { get; set; }

    public virtual DbSet<TestTable> TestTables { get; set; }

    public virtual DbSet<TestTable1> TestTable1s { get; set; }

    public virtual DbSet<TherapeuticSegment> TherapeuticSegments { get; set; }

    public virtual DbSet<TimeSheetActivity> TimeSheetActivities { get; set; }

    public virtual DbSet<TourPlan> TourPlans { get; set; }

    public virtual DbSet<TrainingDetail> TrainingDetails { get; set; }

    public virtual DbSet<TypeOfGuest> TypeOfGuests { get; set; }

    public virtual DbSet<UidrequestType> UidrequestTypes { get; set; }

    public virtual DbSet<UidrequestTypeConfig> UidrequestTypeConfigs { get; set; }

    public virtual DbSet<UnitMesurement> UnitMesurements { get; set; }

    public virtual DbSet<UnlockPasswordResetHistory> UnlockPasswordResetHistories { get; set; }

    public virtual DbSet<UomMaster> UomMasters { get; set; }

    public virtual DbSet<UrlMaster> UrlMasters { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserDeptMaintenance> UserDeptMaintenances { get; set; }

    public virtual DbSet<UserGroupsMaster> UserGroupsMasters { get; set; }

    public virtual DbSet<UserIdEquipmentDetail> UserIdEquipmentDetails { get; set; }

    public virtual DbSet<UserIdMasterDetail> UserIdMasterDetails { get; set; }

    public virtual DbSet<UserIdRequest> UserIdRequests { get; set; }

    public virtual DbSet<UserIdRequestOld> UserIdRequestOlds { get; set; }

    public virtual DbSet<UserIdmaster> UserIdmasters { get; set; }

    public virtual DbSet<UserIdtype> UserIdtypes { get; set; }

    public virtual DbSet<UserMaster> UserMasters { get; set; }

    public virtual DbSet<UserPlantMaintenance> UserPlantMaintenances { get; set; }

    public virtual DbSet<UserProfileMaintenance> UserProfileMaintenances { get; set; }

    public virtual DbSet<UserSubgroupsMaster> UserSubgroupsMasters { get; set; }

    public virtual DbSet<ValuationClass> ValuationClasses { get; set; }

    public virtual DbSet<VendorMaster> VendorMasters { get; set; }

    public virtual DbSet<VendorMasterChange> VendorMasterChanges { get; set; }

    public virtual DbSet<VendorMasterDetail> VendorMasterDetails { get; set; }

    public virtual DbSet<VendorType> VendorTypes { get; set; }

    public virtual DbSet<Visitor> Visitors { get; set; }

    public virtual DbSet<VisitorBelonging> VisitorBelongings { get; set; }

    public virtual DbSet<VisitorImage> VisitorImages { get; set; }

    public virtual DbSet<VisitorPurpose> VisitorPurposes { get; set; }

    public virtual DbSet<VisitorType> VisitorTypes { get; set; }

    public virtual DbSet<VmsApprovalM> VmsApprovalMs { get; set; }

    public virtual DbSet<VmsapproverConfig> VmsapproverConfigs { get; set; }

    public virtual DbSet<VwApproverCr> VwApproverCrs { get; set; }

    public virtual DbSet<VwAsset> VwAssets { get; set; }

    public virtual DbSet<VwBarchart> VwBarcharts { get; set; }

    public virtual DbSet<VwCategorytype> VwCategorytypes { get; set; }

    public virtual DbSet<VwChangeRequest> VwChangeRequests { get; set; }

    public virtual DbSet<VwChangeRequestHistory> VwChangeRequestHistories { get; set; }

    public virtual DbSet<VwChangeRequestSummary> VwChangeRequestSummaries { get; set; }

    public virtual DbSet<VwChecklist> VwChecklists { get; set; }

    public virtual DbSet<VwCrclosure> VwCrclosures { get; set; }

    public virtual DbSet<VwCremail> VwCremails { get; set; }

    public virtual DbSet<VwCrfollowup> VwCrfollowups { get; set; }

    public virtual DbSet<VwCrlesson> VwCrlessons { get; set; }

    public virtual DbSet<VwCrrelease> VwCrreleases { get; set; }

    public virtual DbSet<VwCrtaskEmail> VwCrtaskEmails { get; set; }

    public virtual DbSet<VwCrtemplate> VwCrtemplates { get; set; }

    public virtual DbSet<VwDepartmentHead> VwDepartmentHeads { get; set; }

    public virtual DbSet<VwDepartmentMaster> VwDepartmentMasters { get; set; }

    public virtual DbSet<VwDepartmentPlantlist> VwDepartmentPlantlists { get; set; }

    public virtual DbSet<VwEmployeeDetail> VwEmployeeDetails { get; set; }

    public virtual DbSet<VwEmployeeMaster> VwEmployeeMasters { get; set; }

    public virtual DbSet<VwExecPlan> VwExecPlans { get; set; }

    public virtual DbSet<VwHead> VwHeads { get; set; }

    public virtual DbSet<VwIssueList> VwIssueLists { get; set; }

    public virtual DbSet<VwIssueListHistory> VwIssueListHistories { get; set; }

    public virtual DbSet<VwNatureofChange> VwNatureofChanges { get; set; }

    public virtual DbSet<VwNewtest> VwNewtests { get; set; }

    public virtual DbSet<VwRptcrexecPlan> VwRptcrexecPlans { get; set; }

    public virtual DbSet<VwServiceCitrix> VwServiceCitrixes { get; set; }

    public virtual DbSet<VwSupportEngineer> VwSupportEngineers { get; set; }

    public virtual DbSet<VwSupportTeamAll> VwSupportTeamAlls { get; set; }

    public virtual DbSet<VwSupportTeamDtl> VwSupportTeamDtls { get; set; }

    public virtual DbSet<VwSystemlandscape> VwSystemlandscapes { get; set; }

    public virtual DbSet<WeightUom> WeightUoms { get; set; }

    public virtual DbSet<WorkFlowApprover> WorkFlowApprovers { get; set; }

    public virtual DbSet<WorkType> WorkTypes { get; set; }

    public virtual DbSet<WorkingCalendar> WorkingCalendars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.1.134;Database=MicroLabs_Dev; user id=IT_Portal; password=Welcome@1; Trusted_Connection=false;TrustServerCertificate=True;MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AI");

        modelBuilder.Entity<AboutCompanydetail>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Createdby).HasMaxLength(100);
            entity.Property(e => e.Createdon)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Menu).HasMaxLength(100);
            entity.Property(e => e.MenuId)
                .HasMaxLength(100)
                .HasColumnName("MenuID");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Modifiedby).HasMaxLength(100);
        });

        modelBuilder.Entity<AbsentIntimation>(entity =>
        {
            entity.ToTable("Absent_Intimation");

            entity.Property(e => e.Duration).HasMaxLength(50);
            entity.Property(e => e.EmpId).HasMaxLength(10);
            entity.Property(e => e.FromDate).HasColumnType("datetime");
            entity.Property(e => e.IntimationOver).HasMaxLength(50);
            entity.Property(e => e.IntimationType).HasMaxLength(80);
            entity.Property(e => e.ToDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<AccClerkM>(entity =>
        {
            entity.ToTable("ACC_CLERK_M");

            entity.Property(e => e.AccClerkDesc)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("ACC_CLERK_DESC");
            entity.Property(e => e.AccClerkId)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("ACC_CLERK_ID");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(50);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<AccountGroupM>(entity =>
        {
            entity.HasKey(e => e.AccountGroupId);

            entity.ToTable("ACCOUNT_GROUP_M");

            entity.Property(e => e.AccountGroupId).HasColumnName("ACCOUNT_GROUP_ID");
            entity.Property(e => e.AccountGroupName)
                .HasMaxLength(20)
                .HasColumnName("ACCOUNT_GROUP_NAME");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(50);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.MaterialTypeId)
                .HasMaxLength(4)
                .HasColumnName("MATERIAL_TYPE_ID");
        });

        modelBuilder.Entity<Activity>(entity =>
        {
            entity.ToTable("Activity", "HR");

            entity.Property(e => e.ActivityDate).HasColumnType("datetime");
            entity.Property(e => e.ActivityType).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.ObjectType).HasMaxLength(50);
        });

        modelBuilder.Entity<ActivityType>(entity =>
        {
            entity.ToTable("Activity_Type");

            entity.Property(e => e.ActivityType1)
                .HasMaxLength(200)
                .HasColumnName("ActivityType");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<AdditionalVisitor>(entity =>
        {
            entity.Property(e => e.CompanyName).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fkid).HasColumnName("FKId");
            entity.Property(e => e.Mobile).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(500);

            entity.HasOne(d => d.Fk).WithMany(p => p.AdditionalVisitors)
                .HasForeignKey(d => d.Fkid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKId");
        });

        modelBuilder.Entity<AddrTypM>(entity =>
        {
            entity.ToTable("AddrTyp_M");

            entity.HasIndex(e => e.AddressType, "UQ_AddrTyp_M").IsUnique();

            entity.Property(e => e.AddressType)
                .HasMaxLength(50)
                .HasColumnName("Address_Type");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<AllRequest>(entity =>
        {
            entity.ToTable("All_Request");

            entity.Property(e => e.DoneOn).HasColumnType("datetime");
            entity.Property(e => e.HrId)
                .HasMaxLength(50)
                .HasColumnName("HR_Id");
            entity.Property(e => e.LastApprover)
                .HasMaxLength(50)
                .HasColumnName("Last_Approver");
            entity.Property(e => e.PendingApprover)
                .HasMaxLength(50)
                .HasColumnName("Pending_Approver");
            entity.Property(e => e.ReqDate)
                .HasColumnType("datetime")
                .HasColumnName("Req_Date");
            entity.Property(e => e.ReqNo)
                .HasMaxLength(10)
                .HasColumnName("Req_No");
            entity.Property(e => e.ReqStatus)
                .HasMaxLength(50)
                .HasColumnName("Req_Status");
            entity.Property(e => e.ReqType)
                .HasMaxLength(150)
                .HasColumnName("Req_Type");
            entity.Property(e => e.RequesterId).HasMaxLength(50);
        });

        modelBuilder.Entity<AllRequestHistory>(entity =>
        {
            entity.ToTable("All_Request_History");

            entity.Property(e => e.ActualApprover).HasMaxLength(50);
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.LastApprover).HasMaxLength(50);
            entity.Property(e => e.PendingApprover).HasMaxLength(50);
            entity.Property(e => e.RequestNo).HasMaxLength(50);
            entity.Property(e => e.RequestStatus).HasMaxLength(100);
            entity.Property(e => e.RequestType).HasMaxLength(50);
            entity.Property(e => e.RequestedBy).HasMaxLength(50);
            entity.Property(e => e.RequestedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<AllertApplicable>(entity =>
        {
            entity.HasOne(d => d.Allert).WithMany(p => p.AllertApplicables)
                .HasForeignKey(d => d.AllertId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AllertApplicables_AllertId");
        });

        modelBuilder.Entity<Allertbox>(entity =>
        {
            entity.HasKey(e => e.AllertId);

            entity.ToTable("Allertbox");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EffectiveFromDate).HasColumnType("datetime");
            entity.Property(e => e.EffectiveToDate).HasColumnType("datetime");
            entity.Property(e => e.ImageFileName).HasMaxLength(100);
            entity.Property(e => e.ImageFilePath).HasMaxLength(200);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ShortDescription).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(300);

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.AllertboxCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Allertbox_CreatedById");

            entity.HasOne(d => d.ModifiedBy).WithMany(p => p.AllertboxModifiedBies)
                .HasForeignKey(d => d.ModifiedById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Allertbox_ModifiedById");
        });

        modelBuilder.Entity<AllowanceMapping>(entity =>
        {
            entity.ToTable("Allowance_Mapping");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EffectiveFrom).HasColumnType("datetime");
            entity.Property(e => e.EmployeeCategoryId).HasColumnName("Employee_CategoryId");
            entity.Property(e => e.Metro)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.AllowanceType).WithMany(p => p.AllowanceMappings)
                .HasForeignKey(d => d.AllowanceTypeId)
                .HasConstraintName("FK_Allowance_Mapping_Assesment_Master");
        });

        modelBuilder.Entity<AllowanceMaster>(entity =>
        {
            entity.ToTable("Allowance_Master");

            entity.Property(e => e.AllowanceType).HasMaxLength(50);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Exhq).HasColumnName("EXHQ");
            entity.Property(e => e.Hq).HasColumnName("HQ");
            entity.Property(e => e.Hs).HasColumnName("HS");
            entity.Property(e => e.Ia).HasColumnName("IA");
            entity.Property(e => e.Ma).HasColumnName("MA");
            entity.Property(e => e.Metro)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Os).HasColumnName("OS");
            entity.Property(e => e.Sa).HasColumnName("SA");
        });

        modelBuilder.Entity<AmcvisitDetail>(entity =>
        {
            entity.ToTable("AMCVisitDetails");

            entity.Property(e => e.Department).HasMaxLength(100);
            entity.Property(e => e.EquipmentId).HasMaxLength(50);
            entity.Property(e => e.EquipmentName).HasMaxLength(80);
            entity.Property(e => e.ModelNo).HasMaxLength(50);
            entity.Property(e => e.ReasonforAmc).HasColumnName("ReasonforAMC");
            entity.Property(e => e.ServiceRequestedBy).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TypeOfService).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Visitor).WithMany(p => p.AmcvisitDetails)
                .HasForeignKey(d => d.VisitorId)
                .HasConstraintName("FK_AMCVisitDetails_Visitor");
        });

        modelBuilder.Entity<ApiManufacturer>(entity =>
        {
            entity.ToTable("API_Manufacturer");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(500);
        });

        modelBuilder.Entity<ApiMaster>(entity =>
        {
            entity.ToTable("API_Master");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(500);
        });

        modelBuilder.Entity<AppointmentAddressDetail>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK_Appointment_AppointMentAddressDetails");

            entity.ToTable("AppointmentAddressDetails", "HR");

            entity.Property(e => e.AddressLine1).HasMaxLength(100);
            entity.Property(e => e.AddressLine2).HasMaxLength(100);
            entity.Property(e => e.AddressLine3).HasMaxLength(100);
            entity.Property(e => e.CareOf).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.FromDate).HasColumnType("datetime");
            entity.Property(e => e.HouseNo).HasMaxLength(50);
            entity.Property(e => e.OwnOrRented).HasMaxLength(10);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.ToDate).HasColumnType("datetime");

            entity.HasOne(d => d.AddressType).WithMany(p => p.AppointmentAddressDetails)
                .HasForeignKey(d => d.AddressTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointMentAddressDetails_AddrTyp_M_AppointmentId");

            entity.HasOne(d => d.Appointment).WithMany(p => p.AppointmentAddressDetails)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointMentAddressDetails_AppointmentPersonalDetails");

            entity.HasOne(d => d.Country).WithMany(p => p.AppointmentAddressDetails)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointMentAddressDetails_Country");

            entity.HasOne(d => d.Employee).WithMany(p => p.AppointmentAddressDetails)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_AppointmentAddressDetails_EmployeeId");

            entity.HasOne(d => d.State).WithMany(p => p.AppointmentAddressDetails)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointMentAddressDetails_State");
        });

        modelBuilder.Entity<AppointmentAssetDetail>(entity =>
        {
            entity.HasKey(e => e.AppointmentAssetId);

            entity.ToTable("AppointmentAssetDetails", "HR");

            entity.Property(e => e.AssetNo).HasMaxLength(50);
            entity.Property(e => e.AssetValue).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.AttachmentFileName).HasMaxLength(200);
            entity.Property(e => e.AttachmentFilePath).HasMaxLength(500);
            entity.Property(e => e.PerquisitesOn).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.ReturnDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Appointment).WithMany(p => p.AppointmentAssetDetails)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentAssetDetails_AppointmentPersonalDetails");

            entity.HasOne(d => d.AssetType).WithMany(p => p.AppointmentAssetDetails)
                .HasForeignKey(d => d.AssetTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentAssetDetails_AssetTypeId");

            entity.HasOne(d => d.Employee).WithMany(p => p.AppointmentAssetDetails)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_AppointmentAssetDetails_EmployeeId");
        });

        modelBuilder.Entity<AppointmentAttachmentDetail>(entity =>
        {
            entity.HasKey(e => e.AttachmentId).HasName("PK_Appointment_AppointmentAttachmentDetails");

            entity.ToTable("AppointmentAttachmentDetails", "HR");

            entity.Property(e => e.AttachmentType).HasMaxLength(200);
            entity.Property(e => e.FileName).HasMaxLength(200);
            entity.Property(e => e.FilePath).HasMaxLength(500);
            entity.Property(e => e.Note).HasMaxLength(200);

            entity.HasOne(d => d.Appointment).WithMany(p => p.AppointmentAttachmentDetails)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentAttachmentDetails_AppointmentPersonalDetails");

            entity.HasOne(d => d.Employee).WithMany(p => p.AppointmentAttachmentDetails)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_AppointmentAttachmentDetails_EmployeeId");
        });

        modelBuilder.Entity<AppointmentEducationDetail>(entity =>
        {
            entity.HasKey(e => e.AppointmentEducationId).HasName("PK_Appointment_AppointmentEducationDetails");

            entity.ToTable("AppointmentEducationDetails", "HR");

            entity.Property(e => e.AttachmentFileName).HasMaxLength(100);
            entity.Property(e => e.AttachmentFilePath).HasMaxLength(200);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.DurationofCourse).HasMaxLength(20);
            entity.Property(e => e.FullorPartTime).HasMaxLength(10);
            entity.Property(e => e.Percentage).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Specialisation).HasMaxLength(100);
            entity.Property(e => e.University).HasMaxLength(100);
            entity.Property(e => e.YearOfPassing).HasMaxLength(10);

            entity.HasOne(d => d.Appointment).WithMany(p => p.AppointmentEducationDetails)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentEducationDetails_AppointmentPersonalDetails");

            entity.HasOne(d => d.Country).WithMany(p => p.AppointmentEducationDetails)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentEducationDetails_Country");

            entity.HasOne(d => d.Course).WithMany(p => p.AppointmentEducationDetails)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentEducationDetails_Course");

            entity.HasOne(d => d.EducationLevel).WithMany(p => p.AppointmentEducationDetails)
                .HasForeignKey(d => d.EducationLevelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentEducationDetails_EducationLevel");

            entity.HasOne(d => d.Employee).WithMany(p => p.AppointmentEducationDetails)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_AppointmentEducationDetails_EmployeeId");

            entity.HasOne(d => d.State).WithMany(p => p.AppointmentEducationDetails)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentEducationDetails_State");
        });

        modelBuilder.Entity<AppointmentFamilyDetail>(entity =>
        {
            entity.HasKey(e => e.FamilyDetailsId).HasName("PK_Appointment_AppointmentFamilyDetails");

            entity.ToTable("AppointmentFamilyDetails", "HR");

            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.BirthPlace).HasMaxLength(100);
            entity.Property(e => e.BloodGroup).HasMaxLength(10);
            entity.Property(e => e.EmailAddress).HasMaxLength(100);
            entity.Property(e => e.EmployeeNumber).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Initial).HasMaxLength(100);
            entity.Property(e => e.IsDependent).HasMaxLength(10);
            entity.Property(e => e.IsEmployee).HasMaxLength(10);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MiddleName).HasMaxLength(100);
            entity.Property(e => e.MobileNumber).HasMaxLength(20);
            entity.Property(e => e.Occupation).HasMaxLength(100);
            entity.Property(e => e.TelephoneNumber).HasMaxLength(20);
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Appointment).WithMany(p => p.AppointmentFamilyDetails)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentFamilyDetails_AppointmentPersonalDetails");

            entity.HasOne(d => d.Employee).WithMany(p => p.AppointmentFamilyDetails)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_AppointmentFamilyDetails_EmployeeId");

            entity.HasOne(d => d.RelationshipType).WithMany(p => p.AppointmentFamilyDetails)
                .HasForeignKey(d => d.RelationshipTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentFamilyDetails_Relationship_M");
        });

        modelBuilder.Entity<AppointmentLanguageDetail>(entity =>
        {
            entity.HasKey(e => e.AppointmentLanguageId).HasName("PK_Appointment_AppointmentLanguageDetails");

            entity.ToTable("AppointmentLanguageDetails", "HR");

            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.MotherTongue).HasMaxLength(10);
            entity.Property(e => e.Reading).HasMaxLength(10);
            entity.Property(e => e.Speaking).HasMaxLength(10);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Writing).HasMaxLength(10);

            entity.HasOne(d => d.Appointment).WithMany(p => p.AppointmentLanguageDetails)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentLanguageDetails_AppointmentPersonalDetails");

            entity.HasOne(d => d.Employee).WithMany(p => p.AppointmentLanguageDetails)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_AppointmentLanguageDetails_EmployeeId");

            entity.HasOne(d => d.Language).WithMany(p => p.AppointmentLanguageDetails)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentWorkExperienceDetails_Language_M");
        });

        modelBuilder.Entity<AppointmentNominationDetail>(entity =>
        {
            entity.HasKey(e => e.AppointmentNominationDetailsId);

            entity.ToTable("AppointmentNominationDetails", "HR");

            entity.Property(e => e.Esipercent)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("ESIPercent");
            entity.Property(e => e.GratuityPercent).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Pfpercent)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("PFPercent");

            entity.HasOne(d => d.AppointmentFamilyDetails).WithMany(p => p.AppointmentNominationDetails)
                .HasForeignKey(d => d.AppointmentFamilyDetailsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentNominationDetails_AppointmentFamilyDetailsId");

            entity.HasOne(d => d.Employee).WithMany(p => p.AppointmentNominationDetails)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_AppointmentNominationDetails_EmployeeId");
        });

        modelBuilder.Entity<AppointmentOfficialDetail>(entity =>
        {
            entity.HasKey(e => e.AppointmentOfficialDetailsId);

            entity.ToTable("AppointmentOfficialDetails", "HR");

            entity.Property(e => e.Aolocation)
                .HasMaxLength(50)
                .HasColumnName("AOLocation");
            entity.Property(e => e.Building).HasMaxLength(50);
            entity.Property(e => e.DateOfConfirmation).HasColumnType("datetime");
            entity.Property(e => e.DateOfJoining).HasColumnType("datetime");
            entity.Property(e => e.Extension).HasMaxLength(10);
            entity.Property(e => e.FirstName).HasMaxLength(500);
            entity.Property(e => e.Floor).HasMaxLength(50);
            entity.Property(e => e.Initial).HasMaxLength(500);
            entity.Property(e => e.IsSharedEmailId).HasMaxLength(5);
            entity.Property(e => e.LastName).HasMaxLength(500);
            entity.Property(e => e.MiddleName).HasMaxLength(500);
            entity.Property(e => e.MobileNo).HasMaxLength(10);
            entity.Property(e => e.OfficialEmailId).HasMaxLength(50);
            entity.Property(e => e.RoomOrBlock).HasMaxLength(50);
            entity.Property(e => e.TelephoneNo).HasMaxLength(20);
            entity.Property(e => e.Title).HasMaxLength(500);

            entity.HasOne(d => d.Appointment).WithMany(p => p.AppointmentOfficialDetails)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentOfficialDetails_AppointmentId");

            entity.HasOne(d => d.ApprovingManager).WithMany(p => p.AppointmentOfficialDetailApprovingManagers)
                .HasForeignKey(d => d.ApprovingManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentOfficialDetails_ApprovingManagerId");

            entity.HasOne(d => d.CorrespondingAddressType).WithMany(p => p.AppointmentOfficialDetails)
                .HasForeignKey(d => d.CorrespondingAddressTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentOfficialDetails_CorrespondingAddressTypeId");

            entity.HasOne(d => d.Country).WithMany(p => p.AppointmentOfficialDetails)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_AppointmentOfficialDetails_Country_Master");

            entity.HasOne(d => d.Designation).WithMany(p => p.AppointmentOfficialDetails)
                .HasForeignKey(d => d.DesignationId)
                .HasConstraintName("FK_AppointmentOfficialDetails_Designation_Master");

            entity.HasOne(d => d.EmployeeCategory).WithMany(p => p.AppointmentOfficialDetails)
                .HasForeignKey(d => d.EmployeeCategoryid)
                .HasConstraintName("FK_AppointmentOfficialDetails_emp_Category_Master");

            entity.HasOne(d => d.Location).WithMany(p => p.AppointmentOfficialDetails)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK_AppointmentOfficialDetails_Location_Master");

            entity.HasOne(d => d.Paygroup).WithMany(p => p.AppointmentOfficialDetails)
                .HasForeignKey(d => d.PaygroupId)
                .HasConstraintName("FK_AppointmentOfficialDetails_Paygroup_Master");

            entity.HasOne(d => d.Plant).WithMany(p => p.AppointmentOfficialDetails)
                .HasForeignKey(d => d.PlantId)
                .HasConstraintName("FK_AppointmentOfficialDetails_Plant_Master");

            entity.HasOne(d => d.PrintTemplate).WithMany(p => p.AppointmentOfficialDetails)
                .HasForeignKey(d => d.PrintTemplateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentOfficialDetails_PrintTemplateId");

            entity.HasOne(d => d.ReportingManager).WithMany(p => p.AppointmentOfficialDetailReportingManagers)
                .HasForeignKey(d => d.ReportingManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentOfficialDetails_ReportingManagerId");

            entity.HasOne(d => d.Role).WithMany(p => p.AppointmentOfficialDetails)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_AppointmentOfficialDetails_Role_Master");

            entity.HasOne(d => d.Signatory).WithMany(p => p.AppointmentOfficialDetailSignatories)
                .HasForeignKey(d => d.SignatoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentOfficialDetails_SignatoryId");

            entity.HasOne(d => d.State).WithMany(p => p.AppointmentOfficialDetails)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK_AppointmentOfficialDetails_State_Master");

            entity.HasOne(d => d.SubDepartment).WithMany(p => p.AppointmentOfficialDetails)
                .HasForeignKey(d => d.SubDepartmentId)
                .HasConstraintName("FK_AppointmentOfficialDetails_SubDept_Master");
        });

        modelBuilder.Entity<AppointmentPersonalDetail>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK_Appointment_PersonalDetails");

            entity.ToTable("AppointmentPersonalDetails", "HR");

            entity.Property(e => e.AccountNo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.AppointmentDate).HasColumnType("datetime");
            entity.Property(e => e.AppointmentGuid).HasMaxLength(50);
            entity.Property(e => e.AppointmentNo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BankName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BloodGroup).HasMaxLength(10);
            entity.Property(e => e.BranchName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Caste).HasMaxLength(500);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.EmailId).HasMaxLength(50);
            entity.Property(e => e.EmergencyContactAddressLine1).HasMaxLength(100);
            entity.Property(e => e.EmergencyContactAddressLine2).HasMaxLength(100);
            entity.Property(e => e.EmergencyContactMobileNumber).HasMaxLength(15);
            entity.Property(e => e.EmergencyContactPersonName).HasMaxLength(100);
            entity.Property(e => e.EmergencyContactTelephoneNumber).HasMaxLength(15);
            entity.Property(e => e.Esino)
                .HasMaxLength(50)
                .HasColumnName("ESINo");
            entity.Property(e => e.Fax).HasMaxLength(20);
            entity.Property(e => e.IdentificationMarks).HasMaxLength(500);
            entity.Property(e => e.Ifsccode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IFSCCode");
            entity.Property(e => e.JoinedDate).HasColumnType("datetime");
            entity.Property(e => e.MobileNumber).HasMaxLength(20);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PanNumber).HasMaxLength(15);
            entity.Property(e => e.PassportExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.PassportIssueDate).HasColumnType("datetime");
            entity.Property(e => e.PassportNumber).HasMaxLength(20);
            entity.Property(e => e.PhysicallyChallenged).HasMaxLength(5);
            entity.Property(e => e.PhysicallyChallengedDetails).HasMaxLength(100);
            entity.Property(e => e.PlaceOfBirth).HasMaxLength(100);
            entity.Property(e => e.PlaceOfPassportIssue).HasMaxLength(100);
            entity.Property(e => e.SalaryCreditAccountNo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SalaryCreditBranch)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SalaryCreditIfsccode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SalaryCreditIFSCCode");
            entity.Property(e => e.Status).HasMaxLength(100);
            entity.Property(e => e.TelephoneNumber).HasMaxLength(20);
            entity.Property(e => e.Uannumber)
                .HasMaxLength(50)
                .HasColumnName("UANNumber");
            entity.Property(e => e.Website).HasMaxLength(100);

            entity.HasOne(d => d.AccountType).WithMany(p => p.AppointmentPersonalDetails)
                .HasForeignKey(d => d.AccountTypeId)
                .HasConstraintName("FK_AppointmentPersonalDetails_AccountTypeId");

            entity.HasOne(d => d.CountryOfBirth).WithMany(p => p.AppointmentPersonalDetails)
                .HasForeignKey(d => d.CountryOfBirthId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentPersonalDetail_Country");

            entity.HasOne(d => d.Currency).WithMany(p => p.AppointmentPersonalDetails)
                .HasForeignKey(d => d.CurrencyId)
                .HasConstraintName("FK_AppointmentPersonalDetails_CurrencyId");

            entity.HasOne(d => d.EmergencyContactRelationship).WithMany(p => p.AppointmentPersonalDetails)
                .HasForeignKey(d => d.EmergencyContactRelationshipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentPersonalDetail_Relationship_M");

            entity.HasOne(d => d.Employee).WithMany(p => p.AppointmentPersonalDetails)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_AppointmentPersonalDetails_EmployeeId");

            entity.HasOne(d => d.MaritalStatus).WithMany(p => p.AppointmentPersonalDetails)
                .HasForeignKey(d => d.MaritalStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentPersonalDetail_Marital_M");

            entity.HasOne(d => d.Nationality).WithMany(p => p.AppointmentPersonalDetails)
                .HasForeignKey(d => d.NationalityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentPersonalDetail_Nationality_M");

            entity.HasOne(d => d.Offer).WithMany(p => p.AppointmentPersonalDetails)
                .HasForeignKey(d => d.OfferId)
                .HasConstraintName("FK_AppointmentPersonalDetail_OfferDetails");

            entity.HasOne(d => d.Religion).WithMany(p => p.AppointmentPersonalDetails)
                .HasForeignKey(d => d.ReligionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentPersonalDetail_Religion_M");

            entity.HasOne(d => d.SalaryCreditBank).WithMany(p => p.AppointmentPersonalDetails)
                .HasForeignKey(d => d.SalaryCreditBankId)
                .HasConstraintName("FK_AppointmentPersonalDetails_SalaryCreditBankId");
        });

        modelBuilder.Entity<AppointmentSalaryDetail>(entity =>
        {
            entity.HasKey(e => e.AppointmentSalaryDetailsId);

            entity.ToTable("AppointmentSalaryDetails", "HR");

            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.OfferedSalary).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PackageType).HasMaxLength(20);
            entity.Property(e => e.PrintNoteOnAo).HasColumnName("PrintNoteOnAO");
            entity.Property(e => e.SalaryType).HasMaxLength(20);
            entity.Property(e => e.SecondYearCtc)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("SecondYearCTC");
            entity.Property(e => e.ThirdYearCtc)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("ThirdYearCTC");

            entity.HasOne(d => d.Allowance).WithMany(p => p.AppointmentSalaryDetails)
                .HasForeignKey(d => d.AllowanceId)
                .HasConstraintName("FK_AppointmentSalaryDetails_AllowanceId");

            entity.HasOne(d => d.Appointment).WithMany(p => p.AppointmentSalaryDetails)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentSalaryDetails_AppointmentId");
        });

        modelBuilder.Entity<AppointmentSalaryHeadDetail>(entity =>
        {
            entity.HasKey(e => e.AppointmentSalaryHeadDetailsId);

            entity.ToTable("AppointmentSalaryHeadDetails", "HR");

            entity.Property(e => e.Amount).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.AnnualAmount).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Appointment).WithMany(p => p.AppointmentSalaryHeadDetails)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentSalaryHeadDetails_AppointmentId");

            entity.HasOne(d => d.SalaryHead).WithMany(p => p.AppointmentSalaryHeadDetails)
                .HasForeignKey(d => d.SalaryHeadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentSalaryHeadDetails_SalaryHeadId");
        });

        modelBuilder.Entity<AppointmentSalaryHeadPayableDetail>(entity =>
        {
            entity.HasKey(e => e.AppointmentSalaryHeadPayableDetailsId);

            entity.ToTable("AppointmentSalaryHeadPayableDetails", "HR");

            entity.Property(e => e.Month).HasMaxLength(20);

            entity.HasOne(d => d.Appointment).WithMany(p => p.AppointmentSalaryHeadPayableDetails)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentSalaryHeadPayableDetails_AppointmentId");

            entity.HasOne(d => d.SalaryHead).WithMany(p => p.AppointmentSalaryHeadPayableDetails)
                .HasForeignKey(d => d.SalaryHeadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentSalaryHeadPayableDetails_SalaryHeadId");
        });

        modelBuilder.Entity<AppointmentStatutoryDetail>(entity =>
        {
            entity.HasKey(e => e.AppointmentStatutoryDetailsId);

            entity.ToTable("AppointmentStatutoryDetails", "HR");

            entity.Property(e => e.AadharNo).HasMaxLength(20);
            entity.Property(e => e.BonusPay).HasMaxLength(5);
            entity.Property(e => e.Eps)
                .HasMaxLength(5)
                .HasColumnName("EPS");
            entity.Property(e => e.Esideduction)
                .HasMaxLength(5)
                .HasColumnName("ESIDeduction");
            entity.Property(e => e.Esino)
                .HasMaxLength(50)
                .HasColumnName("ESINo");
            entity.Property(e => e.Gratuity).HasMaxLength(5);
            entity.Property(e => e.Itdeduction)
                .HasMaxLength(5)
                .HasColumnName("ITDeduction");
            entity.Property(e => e.Leaves).HasMaxLength(5);
            entity.Property(e => e.Panno)
                .HasMaxLength(10)
                .HasColumnName("PANNo");
            entity.Property(e => e.Pfdeduction)
                .HasMaxLength(5)
                .HasColumnName("PFDeduction");
            entity.Property(e => e.Pfno)
                .HasMaxLength(50)
                .HasColumnName("PFNo");
            entity.Property(e => e.Pt)
                .HasMaxLength(5)
                .HasColumnName("PT");
            entity.Property(e => e.Uanno)
                .HasMaxLength(50)
                .HasColumnName("UANNo");

            entity.HasOne(d => d.Employee).WithMany(p => p.AppointmentStatutoryDetails)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_AppointmentStatutoryDetails_EmployeeId");
        });

        modelBuilder.Entity<AppointmentWorkExperienceDetail>(entity =>
        {
            entity.HasKey(e => e.AppointmentWorkExperienceId).HasName("PK_Appointment_AppointmentWorkExperienceDetails");

            entity.ToTable("AppointmentWorkExperienceDetails", "HR");

            entity.Property(e => e.AttachmentFileName).HasMaxLength(100);
            entity.Property(e => e.AttachmentFilePath).HasMaxLength(200);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Designation).HasMaxLength(100);
            entity.Property(e => e.Employer).HasMaxLength(100);
            entity.Property(e => e.FromDate).HasColumnType("datetime");
            entity.Property(e => e.IsMicroLab).HasMaxLength(10);
            entity.Property(e => e.JobRole).HasMaxLength(100);
            entity.Property(e => e.OldEmployeeNumber).HasMaxLength(100);
            entity.Property(e => e.ToDate).HasColumnType("datetime");

            entity.HasOne(d => d.Appointment).WithMany(p => p.AppointmentWorkExperienceDetails)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentWorkExperienceDetails_AppointmentPersonalDetails");

            entity.HasOne(d => d.Employee).WithMany(p => p.AppointmentWorkExperienceDetails)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_AppointmentWorkExperienceDetails_EmployeeId");

            entity.HasOne(d => d.Industry).WithMany(p => p.AppointmentWorkExperienceDetails)
                .HasForeignKey(d => d.IndustryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppointmentWorkExperienceDetails_Industry_M");
        });

        modelBuilder.Entity<AppraisalDetail>(entity =>
        {
            entity.ToTable("Appraisal_Details");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CompentcyComments).HasColumnName("Compentcy_Comments");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(50)
                .HasColumnName("Employee_ID");
            entity.Property(e => e.FixedHike).HasColumnName("Fixed_Hike");
            entity.Property(e => e.FkAssesmentId).HasColumnName("FK_Assesment_Id");
            entity.Property(e => e.FkCalenderId).HasColumnName("FK_Calender_ID");
            entity.Property(e => e.FkEmpId).HasColumnName("FK_Emp_ID");
            entity.Property(e => e.FkManagerId).HasColumnName("FK_Manager_ID");
            entity.Property(e => e.FkRecommendationDesignation).HasColumnName("FK_Recommendation_Designation");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ManagementComments).HasColumnName("Management_Comments");
            entity.Property(e => e.ManagerComments).HasColumnName("Manager_Comments");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.RecommendationHike).HasColumnName("Recommendation_Hike");
            entity.Property(e => e.SbuComments).HasColumnName("Sbu_Comments");
            entity.Property(e => e.VariableHike).HasColumnName("Variable_Hike");
            entity.Property(e => e.VariableIncentive).HasColumnName("Variable_Incentive");

            entity.HasOne(d => d.FkAssesment).WithMany(p => p.AppraisalDetails)
                .HasForeignKey(d => d.FkAssesmentId)
                .HasConstraintName("FK_Appraisal_Details_Assesment_Master");

            entity.HasOne(d => d.FkCalender).WithMany(p => p.AppraisalDetails)
                .HasForeignKey(d => d.FkCalenderId)
                .HasConstraintName("FK_Appraisal_Details_Calendar_Master");
        });

        modelBuilder.Entity<ApprovalTemplate>(entity =>
        {
            entity.ToTable("Approval_Template");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApprovalOrderByHierarchy)
                .HasMaxLength(500)
                .HasColumnName("Approval_Order_by_hierarchy");
            entity.Property(e => e.ApprovalOrderByTemplate)
                .HasMaxLength(500)
                .HasColumnName("Approval_Order_by_Template");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FkProject).HasColumnName("FK_Project");
            entity.Property(e => e.FkSbuId).HasColumnName("FK_SBU_ID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.FkProjectNavigation).WithMany(p => p.ApprovalTemplates)
                .HasForeignKey(d => d.FkProject)
                .HasConstraintName("FK_Approval_Template_Project_Master");
        });

        modelBuilder.Entity<ApprovalTransaction>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Comments)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DoneBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.DoneOn).HasColumnType("datetime");
            entity.Property(e => e.KeyValue).HasMaxLength(80);
            entity.Property(e => e.ParallelApprover1).HasMaxLength(50);
            entity.Property(e => e.ParallelApprover2).HasMaxLength(50);
            entity.Property(e => e.ParallelApprover3).HasMaxLength(50);
            entity.Property(e => e.ParallelApprover4).HasMaxLength(50);
            entity.Property(e => e.ParallelApprover5).HasMaxLength(100);
            entity.Property(e => e.ProcessType).HasMaxLength(100);
            entity.Property(e => e.RequestNo).HasMaxLength(20);
            entity.Property(e => e.TransactionType).HasComment("0=Created,\r\n1=Approved,\r\n2=Rejected,\r\n3=Revert to PreviousApprover,\r\n4=Revert to Initiator");
        });

        modelBuilder.Entity<Approver>(entity =>
        {
            entity.HasKey(e => e.ItapproverId).HasName("PK_IT.Approver");

            entity.ToTable("Approver", "IT");

            entity.Property(e => e.ItapproverId).HasColumnName("ITApproverID");
            entity.Property(e => e.Approverstage).HasMaxLength(50);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ClassificationId).HasColumnName("ClassificationID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");

            entity.HasOne(d => d.Approver1Navigation).WithMany(p => p.ApproverApprover1Navigations)
                .HasForeignKey(d => d.Approver1)
                .HasConstraintName("FK_Approver_SupportTeam");

            entity.HasOne(d => d.Approver2Navigation).WithMany(p => p.ApproverApprover2Navigations)
                .HasForeignKey(d => d.Approver2)
                .HasConstraintName("FK_Approver_Approver2");

            entity.HasOne(d => d.Approver3Navigation).WithMany(p => p.ApproverApprover3Navigations)
                .HasForeignKey(d => d.Approver3)
                .HasConstraintName("FK_Approver_Approver3");

            entity.HasOne(d => d.Support).WithMany(p => p.Approvers)
                .HasForeignKey(d => d.SupportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Approver_Support");
        });

        modelBuilder.Entity<AssesmentDetail>(entity =>
        {
            entity.ToTable("Assesment_Detail");

            entity.Property(e => e.AssesmentAppraisee).HasColumnName("Assesment_Appraisee");
            entity.Property(e => e.AssesmentAppraiser).HasColumnName("Assesment_Appraiser");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FkAssesmentId).HasColumnName("FK_Assesment_Id");
            entity.Property(e => e.FkSoftSkillId).HasColumnName("FK_Soft_Skill_ID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.FkAssesment).WithMany(p => p.AssesmentDetails)
                .HasForeignKey(d => d.FkAssesmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assesment_Detail_Assesment_Master");

            entity.HasOne(d => d.FkSoftSkill).WithMany(p => p.AssesmentDetails)
                .HasForeignKey(d => d.FkSoftSkillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Assesment_Detail_SoftSkill_Master");
        });

        modelBuilder.Entity<AssesmentMaster>(entity =>
        {
            entity.ToTable("Assesment_Master");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmployeePcpStatus).HasMaxLength(50);
            entity.Property(e => e.FkCalendarId).HasColumnName("FK_Calendar_Id");
            entity.Property(e => e.FkEmpId).HasColumnName("FK_Emp_ID");
            entity.Property(e => e.FormStatus)
                .HasDefaultValue(false)
                .HasColumnName("Form_Status");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsApprovedByFifthLevel)
                .HasDefaultValue(false)
                .HasColumnName("IsApproved_By_FifthLevel");
            entity.Property(e => e.IsApprovedByFirstLevel)
                .HasDefaultValue(false)
                .HasColumnName("IsApproved_By_FirstLevel");
            entity.Property(e => e.IsApprovedByFourthLevel)
                .HasDefaultValue(false)
                .HasColumnName("IsApproved_By_FourthLevel");
            entity.Property(e => e.IsApprovedBySecondLevel)
                .HasDefaultValue(false)
                .HasColumnName("IsApproved_By_SecondLevel");
            entity.Property(e => e.IsApprovedByThirdLevel)
                .HasDefaultValue(false)
                .HasColumnName("IsApproved_By_ThirdLevel");
            entity.Property(e => e.IsInitiatedByEmployee)
                .HasDefaultValue(false)
                .HasColumnName("IsInitiated_By_Employee");
            entity.Property(e => e.IsInitiatedBySystem)
                .HasDefaultValue(true)
                .HasColumnName("IsInitiated_By_System");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.FkCalendar).WithMany(p => p.AssesmentMasters)
                .HasForeignKey(d => d.FkCalendarId)
                .HasConstraintName("FK_Assesment_Master_Calendar_Master");
        });

        modelBuilder.Entity<AssetTypeMaster>(entity =>
        {
            entity.ToTable("Asset_Type_Master");

            entity.Property(e => e.AssetType).HasMaxLength(50);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<AttendanceMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ATTENDANCE_MASTER");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Floor).HasMaxLength(20);
            entity.Property(e => e.Id).HasMaxLength(200);
            entity.Property(e => e.Location).HasMaxLength(20);
            entity.Property(e => e.LogDate).HasColumnType("datetime");
            entity.Property(e => e.ProcessDate)
                .HasDefaultValueSql("('')")
                .HasColumnType("datetime");
            entity.Property(e => e.ProcessFlag).HasDefaultValue(0);
            entity.Property(e => e.UserId).HasMaxLength(50);
            entity.Property(e => e.Wing).HasMaxLength(20);
        });

        modelBuilder.Entity<AttendanceProcessLog>(entity =>
        {
            entity.ToTable("Attendance_Process_log");

            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.EmpCount).HasColumnName("emp_count");
            entity.Property(e => e.EmpId)
                .HasMaxLength(10)
                .HasColumnName("emp_id");
            entity.Property(e => e.EmpLoc)
                .HasMaxLength(50)
                .HasColumnName("emp_loc");
            entity.Property(e => e.EmpName)
                .HasMaxLength(100)
                .HasColumnName("emp_name");
            entity.Property(e => e.EndDate)
                .HasMaxLength(50)
                .HasColumnName("End_date");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("End_Time");
            entity.Property(e => e.FetchEt)
                .HasColumnType("datetime")
                .HasColumnName("fetch_et");
            entity.Property(e => e.FetchSt)
                .HasColumnType("datetime")
                .HasColumnName("fetch_st");
            entity.Property(e => e.LeaveEt)
                .HasColumnType("datetime")
                .HasColumnName("leave_et");
            entity.Property(e => e.LeaveSt)
                .HasColumnType("datetime")
                .HasColumnName("leave_st");
            entity.Property(e => e.LockId)
                .HasMaxLength(50)
                .HasColumnName("Lock_id");
            entity.Property(e => e.ManualEt)
                .HasColumnType("datetime")
                .HasColumnName("Manual_et");
            entity.Property(e => e.ManualSt)
                .HasColumnType("datetime")
                .HasColumnName("Manual_st");
            entity.Property(e => e.ProcessLocation)
                .HasMaxLength(50)
                .HasColumnName("process_Location");
            entity.Property(e => e.ProcessName)
                .HasMaxLength(100)
                .HasColumnName("process_Name");
            entity.Property(e => e.ProcessParameter)
                .HasMaxLength(50)
                .HasColumnName("process_parameter");
            entity.Property(e => e.ProcessStatus)
                .HasMaxLength(50)
                .HasColumnName("process_Status");
            entity.Property(e => e.Progress).HasColumnName("progress");
            entity.Property(e => e.PunchEt)
                .HasColumnType("datetime")
                .HasColumnName("Punch_et");
            entity.Property(e => e.PunchSt)
                .HasColumnType("datetime")
                .HasColumnName("Punch_st");
            entity.Property(e => e.RepEt)
                .HasColumnType("datetime")
                .HasColumnName("Rep_et");
            entity.Property(e => e.RepSt)
                .HasColumnType("datetime")
                .HasColumnName("Rep_st");
            entity.Property(e => e.StartDate)
                .HasMaxLength(50)
                .HasColumnName("Start_date");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("Start_Time");
            entity.Property(e => e.WeekEt)
                .HasColumnType("datetime")
                .HasColumnName("Week_et");
            entity.Property(e => e.WeekSt)
                .HasColumnType("datetime")
                .HasColumnName("Week_st");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.ToTable("AuditLog");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.AduitUser).HasMaxLength(200);
            entity.Property(e => e.AuditDateTime).HasColumnType("datetime");
            entity.Property(e => e.AuditType).HasMaxLength(50);
            entity.Property(e => e.MasterName).HasMaxLength(200);
        });

        modelBuilder.Entity<Band>(entity =>
        {
            entity.ToTable("BAND");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Aedtm)
                .HasColumnType("datetime")
                .HasColumnName("AEDTM");
            entity.Property(e => e.Aename)
                .HasMaxLength(12)
                .HasColumnName("AENAME");
            entity.Property(e => e.Bandid)
                .HasMaxLength(3)
                .HasColumnName("BANDID");
            entity.Property(e => e.Bandtxt)
                .HasMaxLength(20)
                .HasColumnName("BANDTXT");
            entity.Property(e => e.Cputm)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("CPUTM");
            entity.Property(e => e.Crdat)
                .HasColumnType("datetime")
                .HasColumnName("CRDAT");
            entity.Property(e => e.Uname)
                .HasMaxLength(12)
                .HasColumnName("UNAME");
        });

        modelBuilder.Entity<BankAccType>(entity =>
        {
            entity.ToTable("Bank_Acc_Type");

            entity.Property(e => e.Account)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Created_By");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("Created_On");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Modified_By");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("Modified_On");
            entity.Property(e => e.Sapid)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SAPID");
        });

        modelBuilder.Entity<BankTypeM>(entity =>
        {
            entity.ToTable("Bank_Type_M");

            entity.Property(e => e.BankCountry)
                .HasMaxLength(10)
                .HasColumnName("Bank_Country");
            entity.Property(e => e.BankKey)
                .HasMaxLength(50)
                .HasColumnName("Bank_Key");
            entity.Property(e => e.BankNumber)
                .HasMaxLength(50)
                .HasColumnName("Bank_Number");
            entity.Property(e => e.BranchName)
                .HasMaxLength(250)
                .HasColumnName("Branch_Name");
            entity.Property(e => e.City).HasMaxLength(150);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Region).HasMaxLength(10);
            entity.Property(e => e.Street).HasMaxLength(250);
            entity.Property(e => e.SwiftBic)
                .HasMaxLength(50)
                .HasColumnName("SWIFT_BIC");
        });

        modelBuilder.Entity<BellCurveMaster>(entity =>
        {
            entity.ToTable("Bell_Curve_Master");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.FkCalanderId).HasColumnName("FK_Calander_Id");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<BelongingsChecklist>(entity =>
        {
            entity.ToTable("Belongings_Checklist");

            entity.Property(e => e.Belongings).HasMaxLength(100);
            entity.Property(e => e.CheckInDate).HasColumnType("datetime");
            entity.Property(e => e.CheckoutDate).HasColumnType("datetime");
            entity.Property(e => e.Details).HasMaxLength(100);
            entity.Property(e => e.MobileNo).HasMaxLength(15);
            entity.Property(e => e.ModelNo).HasMaxLength(50);
            entity.Property(e => e.SerialNo).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.VisitorName).HasMaxLength(100);

            entity.HasOne(d => d.FkVisitor).WithMany(p => p.BelongingsChecklists)
                .HasForeignKey(d => d.FkVisitorId)
                .HasConstraintName("FK_Belongings_Checklist_Visitor");
        });

        modelBuilder.Entity<BookPurposeMaster>(entity =>
        {
            entity.ToTable("Book_Purpose_Master");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Purpose).HasMaxLength(500);
            entity.Property(e => e.Type).HasMaxLength(500);
        });

        modelBuilder.Entity<BookingParticipant>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.EmployeeId).HasMaxLength(50);
            entity.Property(e => e.FkBookingId).HasColumnName("FK_BookingId");
            entity.Property(e => e.Mobile).HasMaxLength(50);
            entity.Property(e => e.MobileCode).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.FkBooking).WithMany(p => p.BookingParticipants)
                .HasForeignKey(d => d.FkBookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookingId");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.ToTable("BRAND");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BrandCode)
                .HasMaxLength(50)
                .HasColumnName("BRAND_CODE");
            entity.Property(e => e.BrandDesc)
                .HasMaxLength(100)
                .HasColumnName("BRAND_DESC");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<CabBooking>(entity =>
        {
            entity.ToTable("CabBooking");

            entity.Property(e => e.AdminApprovalDate).HasColumnType("datetime");
            entity.Property(e => e.AdminComments).IsUnicode(false);
            entity.Property(e => e.AdminEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AdminName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CabDetails).IsUnicode(false);
            entity.Property(e => e.CancelComments).IsUnicode(false);
            entity.Property(e => e.Comments).IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DriverContact)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DriverName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmpContactNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.EmpDesignation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmpEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmpName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fkpurpose).HasColumnName("FKPurpose");
            entity.Property(e => e.FromDateTime).HasColumnType("datetime");
            entity.Property(e => e.ManagerApprovalDate).HasColumnType("datetime");
            entity.Property(e => e.ManagerComments).IsUnicode(false);
            entity.Property(e => e.ManagerEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ManagerName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ServiceType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ToDateTime).HasColumnType("datetime");
            entity.Property(e => e.TypeofTrip)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.FkpurposeNavigation).WithMany(p => p.CabBookings)
                .HasForeignKey(d => d.Fkpurpose)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKCabPurpose");
        });

        modelBuilder.Entity<CalendarMaster>(entity =>
        {
            entity.ToTable("Calendar_Master");

            entity.Property(e => e.CloseMonth).HasColumnName("Close_Month");
            entity.Property(e => e.CloseYear).HasColumnName("Close_Year");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnName("End_Date");
            entity.Property(e => e.FiscalYear)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Fiscal_Year");
            entity.Property(e => e.FkCompanyId).HasColumnName("Fk_Company_id");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Month)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnName("Start_Date");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.ItcategoryId).HasName("PK_IT.Category");

            entity.ToTable("Category", "IT");

            entity.Property(e => e.ItcategoryId).HasColumnName("ITCategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");

            entity.HasOne(d => d.Support).WithMany(p => p.Categories)
                .HasForeignKey(d => d.SupportId)
                .HasConstraintName("FK_Category_Support");
        });

        modelBuilder.Entity<CategoryTyp>(entity =>
        {
            entity.HasKey(e => e.CategoryTypeId).HasName("PK_IT.CategoryTyp");

            entity.ToTable("CategoryTyp", "IT");

            entity.Property(e => e.CategoryTypeId).HasColumnName("CategoryTypeID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryType).HasMaxLength(500);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ChangeRequest>(entity =>
        {
            entity.HasKey(e => e.Itcrid);

            entity.ToTable("ChangeRequest", "IT", tb => tb.HasTrigger("TR_ChangeRequestHistory"));

            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.AlternateConsidetation)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ApprovedDt).HasColumnType("datetime");
            entity.Property(e => e.BackoutPlan)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Benefits)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.BusinessImpact)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypeId).HasColumnName("CategoryTypeID");
            entity.Property(e => e.ChangeControlNo).HasMaxLength(50);
            entity.Property(e => e.ChangeDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ClassifcationId).HasColumnName("ClassifcationID");
            entity.Property(e => e.ClosedDt).HasColumnType("datetime");
            entity.Property(e => e.ClosedStatus).HasMaxLength(150);
            entity.Property(e => e.Crcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CRCode");
            entity.Property(e => e.Crdate)
                .HasColumnType("datetime")
                .HasColumnName("CRDate");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CrinitiatedFor).HasColumnName("CRInitiatedFor");
            entity.Property(e => e.Crowner).HasColumnName("CROwner");
            entity.Property(e => e.CrremailNotification).HasColumnName("CRREmailNotification");
            entity.Property(e => e.CrrequestedBy).HasColumnName("CRRequestedBy");
            entity.Property(e => e.CrrequestedDt)
                .HasColumnType("datetime")
                .HasColumnName("CRRequestedDt");
            entity.Property(e => e.DownTimeFromDate).HasColumnType("datetime");
            entity.Property(e => e.DownTimeToDate).HasColumnType("datetime");
            entity.Property(e => e.EstimatedCost).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.EstimatedCostCurr)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EstimatedEffortUnit).HasMaxLength(50);
            entity.Property(e => e.Gxpclassification).HasColumnName("GXPClassification");
            entity.Property(e => e.GxpplantId).HasColumnName("GXPPlantID");
            entity.Property(e => e.ImactedFunc).HasMaxLength(50);
            entity.Property(e => e.ImpactNotDoing)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ImpactedDept).HasMaxLength(50);
            entity.Property(e => e.ImpactedLocation).HasMaxLength(50);
            entity.Property(e => e.IsApproved)
                .HasDefaultValue(false)
                .HasColumnName("isApproved");
            entity.Property(e => e.IsImplemented)
                .HasDefaultValue(false)
                .HasColumnName("isImplemented");
            entity.Property(e => e.IsReleased)
                .HasDefaultValue(false)
                .HasColumnName("isReleased");
            entity.Property(e => e.IsSubmitted)
                .HasDefaultValue(false)
                .HasColumnName("isSubmitted");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.ReasonForChange)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceId).HasColumnName("ReferenceID");
            entity.Property(e => e.RollbackPlan)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.SysLandscapeId)
                .HasMaxLength(500)
                .HasColumnName("SysLandscapeID");
            entity.Property(e => e.TriggeredBy)
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.ChangeRequests)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChangeRequest_Category");

            entity.HasOne(d => d.Classifcation).WithMany(p => p.ChangeRequests)
                .HasForeignKey(d => d.ClassifcationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChangeRequest_Classification");
        });

        modelBuilder.Entity<ChangeRequestHistory>(entity =>
        {
            entity.HasKey(e => e.CrhistoryId);

            entity.ToTable("ChangeRequestHistory", "IT");

            entity.Property(e => e.CrhistoryId).HasColumnName("CRHistoryID");
            entity.Property(e => e.AlternateConsidetation)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ApprovedDt)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.BackoutPlan)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Benefits)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.BusinessImpact)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypeId).HasColumnName("CategoryTypeID");
            entity.Property(e => e.ChangeControlNo)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ChangeDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ClassifcationId).HasColumnName("ClassifcationID");
            entity.Property(e => e.ClosedDt).HasColumnType("datetime");
            entity.Property(e => e.ClosedStatus).HasMaxLength(150);
            entity.Property(e => e.Crcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CRCode");
            entity.Property(e => e.Crdate)
                .HasColumnType("datetime")
                .HasColumnName("CRDate");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CrhistoryDt)
                .HasColumnType("datetime")
                .HasColumnName("CRHistoryDt");
            entity.Property(e => e.CrinitiatedFor).HasColumnName("CRInitiatedFor");
            entity.Property(e => e.Crowner).HasColumnName("CROwner");
            entity.Property(e => e.CrrequestedBy).HasColumnName("CRRequestedBy");
            entity.Property(e => e.CrrequestedDt)
                .HasColumnType("datetime")
                .HasColumnName("CRRequestedDt");
            entity.Property(e => e.DownTimeFromDate).HasColumnType("datetime");
            entity.Property(e => e.DownTimeToDate).HasColumnType("datetime");
            entity.Property(e => e.EstimatedCost).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.EstimatedCostCurr)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EstimatedEffortUnit)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.EventName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gxpclassification).HasColumnName("GXPClassification");
            entity.Property(e => e.GxpplantId).HasColumnName("GXPPlantID");
            entity.Property(e => e.ImactedFunc).HasMaxLength(50);
            entity.Property(e => e.ImpactNotDoing)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ImpactedDept).HasMaxLength(50);
            entity.Property(e => e.ImpactedLocation).HasMaxLength(50);
            entity.Property(e => e.IsApproved).HasColumnName("isApproved");
            entity.Property(e => e.IsImplemented).HasColumnName("isImplemented");
            entity.Property(e => e.IsReleased).HasColumnName("isReleased");
            entity.Property(e => e.IsSubmitted).HasColumnName("isSubmitted");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.ReasonForChange)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceId).HasColumnName("ReferenceID");
            entity.Property(e => e.RollbackPlan)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Stage)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.SysLandscapeId)
                .HasMaxLength(500)
                .HasColumnName("SysLandscapeID");
            entity.Property(e => e.TriggeredBy)
                .HasMaxLength(2000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ChangeShiftLog>(entity =>
        {
            entity.HasKey(e => e.ReqNo).HasName("PK_ChangeShift_Log_1");

            entity.ToTable("ChangeShift_Log");

            entity.Property(e => e.ReqNo).HasColumnName("Req_No");
            entity.Property(e => e.ApprovalStatus)
                .HasMaxLength(50)
                .HasColumnName("Approval_Status");
            entity.Property(e => e.ApprovedDate)
                .HasColumnType("datetime")
                .HasColumnName("Approved_Date");
            entity.Property(e => e.ApproverId)
                .HasMaxLength(50)
                .HasColumnName("Approver_Id");
            entity.Property(e => e.Comments).HasMaxLength(200);
            entity.Property(e => e.PendingApprover)
                .HasMaxLength(50)
                .HasColumnName("Pending_Approver");
            entity.Property(e => e.PreviousShift)
                .HasMaxLength(50)
                .HasColumnName("Previous_Shift");
            entity.Property(e => e.RejectedDate)
                .HasColumnType("datetime")
                .HasColumnName("Rejected_Date");
            entity.Property(e => e.RequestedBy)
                .HasMaxLength(50)
                .HasColumnName("Requested_by");
            entity.Property(e => e.RequestedDate)
                .HasColumnType("datetime")
                .HasColumnName("Requested_Date");
            entity.Property(e => e.UpdatedShift)
                .HasMaxLength(50)
                .HasColumnName("Updated_Shift");
        });

        modelBuilder.Entity<Checklist>(entity =>
        {
            entity.HasKey(e => e.ItchecklistId).HasName("PK_ITChecklist");

            entity.ToTable("Checklist", "IT");

            entity.Property(e => e.ItchecklistId).HasColumnName("ITChecklistID");
            entity.Property(e => e.ApproverId).HasColumnName("ApproverID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ChecklistDesc).HasMaxLength(1500);
            entity.Property(e => e.ChecklistTitle).HasMaxLength(150);
            entity.Property(e => e.ClassificationId).HasColumnName("ClassificationID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");

            entity.HasOne(d => d.Support).WithMany(p => p.Checklists)
                .HasForeignKey(d => d.SupportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Checklist_Support");
        });

        modelBuilder.Entity<ChecklistConfig>(entity =>
        {
            entity.ToTable("ChecklistConfig", "HR");

            entity.Property(e => e.ChecklistType).HasMaxLength(50);
            entity.Property(e => e.SpocemployeeId).HasColumnName("SPOCEmployeeId");
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Department).WithMany(p => p.ChecklistConfigs)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChecklistConfig_DepartmentId");

            entity.HasOne(d => d.EmployeeCategory).WithMany(p => p.ChecklistConfigs)
                .HasForeignKey(d => d.EmployeeCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChecklistConfig_EmployeeCategoryId");

            entity.HasOne(d => d.Grade).WithMany(p => p.ChecklistConfigs)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChecklistConfig_GradeId");

            entity.HasOne(d => d.PayGroup).WithMany(p => p.ChecklistConfigs)
                .HasForeignKey(d => d.PayGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChecklistConfig_PayGroupId");

            entity.HasOne(d => d.Plant).WithMany(p => p.ChecklistConfigs)
                .HasForeignKey(d => d.PlantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChecklistConfig_PlantId");

            entity.HasOne(d => d.Spocemployee).WithMany(p => p.ChecklistConfigs)
                .HasForeignKey(d => d.SpocemployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChecklistConfig_SPOCEmployeeId");
        });

        modelBuilder.Entity<ChecklistItem>(entity =>
        {
            entity.ToTable("ChecklistItems", "HR");

            entity.Property(e => e.ChecklistType).HasMaxLength(50);
            entity.Property(e => e.CompletedDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ObjectType).HasMaxLength(50);
            entity.Property(e => e.Remarks).HasMaxLength(200);
            entity.Property(e => e.SpocemployeeId).HasColumnName("SPOCEmployeeId");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.CompletedBy).WithMany(p => p.ChecklistItemCompletedBies)
                .HasForeignKey(d => d.CompletedById)
                .HasConstraintName("FK_ChecklistItems_CompletedById");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.ChecklistItemCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChecklistItems_CreatedById");

            entity.HasOne(d => d.Department).WithMany(p => p.ChecklistItems)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChecklistItems_DepartmentId");

            entity.HasOne(d => d.ModifiedBy).WithMany(p => p.ChecklistItemModifiedBies)
                .HasForeignKey(d => d.ModifiedById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChecklistItems_ModifiedById");

            entity.HasOne(d => d.Spocemployee).WithMany(p => p.ChecklistItemSpocemployees)
                .HasForeignKey(d => d.SpocemployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChecklistItems_SPOCEmployeeId");
        });

        modelBuilder.Entity<Classification>(entity =>
        {
            entity.HasKey(e => e.ItclassificationId).HasName("PK_ITClassification");

            entity.ToTable("Classification", "IT");

            entity.Property(e => e.ItclassificationId).HasColumnName("ITClassificationID");
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
        });

        modelBuilder.Entity<CompOt>(entity =>
        {
            entity.ToTable("COMP_OT");

            entity.Property(e => e.Applicabale).HasMaxLength(4);
            entity.Property(e => e.ApprvdDate).HasColumnType("datetime");
            entity.Property(e => e.ApprvrStatus).HasMaxLength(20);
            entity.Property(e => e.Cancelflag)
                .HasDefaultValue(0)
                .HasColumnName("cancelflag");
            entity.Property(e => e.CompAvailed).HasColumnName("Comp_Availed");
            entity.Property(e => e.CompLapsed).HasColumnName("Comp_Lapsed");
            entity.Property(e => e.CompType)
                .HasMaxLength(20)
                .HasColumnName("Comp_type");
            entity.Property(e => e.LastApprover).HasColumnName("Last_approver");
            entity.Property(e => e.NoHrs)
                .HasMaxLength(10)
                .HasColumnName("NoHRS");
            entity.Property(e => e.PendingApprover).HasColumnName("Pending_approver");
            entity.Property(e => e.Pernr).HasMaxLength(50);
            entity.Property(e => e.ReqNo).HasColumnName("Req_no");
            entity.Property(e => e.RequestedBy).HasMaxLength(50);
            entity.Property(e => e.RequestedDate).HasColumnType("datetime");
            entity.Property(e => e.SapApproved).HasColumnName("SAP_Approved");
            entity.Property(e => e.SapMessage)
                .HasMaxLength(100)
                .HasColumnName("SAP_Message");
            entity.Property(e => e.SapPrevDate).HasColumnName("SAP_Prev_date");
            entity.Property(e => e.SapReqNo).HasColumnName("SAP_ReqNo");
            entity.Property(e => e.SapUpdated)
                .HasMaxLength(4)
                .HasColumnName("SAP_Updated");
            entity.Property(e => e.SapUpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("SAP_Updated_Date");
            entity.Property(e => e.Shift).HasMaxLength(50);
        });

        modelBuilder.Entity<CompOtRule>(entity =>
        {
            entity.ToTable("Comp_Ot_Rules");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.GradeNavigation).WithMany(p => p.CompOtRules)
                .HasForeignKey(d => d.Grade)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comp_Ot_Rules_Grade");

            entity.HasOne(d => d.PaygroupNavigation).WithMany(p => p.CompOtRules)
                .HasForeignKey(d => d.Paygroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comp_Ot_Rules_Paygroup_Master");

            entity.HasOne(d => d.PlantNavigation).WithMany(p => p.CompOtRules)
                .HasForeignKey(d => d.Plant)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comp_Ot_Rules_Plant_Master");

            entity.HasOne(d => d.StaffcategoryNavigation).WithMany(p => p.CompOtRules)
                .HasForeignKey(d => d.Staffcategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comp_Ot_Rules_emp_category_master");
        });

        modelBuilder.Entity<CompOtSap>(entity =>
        {
            entity.ToTable("COMP_OT_SAP");

            entity.Property(e => e.ActualTime)
                .HasMaxLength(20)
                .HasColumnName("Actual_Time");
            entity.Property(e => e.CalendarYear).HasColumnName("Calendar_Year");
            entity.Property(e => e.ChangedOn).HasColumnName("Changed_on");
            entity.Property(e => e.CompOffAvailedDate).HasColumnName("Comp_Off_Availed_Date");
            entity.Property(e => e.CompOffAvailedDays)
                .HasDefaultValue(0.0)
                .HasColumnName("Comp_Off_Availed_Days");
            entity.Property(e => e.CompOffBalance)
                .HasDefaultValue(0.0)
                .HasColumnName("Comp_Off_Balance");
            entity.Property(e => e.CreationDate).HasColumnName("Creation_date");
            entity.Property(e => e.EmployeeNumber).HasColumnName("Employee_Number");
            entity.Property(e => e.EndDate).HasColumnName("End_Date");
            entity.Property(e => e.EndTime)
                .HasMaxLength(10)
                .HasColumnName("End_Time");
            entity.Property(e => e.FromTime)
                .HasMaxLength(10)
                .HasColumnName("From_Time");
            entity.Property(e => e.LastChangedBy)
                .HasMaxLength(20)
                .HasColumnName("Last_changed_by");
            entity.Property(e => e.LeavReqNo).HasColumnName("Leav_req_no");
            entity.Property(e => e.NumberOfDays)
                .HasDefaultValue(0.0)
                .HasColumnName("Number_of_Days");
            entity.Property(e => e.ProcessdDate)
                .HasColumnType("datetime")
                .HasColumnName("Processd_Date");
            entity.Property(e => e.Remarks).HasMaxLength(100);
            entity.Property(e => e.RequestedBy).HasColumnName("Requested_By");
            entity.Property(e => e.RequestedDate).HasColumnName("Requested_Date");
            entity.Property(e => e.SalaryPayGroup).HasColumnName("Salary_Pay_Group");
            entity.Property(e => e.SapMessage)
                .HasMaxLength(100)
                .HasColumnName("SAP_Message");
            entity.Property(e => e.SapUpdated)
                .HasMaxLength(4)
                .HasColumnName("SAP_Updated");
            entity.Property(e => e.SapUpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("SAP_Updated_Date");
            entity.Property(e => e.StartDate).HasColumnName("Start_Date");
            entity.Property(e => e.TimeOfEntry)
                .HasMaxLength(20)
                .HasColumnName("Time_of_Entry");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .HasColumnName("User_Name");
        });

        modelBuilder.Entity<CompanyMaster>(entity =>
        {
            entity.ToTable("Company_Master");

            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.CountryCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CountryName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CurrentLoggedIn)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DbName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DbPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DbPort)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DbServerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DbUserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DomainName)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gstn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LegalName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Pan)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PrimaryContactNo)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.StateCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StateName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WebSite)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CompetencyMaster>(entity =>
        {
            entity.ToTable("Competency_Master");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(600)
                .IsUnicode(false);
            entity.Property(e => e.FkHeadEmpId).HasColumnName("FK_Head_Emp_ID");
            entity.Property(e => e.FkParentId).HasColumnName("FK_ParentId");
            entity.Property(e => e.FkSbuId).HasColumnName("FK_SBU_ID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.HasOne(d => d.FkSbu).WithMany(p => p.CompetencyMasters)
                .HasForeignKey(d => d.FkSbuId)
                .HasConstraintName("FK_Competency_Master_SBU_Master");
        });

        modelBuilder.Entity<ContractEmpAttachment>(entity =>
        {
            entity.ToTable("Contract_Emp_Attachments");

            entity.Property(e => e.FileName).HasMaxLength(200);
            entity.Property(e => e.FilePath).HasMaxLength(500);
            entity.Property(e => e.FkContractId).HasColumnName("Fk_Contract_Id");

            entity.HasOne(d => d.FkContract).WithMany(p => p.ContractEmpAttachments)
                .HasForeignKey(d => d.FkContractId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contract_Emp_Attachments_Contract_Employee_M");
        });

        modelBuilder.Entity<ContractEmployeeApprover>(entity =>
        {
            entity.ToTable("Contract_Employee_Approvers");

            entity.Property(e => e.ApproverId).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.ParallelApprover1).HasMaxLength(50);
            entity.Property(e => e.ParallelApprover2).HasMaxLength(50);
            entity.Property(e => e.Plant).HasMaxLength(5);
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        modelBuilder.Entity<ContractEmployeeM>(entity =>
        {
            entity.ToTable("Contract_Employee_M");

            entity.HasIndex(e => e.EmployeeId, "IX_Contract_Employee_M").IsUnique();

            entity.Property(e => e.Apprmngr)
                .HasMaxLength(10)
                .HasColumnName("APPRMNGR");
            entity.Property(e => e.Bandid)
                .HasMaxLength(10)
                .HasColumnName("BANDID");
            entity.Property(e => e.Block).HasMaxLength(20);
            entity.Property(e => e.BloodGroup).HasMaxLength(10);
            entity.Property(e => e.Building).HasMaxLength(50);
            entity.Property(e => e.CalendarCode).HasMaxLength(50);
            entity.Property(e => e.CalendarName).HasMaxLength(100);
            entity.Property(e => e.CalendarType).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(5);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.Doj)
                .HasColumnType("datetime")
                .HasColumnName("DOJ");
            entity.Property(e => e.Dol)
                .HasColumnType("datetime")
                .HasColumnName("DOL");
            entity.Property(e => e.Dptid).HasColumnName("DPTID");
            entity.Property(e => e.Dsgid).HasColumnName("DSGID");
            entity.Property(e => e.EligibleforOt).HasColumnName("EligibleforOT");
            entity.Property(e => e.EmailId).HasMaxLength(50);
            entity.Property(e => e.EmergencyContactAddress1).HasColumnName("Emergency_Contact_Address1");
            entity.Property(e => e.EmergencyContactAddress2).HasColumnName("Emergency_Contact_Address2");
            entity.Property(e => e.EmergencyContactAddress3).HasColumnName("Emergency_Contact_Address3");
            entity.Property(e => e.EmergencyContactMob)
                .HasMaxLength(10)
                .HasColumnName("Emergency_Contact_Mob");
            entity.Property(e => e.EmergencyContactPerson)
                .HasMaxLength(50)
                .HasColumnName("Emergency_Contact_Person");
            entity.Property(e => e.EmergencyContactTel)
                .HasMaxLength(20)
                .HasColumnName("Emergency_Contact_Tel");
            entity.Property(e => e.EmployeeId).HasMaxLength(15);
            entity.Property(e => e.FirstName).HasMaxLength(40);
            entity.Property(e => e.Floor).HasMaxLength(20);
            entity.Property(e => e.Gender).HasMaxLength(1);
            entity.Property(e => e.GradeId)
                .HasMaxLength(10)
                .HasColumnName("GradeID");
            entity.Property(e => e.InActivatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastName).HasMaxLength(40);
            entity.Property(e => e.Location).HasMaxLength(5);
            entity.Property(e => e.MaritalStatus).HasMaxLength(15);
            entity.Property(e => e.MiddleName).HasMaxLength(40);
            entity.Property(e => e.Mobile).HasMaxLength(50);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Nationality).HasMaxLength(5);
            entity.Property(e => e.Pan)
                .HasMaxLength(50)
                .HasColumnName("PAN");
            entity.Property(e => e.PendingApprover).HasMaxLength(50);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.Rptmngr)
                .HasMaxLength(10)
                .HasColumnName("RPTMNGR");
            entity.Property(e => e.SalaryAmount).HasColumnType("decimal(18, 5)");
            entity.Property(e => e.SalaryFreq).HasMaxLength(5);
            entity.Property(e => e.Salarypermonth).HasMaxLength(50);
            entity.Property(e => e.Sdptid).HasColumnName("SDPTID");
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(100);
            entity.Property(e => e.SwipeCount).HasMaxLength(10);
            entity.Property(e => e.Telphone).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(5);
            entity.Property(e => e.TotalExp)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("Total_Exp");
            entity.Property(e => e.ValidThrough).HasColumnType("datetime");
            entity.Property(e => e.VendorContractorId).HasColumnName("Vendor_contractorId");
        });

        modelBuilder.Entity<ContractManpowerPlanning>(entity =>
        {
            entity.ToTable("Contract_Manpower_Planning");

            entity.Property(e => e.Budget).HasMaxLength(50);
            entity.Property(e => e.Contractor).HasMaxLength(150);
            entity.Property(e => e.CreatedBy).HasMaxLength(10);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Plant).HasMaxLength(5);
        });

        modelBuilder.Entity<ContractorMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CONTRACTOR_MASTER");

            entity.Property(e => e.ConId).HasColumnName("Con_ID");
            entity.Property(e => e.ConName).HasColumnName("Con_Name");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Land1)
                .HasMaxLength(5)
                .HasColumnName("LAND1");
            entity.Property(e => e.Landx)
                .HasMaxLength(30)
                .HasColumnName("LANDX");
            entity.Property(e => e.Landx50)
                .HasMaxLength(100)
                .HasColumnName("LANDX50");
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<Crapprover>(entity =>
        {
            entity.HasKey(e => e.ItcrapproverId).HasName("PK_ITCRApproverID");

            entity.ToTable("CRApprover", "IT", tb => tb.HasTrigger("TR_CRApproverHistory"));

            entity.Property(e => e.ItcrapproverId).HasColumnName("ITCRApproverID");
            entity.Property(e => e.ApprovedDt).HasColumnType("datetime");
            entity.Property(e => e.ApproverId).HasColumnName("ApproverID");
            entity.Property(e => e.Attachment)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Comments)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Crid).HasColumnName("CRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.Remarks)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Stage)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<CrapproverHistory>(entity =>
        {
            entity.HasKey(e => e.ItcrapproverHistoryId).HasName("PK_ITCRApproverHistoryID");

            entity.ToTable("CRApproverHistory", "IT");

            entity.Property(e => e.ItcrapproverHistoryId).HasColumnName("ITCRApproverHistoryID");
            entity.Property(e => e.ApprovedDt).HasColumnType("datetime");
            entity.Property(e => e.ApproverId).HasColumnName("ApproverID");
            entity.Property(e => e.Attachment)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Comments)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CrhistoryDt)
                .HasColumnType("datetime")
                .HasColumnName("CRHistoryDt");
            entity.Property(e => e.Crid).HasColumnName("CRID");
            entity.Property(e => e.ItcrapproverId).HasColumnName("ITCRApproverID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.Remarks)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Stage)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<CrexecutionPlan>(entity =>
        {
            entity.HasKey(e => e.ItcrexecId).HasName("PK_IT.CRExecutionPlan");

            entity.ToTable("CRExecutionPlan", "IT", tb => tb.HasTrigger("TR_CRExecutionPlanHistory"));

            entity.Property(e => e.ItcrexecId).HasColumnName("ITCRExecID");
            entity.Property(e => e.ActualEndDt).HasColumnType("datetime");
            entity.Property(e => e.ActualStartDt).HasColumnType("datetime");
            entity.Property(e => e.Attachments).HasMaxLength(500);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.DependTaskId).HasColumnName("DependTaskID");
            entity.Property(e => e.EndDt)
                .HasColumnType("datetime")
                .HasColumnName("EndDT");
            entity.Property(e => e.ExecutionStepDesc).HasMaxLength(2000);
            entity.Property(e => e.ExecutionStepName).HasMaxLength(500);
            entity.Property(e => e.ForwardStatus).HasMaxLength(50);
            entity.Property(e => e.ForwardedDt).HasColumnType("datetime");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PickedDt).HasColumnType("datetime");
            entity.Property(e => e.PickedStatus).HasMaxLength(50);
            entity.Property(e => e.ReasonForwarded).HasMaxLength(500);
            entity.Property(e => e.Remarks).HasMaxLength(2000);
            entity.Property(e => e.StartDt).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Itcr).WithMany(p => p.CrexecutionPlans)
                .HasForeignKey(d => d.Itcrid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CRExecutionPlan_ChangeRequest1");
        });

        modelBuilder.Entity<CrexecutionPlanHistory>(entity =>
        {
            entity.HasKey(e => e.ItcrexecHistoryId).HasName("PK_IT.CRExecutionPlanHistory");

            entity.ToTable("CRExecutionPlanHistory", "IT");

            entity.Property(e => e.ItcrexecHistoryId).HasColumnName("ITCRExecHistoryID");
            entity.Property(e => e.ActualEndDt).HasColumnType("datetime");
            entity.Property(e => e.ActualStartDt).HasColumnType("datetime");
            entity.Property(e => e.Attachments).HasMaxLength(500);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CrhistoryDt)
                .HasColumnType("datetime")
                .HasColumnName("CRHistoryDt");
            entity.Property(e => e.DependTaskId).HasColumnName("DependTaskID");
            entity.Property(e => e.EndDt)
                .HasColumnType("datetime")
                .HasColumnName("EndDT");
            entity.Property(e => e.ExecutionStepDesc).HasMaxLength(2000);
            entity.Property(e => e.ExecutionStepName).HasMaxLength(500);
            entity.Property(e => e.ForwardStatus).HasMaxLength(50);
            entity.Property(e => e.ForwardedDt).HasColumnType("datetime");
            entity.Property(e => e.ItcrexecId).HasColumnName("ITCRExecID");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PickedDt).HasColumnType("datetime");
            entity.Property(e => e.PickedStatus).HasMaxLength(50);
            entity.Property(e => e.ReasonForwarded).HasMaxLength(500);
            entity.Property(e => e.Remarks).HasMaxLength(2000);
            entity.Property(e => e.StartDt).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<Crfollowup>(entity =>
        {
            entity.HasKey(e => e.CrfollowupId).HasName("PK_IT.CRFollowup");

            entity.ToTable("CRFollowup", "IT");

            entity.Property(e => e.CrfollowupId).HasColumnName("CRFollowupID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.FollowupDt).HasColumnType("datetime");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");

            entity.HasOne(d => d.Itcr).WithMany(p => p.Crfollowups)
                .HasForeignKey(d => d.Itcrid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CRFollowup_ChangeRequest");
        });

        modelBuilder.Entity<Crlesson>(entity =>
        {
            entity.HasKey(e => e.CrlessonId).HasName("PK_IT.CRLesson");

            entity.ToTable("CRLesson", "IT");

            entity.Property(e => e.CrlessonId).HasColumnName("CRLessonID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.LessonDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");

            entity.HasOne(d => d.Itcr).WithMany(p => p.Crlessons)
                .HasForeignKey(d => d.Itcrid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CRLessonID_ChangeRequest");
        });

        modelBuilder.Entity<Crrelease>(entity =>
        {
            entity.HasKey(e => e.CrreleaseId).HasName("PK_IT.CRRelease");

            entity.ToTable("CRRelease", "IT");

            entity.Property(e => e.CrreleaseId).HasColumnName("CRReleaseID");
            entity.Property(e => e.ApprovedDt).HasColumnType("datetime");
            entity.Property(e => e.Attachments).HasMaxLength(500);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ReleaseDt).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Itcr).WithMany(p => p.Crreleases)
                .HasForeignKey(d => d.Itcrid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CRReleaseID_ChangeRequest");
        });

        modelBuilder.Entity<Crtemplate>(entity =>
        {
            entity.HasKey(e => e.CrtemplateId).HasName("PK_IT.CRTemplate");

            entity.ToTable("CRTemplate", "IT");

            entity.Property(e => e.CrtemplateId).HasColumnName("CRTemplateID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.TemplateName)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CrtemplateDtl>(entity =>
        {
            entity.HasKey(e => e.CrtemplateDtlsId).HasName("PK_IT.CRTemplateDtls");

            entity.ToTable("CRTemplateDtls", "IT");

            entity.Property(e => e.CrtemplateDtlsId).HasColumnName("CRTemplateDtlsID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CrtemplateId).HasColumnName("CRTemplateID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.SysLandscapeId).HasColumnName("SysLandscapeID");
            entity.Property(e => e.TaskDesc).HasMaxLength(2000);
            entity.Property(e => e.TaskName).HasMaxLength(500);

            entity.HasOne(d => d.Crtemplate).WithMany(p => p.CrtemplateDtls)
                .HasForeignKey(d => d.CrtemplateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CRTemplateDtls_CRTemplate");
        });

        modelBuilder.Entity<CtcFormula>(entity =>
        {
            entity.ToTable("CTC_Formula");

            entity.Property(e => e.Calculation)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CheckBox)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EffectiveFrom).HasColumnType("datetime");
            entity.Property(e => e.EffectiveTo).HasColumnType("datetime");
            entity.Property(e => e.EmployeeCategoryId).HasColumnName("EmployeeCategoryID");
            entity.Property(e => e.FromSlabofSalary).HasColumnName("FromSLABofSalary");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.ToSlabofSalary).HasColumnName("ToSLABofSalary");

            entity.HasOne(d => d.SalaryStructure).WithMany(p => p.CtcFormulas)
                .HasForeignKey(d => d.SalaryStructureId)
                .HasConstraintName("FK__CTC_Formu__Salar__6F405F80");
        });

        modelBuilder.Entity<CtcSlab>(entity =>
        {
            entity.ToTable("CTC_Slab");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.ToTable("Currency");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Gdatu)
                .HasColumnType("datetime")
                .HasColumnName("GDATU");
            entity.Property(e => e.Isocd)
                .HasMaxLength(100)
                .HasColumnName("ISOCD");
            entity.Property(e => e.Ktext)
                .HasMaxLength(50)
                .HasColumnName("KTEXT");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(50);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Waers)
                .HasMaxLength(5)
                .HasColumnName("WAERS");
        });

        modelBuilder.Entity<CustomerGroup>(entity =>
        {
            entity.ToTable("Customer_Group");

            entity.Property(e => e.CGroupId)
                .HasMaxLength(5)
                .HasColumnName("C_GROUP_ID");
            entity.Property(e => e.CGroupName)
                .HasMaxLength(50)
                .HasColumnName("C_GROUP_NAME");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(50);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<CustomerMasterChange>(entity =>
        {
            entity.Property(e => e.Address)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CustomerCode).HasMaxLength(100);
            entity.Property(e => e.CustomerName).HasMaxLength(50);
            entity.Property(e => e.CustomerType).HasMaxLength(50);
            entity.Property(e => e.FromDate).HasColumnType("datetime");
            entity.Property(e => e.GstinNumber)
                .HasMaxLength(100)
                .HasColumnName("GSTIN_Number");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.PendingApprover).HasMaxLength(100);
            entity.Property(e => e.Plant).HasMaxLength(50);
            entity.Property(e => e.RequestedBy).HasMaxLength(50);
            entity.Property(e => e.RequestedDate).HasColumnType("datetime");
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.ToDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<CustomerMasterM>(entity =>
        {
            entity.ToTable("CUSTOMER_MASTER_M");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountClerkId)
                .HasMaxLength(5)
                .HasColumnName("ACCOUNT_CLERK_ID");
            entity.Property(e => e.AccountGroupId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ACCOUNT_GROUP_ID");
            entity.Property(e => e.Address1)
                .HasMaxLength(40)
                .HasColumnName("ADDRESS1");
            entity.Property(e => e.Address2)
                .HasMaxLength(40)
                .HasColumnName("ADDRESS2");
            entity.Property(e => e.Address3)
                .HasMaxLength(40)
                .HasColumnName("ADDRESS3");
            entity.Property(e => e.Address4)
                .HasMaxLength(40)
                .HasColumnName("ADDRESS4");
            entity.Property(e => e.ApproveDate)
                .HasColumnType("datetime")
                .HasColumnName("approve_date");
            entity.Property(e => e.ApproveStatus)
                .HasMaxLength(30)
                .HasColumnName("Approve_Status");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .HasColumnName("CITY");
            entity.Property(e => e.CountryId)
                .HasMaxLength(5)
                .HasColumnName("COUNTRY_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.CstNo)
                .HasMaxLength(40)
                .HasColumnName("CST_NO");
            entity.Property(e => e.CurrencyId)
                .HasMaxLength(5)
                .HasColumnName("CURRENCY_ID");
            entity.Property(e => e.CustomerGroup)
                .HasMaxLength(5)
                .HasColumnName("Customer_Group");
            entity.Property(e => e.CustomerType)
                .HasMaxLength(10)
                .HasColumnName("Customer_Type");
            entity.Property(e => e.CutomerCode)
                .HasMaxLength(200)
                .HasColumnName("cutomer_code");
            entity.Property(e => e.Dlno1)
                .HasMaxLength(40)
                .HasColumnName("DLNO1");
            entity.Property(e => e.Dlno2)
                .HasMaxLength(40)
                .HasColumnName("DLNO2");
            entity.Property(e => e.EccNo)
                .HasMaxLength(40)
                .HasColumnName("ECC_No");
            entity.Property(e => e.EmailId)
                .HasMaxLength(80)
                .HasColumnName("EMAIL_ID");
            entity.Property(e => e.ExciseDivision)
                .HasMaxLength(40)
                .HasColumnName("Excise_Division");
            entity.Property(e => e.ExciseRange)
                .HasMaxLength(40)
                .HasColumnName("Excise_Range");
            entity.Property(e => e.ExciseRegNo)
                .HasMaxLength(40)
                .HasColumnName("Excise_Reg_No");
            entity.Property(e => e.FaxNo)
                .HasMaxLength(20)
                .HasColumnName("FAX_NO");
            entity.Property(e => e.GstinNumber).HasColumnName("GSTIN_Number");
            entity.Property(e => e.IsEligibleForTds)
                .HasDefaultValue(false)
                .HasColumnName("IsEligibleForTDS");
            entity.Property(e => e.IsRegdExciseCustomer).HasColumnName("IS_REGD_EXCISE_Customer");
            entity.Property(e => e.IsRegdExciseVendor).HasColumnName("IS_REGD_EXCISE_VENDOR");
            entity.Property(e => e.LandlineNo)
                .HasMaxLength(20)
                .HasColumnName("LANDLINE_NO");
            entity.Property(e => e.LastApprover)
                .HasMaxLength(200)
                .HasColumnName("last_approver");
            entity.Property(e => e.LstNo)
                .HasMaxLength(40)
                .HasColumnName("LST_NO");
            entity.Property(e => e.MobileNo)
                .HasMaxLength(20)
                .HasColumnName("MOBILE_NO");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(30)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DATE");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .HasColumnName("NAME");
            entity.Property(e => e.PanNo)
                .HasMaxLength(40)
                .HasColumnName("PAN_No");
            entity.Property(e => e.PaymentTermId)
                .HasMaxLength(5)
                .HasColumnName("PAYMENT_TERM_ID");
            entity.Property(e => e.PendingApprover)
                .HasMaxLength(200)
                .HasColumnName("pending_approver");
            entity.Property(e => e.Pincode)
                .HasMaxLength(10)
                .HasColumnName("PINCODE");
            entity.Property(e => e.PlantCode)
                .HasMaxLength(50)
                .HasColumnName("plant_code");
            entity.Property(e => e.PriceGroup)
                .HasMaxLength(5)
                .HasColumnName("Price_Group");
            entity.Property(e => e.PriceList)
                .HasMaxLength(5)
                .HasColumnName("Price_List");
            entity.Property(e => e.RejectedFlag)
                .HasMaxLength(50)
                .HasColumnName("rejected_flag");
            entity.Property(e => e.RequestDate)
                .HasColumnType("datetime")
                .HasColumnName("REQUEST_DATE");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(20)
                .HasColumnName("REQUEST_NO");
            entity.Property(e => e.RequestedBy)
                .HasMaxLength(30)
                .HasColumnName("REQUESTED_BY");
            entity.Property(e => e.SapCodeExists)
                .HasMaxLength(50)
                .HasColumnName("SAP_CODE_EXISTS");
            entity.Property(e => e.SapCodeNo)
                .HasMaxLength(100)
                .HasColumnName("SAP_CODE_NO");
            entity.Property(e => e.SapCreatedBy)
                .HasMaxLength(50)
                .HasColumnName("SAP_CREATED_BY");
            entity.Property(e => e.SapCreationDate)
                .HasColumnType("datetime")
                .HasColumnName("SAP_CREATION_DATE");
            entity.Property(e => e.ServiceTaxRegistrationNo)
                .HasMaxLength(40)
                .HasColumnName("Service_Tax_Registration_No");
            entity.Property(e => e.State)
                .HasMaxLength(5)
                .HasColumnName("STATE");
            entity.Property(e => e.TaxType)
                .HasMaxLength(5)
                .HasColumnName("Tax_Type");
            entity.Property(e => e.TdsCode)
                .HasMaxLength(5)
                .HasColumnName("TDS_CODE");
            entity.Property(e => e.TinNo)
                .HasMaxLength(40)
                .HasColumnName("TIN_NO");
            entity.Property(e => e.ViewType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("VIEW_TYPE");
        });

        modelBuilder.Entity<DepartmentMaster>(entity =>
        {
            entity.ToTable("Department_Master");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(600)
                .IsUnicode(false);
            entity.Property(e => e.FkParentId).HasColumnName("FK_ParentId");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DesignationMaster>(entity =>
        {
            entity.ToTable("Designation_Master");

            entity.Property(e => e.AtemId).HasColumnName("ATEM_ID");
            entity.Property(e => e.Bandid).HasColumnName("BANDID");
            entity.Property(e => e.Cooff).HasColumnName("COOFF");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Dsgid).HasColumnName("DSGID");
            entity.Property(e => e.FkParentId).HasColumnName("FK_ParentId");
            entity.Property(e => e.Gradeid).HasColumnName("GRADEID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Ot).HasColumnName("OT");
        });

        modelBuilder.Entity<DetailStructureInput>(entity =>
        {
            entity.ToTable("Detail_Structure_Input");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Approver)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Breadcrumb)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.BreadcrumbAddUpdate)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Breadcrumb_add_update");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FkFormId).HasColumnName("FK_Form_id");
            entity.Property(e => e.Header)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.HeaderTitle)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Header_title");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Subheader)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.SubheaderTitle)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Subheader_title");
            entity.Property(e => e.Temp1)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Temp10)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Temp11)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Temp12)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Temp13)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Temp2)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Temp3)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Temp4)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Temp5)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Temp6)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Temp7)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Temp8)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Temp9)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.FkForm).WithMany(p => p.DetailStructureInputs)
                .HasForeignKey(d => d.FkFormId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detail_Structure_Input_Form_Master");
        });

        modelBuilder.Entity<DevAccount>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.EmailId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EmailID");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EmployeeID");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Device>(entity =>
        {
            entity.ToTable("Device");

            entity.Property(e => e.DeviceId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Device1>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.DeviceId });

            entity.ToTable("Devices");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.AttPhotoStamp).HasMaxLength(255);
            entity.Property(e => e.BaudRate).HasMaxLength(255);
            entity.Property(e => e.C1).HasMaxLength(255);
            entity.Property(e => e.C2).HasMaxLength(255);
            entity.Property(e => e.C3).HasMaxLength(255);
            entity.Property(e => e.C4).HasMaxLength(255);
            entity.Property(e => e.C5).HasMaxLength(255);
            entity.Property(e => e.C6).HasMaxLength(255);
            entity.Property(e => e.C7).HasMaxLength(255);
            entity.Property(e => e.ComPort).HasMaxLength(255);
            entity.Property(e => e.CommKey).HasMaxLength(255);
            entity.Property(e => e.ConnectionType).HasMaxLength(255);
            entity.Property(e => e.DeviceActivationCode).HasMaxLength(50);
            entity.Property(e => e.DeviceDirection).HasMaxLength(255);
            entity.Property(e => e.DeviceFname)
                .HasMaxLength(255)
                .HasColumnName("DeviceFName");
            entity.Property(e => e.DeviceLocation).HasMaxLength(50);
            entity.Property(e => e.DeviceSname)
                .HasMaxLength(255)
                .HasColumnName("DeviceSName");
            entity.Property(e => e.DeviceType).HasMaxLength(255);
            entity.Property(e => e.EmailId).HasMaxLength(100);
            entity.Property(e => e.FaceDeviceType).HasMaxLength(255);
            entity.Property(e => e.IpAddress).HasMaxLength(255);
            entity.Property(e => e.LastLogDownloadDate).HasColumnType("datetime");
            entity.Property(e => e.LastPing).HasColumnType("datetime");
            entity.Property(e => e.OpStamp).HasMaxLength(255);
            entity.Property(e => e.SerialNumber).HasMaxLength(255);
            entity.Property(e => e.TimeOut).HasMaxLength(50);
            entity.Property(e => e.Timezone).HasMaxLength(50);
            entity.Property(e => e.Transactionstamp).HasMaxLength(50);
        });

        modelBuilder.Entity<DeviceDetail>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FkDeviceId).HasColumnName("Fk_DeviceId");
            entity.Property(e => e.Model)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.FkDevice).WithMany(p => p.DeviceDetails)
                .HasForeignKey(d => d.FkDeviceId)
                .HasConstraintName("FK_DeviceDetails_Devices");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.DivCode);

            entity.ToTable("DIVISION");

            entity.Property(e => e.DivCode).HasColumnName("DIV_CODE");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DivDesc)
                .HasMaxLength(100)
                .HasColumnName("DIV_DESC");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<Dmaction>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DMActions");

            entity.Property(e => e.ActionType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Comments)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeRole)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ReturnComments).IsUnicode(false);
            entity.Property(e => e.Stage)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<DmactionItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DMActionItems");

            entity.Property(e => e.ActionDetails).IsUnicode(false);
            entity.Property(e => e.Attachments).IsUnicode(false);
            entity.Property(e => e.Comments).IsUnicode(false);
            entity.Property(e => e.CompletionDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EmployeeEmailId)
                .IsUnicode(false)
                .HasColumnName("EmployeeEmailID");
            entity.Property(e => e.EmployeeName).IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ResponsibleEmployeeId)
                .IsUnicode(false)
                .HasColumnName("ResponsibleEmployeeID");
            entity.Property(e => e.ReturnComments).IsUnicode(false);
            entity.Property(e => e.StageStatus)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Tcd)
                .HasColumnType("datetime")
                .HasColumnName("TCD");
        });

        modelBuilder.Entity<Dmapprover>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DMApprovers");

            entity.Property(e => e.ApproverId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ApproverID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Department)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.KeyValue)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.ParallelApprover1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ParallelApprover2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ParallelApprover3)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ParallelApprover4)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Plant)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DmdiscrepancyCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DMDiscrepancyCategories");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DiscrepancyCategoryText)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<DmenvironmentValidation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DMEnvironmentValidations");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EnvironmentValidationText)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<DmfGrade>(entity =>
        {
            entity.ToTable("DMF_GRADE");

            entity.Property(e => e.DmfGradeId).HasColumnName("DMF_GRADE_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DmfGradeDesc)
                .HasMaxLength(500)
                .HasColumnName("DMF_GRADE_DESC");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<DmimpactOnCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DMImpactOnCategories");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ImpactText)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<DmrequestType>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DMRequestTypes");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.RequestTypeText)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DmrequirementDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DMRequirementDetails");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.RequirementDetailsText)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Dmstatus>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DMStatuses");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.StatusText)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(500);
        });

        modelBuilder.Entity<DossierTypeOfRegistrationTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Dossier_TypeOfRegistration_Table");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.TypeOfRegistration).HasMaxLength(50);
        });

        modelBuilder.Entity<EducationCM>(entity =>
        {
            entity.ToTable("EducationC_M");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EducationCourse)
                .HasMaxLength(100)
                .HasColumnName("Education_Course");
            entity.Property(e => e.EducationLId).HasColumnName("EducationL_Id");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<EducationLM>(entity =>
        {
            entity.ToTable("EducationL_M");

            entity.HasIndex(e => e.EducationLevel, "UQ_EducationL_M").IsUnique();

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EducationLevel)
                .HasMaxLength(100)
                .HasColumnName("Education_Level");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<Emactivity>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EMActivities");

            entity.Property(e => e.Attachments).IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DocumentTitle).IsUnicode(false);
            entity.Property(e => e.EmployeeEmailId)
                .IsUnicode(false)
                .HasColumnName("EmployeeEmailID");
            entity.Property(e => e.EmployeeName).IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Particulars).IsUnicode(false);
            entity.Property(e => e.ReferenceDocumentNumber).IsUnicode(false);
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ResponsibleEmployeeId)
                .IsUnicode(false)
                .HasColumnName("ResponsibleEmployeeID");
            entity.Property(e => e.ReturnComments).IsUnicode(false);
            entity.Property(e => e.SectionNumber).IsUnicode(false);
            entity.Property(e => e.Stage7EmproposalId).HasColumnName("Stage7EMProposalId");
            entity.Property(e => e.StageStatus)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SummaryOfGaps).IsUnicode(false);
            entity.Property(e => e.VerificationComments).IsUnicode(false);
        });

        modelBuilder.Entity<EmailNotificationMapping>(entity =>
        {
            entity.ToTable("EmailNotification_Mapping");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EmailId).HasMaxLength(80);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.DeptNavigation).WithMany(p => p.EmailNotificationMappings)
                .HasForeignKey(d => d.Dept)
                .HasConstraintName("FK_EmailNotification_Mapping_Department_Master");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmailNotificationMappings)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_EmailNotification_Mapping_Employee_Master");

            entity.HasOne(d => d.PlantNavigation).WithMany(p => p.EmailNotificationMappings)
                .HasForeignKey(d => d.Plant)
                .HasConstraintName("FK_EmailNotification_Mapping_Location_Master");
        });

        modelBuilder.Entity<EmailTemplate>(entity =>
        {
            entity.ToTable("Email_Template");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmpCal>(entity =>
        {
            entity.ToTable("EMP_CAL");

            entity.Property(e => e.Apr)
                .HasMaxLength(50)
                .HasColumnName("APR");
            entity.Property(e => e.Aug)
                .HasMaxLength(50)
                .HasColumnName("AUG");
            entity.Property(e => e.Cyear).HasColumnName("CYEAR");
            entity.Property(e => e.Day).HasColumnName("DAY");
            entity.Property(e => e.Dec)
                .HasMaxLength(50)
                .HasColumnName("DEC");
            entity.Property(e => e.Feb)
                .HasMaxLength(50)
                .HasColumnName("FEB");
            entity.Property(e => e.Jan)
                .HasMaxLength(50)
                .HasColumnName("JAN");
            entity.Property(e => e.Jul)
                .HasMaxLength(50)
                .HasColumnName("JUL");
            entity.Property(e => e.Jun)
                .HasMaxLength(50)
                .HasColumnName("JUN");
            entity.Property(e => e.Mar)
                .HasMaxLength(50)
                .HasColumnName("MAR");
            entity.Property(e => e.May)
                .HasMaxLength(50)
                .HasColumnName("MAY");
            entity.Property(e => e.Nov)
                .HasMaxLength(50)
                .HasColumnName("NOV");
            entity.Property(e => e.Oct)
                .HasMaxLength(50)
                .HasColumnName("OCT");
            entity.Property(e => e.Sep)
                .HasMaxLength(50)
                .HasColumnName("SEP");
        });

        modelBuilder.Entity<EmpCatMapping>(entity =>
        {
            entity.ToTable("EMP_CAT_MAPPING");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.FkEmpId).HasColumnName("FK_EmpId");
            entity.Property(e => e.FkEmpcatId).HasColumnName("FK_EmpcatId");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.FkEmp).WithMany(p => p.EmpCatMappings)
                .HasForeignKey(d => d.FkEmpId)
                .HasConstraintName("FK_EMP_CAT_MAPPING_Employee_Master");
        });

        modelBuilder.Entity<EmpCategoryMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_emp_category_master_1");

            entity.ToTable("emp_category_master");

            entity.HasIndex(e => e.Staffcat, "IX_emp_category_master").IsUnique();

            entity.Property(e => e.Aoemail)
                .HasMaxLength(1)
                .HasColumnName("AOEMAIL");
            entity.Property(e => e.Bemnth)
                .HasMaxLength(1)
                .HasColumnName("BEMNTH");
            entity.Property(e => e.Catltxt)
                .HasMaxLength(50)
                .HasColumnName("CATLTXT");
            entity.Property(e => e.Catstxt)
                .HasMaxLength(20)
                .HasColumnName("CATSTXT");
            entity.Property(e => e.CostCenter).HasMaxLength(20);
            entity.Property(e => e.Glno)
                .HasMaxLength(20)
                .HasColumnName("GLNo");
            entity.Property(e => e.Ofemail)
                .HasMaxLength(1)
                .HasColumnName("OFEMAIL");
            entity.Property(e => e.Prcday).HasColumnName("PRCDAY");
            entity.Property(e => e.Staffcat).HasColumnName("STAFFCAT");
        });

        modelBuilder.Entity<EmpHolidayCalendarMapping>(entity =>
        {
            entity.ToTable("Emp_HolidayCalendar_Mapping");

            entity.Property(e => e.CalendarType).HasMaxLength(150);
            entity.Property(e => e.EmployeeId).HasMaxLength(10);
            entity.Property(e => e.Holiday).HasMaxLength(150);
            entity.Property(e => e.MediclaimExpiry).HasColumnType("datetime");
            entity.Property(e => e.MediclaimNo).HasMaxLength(80);
            entity.Property(e => e.MediclaimorEsi)
                .HasMaxLength(50)
                .HasColumnName("MediclaimorESI");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Plant).HasMaxLength(10);
            entity.Property(e => e.TypeCodeC)
                .HasMaxLength(50)
                .HasColumnName("TypeCode_C");
            entity.Property(e => e.TypeCodeH)
                .HasMaxLength(50)
                .HasColumnName("TypeCode_H");
            entity.Property(e => e.TypeNameC)
                .HasMaxLength(50)
                .HasColumnName("TypeName_C");
            entity.Property(e => e.TypeNameH)
                .HasMaxLength(50)
                .HasColumnName("TypeName_H");
            entity.Property(e => e.WorkType).HasMaxLength(100);
        });

        modelBuilder.Entity<EmpInOut>(entity =>
        {
            entity.ToTable("EMP_IN_OUT");

            entity.Property(e => e.ChangedBy).HasMaxLength(100);
            entity.Property(e => e.Date).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Day1).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day10).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day11).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day12).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day13).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day14).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day15).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day16).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day17).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day18).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day19).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day2).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day20).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day21).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day22).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day23).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day24).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day25).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day26).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day27).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day28).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day29).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day3).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day30).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day31).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day4).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day5).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day6).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day7).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day8).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Day9).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.InOut)
                .HasMaxLength(50)
                .HasColumnName("In_Out");
            entity.Property(e => e.PayGrp).HasColumnName("Pay_grp");
            entity.Property(e => e.Pernr).HasMaxLength(100);
            entity.Property(e => e.Time).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Username).HasMaxLength(100);
            entity.Property(e => e.Year).HasMaxLength(50);
        });

        modelBuilder.Entity<EmpInOutStatus>(entity =>
        {
            entity.ToTable("EMP_IN_OUT_Status");

            entity.Property(e => e.ChangedBy).HasMaxLength(100);
            entity.Property(e => e.Date).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Day1)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day10)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day11)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day12)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day13)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day14)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day15)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day16)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day17)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day18)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day19)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day2)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day20)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day21)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day22)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day23)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day24)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day25)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day26)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day27)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day28)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day29)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day3)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day30)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day31)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day4)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day5)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day6)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day7)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day8)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.Day9)
                .HasMaxLength(10)
                .HasDefaultValue("AAAA");
            entity.Property(e => e.LateCount)
                .HasDefaultValue(0)
                .HasColumnName("Late_count");
            entity.Property(e => e.PayGrp).HasColumnName("Pay_grp");
            entity.Property(e => e.Pernr).HasMaxLength(100);
            entity.Property(e => e.Time).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Username).HasMaxLength(100);
            entity.Property(e => e.WeeklyOFf)
                .HasDefaultValue(0)
                .HasColumnName("Weekly_oFF");
            entity.Property(e => e.Year).HasMaxLength(50);
        });

        modelBuilder.Entity<EmpManualSwipe>(entity =>
        {
            entity.ToTable("EMP_MANUAL_SWIPE");

            entity.Property(e => e.ChangedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_date");
            entity.Property(e => e.InOut)
                .HasMaxLength(10)
                .HasColumnName("In_Out");
            entity.Property(e => e.IpAddr)
                .HasMaxLength(50)
                .HasColumnName("IP_Addr");
            entity.Property(e => e.LateFlag).HasColumnName("late_flag");
            entity.Property(e => e.LostEntryReasonType)
                .HasMaxLength(50)
                .HasColumnName("Lost_Entry_Reason_Type");
            entity.Property(e => e.PayGrp).HasColumnName("Pay_Grp");
            entity.Property(e => e.Pernr).HasMaxLength(50);
            entity.Property(e => e.PrevTime).HasColumnName("Prev_time");
            entity.Property(e => e.ShiftCode)
                .HasMaxLength(20)
                .HasColumnName("Shift_Code");
            entity.Property(e => e.Start).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.StartDate).HasColumnName("Start_date");
            entity.Property(e => e.StatusFlag)
                .HasDefaultValue(0)
                .HasColumnName("Status_Flag");
            entity.Property(e => e.SwipeStatus)
                .HasMaxLength(10)
                .HasColumnName("Swipe_Status");
            entity.Property(e => e.Time).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<EmpOfficialInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("emp_official_info");

            entity.Property(e => e.AadharNo)
                .HasMaxLength(50)
                .HasColumnName("Aadhar_No");
            entity.Property(e => e.Active).HasColumnName("ACTIVE");
            entity.Property(e => e.Appmgr)
                .HasMaxLength(8)
                .HasColumnName("APPMGR");
            entity.Property(e => e.Baccno)
                .HasMaxLength(50)
                .HasColumnName("BACCNO");
            entity.Property(e => e.Bacctyp)
                .HasMaxLength(30)
                .HasColumnName("BACCTYP");
            entity.Property(e => e.Bankid).HasColumnName("BANKID");
            entity.Property(e => e.BoardLine)
                .HasMaxLength(20)
                .HasColumnName("BOARD_LINE");
            entity.Property(e => e.Bonus)
                .HasMaxLength(5)
                .HasColumnName("BONUS");
            entity.Property(e => e.Branch)
                .HasMaxLength(50)
                .HasColumnName("BRANCH");
            entity.Property(e => e.Building)
                .HasMaxLength(50)
                .HasColumnName("BUILDING");
            entity.Property(e => e.Bukrs)
                .HasMaxLength(4)
                .HasColumnName("BUKRS");
            entity.Property(e => e.ConId).HasColumnName("Con_ID");
            entity.Property(e => e.ConSal).HasColumnName("Con_SAL");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_date");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Doc).HasColumnName("DOC");
            entity.Property(e => e.Doj).HasColumnName("DOJ");
            entity.Property(e => e.Dol).HasColumnName("DOL");
            entity.Property(e => e.Dptid).HasColumnName("DPTID");
            entity.Property(e => e.Dsgid).HasColumnName("DSGID");
            entity.Property(e => e.Dstatus)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .HasColumnName("EMAIL_ID");
            entity.Property(e => e.EmpFullname)
                .HasMaxLength(100)
                .HasColumnName("EMP_FULLNAME");
            entity.Property(e => e.Esi)
                .HasMaxLength(5)
                .HasColumnName("ESI");
            entity.Property(e => e.Esino)
                .HasMaxLength(50)
                .HasColumnName("ESINO");
            entity.Property(e => e.Floor)
                .HasMaxLength(50)
                .HasColumnName("FLOOR");
            entity.Property(e => e.Grdid)
                .HasMaxLength(5)
                .HasColumnName("GRDID");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IfscCode)
                .HasMaxLength(50)
                .HasColumnName("IFSC_CODE");
            entity.Property(e => e.IpPhone).HasColumnName("IP_PHONE");
            entity.Property(e => e.IsHod).HasColumnName("Is_Hod");
            entity.Property(e => e.It)
                .HasMaxLength(5)
                .HasColumnName("IT");
            entity.Property(e => e.Land1)
                .HasMaxLength(5)
                .HasColumnName("LAND1");
            entity.Property(e => e.Leaves)
                .HasMaxLength(5)
                .HasColumnName("LEAVES");
            entity.Property(e => e.Locid)
                .HasMaxLength(5)
                .HasColumnName("LOCID");
            entity.Property(e => e.MicrCode)
                .HasMaxLength(50)
                .HasColumnName("MICR_CODE");
            entity.Property(e => e.Panno)
                .HasMaxLength(50)
                .HasColumnName("PANNO");
            entity.Property(e => e.PayGroup)
                .HasMaxLength(5)
                .HasColumnName("PAY_GROUP");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("PAYMENT_METHOD");
            entity.Property(e => e.Pdol).HasColumnName("PDOL");
            entity.Property(e => e.Pernr).HasColumnName("PERNR");
            entity.Property(e => e.Pf)
                .HasMaxLength(5)
                .HasColumnName("PF");
            entity.Property(e => e.Pfno)
                .HasMaxLength(50)
                .HasColumnName("PFNO");
            entity.Property(e => e.Pt)
                .HasMaxLength(5)
                .HasColumnName("PT");
            entity.Property(e => e.ReportingGrp).HasColumnName("Reporting_Grp");
            entity.Property(e => e.Room)
                .HasMaxLength(50)
                .HasColumnName("ROOM");
            entity.Property(e => e.Rptmgr)
                .HasMaxLength(8)
                .HasColumnName("RPTMGR");
            entity.Property(e => e.RuleCode)
                .HasMaxLength(10)
                .HasColumnName("Rule_Code");
            entity.Property(e => e.SapApprovedDate)
                .HasColumnType("datetime")
                .HasColumnName("SAP_Approved_Date");
            entity.Property(e => e.SapMessage)
                .HasMaxLength(500)
                .HasColumnName("SAP_Message");
            entity.Property(e => e.SapStatus)
                .HasMaxLength(10)
                .HasColumnName("SAP_Status");
            entity.Property(e => e.Sdptid).HasColumnName("SDPTID");
            entity.Property(e => e.Sdptid1).HasColumnName("SDPTID_1");
            entity.Property(e => e.Sex)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SEX");
            entity.Property(e => e.ShiftCode)
                .HasMaxLength(10)
                .HasColumnName("Shift_Code");
            entity.Property(e => e.Staffcat)
                .HasMaxLength(5)
                .HasColumnName("STAFFCAT");
            entity.Property(e => e.State).HasColumnName("STATE");
            entity.Property(e => e.SwipeCount).HasColumnName("Swipe_Count");
            entity.Property(e => e.SwipeNo).HasColumnName("Swipe_No");
            entity.Property(e => e.TelExtens).HasColumnName("TEL_EXTENS");
            entity.Property(e => e.TelNo)
                .HasMaxLength(50)
                .HasColumnName("TEL_NO");
            entity.Property(e => e.Title)
                .HasMaxLength(10)
                .HasColumnName("TITLE");
            entity.Property(e => e.Uanno)
                .HasMaxLength(50)
                .HasColumnName("UANNO");
            entity.Property(e => e.Waers)
                .HasMaxLength(5)
                .HasColumnName("WAERS");
            entity.Property(e => e.Werks)
                .HasMaxLength(50)
                .HasColumnName("WERKS");
            entity.Property(e => e.Wing).HasMaxLength(50);
            entity.Property(e => e.WorkId).HasColumnName("Work_ID");
        });

        modelBuilder.Entity<EmpPaygroupMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Table_1");

            entity.ToTable("EMP_PAYGROUP_MAPPING");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.FkEmpId).HasColumnName("FK_EmpId");
            entity.Property(e => e.FkPaygroupId).HasColumnName("FK_PaygroupId");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.FkEmp).WithMany(p => p.EmpPaygroupMappings)
                .HasForeignKey(d => d.FkEmpId)
                .HasConstraintName("FK_Table_1_Employee_Master");

            entity.HasOne(d => d.FkPaygroup).WithMany(p => p.EmpPaygroupMappings)
                .HasForeignKey(d => d.FkPaygroupId)
                .HasConstraintName("FK_Table_1_Paygroup_Master");
        });

        modelBuilder.Entity<EmpShiftLateRule>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EMP_SHIFT_LATE_RULES");

            entity.Property(e => e.ComeLateBy)
                .HasDefaultValue(new TimeOnly(0, 0, 0))
                .HasColumnName("Come_Late_by");
            entity.Property(e => e.CutHalfDayIfEarlyGoingBy)
                .HasDefaultValue(new TimeOnly(0, 0, 0))
                .HasColumnName("Cut_half_day_if_early_going_by");
            entity.Property(e => e.DeductHalfDayIfLateComingBy)
                .HasDefaultValue(new TimeOnly(0, 0, 0))
                .HasColumnName("Deduct_Half_Day_if_late_coming_by");
            entity.Property(e => e.GoEarlyBy)
                .HasDefaultValue(new TimeOnly(0, 0, 0))
                .HasColumnName("Go_Early_by");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IgnoreEarlyArrivalBeforeShiftBy)
                .HasDefaultValue(new TimeOnly(0, 0, 0))
                .HasColumnName("Ignore_early_arrival_before_shift_by");
            entity.Property(e => e.IgnoreLateGoingAfterShiftBy)
                .HasDefaultValue(new TimeOnly(0, 0, 0))
                .HasColumnName("Ignore_late_going_after_shift_by");
            entity.Property(e => e.Loc).HasMaxLength(50);
            entity.Property(e => e.LopForLateComing).HasColumnName("LOP_For_Late_Coming");
            entity.Property(e => e.NoOfEarlyCount).HasColumnName("No_of_Early_Count");
            entity.Property(e => e.NumberOfLateCountsAllowedPerMonth).HasColumnName("Number_of_Late_Counts_Allowed_per_month");
            entity.Property(e => e.RuleCode)
                .HasMaxLength(50)
                .HasColumnName("Rule_Code");
            entity.Property(e => e.RuleName)
                .HasMaxLength(110)
                .HasColumnName("Rule_Name");
            entity.Property(e => e.Time).HasDefaultValue(new TimeOnly(0, 0, 0));
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<EmpShiftMaster>(entity =>
        {
            entity.ToTable("EMP_SHIFT_MASTER");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AllowanceAmount).HasMaxLength(15);
            entity.Property(e => e.ComeLate).HasColumnName("Come_Late");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DeductBreakUp)
                .HasMaxLength(10)
                .HasColumnName("Deduct_break_up");
            entity.Property(e => e.DeletedBy).HasMaxLength(50);
            entity.Property(e => e.DeletedOn).HasColumnType("datetime");
            entity.Property(e => e.DeletedReason).HasMaxLength(150);
            entity.Property(e => e.FirstBreakEndTime).HasColumnName("First_Break_End_Time");
            entity.Property(e => e.FirstBreakStartTime).HasColumnName("First_Break_Start_Time");
            entity.Property(e => e.FirstHalfEndTime).HasColumnName("First_Half_End_Time");
            entity.Property(e => e.GoEarly).HasColumnName("Go_Early");
            entity.Property(e => e.Loc).HasMaxLength(50);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.NightShift).HasColumnName("Night_Shift");
            entity.Property(e => e.OtFull).HasColumnName("OT_FULL");
            entity.Property(e => e.OtHalf).HasColumnName("OT_HALF");
            entity.Property(e => e.PunchEndTime).HasColumnName("Punch_End_Time");
            entity.Property(e => e.PunchStartTime).HasColumnName("Punch_Start_Time");
            entity.Property(e => e.PunchValidTill).HasColumnName("Punch_Valid_till");
            entity.Property(e => e.RuleCode)
                .HasMaxLength(50)
                .HasColumnName("Rule_code");
            entity.Property(e => e.SecondBreakEndTime).HasColumnName("Second_Break_End_Time");
            entity.Property(e => e.SecondBreakStartTime).HasColumnName("Second_Break_Start_Time");
            entity.Property(e => e.ShStartTime).HasColumnName("SH_Start_Time");
            entity.Property(e => e.ShiftCode)
                .HasMaxLength(50)
                .HasColumnName("Shift_code");
            entity.Property(e => e.ShiftEndTime).HasColumnName("Shift_End_Time");
            entity.Property(e => e.ShiftName)
                .HasMaxLength(100)
                .HasColumnName("Shift_Name");
            entity.Property(e => e.ShiftStartTime).HasColumnName("Shift_start_time");
            entity.Property(e => e.Stxt)
                .HasMaxLength(100)
                .HasColumnName("STXT");
            entity.Property(e => e.ThirdBreakEndTime).HasColumnName("Third_Break_End_Time");
            entity.Property(e => e.ThirdBreakStartTime).HasColumnName("Third_Break_Start_Time");
            entity.Property(e => e.TotalShiftTime).HasColumnName("Total_Shift_Time");
            entity.Property(e => e.Username).HasMaxLength(50);
            entity.Property(e => e.WfhFlag).HasColumnName("WFH_Flag");
            entity.Property(e => e.WorkHours).HasMaxLength(10);
        });

        modelBuilder.Entity<EmpShiftReference>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EMP_SHIFT_REFERENCE");

            entity.Property(e => e.Day1).HasMaxLength(50);
            entity.Property(e => e.Day10).HasMaxLength(50);
            entity.Property(e => e.Day11).HasMaxLength(50);
            entity.Property(e => e.Day12).HasMaxLength(50);
            entity.Property(e => e.Day13).HasMaxLength(50);
            entity.Property(e => e.Day14).HasMaxLength(50);
            entity.Property(e => e.Day15).HasMaxLength(50);
            entity.Property(e => e.Day16).HasMaxLength(50);
            entity.Property(e => e.Day17).HasMaxLength(50);
            entity.Property(e => e.Day18).HasMaxLength(50);
            entity.Property(e => e.Day19).HasMaxLength(50);
            entity.Property(e => e.Day2).HasMaxLength(50);
            entity.Property(e => e.Day20).HasMaxLength(50);
            entity.Property(e => e.Day21).HasMaxLength(50);
            entity.Property(e => e.Day22).HasMaxLength(50);
            entity.Property(e => e.Day23).HasMaxLength(50);
            entity.Property(e => e.Day24).HasMaxLength(50);
            entity.Property(e => e.Day25).HasMaxLength(50);
            entity.Property(e => e.Day26).HasMaxLength(50);
            entity.Property(e => e.Day27).HasMaxLength(50);
            entity.Property(e => e.Day28).HasMaxLength(50);
            entity.Property(e => e.Day29).HasMaxLength(50);
            entity.Property(e => e.Day3).HasMaxLength(50);
            entity.Property(e => e.Day30).HasMaxLength(50);
            entity.Property(e => e.Day31).HasMaxLength(50);
            entity.Property(e => e.Day4).HasMaxLength(50);
            entity.Property(e => e.Day5).HasMaxLength(50);
            entity.Property(e => e.Day6).HasMaxLength(50);
            entity.Property(e => e.Day7).HasMaxLength(50);
            entity.Property(e => e.Day8).HasMaxLength(50);
            entity.Property(e => e.Day9).HasMaxLength(50);
            entity.Property(e => e.ShiftCode)
                .HasMaxLength(10)
                .HasColumnName("Shift_code");
        });

        modelBuilder.Entity<EmpShiftRegister>(entity =>
        {
            entity.ToTable("EMP_Shift_Register");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ChangedBy).HasMaxLength(100);
            entity.Property(e => e.ChangedOn).HasColumnType("datetime");
            entity.Property(e => e.Day1).HasMaxLength(50);
            entity.Property(e => e.Day10).HasMaxLength(50);
            entity.Property(e => e.Day11).HasMaxLength(50);
            entity.Property(e => e.Day12).HasMaxLength(50);
            entity.Property(e => e.Day13).HasMaxLength(50);
            entity.Property(e => e.Day14).HasMaxLength(50);
            entity.Property(e => e.Day15).HasMaxLength(50);
            entity.Property(e => e.Day16).HasMaxLength(50);
            entity.Property(e => e.Day17).HasMaxLength(50);
            entity.Property(e => e.Day18).HasMaxLength(50);
            entity.Property(e => e.Day19).HasMaxLength(50);
            entity.Property(e => e.Day2).HasMaxLength(50);
            entity.Property(e => e.Day20).HasMaxLength(50);
            entity.Property(e => e.Day21).HasMaxLength(50);
            entity.Property(e => e.Day22).HasMaxLength(50);
            entity.Property(e => e.Day23).HasMaxLength(50);
            entity.Property(e => e.Day24).HasMaxLength(50);
            entity.Property(e => e.Day25).HasMaxLength(50);
            entity.Property(e => e.Day26).HasMaxLength(50);
            entity.Property(e => e.Day27).HasMaxLength(50);
            entity.Property(e => e.Day28).HasMaxLength(50);
            entity.Property(e => e.Day29).HasMaxLength(50);
            entity.Property(e => e.Day3).HasMaxLength(50);
            entity.Property(e => e.Day30).HasMaxLength(50);
            entity.Property(e => e.Day31).HasMaxLength(50);
            entity.Property(e => e.Day4).HasMaxLength(50);
            entity.Property(e => e.Day5).HasMaxLength(50);
            entity.Property(e => e.Day6).HasMaxLength(50);
            entity.Property(e => e.Day7).HasMaxLength(50);
            entity.Property(e => e.Day8).HasMaxLength(50);
            entity.Property(e => e.Day9).HasMaxLength(50);
            entity.Property(e => e.PayGrp).HasColumnName("Pay_grp");
            entity.Property(e => e.Pernr).HasMaxLength(100);
            entity.Property(e => e.Username).HasMaxLength(100);
            entity.Property(e => e.Year).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee", "HR", tb =>
                {
                    tb.HasTrigger("trg_InsertEmployeeDetails");
                    tb.HasTrigger("trg_UpdateEmployeeDetails");
                });

            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.Building).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CurrentCtc)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("CurrentCTC");
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.DateOfConfirmation).HasColumnType("datetime");
            entity.Property(e => e.DateOfJoining).HasColumnType("datetime");
            entity.Property(e => e.DateOfLeaving).HasColumnType("datetime");
            entity.Property(e => e.EmpNoGeneratedDate).HasColumnType("datetime");
            entity.Property(e => e.EmployeeNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.EmploymentType).HasMaxLength(100);
            entity.Property(e => e.Extension).HasMaxLength(10);
            entity.Property(e => e.FirstName).HasMaxLength(500);
            entity.Property(e => e.Floor).HasMaxLength(50);
            entity.Property(e => e.Initial).HasMaxLength(500);
            entity.Property(e => e.IsSharedEmailId).HasMaxLength(5);
            entity.Property(e => e.LastName).HasMaxLength(500);
            entity.Property(e => e.LeavingType).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(500);
            entity.Property(e => e.MobileNo).HasMaxLength(20);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.OfficialEmailId).HasMaxLength(50);
            entity.Property(e => e.PersonalEmailId).HasMaxLength(50);
            entity.Property(e => e.RoomOrBlock).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TelephoneNo).HasMaxLength(20);
            entity.Property(e => e.Title).HasMaxLength(500);

            entity.HasOne(d => d.Appointment).WithMany(p => p.Employees)
                .HasForeignKey(d => d.AppointmentId)
                .HasConstraintName("FK_Employee_AppointmentId");

            entity.HasOne(d => d.ApprovingManager).WithMany(p => p.EmployeeApprovingManagers)
                .HasForeignKey(d => d.ApprovingManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_ApprovingManagerId");

            entity.HasOne(d => d.CorrespondingAddressType).WithMany(p => p.Employees)
                .HasForeignKey(d => d.CorrespondingAddressTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_CorrespondingAddressTypeId");

            entity.HasOne(d => d.Country).WithMany(p => p.Employees)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Country_Master");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.EmployeeCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_CreatedById");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_DepartmentId");

            entity.HasOne(d => d.Designation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DesignationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Designation_Master");

            entity.HasOne(d => d.EmployeeCategory).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeeCategoryid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_emp_Category_Master");

            entity.HasOne(d => d.Location).WithMany(p => p.Employees)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Location_Master");

            entity.HasOne(d => d.ModifiedBy).WithMany(p => p.EmployeeModifiedBies)
                .HasForeignKey(d => d.ModifiedById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_ModifiedById");

            entity.HasOne(d => d.Paygroup).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PaygroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Paygroup_Master");

            entity.HasOne(d => d.Plant).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PlantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Plant_Master");

            entity.HasOne(d => d.ReportingGroup).WithMany(p => p.Employees)
                .HasForeignKey(d => d.ReportingGroupId)
                .HasConstraintName("FK_Employee_ReportingGroupId");

            entity.HasOne(d => d.ReportingManager).WithMany(p => p.EmployeeReportingManagers)
                .HasForeignKey(d => d.ReportingManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_ReportingManagerId");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Role_Master");

            entity.HasOne(d => d.State).WithMany(p => p.Employees)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_State_Master");

            entity.HasOne(d => d.SubDepartment).WithMany(p => p.Employees)
                .HasForeignKey(d => d.SubDepartmentId)
                .HasConstraintName("FK_Employee_SubDepartmentId");
        });

        modelBuilder.Entity<EmployeeAddress>(entity =>
        {
            entity.ToTable("Employee_Address");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CurrentAddress)
                .HasMaxLength(500)
                .HasColumnName("Current_Address");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.EmgContactName)
                .HasMaxLength(50)
                .HasColumnName("Emg_Contact_Name");
            entity.Property(e => e.EmgContactNumber)
                .HasMaxLength(50)
                .HasColumnName("Emg_Contact_Number");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(50)
                .HasColumnName("Employee_ID");
            entity.Property(e => e.FkEmpId).HasColumnName("FK_Emp_ID");
            entity.Property(e => e.GuardianName)
                .HasMaxLength(50)
                .HasColumnName("Guardian_Name");
            entity.Property(e => e.GuardianPhone)
                .HasMaxLength(50)
                .HasColumnName("Guardian_Phone");
            entity.Property(e => e.GuardianRelation)
                .HasMaxLength(50)
                .HasColumnName("Guardian_Relation");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ModuleEnableId).HasColumnName("Module_enableId");
            entity.Property(e => e.NomineeName)
                .HasMaxLength(50)
                .HasColumnName("Nominee_Name");
            entity.Property(e => e.NomineePhone)
                .HasMaxLength(50)
                .HasColumnName("Nominee_Phone");
            entity.Property(e => e.PermanentAddress)
                .HasMaxLength(500)
                .HasColumnName("Permanent_Address");
            entity.Property(e => e.PersonalEmail).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
        });

        modelBuilder.Entity<EmployeeAppraisal>(entity =>
        {
            entity.HasKey(e => e.EmployeeAppraisalId).HasName("PK_EmployeeUpdates");

            entity.ToTable("EmployeeAppraisal", "HR");

            entity.Property(e => e.AppraisalType).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EffectiveDate).HasColumnType("datetime");
            entity.Property(e => e.PackageType).HasMaxLength(50);
            entity.Property(e => e.PerformanceRating).HasMaxLength(50);
            entity.Property(e => e.SalaryProcessingMonth).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeAppraisals)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeUpdates_EmployeeUpdates");
        });

        modelBuilder.Entity<EmployeeAppraisalSalary>(entity =>
        {
            entity.HasKey(e => e.EmployeeAppraisalSalaryId).HasName("PK_EmployeeSalaryUpdates");

            entity.ToTable("EmployeeAppraisalSalary", "HR");

            entity.Property(e => e.Amount).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.AnnualAmount).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.EmployeeAppraisal).WithMany(p => p.EmployeeAppraisalSalaries)
                .HasForeignKey(d => d.EmployeeAppraisalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeSalaryUpdates_EmployeeUpdates");

            entity.HasOne(d => d.SalaryHead).WithMany(p => p.EmployeeAppraisalSalaries)
                .HasForeignKey(d => d.SalaryHeadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeSalaryUpdates_Salary_Structure");
        });

        modelBuilder.Entity<EmployeeApproval>(entity =>
        {
            entity.ToTable("Employee_Approval");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(50)
                .HasColumnName("Employee_ID");
            entity.Property(e => e.FkCompetencyId).HasColumnName("FK_Competency_ID");
            entity.Property(e => e.FkDesignation).HasColumnName("FK_Designation");
            entity.Property(e => e.FkEmpId).HasColumnName("FK_Emp_ID");
            entity.Property(e => e.FkHrManagerId).HasColumnName("FK_HR_Manager_ID");
            entity.Property(e => e.FkManagerId).HasColumnName("FK_Manager_ID");
            entity.Property(e => e.FkParentEmployeeId).HasColumnName("FK_Parent_Employee_ID");
            entity.Property(e => e.FkReviewerEmployeeId).HasColumnName("FK_Reviewer_Employee_ID");
            entity.Property(e => e.FkSbuId).HasColumnName("FK_SBU_ID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmployeeAttachment>(entity =>
        {
            entity.ToTable("EmployeeAttachments", "HR");

            entity.Property(e => e.AttachmentType).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FileName).HasMaxLength(200);
            entity.Property(e => e.FilePath).HasMaxLength(500);
            entity.Property(e => e.Note).HasMaxLength(200);
            entity.Property(e => e.ObjectType).HasMaxLength(50);

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.EmployeeAttachments)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeAttachments_CreatedById");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeAttachments)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_EmployeeAttachments_EmployeeId");
        });

        modelBuilder.Entity<EmployeeConfirmation>(entity =>
        {
            entity.ToTable("EmployeeConfirmation", "HR");

            entity.Property(e => e.Achievement)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Comments)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CurrentJobResponsibilty).IsUnicode(false);
            entity.Property(e => e.JobChangeDetails).IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.NewJobResponsibility).IsUnicode(false);
            entity.Property(e => e.NextConfirmation).HasColumnType("datetime");
            entity.Property(e => e.PerformanceRating)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Reason).IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.EmployeeConfirmationCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeConfirmation_CreatedById_Employee_Master");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeConfirmations)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeConfirmation_EmpId_Hr_Employee");

            entity.HasOne(d => d.Hod).WithMany(p => p.EmployeeConfirmationHods)
                .HasForeignKey(d => d.HodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeConfirmation_HodId_Employee_Master");

            entity.HasOne(d => d.ModifiedBy).WithMany(p => p.EmployeeConfirmationModifiedBies)
                .HasForeignKey(d => d.ModifiedById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeConfirmation_ModifiedById_Employee_Master");

            entity.HasOne(d => d.SubmitedBy).WithMany(p => p.EmployeeConfirmationSubmitedBies)
                .HasForeignKey(d => d.SubmitedById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeConfirmation_SubmitedById_Employee_Master");
        });

        modelBuilder.Entity<EmployeeDocument>(entity =>
        {
            entity.ToTable("EmployeeDocuments", "HR");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DocumentType).HasMaxLength(100);
            entity.Property(e => e.FileName).HasMaxLength(200);
            entity.Property(e => e.FilePath).HasMaxLength(500);
            entity.Property(e => e.Note).HasMaxLength(200);
            entity.Property(e => e.ObjectType).HasMaxLength(50);

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.EmployeeDocuments)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeDocuments_CreatedById");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeDocuments)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_EmployeeDocuments_EmployeeId");
        });

        modelBuilder.Entity<EmployeeDummy>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Employee_Dummy");

            entity.Property(e => e.Active).HasColumnName("ACTIVE");
            entity.Property(e => e.AddressLine1)
                .HasColumnType("ntext")
                .HasColumnName("address_line1");
            entity.Property(e => e.Dept).HasMaxLength(100);
            entity.Property(e => e.Desig).HasMaxLength(100);
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .HasColumnName("EMAIL_ID");
            entity.Property(e => e.EmegencyMobileNumber)
                .HasMaxLength(50)
                .HasColumnName("emegency_mobile_number");
            entity.Property(e => e.EmergencyContactPersonName)
                .HasMaxLength(50)
                .HasColumnName("emergency_contact_person_name");
            entity.Property(e => e.EmpFullname)
                .HasMaxLength(100)
                .HasColumnName("EMP_FULLNAME");
            entity.Property(e => e.MobileNo)
                .HasMaxLength(50)
                .HasColumnName("mobile_no");
            entity.Property(e => e.Pernr)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PERNR");
            entity.Property(e => e.Rptmgr)
                .HasMaxLength(8)
                .HasColumnName("RPTMGR");
            entity.Property(e => e.Werks)
                .HasMaxLength(50)
                .HasColumnName("WERKS");
        });

        modelBuilder.Entity<EmployeeDummy1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Employee_Dummy1");

            entity.Property(e => e.AadharNo)
                .HasMaxLength(50)
                .HasColumnName("Aadhar_No");
            entity.Property(e => e.Active).HasColumnName("ACTIVE");
            entity.Property(e => e.Appmgr)
                .HasMaxLength(8)
                .HasColumnName("APPMGR");
            entity.Property(e => e.Baccno)
                .HasMaxLength(50)
                .HasColumnName("BACCNO");
            entity.Property(e => e.Bacctyp)
                .HasMaxLength(30)
                .HasColumnName("BACCTYP");
            entity.Property(e => e.Bankid).HasColumnName("BANKID");
            entity.Property(e => e.BoardLine)
                .HasMaxLength(20)
                .HasColumnName("BOARD_LINE");
            entity.Property(e => e.Bonus)
                .HasMaxLength(5)
                .HasColumnName("BONUS");
            entity.Property(e => e.Branch)
                .HasMaxLength(50)
                .HasColumnName("BRANCH");
            entity.Property(e => e.Building)
                .HasMaxLength(50)
                .HasColumnName("BUILDING");
            entity.Property(e => e.Bukrs)
                .HasMaxLength(4)
                .HasColumnName("BUKRS");
            entity.Property(e => e.ConId).HasColumnName("Con_ID");
            entity.Property(e => e.ConSal).HasColumnName("Con_SAL");
            entity.Property(e => e.CreatedDate)
                .HasPrecision(3)
                .HasColumnName("Created_date");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Doc).HasColumnName("DOC");
            entity.Property(e => e.Doj).HasColumnName("DOJ");
            entity.Property(e => e.Dol).HasColumnName("DOL");
            entity.Property(e => e.Dptid).HasColumnName("DPTID");
            entity.Property(e => e.Dsgid).HasColumnName("DSGID");
            entity.Property(e => e.Dstatus)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .HasColumnName("EMAIL_ID");
            entity.Property(e => e.EmpFullname)
                .HasMaxLength(100)
                .HasColumnName("EMP_FULLNAME");
            entity.Property(e => e.Esi)
                .HasMaxLength(5)
                .HasColumnName("ESI");
            entity.Property(e => e.Esino)
                .HasMaxLength(50)
                .HasColumnName("ESINO");
            entity.Property(e => e.Floor)
                .HasMaxLength(50)
                .HasColumnName("FLOOR");
            entity.Property(e => e.Grdid)
                .HasMaxLength(5)
                .HasColumnName("GRDID");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IfscCode)
                .HasMaxLength(50)
                .HasColumnName("IFSC_CODE");
            entity.Property(e => e.IpPhone).HasColumnName("IP_PHONE");
            entity.Property(e => e.IsHod).HasColumnName("Is_Hod");
            entity.Property(e => e.It)
                .HasMaxLength(5)
                .HasColumnName("IT");
            entity.Property(e => e.Land1)
                .HasMaxLength(5)
                .HasColumnName("LAND1");
            entity.Property(e => e.Leaves)
                .HasMaxLength(5)
                .HasColumnName("LEAVES");
            entity.Property(e => e.Locid)
                .HasMaxLength(5)
                .HasColumnName("LOCID");
            entity.Property(e => e.MicrCode)
                .HasMaxLength(50)
                .HasColumnName("MICR_CODE");
            entity.Property(e => e.Panno)
                .HasMaxLength(50)
                .HasColumnName("PANNO");
            entity.Property(e => e.PayGroup)
                .HasMaxLength(5)
                .HasColumnName("PAY_GROUP");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("PAYMENT_METHOD");
            entity.Property(e => e.Pdol).HasColumnName("PDOL");
            entity.Property(e => e.Pernr).HasColumnName("PERNR");
            entity.Property(e => e.Pf)
                .HasMaxLength(5)
                .HasColumnName("PF");
            entity.Property(e => e.Pfno)
                .HasMaxLength(50)
                .HasColumnName("PFNO");
            entity.Property(e => e.Pt)
                .HasMaxLength(5)
                .HasColumnName("PT");
            entity.Property(e => e.ReportingGrp).HasColumnName("Reporting_Grp");
            entity.Property(e => e.Room)
                .HasMaxLength(50)
                .HasColumnName("ROOM");
            entity.Property(e => e.Rptmgr)
                .HasMaxLength(8)
                .HasColumnName("RPTMGR");
            entity.Property(e => e.RuleCode)
                .HasMaxLength(10)
                .HasColumnName("Rule_Code");
            entity.Property(e => e.SapApprovedDate)
                .HasPrecision(3)
                .HasColumnName("SAP_Approved_Date");
            entity.Property(e => e.SapMessage)
                .HasMaxLength(500)
                .HasColumnName("SAP_Message");
            entity.Property(e => e.SapStatus)
                .HasMaxLength(10)
                .HasColumnName("SAP_Status");
            entity.Property(e => e.Sdptid).HasColumnName("SDPTID");
            entity.Property(e => e.Sdptid1).HasColumnName("SDPTID_1");
            entity.Property(e => e.Sex)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SEX");
            entity.Property(e => e.ShiftCode)
                .HasMaxLength(10)
                .HasColumnName("Shift_Code");
            entity.Property(e => e.Staffcat)
                .HasMaxLength(5)
                .HasColumnName("STAFFCAT");
            entity.Property(e => e.State).HasColumnName("STATE");
            entity.Property(e => e.SwipeCount).HasColumnName("Swipe_Count");
            entity.Property(e => e.SwipeNo).HasColumnName("Swipe_No");
            entity.Property(e => e.TelExtens).HasColumnName("TEL_EXTENS");
            entity.Property(e => e.TelNo)
                .HasMaxLength(50)
                .HasColumnName("TEL_NO");
            entity.Property(e => e.Title)
                .HasMaxLength(10)
                .HasColumnName("TITLE");
            entity.Property(e => e.Uanno)
                .HasMaxLength(50)
                .HasColumnName("UANNO");
            entity.Property(e => e.Waers)
                .HasMaxLength(5)
                .HasColumnName("WAERS");
            entity.Property(e => e.Werks)
                .HasMaxLength(50)
                .HasColumnName("WERKS");
            entity.Property(e => e.Wing).HasMaxLength(50);
            entity.Property(e => e.WorkId).HasColumnName("Work_ID");
        });

        modelBuilder.Entity<EmployeeInitialAppraisalDetail>(entity =>
        {
            entity.HasKey(e => e.EmployeeInitialAppraisalDetailId).HasName("PK_InitialAppraisalDetail");

            entity.ToTable("EmployeeInitialAppraisalDetail", "HR");

            entity.Property(e => e.AppraisalInitiatorType).HasMaxLength(50);
            entity.Property(e => e.AppraisalType).HasMaxLength(50);
            entity.Property(e => e.InitialAppraisalApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.InitiatedDate).HasColumnType("datetime");
            entity.Property(e => e.Rating).HasMaxLength(200);
            entity.Property(e => e.RecommendedSalary).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.SpecialAchievement).HasMaxLength(200);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Hod).WithMany(p => p.EmployeeInitialAppraisalDetailHods)
                .HasForeignKey(d => d.HodId)
                .HasConstraintName("FK_InitialAppraisalDetail_Employee_Master1");

            entity.HasOne(d => d.InitiatedBy).WithMany(p => p.EmployeeInitialAppraisalDetailInitiatedBies)
                .HasForeignKey(d => d.InitiatedById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InitialAppraisalDetail_Employee_Master");

            entity.HasOne(d => d.RecommendedDesignation).WithMany(p => p.EmployeeInitialAppraisalDetails)
                .HasForeignKey(d => d.RecommendedDesignationId)
                .HasConstraintName("FK_EmployeeInitialAppraisalDetail_Designation_Master");

            entity.HasOne(d => d.RecommendedRole).WithMany(p => p.EmployeeInitialAppraisalDetails)
                .HasForeignKey(d => d.RecommendedRoleId)
                .HasConstraintName("FK_EmployeeInitialAppraisalDetail_Role_Master");
        });

        modelBuilder.Entity<EmployeeMaster>(entity =>
        {
            entity.ToTable("Employee_Master");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BaseLocation)
                .HasMaxLength(50)
                .HasColumnName("Base_Location");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Designation).HasMaxLength(100);
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Dol)
                .HasColumnType("datetime")
                .HasColumnName("DOL");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(10)
                .HasColumnName("Employee_ID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(1000)
                .HasColumnName("First_Name");
            entity.Property(e => e.FkAddressId).HasColumnName("FK_Address_ID");
            entity.Property(e => e.FkApprovalTemplateId).HasColumnName("FK_Approval_Template_ID");
            entity.Property(e => e.FkCompetency).HasColumnName("FK_Competency");
            entity.Property(e => e.FkDepartment).HasColumnName("FK_Department");
            entity.Property(e => e.FkDesignation).HasColumnName("FK_Designation");
            entity.Property(e => e.FkManager).HasColumnName("FK_Manager");
            entity.Property(e => e.FkOtherDetailsId).HasColumnName("FK_Other_Details_ID");
            entity.Property(e => e.FkParentId).HasColumnName("FK_Parent_ID");
            entity.Property(e => e.FkParentIdCount).HasColumnName("FK_Parent_ID_Count");
            entity.Property(e => e.FkPayroll).HasColumnName("FK_Payroll");
            entity.Property(e => e.FkProfileId).HasColumnName("FK_Profile_Id");
            entity.Property(e => e.FkProjectId).HasColumnName("FK_Project_ID");
            entity.Property(e => e.FkReportingManager).HasColumnName("FK_Reporting_Manager");
            entity.Property(e => e.FkRoleId).HasColumnName("FK_Role_ID");
            entity.Property(e => e.FkSbuId).HasColumnName("FK_SBU_Id");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(200)
                .HasColumnName("Img_Url");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.JoiningDate).HasColumnType("datetime");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.RedirectUrl).HasMaxLength(500);

            entity.HasOne(d => d.FkDesignationNavigation).WithMany(p => p.EmployeeMasters)
                .HasForeignKey(d => d.FkDesignation)
                .HasConstraintName("FK_Employee_Master_Designation_Master");

            entity.HasOne(d => d.FkProfile).WithMany(p => p.EmployeeMasters)
                .HasForeignKey(d => d.FkProfileId)
                .HasConstraintName("FK_Employee_Master_Profile_Master");

            entity.HasOne(d => d.FkRole).WithMany(p => p.EmployeeMasters)
                .HasForeignKey(d => d.FkRoleId)
                .HasConstraintName("FK_Employee_Master_Sub_Roles");
        });

        modelBuilder.Entity<EmployeeMaster1>(entity =>
        {
            entity.ToTable("Employee_Master1");

            entity.Property(e => e.BaseLocation).HasColumnName("Base_Location");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Designation).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Employee_ID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("First_Name");
            entity.Property(e => e.FkAddressId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("FK_Address_ID");
            entity.Property(e => e.FkApprovalTemplateId).HasColumnName("FK_Approval_Template_ID");
            entity.Property(e => e.FkCompetency).HasColumnName("FK_Competency");
            entity.Property(e => e.FkDepartment).HasColumnName("FK_Department");
            entity.Property(e => e.FkDesignation).HasColumnName("FK_Designation");
            entity.Property(e => e.FkManager)
                .HasMaxLength(8)
                .HasColumnName("FK_Manager");
            entity.Property(e => e.FkOtherDetailsId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("FK_Other_Details_ID");
            entity.Property(e => e.FkParentId)
                .HasMaxLength(8)
                .HasColumnName("FK_Parent_ID");
            entity.Property(e => e.FkParentIdCount).HasColumnName("FK_Parent_ID_Count");
            entity.Property(e => e.FkPayroll).HasColumnName("FK_Payroll");
            entity.Property(e => e.FkProfileId).HasColumnName("FK_Profile_Id");
            entity.Property(e => e.FkProjectId).HasColumnName("FK_Project_ID");
            entity.Property(e => e.FkReportingManager)
                .HasMaxLength(8)
                .HasColumnName("FK_Reporting_Manager");
            entity.Property(e => e.FkRoleId).HasColumnName("FK_Role_ID");
            entity.Property(e => e.FkSbuId).HasColumnName("FK_SBU_Id");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Img_Url");
            entity.Property(e => e.LastName)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmployeeOtherDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Employee_Other");

            entity.ToTable("Employee_Other_Details");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CurrentLocation)
                .HasMaxLength(100)
                .HasColumnName("Current_location");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(10)
                .HasColumnName("Employee_ID");
            entity.Property(e => e.FkEmpId).HasColumnName("FK_Emp_ID");
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.HardSkill)
                .HasMaxLength(500)
                .HasColumnName("Hard_skill");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(200)
                .HasColumnName("Img_Url");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastCompany)
                .HasMaxLength(100)
                .HasColumnName("Last_company");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PanNumber)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.PassportNumber).HasMaxLength(50);
            entity.Property(e => e.PreviousLocation)
                .HasMaxLength(100)
                .HasColumnName("Previous_location");
            entity.Property(e => e.Qualification).HasMaxLength(100);
            entity.Property(e => e.RelativeExp).HasColumnName("Relative_Exp");
            entity.Property(e => e.SecondLastCompany)
                .HasMaxLength(100)
                .HasColumnName("Second_Last_company");
            entity.Property(e => e.SoftSkill)
                .HasMaxLength(500)
                .HasColumnName("Soft_skill");
            entity.Property(e => e.VisaIsActive).HasColumnName("Visa_IsActive");
            entity.Property(e => e.VisaNumber).HasMaxLength(50);
            entity.Property(e => e.YearExp).HasColumnName("Year_Exp");
            entity.Property(e => e.YearOfPassing)
                .HasMaxLength(50)
                .HasColumnName("Year_of_passing");
        });

        modelBuilder.Entity<EmployeePayroll>(entity =>
        {
            entity.ToTable("Employee_Payroll");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AppraisalDueDate).HasColumnName("Appraisal_Due_Date");
            entity.Property(e => e.BillingRate).HasColumnName("Billing_Rate");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CurrentAnnualCtc).HasColumnName("Current_Annual_CTC");
            entity.Property(e => e.CurrentWorkStatus)
                .HasMaxLength(50)
                .HasColumnName("Current_Work_Status");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(10)
                .HasColumnName("Employee_ID");
            entity.Property(e => e.FixedCtc).HasColumnName("Fixed_CTC");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PreviousAppraisalDate).HasColumnName("Previous_Appraisal_Date");
            entity.Property(e => e.VeriablePay).HasColumnName("Veriable_Pay");
        });

        modelBuilder.Entity<EmployeePpcMapping>(entity =>
        {
            entity.HasKey(e => e.EmployeePpcmappingId).HasName("PK_Emp_PPC_Mapping");

            entity.ToTable("Employee_PPC_Mapping");

            entity.Property(e => e.EmployeePpcmappingId).HasColumnName("EmployeePPCMappingId");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmployeeResignationDetail>(entity =>
        {
            entity.HasKey(e => e.ResignationId).HasName("PK_Employee_Resignation_Details");

            entity.ToTable("EmployeeResignationDetails", "HR");

            entity.Property(e => e.ExitInterviewSubmittedDate).HasColumnType("datetime");
            entity.Property(e => e.Hod).HasColumnName("HOD");
            entity.Property(e => e.Reason).HasMaxLength(100);
            entity.Property(e => e.ReasonDetail).HasMaxLength(1000);
            entity.Property(e => e.ReasonExpectedDateChange).HasMaxLength(1000);
            entity.Property(e => e.ReasonForNoExitInterview).HasMaxLength(500);
            entity.Property(e => e.ResignationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeResignationDetails)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeResignation_EmployeeId");

            entity.HasOne(d => d.ExitInterviewTemplate).WithMany(p => p.EmployeeResignationDetails)
                .HasForeignKey(d => d.ExitInterviewTemplateId)
                .HasConstraintName("FK_EmployeeResignationDetails_ExitInterviewTemplateId");
        });

        modelBuilder.Entity<EmployeeRetirementDetail>(entity =>
        {
            entity.HasKey(e => e.EmployeeRetirementDetailsId);

            entity.ToTable("EmployeeRetirementDetails", "HR");

            entity.Property(e => e.ApprovalDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ExtendedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.Status).HasMaxLength(40);
            entity.Property(e => e.SubmittedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.EmployeeRetirementDetailCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeRetirementDetails_CreatedById");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeRetirementDetails)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeRetirementDetails_EmployeeId");

            entity.HasOne(d => d.ModifiedBy).WithMany(p => p.EmployeeRetirementDetailModifiedBies)
                .HasForeignKey(d => d.ModifiedById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeRetirementDetails_ModifiedById");
        });

        modelBuilder.Entity<EmployeeSalaryDetail>(entity =>
        {
            entity.HasKey(e => e.EmployeeSalaryDetailsId);

            entity.ToTable("EmployeeSalaryDetails", "HR");

            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.OfferedSalary).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PackageType).HasMaxLength(20);
            entity.Property(e => e.SalaryType).HasMaxLength(20);
            entity.Property(e => e.SecondYearCtc)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("SecondYearCTC");
            entity.Property(e => e.ThirdYearCtc)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("ThirdYearCTC");

            entity.HasOne(d => d.Allowance).WithMany(p => p.EmployeeSalaryDetails)
                .HasForeignKey(d => d.AllowanceId)
                .HasConstraintName("FK_EmployeeSalaryDetails_AllowanceId");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeSalaryDetails)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeSalaryDetails_EmployeeId");
        });

        modelBuilder.Entity<EmployeeSalaryHeadDetail>(entity =>
        {
            entity.HasKey(e => e.EmployeeSalaryHeadDetailsId);

            entity.ToTable("EmployeeSalaryHeadDetails", "HR");

            entity.Property(e => e.Amount).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.AnnualAmount).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeSalaryHeadDetails)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeSalaryHeadDetails_EmployeeId");

            entity.HasOne(d => d.SalaryHead).WithMany(p => p.EmployeeSalaryHeadDetails)
                .HasForeignKey(d => d.SalaryHeadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeSalaryHeadDetails_SalaryHeadId");
        });

        modelBuilder.Entity<EmployeeSalaryHeadPayableDetail>(entity =>
        {
            entity.HasKey(e => e.EmployeeSalaryHeadPayableDetailsId);

            entity.ToTable("EmployeeSalaryHeadPayableDetails", "HR");

            entity.Property(e => e.Month).HasMaxLength(20);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeSalaryHeadPayableDetails)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeSalaryHeadPayableDetails_EmployeeId");

            entity.HasOne(d => d.SalaryHead).WithMany(p => p.EmployeeSalaryHeadPayableDetails)
                .HasForeignKey(d => d.SalaryHeadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeSalaryHeadPayableDetails_SalaryHeadId");
        });

        modelBuilder.Entity<EmployeeSalaryHistory>(entity =>
        {
            entity.ToTable("EmployeeSalaryHistory", "HR");

            entity.Property(e => e.EmployeeSalaryHistoryId).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.AnnualAmount).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.ObjectTypeId).HasMaxLength(50);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeSalaryHistories)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeSalaryHistory_Employee");

            entity.HasOne(d => d.SalaryHead).WithMany(p => p.EmployeeSalaryHistories)
                .HasForeignKey(d => d.SalaryHeadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeSalaryHistory_Salary_Structure");
        });

        modelBuilder.Entity<EmployeeTerminationDetail>(entity =>
        {
            entity.HasKey(e => e.EmployeeTerminationDetailsId).HasName("PK__Employee__A037655C63B7A71B");

            entity.Property(e => e.AdditionalNote)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ApplicableDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Reason).HasMaxLength(50);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.EmployeeTerminationDetailCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployeeT__Creat__23D42350");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeTerminationDetails)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployeeT__Emplo__22DFFF17");

            entity.HasOne(d => d.ModifiedBy).WithMany(p => p.EmployeeTerminationDetailModifiedBies)
                .HasForeignKey(d => d.ModifiedById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployeeT__Modif__24C84789");
        });

        modelBuilder.Entity<ErrorLog>(entity =>
        {
            entity.ToTable("ErrorLog");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApplicationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ErrorDate).HasColumnType("datetime");
            entity.Property(e => e.ErrorDetails)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.FkEmail).HasColumnName("FK_Email");
            entity.Property(e => e.FunctionName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IpAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LineNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PageName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ErrorMaster>(entity =>
        {
            entity.ToTable("ErrorMaster");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RedirectUrl)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EscalationCalendar>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ESCALATION_CALENDAR");

            entity.Property(e => e.Cbwh)
                .HasMaxLength(10)
                .HasColumnName("CBWH");
            entity.Property(e => e.Date).HasColumnName("DATE");
            entity.Property(e => e.Ml00)
                .HasMaxLength(10)
                .HasColumnName("ML00");
            entity.Property(e => e.Ml01)
                .HasMaxLength(10)
                .HasColumnName("ML01");
            entity.Property(e => e.Ml02)
                .HasMaxLength(10)
                .HasColumnName("ML02");
            entity.Property(e => e.Ml03)
                .HasMaxLength(10)
                .HasColumnName("ML03");
            entity.Property(e => e.Ml04)
                .HasMaxLength(10)
                .HasColumnName("ML04");
            entity.Property(e => e.Ml05)
                .HasMaxLength(10)
                .HasColumnName("ML05");
            entity.Property(e => e.Ml06)
                .HasMaxLength(10)
                .HasColumnName("ML06");
            entity.Property(e => e.Ml07)
                .HasMaxLength(10)
                .HasColumnName("ML07");
            entity.Property(e => e.Ml08)
                .HasMaxLength(10)
                .HasColumnName("ML08");
            entity.Property(e => e.Ml09)
                .HasMaxLength(10)
                .HasColumnName("ML09");
            entity.Property(e => e.Ml10)
                .HasMaxLength(10)
                .HasColumnName("ML10");
            entity.Property(e => e.Ml11)
                .HasMaxLength(10)
                .HasColumnName("ML11");
            entity.Property(e => e.Ml12)
                .HasMaxLength(10)
                .HasColumnName("ML12");
            entity.Property(e => e.Ml13)
                .HasMaxLength(10)
                .HasColumnName("ML13");
            entity.Property(e => e.Ml14)
                .HasMaxLength(10)
                .HasColumnName("ML14");
            entity.Property(e => e.Ml15)
                .HasMaxLength(10)
                .HasColumnName("ML15");
            entity.Property(e => e.Ml16)
                .HasMaxLength(10)
                .HasColumnName("ML16");
            entity.Property(e => e.Ml17)
                .HasMaxLength(10)
                .HasColumnName("ML17");
            entity.Property(e => e.Ml18)
                .HasMaxLength(10)
                .HasColumnName("ML18");
            entity.Property(e => e.Ml19)
                .HasMaxLength(10)
                .HasColumnName("ML19");
            entity.Property(e => e.Ml20)
                .HasMaxLength(10)
                .HasColumnName("ML20");
            entity.Property(e => e.Ml21)
                .HasMaxLength(10)
                .HasColumnName("ML21");
            entity.Property(e => e.Ml22)
                .HasMaxLength(10)
                .HasColumnName("ML22");
            entity.Property(e => e.Ml23)
                .HasMaxLength(10)
                .HasColumnName("ML23");
            entity.Property(e => e.Ml24)
                .HasMaxLength(10)
                .HasColumnName("ML24");
            entity.Property(e => e.Ml25)
                .HasMaxLength(10)
                .HasColumnName("ML25");
            entity.Property(e => e.Ml26)
                .HasMaxLength(10)
                .HasColumnName("ML26");
            entity.Property(e => e.Ml27)
                .HasMaxLength(10)
                .HasColumnName("ML27");
            entity.Property(e => e.Ml51)
                .HasMaxLength(10)
                .HasColumnName("ML51");
            entity.Property(e => e.Ml52)
                .HasMaxLength(10)
                .HasColumnName("ML52");
            entity.Property(e => e.Ml53)
                .HasMaxLength(10)
                .HasColumnName("ML53");
            entity.Property(e => e.Ml54)
                .HasMaxLength(10)
                .HasColumnName("ML54");
            entity.Property(e => e.Ml55)
                .HasMaxLength(10)
                .HasColumnName("ML55");
            entity.Property(e => e.Ml56)
                .HasMaxLength(10)
                .HasColumnName("ML56");
            entity.Property(e => e.Ml57)
                .HasMaxLength(10)
                .HasColumnName("ML57");
            entity.Property(e => e.Ml58)
                .HasMaxLength(10)
                .HasColumnName("ML58");
            entity.Property(e => e.Ml59)
                .HasMaxLength(10)
                .HasColumnName("ML59");
            entity.Property(e => e.Ml60)
                .HasMaxLength(10)
                .HasColumnName("ML60");
            entity.Property(e => e.Ml61)
                .HasMaxLength(10)
                .HasColumnName("ML61");
            entity.Property(e => e.Ml62)
                .HasMaxLength(10)
                .HasColumnName("ML62");
            entity.Property(e => e.Ml63)
                .HasMaxLength(10)
                .HasColumnName("ML63");
            entity.Property(e => e.Ml64)
                .HasMaxLength(10)
                .HasColumnName("ML64");
            entity.Property(e => e.Ml65)
                .HasMaxLength(10)
                .HasColumnName("ML65");
            entity.Property(e => e.Ml66)
                .HasMaxLength(10)
                .HasColumnName("ML66");
            entity.Property(e => e.Ml67)
                .HasMaxLength(10)
                .HasColumnName("ML67");
            entity.Property(e => e.Ml68)
                .HasMaxLength(10)
                .HasColumnName("ML68");
            entity.Property(e => e.Ml69)
                .HasMaxLength(10)
                .HasColumnName("ML69");
            entity.Property(e => e.Ml90)
                .HasMaxLength(10)
                .HasColumnName("ML90");
            entity.Property(e => e.Ml91)
                .HasMaxLength(10)
                .HasColumnName("ML91");
            entity.Property(e => e.Ml92)
                .HasMaxLength(10)
                .HasColumnName("ML92");
        });

        modelBuilder.Entity<EssApprover>(entity =>
        {
            entity.ToTable("ESS_Approvers");

            entity.Property(e => e.ApproverId).HasMaxLength(10);
            entity.Property(e => e.EmployeeNumber)
                .HasMaxLength(10)
                .HasColumnName("employeeNumber");
            entity.Property(e => e.EssType)
                .HasMaxLength(20)
                .HasColumnName("essType");
            entity.Property(e => e.ParallelApprover1)
                .HasMaxLength(10)
                .HasColumnName("Parallel_Approver1");
            entity.Property(e => e.ParallelApprover2)
                .HasMaxLength(10)
                .HasColumnName("Parallel_Approver2");
            entity.Property(e => e.ReqType)
                .HasMaxLength(20)
                .HasColumnName("reqType");
        });

        modelBuilder.Entity<EssCancelAppr>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ESS_CANCEL_APPR");

            entity.Property(e => e.HrNo).HasColumnName("HR_NO");
            entity.Property(e => e.Location).HasColumnName("LOCATION");
        });

        modelBuilder.Entity<EssRestrictionRule>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ESS_RESTRICTION_RULE");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("Created_By");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.DeleteFlag)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("delete_flag");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .HasColumnName("Modified_By");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("Modified_Date");
            entity.Property(e => e.Pernr).HasColumnName("pernr");
            entity.Property(e => e.Prefix)
                .HasMaxLength(10)
                .HasColumnName("prefix");
        });

        modelBuilder.Entity<EssTemplate>(entity =>
        {
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Path).HasMaxLength(100);
        });

        modelBuilder.Entity<ExpVendordetail>(entity =>
        {
            entity.ToTable("exp_vendordetails");

            entity.Property(e => e.ExcepientsDetails).HasColumnName("excepients_details");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(20)
                .HasColumnName("REQUEST_NO");
            entity.Property(e => e.VendorDetails).HasColumnName("vendor_details");
        });

        modelBuilder.Entity<ExpenseCategory>(entity =>
        {
            entity.ToTable("Expense_Category");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ExpenseCategory1)
                .HasMaxLength(50)
                .HasColumnName("Expense Category");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<ExternalUserIdmaster>(entity =>
        {
            entity.ToTable("ExternalUserIDMaster");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Sid).HasColumnName("SId");
            entity.Property(e => e.SoftwareType).HasMaxLength(100);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .HasColumnName("UserID");
            entity.Property(e => e.ValidFrom).HasColumnType("datetime");
            entity.Property(e => e.ValidTo).HasColumnType("datetime");
        });

        modelBuilder.Entity<FeedbackMaster>(entity =>
        {
            entity.ToTable("Feedback_Master");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.FkEmpId).HasColumnName("Fk_EmpID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Resolution).HasMaxLength(1000);
            entity.Property(e => e.ResolvedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<FileUpload>(entity =>
        {
            entity.ToTable("FileUpload");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(50)
                .HasColumnName("Employee_ID");
            entity.Property(e => e.FkAssesmentId).HasColumnName("FK_Assesment_Id");
            entity.Property(e => e.FkEmpId).HasColumnName("FK_Emp_ID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Size).HasMaxLength(50);
            entity.Property(e => e.UploadedProfile).HasMaxLength(150);

            entity.HasOne(d => d.FkAssesment).WithMany(p => p.FileUploads)
                .HasForeignKey(d => d.FkAssesmentId)
                .HasConstraintName("FK_FileUpload_Assesment_Master");

            entity.HasOne(d => d.FkEmp).WithMany(p => p.FileUploads)
                .HasForeignKey(d => d.FkEmpId)
                .HasConstraintName("FK_FileUpload_Employee_Master");
        });

        modelBuilder.Entity<FlexibleTimingsMaster>(entity =>
        {
            entity.ToTable("FlexibleTimings_Master");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Created_By");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("Created_On");
            entity.Property(e => e.EffectiveFrom)
                .HasColumnType("datetime")
                .HasColumnName("Effective_From");
            entity.Property(e => e.FlexiInPunch).HasColumnName("Flexi_In_Punch");
            entity.Property(e => e.IsActive).HasColumnName("Is_Active");
            entity.Property(e => e.Plant).HasMaxLength(50);
            entity.Property(e => e.Shift).HasMaxLength(50);
            entity.Property(e => e.ShiftEndTime).HasColumnName("Shift_End_Time");
            entity.Property(e => e.ShiftStartTime).HasColumnName("Shift_Start_Time");
            entity.Property(e => e.TotalWorkingHours)
                .HasMaxLength(50)
                .HasColumnName("Total_Working_Hours");
        });

        modelBuilder.Entity<Flow>(entity =>
        {
            entity.ToTable("Flows", "HR");

            entity.Property(e => e.ActivityTrace).HasMaxLength(500);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.FlowType).HasMaxLength(50);
            entity.Property(e => e.InitialData).HasMaxLength(500);
            entity.Property(e => e.LastData).HasMaxLength(500);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ObjectType).HasMaxLength(50);
            entity.Property(e => e.Result).HasMaxLength(50);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<FlowApprover>(entity =>
        {
            entity.ToTable("FlowApprovers", "HR");

            entity.Property(e => e.FlowType).HasMaxLength(50);
        });

        modelBuilder.Entity<FlowTask>(entity =>
        {
            entity.ToTable("FlowTasks", "HR");

            entity.Property(e => e.ActivityTrace).HasMaxLength(500);
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.InitialData).HasMaxLength(500);
            entity.Property(e => e.LastData).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Result).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<FlowTaskApprover>(entity =>
        {
            entity.ToTable("FlowTaskApprovers", "HR");
        });

        modelBuilder.Entity<FormMaster>(entity =>
        {
            entity.ToTable("Form_Master");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FormDescription)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ModuleEnableId).HasColumnName("Module_enableId");
            entity.Property(e => e.ModuleName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Temp1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GateEntryD>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Mandt, e.FinYear, e.PlantId, e.GiGateno, e.GiNo, e.ItemNo });

            entity.ToTable("GATE_ENTRY_D");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Mandt)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("MANDT");
            entity.Property(e => e.FinYear)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("FIN_YEAR");
            entity.Property(e => e.PlantId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("PLANT_ID");
            entity.Property(e => e.GiGateno)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("GI_GATENO");
            entity.Property(e => e.GiNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("GI_NO");
            entity.Property(e => e.ItemNo).HasColumnName("ITEM_NO");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.DelFlg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("DEL_FLG");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DELETED_BY");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("DELETED_DATE");
            entity.Property(e => e.FkgateEntryM).HasColumnName("FKGATE_ENTRY_M");
            entity.Property(e => e.InItemDesc)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("IN_ITEM_DESC");
            entity.Property(e => e.InQty)
                .HasColumnType("numeric(10, 3)")
                .HasColumnName("IN_QTY");
            entity.Property(e => e.ItemCode)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("ITEM_CODE");
            entity.Property(e => e.ItemCodeP)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("ITEM_CODE_P");
            entity.Property(e => e.ItemDesc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ITEM_DESC");
            entity.Property(e => e.ItemDescP)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ITEM_DESC_P");
            entity.Property(e => e.LineItem)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LINE_ITEM");
            entity.Property(e => e.MaterialType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MATERIAL_TYPE");
            entity.Property(e => e.Mblnr)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MBLNR");
            entity.Property(e => e.Mjahr)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("MJAHR");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DATE");
            entity.Property(e => e.NoOfCases).HasColumnName("NO_OF_CASES");
            entity.Property(e => e.PoDate)
                .HasColumnType("datetime")
                .HasColumnName("PO_DATE");
            entity.Property(e => e.PoNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PO_NO");
            entity.Property(e => e.Qty)
                .HasColumnType("numeric(10, 3)")
                .HasColumnName("QTY");
            entity.Property(e => e.QtyRcvd)
                .HasColumnType("numeric(10, 3)")
                .HasColumnName("QTY_RCVD");
            entity.Property(e => e.ScrapQty)
                .HasColumnType("numeric(10, 3)")
                .HasColumnName("SCRAP_QTY");
            entity.Property(e => e.Uom)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("UOM");
            entity.Property(e => e.Zeile)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ZEILE");
        });

        modelBuilder.Entity<GateEntryM>(entity =>
        {
            entity.HasKey(e => new { e.Mandt, e.FinYear, e.PlantId, e.GiGateno, e.GiNo });

            entity.ToTable("GATE_ENTRY_M");

            entity.Property(e => e.Mandt)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("MANDT");
            entity.Property(e => e.FinYear)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("FIN_YEAR");
            entity.Property(e => e.PlantId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("PLANT_ID");
            entity.Property(e => e.GiGateno)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("GI_GATENO");
            entity.Property(e => e.GiNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("GI_NO");
            entity.Property(e => e.Ack).HasColumnName("ACK");
            entity.Property(e => e.Comments)
                .IsUnicode(false)
                .HasColumnName("COMMENTS");
            entity.Property(e => e.CourierDate)
                .HasColumnType("datetime")
                .HasColumnName("Courier_Date");
            entity.Property(e => e.CourierName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Courier_Name");
            entity.Property(e => e.CourierNum)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Courier_Num");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.DelFlg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("DEL_FLG");
            entity.Property(e => e.DelReason)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DEL_REASON");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DELETED_BY");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("DELETED_DATE");
            entity.Property(e => e.Deliverymode)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DELIVERYMODE");
            entity.Property(e => e.Deliveryperson)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DELIVERYPERSON");
            entity.Property(e => e.DocDate)
                .HasColumnType("datetime")
                .HasColumnName("DOC_DATE");
            entity.Property(e => e.DocNo)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("DOC_NO");
            entity.Property(e => e.DriverName).HasMaxLength(100);
            entity.Property(e => e.GiDate)
                .HasColumnType("datetime")
                .HasColumnName("GI_DATE");
            entity.Property(e => e.GiType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("GI_TYPE");
            entity.Property(e => e.GoFinYear)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GO_FIN_YEAR");
            entity.Property(e => e.GoNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("GO_NO");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.InTime)
                .HasColumnType("datetime")
                .HasColumnName("IN_TIME");
            entity.Property(e => e.Landx)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LANDX");
            entity.Property(e => e.Lifnr)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LIFNR");
            entity.Property(e => e.LrNo).HasMaxLength(100);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DATE");
            entity.Property(e => e.Name1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME1");
            entity.Property(e => e.Ort01)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("ORT01");
            entity.Property(e => e.PersonName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PERSON_NAME");
            entity.Property(e => e.ReceivedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RECEIVED_BY");
            entity.Property(e => e.ReceivedDate)
                .HasColumnType("datetime")
                .HasColumnName("RECEIVED_DATE");
            entity.Property(e => e.Recid)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("RECID");
            entity.Property(e => e.Regio)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("REGIO");
            entity.Property(e => e.Remarks)
                .IsUnicode(false)
                .HasColumnName("REMARKS");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TransporterName).HasMaxLength(100);
            entity.Property(e => e.Vehicleno)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("VEHICLENO");
        });

        modelBuilder.Entity<GateOutwardD>(entity =>
        {
            entity.HasKey(e => new { e.Mandt, e.FinYear, e.PlantId, e.GoGateno, e.GoNo, e.ItemNo });

            entity.ToTable("GATE_OUTWARD_D");

            entity.Property(e => e.Mandt)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("MANDT");
            entity.Property(e => e.FinYear)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("FIN_YEAR");
            entity.Property(e => e.PlantId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("PLANT_ID");
            entity.Property(e => e.GoGateno)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("GO_GATENO");
            entity.Property(e => e.GoNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("GO_NO");
            entity.Property(e => e.ItemNo).HasColumnName("ITEM_NO");
            entity.Property(e => e.Close)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CLOSE");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.DelFlg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("DEL_FLG");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DELETED_BY");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("DELETED_DATE");
            entity.Property(e => e.ExpReturnDate)
                .HasColumnType("datetime")
                .HasColumnName("EXP_RETURN_DATE");
            entity.Property(e => e.FkgateOutwardM).HasColumnName("FKGATE_OUTWARD_M");
            entity.Property(e => e.Hsnsaccode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("HSNSACCode");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.InItemDesc)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("IN_ITEM_DESC");
            entity.Property(e => e.InQty)
                .HasColumnType("numeric(10, 3)")
                .HasColumnName("IN_QTY");
            entity.Property(e => e.ItemCode)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("ITEM_CODE");
            entity.Property(e => e.ItemCodeP)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("ITEM_CODE_P");
            entity.Property(e => e.ItemDesc)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("ITEM_DESC");
            entity.Property(e => e.ItemDescP)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ITEM_DESC_P");
            entity.Property(e => e.MaterialType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MATERIAL_TYPE");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DATE");
            entity.Property(e => e.NoOfCases).HasColumnName("NO_OF_CASES");
            entity.Property(e => e.PoNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PO_NO");
            entity.Property(e => e.Qty)
                .HasColumnType("numeric(10, 3)")
                .HasColumnName("QTY");
            entity.Property(e => e.Remarks)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("REMARKS");
            entity.Property(e => e.Uom)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("UOM");
            entity.Property(e => e.ValuePerUom)
                .HasColumnType("decimal(38, 2)")
                .HasColumnName("ValuePerUOM");
        });

        modelBuilder.Entity<GateOutwardM>(entity =>
        {
            entity.HasKey(e => new { e.Mandt, e.FinYear, e.PlantId, e.GoGateno, e.GoNo });

            entity.ToTable("GATE_OUTWARD_M");

            entity.Property(e => e.Mandt)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("MANDT");
            entity.Property(e => e.FinYear)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("FIN_YEAR");
            entity.Property(e => e.PlantId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("PLANT_ID");
            entity.Property(e => e.GoGateno)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("GO_GATENO");
            entity.Property(e => e.GoNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("GO_NO");
            entity.Property(e => e.ApprovedBy).HasMaxLength(50);
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.Comments)
                .IsUnicode(false)
                .HasColumnName("comments");
            entity.Property(e => e.CourierDate)
                .HasColumnType("datetime")
                .HasColumnName("Courier_Date");
            entity.Property(e => e.CourierName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Courier_Name");
            entity.Property(e => e.CourierNum)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Courier_Num");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.DcDate)
                .HasColumnType("datetime")
                .HasColumnName("DC_DATE");
            entity.Property(e => e.DcNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DC_NO");
            entity.Property(e => e.DelFlg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("DEL_FLG");
            entity.Property(e => e.DelReason)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DEL_REASON");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DELETED_BY");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("DELETED_DATE");
            entity.Property(e => e.Deliverymode)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DELIVERYMODE");
            entity.Property(e => e.Deliveryperson)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DELIVERYPERSON");
            entity.Property(e => e.DestinationNm)
                .IsUnicode(false)
                .HasColumnName("DESTINATION_NM");
            entity.Property(e => e.DocDate)
                .HasColumnType("datetime")
                .HasColumnName("DOC_DATE");
            entity.Property(e => e.DocNo)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("DOC_NO");
            entity.Property(e => e.DriverName).HasMaxLength(100);
            entity.Property(e => e.ExpOutTime)
                .HasColumnType("datetime")
                .HasColumnName("EXP_OUT_TIME");
            entity.Property(e => e.ExpReturnDate)
                .HasColumnType("datetime")
                .HasColumnName("EXP_RETURN_DATE");
            entity.Property(e => e.GoDate)
                .HasColumnType("datetime")
                .HasColumnName("GO_DATE");
            entity.Property(e => e.GoFlg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("GO_FLG");
            entity.Property(e => e.GoType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("GO_TYPE");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LrNo).HasMaxLength(100);
            entity.Property(e => e.MaterialType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DATE");
            entity.Property(e => e.OutDate)
                .HasColumnType("datetime")
                .HasColumnName("OUT_DATE");
            entity.Property(e => e.OutTime)
                .HasColumnType("datetime")
                .HasColumnName("OUT_TIME");
            entity.Property(e => e.PendingWith).HasMaxLength(50);
            entity.Property(e => e.PersonName)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("PERSON_NAME");
            entity.Property(e => e.Recid)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("RECID");
            entity.Property(e => e.Remarks)
                .IsUnicode(false)
                .HasColumnName("REMARKS");
            entity.Property(e => e.SendingDeptNm)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("SENDING_DEPT_NM");
            entity.Property(e => e.SendingPerson)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("SENDING_PERSON");
            entity.Property(e => e.SendingReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SENDING_REASON");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.TransporterName).HasMaxLength(100);
            entity.Property(e => e.Vehicleno)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("VEHICLENO");
            entity.Property(e => e.VendorGstin)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("VendorGSTIN");
        });

        modelBuilder.Entity<GePoIn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("GE_PO_Inn");

            entity.ToTable("GE_PO_IN");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.DcDate).HasColumnName("DC_Date");
            entity.Property(e => e.DcNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DC_No");
            entity.Property(e => e.FkgateNoId).HasColumnName("FKGateNoID");
            entity.Property(e => e.Fy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FY");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PersonName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PoNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PO_No");
            entity.Property(e => e.SupplierCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SupplierCountry)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SupplierName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SupplierPlace)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.VehicleNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WithPo).HasColumnName("WithPO");

            entity.HasOne(d => d.FkgateNo).WithMany(p => p.GePoIns)
                .HasForeignKey(d => d.FkgateNoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKGateNo_Out_ID");
        });

        modelBuilder.Entity<GePoMaterialIn>(entity =>
        {
            entity.ToTable("GE_PO_Material_IN");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FkgeInId).HasColumnName("FKGe_In_Id");
            entity.Property(e => e.MaterialCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MaterialDescription).IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Qty).HasColumnName("QTY");
            entity.Property(e => e.Qtyreceived).HasColumnName("QTYReceived");
            entity.Property(e => e.Uom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UOM");

            entity.HasOne(d => d.FkgeIn).WithMany(p => p.GePoMaterialIns)
                .HasForeignKey(d => d.FkgeInId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKGE_In_PO_ID");
        });

        modelBuilder.Entity<GePoMaterialOut>(entity =>
        {
            entity.ToTable("GE_PO_Material_Out");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FkgeOutId).HasColumnName("FKGe_Out_Id");
            entity.Property(e => e.MaterialCode).HasMaxLength(50);
            entity.Property(e => e.MaterialDescription).IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.NoCases).HasColumnName("No_Cases");
            entity.Property(e => e.Qty).HasColumnName("QTY");
            entity.Property(e => e.Uom)
                .HasMaxLength(50)
                .HasColumnName("UOM");

            entity.HasOne(d => d.FkgeOut).WithMany(p => p.GePoMaterialOuts)
                .HasForeignKey(d => d.FkgeOutId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKGe_Out_Id");
        });

        modelBuilder.Entity<GePoOut>(entity =>
        {
            entity.ToTable("GE_PO_Out");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.DcDate).HasColumnName("DC_Date");
            entity.Property(e => e.DcNo)
                .HasMaxLength(50)
                .HasColumnName("DC_No");
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Destination)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FkgateNoId).HasColumnName("FKGateNoID");
            entity.Property(e => e.Fy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FY");
            entity.Property(e => e.MaterialType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PersonName)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.PoNo)
                .HasMaxLength(50)
                .HasColumnName("PO_No");
            entity.Property(e => e.SendingPerson)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.VehicleNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WithPo).HasColumnName("WithPO");

            entity.HasOne(d => d.FkgateNo).WithMany(p => p.GePoOuts)
                .HasForeignKey(d => d.FkgateNoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKGateNoID");
        });

        modelBuilder.Entity<GeStoIn>(entity =>
        {
            entity.ToTable("GE_STO_IN");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DcNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DestPlantId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ExerciseNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FkgateNoId).HasColumnName("FKGateNoID");
            entity.Property(e => e.FromLocation).HasMaxLength(100);
            entity.Property(e => e.Fy)
                .HasMaxLength(50)
                .HasColumnName("FY");
            entity.Property(e => e.GoNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.InDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.SendingDepartment)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SendingPerson)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.VehicleNo)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.FkgateNo).WithMany(p => p.GeStoIns)
                .HasForeignKey(d => d.FkgateNoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKGE_STO_Gate_ID");
        });

        modelBuilder.Entity<GeStoMaterialIn>(entity =>
        {
            entity.ToTable("GE_STO_Material_IN");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FkgeStoInId).HasColumnName("FKGe_STO_In_Id");
            entity.Property(e => e.MaterialCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MaterialDescription).IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Qty).HasColumnName("QTY");
            entity.Property(e => e.Qtyreceived).HasColumnName("QTYReceived");
            entity.Property(e => e.Uom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UOM");

            entity.HasOne(d => d.FkgeStoIn).WithMany(p => p.GeStoMaterialIns)
                .HasForeignKey(d => d.FkgeStoInId)
                .HasConstraintName("FKGe_STO_In_Id");
        });

        modelBuilder.Entity<GenericName>(entity =>
        {
            entity.ToTable("GENERIC_NAME");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.GenNameCode)
                .HasMaxLength(50)
                .HasColumnName("GEN_NAME_CODE");
            entity.Property(e => e.GenNameDesc)
                .HasMaxLength(100)
                .HasColumnName("GEN_NAME_DESC");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<GenericUserIdemployee>(entity =>
        {
            entity.ToTable("GenericUserIDEmployee");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(50)
                .HasColumnName("EmployeeID");
            entity.Property(e => e.GenericId).HasColumnName("GenericID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<GenericUserIdmaster>(entity =>
        {
            entity.ToTable("GenericUserIDMaster");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Sid).HasColumnName("SId");
            entity.Property(e => e.SoftwareType).HasMaxLength(100);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .HasColumnName("UserID");
            entity.Property(e => e.ValidFrom).HasColumnType("datetime");
            entity.Property(e => e.ValidTo).HasColumnType("datetime");
        });

        modelBuilder.Entity<GetSlalist>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetSLAList", "IT");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.CategoryType).HasMaxLength(500);
            entity.Property(e => e.ClassificationId).HasColumnName("ClassificationID");
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Itslaid).HasColumnName("ITSLAID");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.WaitTimeUnit)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WaitTimeUnitEscal1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WaitTimeUnitEscal2)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GetUserAccessForm>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetUserAccessForms");

            entity.Property(e => e.FkProfileId).HasColumnName("FK_ProfileId");
            entity.Property(e => e.ModuleEnableId).HasColumnName("Module_enableId");
            entity.Property(e => e.ModuleName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Temp1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GigoapprovalTransaction>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GIGOApprovalTransactions");

            entity.Property(e => e.ApprovedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ApprovedOn).HasColumnType("datetime");
            entity.Property(e => e.Comments)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Department)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Gonumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("GONumber");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.KeyValue)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MainApprover)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ParallelApprover1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ParallelApprover2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ParallelApprover3)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ParallelApprover4)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ParallelApprover5)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TransactionType)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Gigoapprover>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GIGOApprovers");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Department)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Gotype)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("GOType");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.KeyValue)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.MainApprover)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MaterialType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Pa1emailEnabled)
                .HasDefaultValue(false)
                .HasColumnName("PA1EmailEnabled");
            entity.Property(e => e.Pa2emailEnabled)
                .HasDefaultValue(false)
                .HasColumnName("PA2EmailEnabled");
            entity.Property(e => e.Pa3emailEnabled)
                .HasDefaultValue(false)
                .HasColumnName("PA3EmailEnabled");
            entity.Property(e => e.Pa4emailEnabled)
                .HasDefaultValue(false)
                .HasColumnName("PA4EmailEnabled");
            entity.Property(e => e.Pa5emailEnabled)
                .HasDefaultValue(false)
                .HasColumnName("PA5EmailEnabled");
            entity.Property(e => e.ParallelApprover1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ParallelApprover2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ParallelApprover3)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ParallelApprover4)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ParallelApprover5)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Plant)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GigoreasonMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GIGOReasonMaster");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Reason)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GlobalSerialization>(entity =>
        {
            entity.ToTable("GLOBAL_SERIALIZATION");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Aun)
                .HasMaxLength(50)
                .HasColumnName("AUN");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Gtin)
                .HasMaxLength(50)
                .HasColumnName("GTIN");
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.NCodeT)
                .HasMaxLength(50)
                .HasColumnName("n-code_t");
            entity.Property(e => e.NationalCode).HasColumnName("NATIONAL_CODE");
            entity.Property(e => e.PackLevel).HasColumnName("pack_level");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.ReqNo).HasColumnName("Req_No");
            entity.Property(e => e.SerializationReqNo).HasColumnName("SerializationReq_No");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.ToTable("Grade");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Aedtm)
                .HasColumnType("datetime")
                .HasColumnName("AEDTM");
            entity.Property(e => e.Aename)
                .HasMaxLength(12)
                .HasColumnName("AENAME");
            entity.Property(e => e.Cputm)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("CPUTM");
            entity.Property(e => e.Crdat)
                .HasColumnType("datetime")
                .HasColumnName("CRDAT");
            entity.Property(e => e.Grdid)
                .HasMaxLength(3)
                .HasColumnName("GRDID");
            entity.Property(e => e.Grdtxt)
                .HasMaxLength(100)
                .HasColumnName("GRDTXT");
            entity.Property(e => e.Uname)
                .HasMaxLength(12)
                .HasColumnName("UNAME");
        });

        modelBuilder.Entity<GuestHouseBooking>(entity =>
        {
            entity.ToTable("GuestHouseBooking");

            entity.Property(e => e.AdminApprovalDate).HasColumnType("datetime");
            entity.Property(e => e.AdminComments).IsUnicode(false);
            entity.Property(e => e.AdminEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AdminName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CancelComments).IsUnicode(false);
            entity.Property(e => e.Comments).IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EmpDesignation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmpEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmpName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fkpurpose).HasColumnName("FKPurpose");
            entity.Property(e => e.FromDate).HasColumnType("datetime");
            entity.Property(e => e.ManagerApprovalDate).HasColumnType("datetime");
            entity.Property(e => e.ManagerComments).IsUnicode(false);
            entity.Property(e => e.ManagerEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ManagerName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ToDate).HasColumnType("datetime");

            entity.HasOne(d => d.FkpurposeNavigation).WithMany(p => p.GuestHouseBookings)
                .HasForeignKey(d => d.Fkpurpose)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKBook_Purpose");
        });

        modelBuilder.Entity<GuestHouseBookingParticipant>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.EmployeeId).HasMaxLength(50);
            entity.Property(e => e.FkBookingId).HasColumnName("FK_BookingId");
            entity.Property(e => e.Mobile).HasMaxLength(50);
            entity.Property(e => e.MobileCode).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.FkBooking).WithMany(p => p.GuestHouseBookingParticipants)
                .HasForeignKey(d => d.FkBookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking_Id");
        });

        modelBuilder.Entity<GuestHouseFacility>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FkFacilityId).HasColumnName("Fk_FacilityId");
            entity.Property(e => e.FkGuestHouseId).HasColumnName("Fk_GuestHouseId");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.FkFacility).WithMany(p => p.GuestHouseFacilities)
                .HasForeignKey(d => d.FkFacilityId)
                .HasConstraintName("Fk_Facility_Id");

            entity.HasOne(d => d.FkGuestHouse).WithMany(p => p.GuestHouseFacilities)
                .HasForeignKey(d => d.FkGuestHouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_GuestHouse_Id");
        });

        modelBuilder.Entity<GuestHouseLocation>(entity =>
        {
            entity.ToTable("GuestHouseLocation");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<GuestHouseMaster>(entity =>
        {
            entity.ToTable("GuestHouse_Master");

            entity.Property(e => e.AdminApproval).HasColumnName("Admin_Approval");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.FkLocation).HasColumnName("Fk_Location");
            entity.Property(e => e.ManagerApproval).HasColumnName("Manager_Approval");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.NoOfBed).HasColumnName("No_Of_Bed");
            entity.Property(e => e.NoOfRoom).HasColumnName("No_Of_Room");

            entity.HasOne(d => d.FkLocationNavigation).WithMany(p => p.GuestHouseMasters)
                .HasForeignKey(d => d.FkLocation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Location_Master_Id");
        });

        modelBuilder.Entity<GuestHousePicture>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.FileName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FkGuestHouseMasterId).HasColumnName("Fk_GuestHouseMasterID");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Path)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.FkGuestHouseMaster).WithMany(p => p.GuestHousePictures)
                .HasForeignKey(d => d.FkGuestHouseMasterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_GuestHouseMaster_ID");
        });

        modelBuilder.Entity<HeadQuarterDetail>(entity =>
        {
            entity.HasKey(e => e.HeadQuarterId);
        });

        modelBuilder.Entity<HisEmployeePpcMapping>(entity =>
        {
            entity.HasKey(e => e.HisId);

            entity.ToTable("His_Employee_PPC_Mapping");

            entity.Property(e => e.HisId).HasColumnName("His_ID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EmployeePpcmappingId).HasColumnName("EmployeePPCMappingId");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Holiday>(entity =>
        {
            entity.ToTable("holidays");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DayName)
                .HasMaxLength(50)
                .HasColumnName("Day_Name");
            entity.Property(e => e.HolidayDate)
                .HasMaxLength(500)
                .HasColumnName("Holiday_Date");
            entity.Property(e => e.HolidayName)
                .HasMaxLength(500)
                .HasColumnName("Holiday_Name");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Type).HasMaxLength(20);
            entity.Property(e => e.TypeCode).HasMaxLength(50);
            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<HrQuery>(entity =>
        {
            entity.ToTable("HR_QUERIES");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApprovedDate)
                .HasColumnType("datetime")
                .HasColumnName("Approved_date");
            entity.Property(e => e.Category).HasMaxLength(100);
            entity.Property(e => e.Comments).HasMaxLength(50);
            entity.Property(e => e.LastApprover)
                .HasMaxLength(200)
                .HasColumnName("Last_Approver");
            entity.Property(e => e.PendingApprover)
                .HasMaxLength(200)
                .HasColumnName("Pending_Approver");
            entity.Property(e => e.ReqBy)
                .HasMaxLength(50)
                .HasColumnName("Req_by");
            entity.Property(e => e.ReqDate)
                .HasColumnType("datetime")
                .HasColumnName("Req_date");
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<HrQueryApprover>(entity =>
        {
            entity.ToTable("HR_Query_Approvers");

            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.HrId).HasColumnName("HR_ID");
            entity.Property(e => e.Location).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        modelBuilder.Entity<HrQueryCategory>(entity =>
        {
            entity.ToTable("HR_Query_Category");

            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<IndustryM>(entity =>
        {
            entity.ToTable("Industry_M");

            entity.HasIndex(e => e.IndDesc, "UQ_Industry_M").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IndDesc)
                .HasMaxLength(100)
                .HasColumnName("Ind_Desc");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<IssueList>(entity =>
        {
            entity.HasKey(e => e.IssueId).HasName("PK_IT_IssueList");

            entity.ToTable("IssueList", "IT", tb => tb.HasTrigger("TR_IssueListHistory"));

            entity.Property(e => e.IssueId).HasColumnName("IssueID");
            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.AssignedOn).HasColumnType("datetime");
            entity.Property(e => e.Attachment).HasMaxLength(100);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.GuestCompany).HasMaxLength(500);
            entity.Property(e => e.GuestEmail).HasMaxLength(50);
            entity.Property(e => e.GuestName).HasMaxLength(50);
            entity.Property(e => e.GuestReportingManagerEmployeeId).HasMaxLength(50);
            entity.Property(e => e.IssueCode).HasMaxLength(50);
            entity.Property(e => e.IssueDate).HasColumnType("datetime");
            entity.Property(e => e.IssueDesc).HasMaxLength(2000);
            entity.Property(e => e.IssueForGuest)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.IssueSelectedfor).HasMaxLength(50);
            entity.Property(e => e.IssueShotDesc).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.ProposedResolutionOn).HasColumnType("datetime");
            entity.Property(e => e.Remarks)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ResolutionDt).HasColumnType("datetime");
            entity.Property(e => e.ResolutionRemarks).HasMaxLength(3000);
            entity.Property(e => e.Source).HasMaxLength(100);
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<IssueListHistory>(entity =>
        {
            entity.HasKey(e => e.IssueHistoryId).HasName("PK_IT_IssueListHistory");

            entity.ToTable("IssueListHistory", "IT");

            entity.Property(e => e.IssueHistoryId).HasColumnName("IssueHistoryID");
            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.AssignedOn).HasColumnType("datetime");
            entity.Property(e => e.Attachment).HasMaxLength(100);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.GuestCompany).HasMaxLength(500);
            entity.Property(e => e.IssueCode).HasMaxLength(50);
            entity.Property(e => e.IssueDate).HasColumnType("datetime");
            entity.Property(e => e.IssueDesc).HasMaxLength(2000);
            entity.Property(e => e.IssueForGuest)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.IssueHistoryDt).HasColumnType("datetime");
            entity.Property(e => e.IssueId).HasColumnName("IssueID");
            entity.Property(e => e.IssueShotDesc).HasMaxLength(200);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.ProposedResolutionOn).HasColumnType("datetime");
            entity.Property(e => e.Remarks)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ResolutionDt).HasColumnType("datetime");
            entity.Property(e => e.ResolutionRemarks).HasMaxLength(3000);
            entity.Property(e => e.Source).HasMaxLength(100);
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<ItApprovedHardware>(entity =>
        {
            entity.ToTable("ItApprovedHardware");

            entity.Property(e => e.AssetType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Configuration)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.MakeModelNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Make_ModelNo");
            entity.Property(e => e.ManufacturerOemname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Manufacturer_OEMName");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Plant)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProcessOfHavingHardware)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UsageDetails)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ItApprovedHardwareAsset>(entity =>
        {
            entity.ToTable("ItApprovedHardwareAsset");

            entity.Property(e => e.Assets).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<ItApprovedSoftware>(entity =>
        {
            entity.ToTable("ItApprovedSoftware");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DescriptionOfSoftware)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.LicenseMode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LicenseType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.PatchLevel)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Plant)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProcessOfHavingSoftware)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Provider)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SoftwareCategory)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UsageDetails)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Version).HasMaxLength(50);
        });

        modelBuilder.Entity<ItContact>(entity =>
        {
            entity.Property(e => e.BriefResponsibility)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Designation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DetailedResponsibility).IsUnicode(false);
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Hod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("HOD");
            entity.Property(e => e.IntercomNo)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("IntercomNO");
            entity.Property(e => e.MobileNo).HasMaxLength(10);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Photo).IsUnicode(false);
            entity.Property(e => e.ReportingManager)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SittingLocation)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ItFaq>(entity =>
        {
            entity.ToTable("ItFAQ");

            entity.Property(e => e.Answer)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Plant)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Question)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ItPolicy>(entity =>
        {
            entity.Property(e => e.BriefDescription)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Plant)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ItPortalLabel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ItPortalLabel");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Itname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ITName");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<ItService>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DetailsOfService)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Plant).HasMaxLength(100);
            entity.Property(e => e.SupportCategory)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ItSolution>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ItSolutions_1");

            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Keywords).HasMaxLength(10);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.PostedBy).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.Topic).HasMaxLength(50);
            entity.Property(e => e.Version).HasColumnType("decimal(10, 3)");
        });

        modelBuilder.Entity<ItSolutionCategory>(entity =>
        {
            entity.ToTable("ItSolution_Category");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<ItSolutionCategoryTable>(entity =>
        {
            entity.ToTable("ItSolutionCategoryTable");

            entity.Property(e => e.CategoryName).HasMaxLength(60);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
        });

        modelBuilder.Entity<ItSolutionsCommentsLikesAndDisLikesTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ItSolutionsReplyLikesAndDisLikesTable");

            entity.ToTable("ItSolutionsCommentsLikesAndDisLikesTable");

            entity.Property(e => e.LikedOrDisLikedBy).HasMaxLength(50);
        });

        modelBuilder.Entity<ItSolutionsCommentsTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ItSolutionsLikesAndViewsTable");

            entity.ToTable("ItSolutionsCommentsTable");

            entity.Property(e => e.CommentedBy).HasMaxLength(50);
            entity.Property(e => e.CommentedOn).HasColumnType("datetime");

            entity.HasOne(d => d.FkSolution).WithMany(p => p.ItSolutionsCommentsTables)
                .HasForeignKey(d => d.FkSolutionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItSolutionsLikesAndViewsTable_ItSolutions");
        });

        modelBuilder.Entity<ItSolutionsReplyTbl>(entity =>
        {
            entity.ToTable("ItSolutionsReplyTbl");

            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Replies).HasMaxLength(250);
            entity.Property(e => e.ReplyedBy).HasMaxLength(50);
            entity.Property(e => e.ReplyedOn).HasColumnType("datetime");

            entity.HasOne(d => d.FkComments).WithMany(p => p.ItSolutionsReplyTbls)
                .HasForeignKey(d => d.FkCommentsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ItSolutionsReplyTbl_ItSolutionsLikesAndViewsTable");
        });

        modelBuilder.Entity<ItSolutionsUpdateTable>(entity =>
        {
            entity.ToTable("ItSolutionsUpdateTable");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Attachments).HasMaxLength(50);
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Keywords).HasMaxLength(50);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.PostedBy).HasMaxLength(50);
            entity.Property(e => e.Solution).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.Topic).HasMaxLength(50);
            entity.Property(e => e.Version).HasColumnType("decimal(10, 3)");
        });

        modelBuilder.Entity<ItSoutionsViewHistory>(entity =>
        {
            entity.ToTable("ItSoutionsViewHistory");

            entity.Property(e => e.SolutionId).HasMaxLength(50);
            entity.Property(e => e.VersionNo).HasMaxLength(50);
            entity.Property(e => e.ViewedBy).HasMaxLength(50);
        });

        modelBuilder.Entity<ItTraining>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ITTraining");

            entity.ToTable("ItTraining");

            entity.Property(e => e.Agenda).HasMaxLength(100);
            entity.Property(e => e.AreaOfTraining).HasMaxLength(50);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("Created_By");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("Created_On");
            entity.Property(e => e.DetailsOfTrainer)
                .HasMaxLength(50)
                .HasColumnName("Details_Of_Trainer");
            entity.Property(e => e.EmailId).HasMaxLength(70);
            entity.Property(e => e.FromTime).HasColumnName("From_Time");
            entity.Property(e => e.IntendedAudience).HasColumnName("Intended_Audience");
            entity.Property(e => e.LocationOfTraining)
                .HasMaxLength(50)
                .HasColumnName("Location_Of_Training");
            entity.Property(e => e.ModeOfTraining)
                .HasMaxLength(50)
                .HasColumnName("Mode_Of_Training");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .HasColumnName("Modified_By");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("Modified_On");
            entity.Property(e => e.Plant)
                .HasMaxLength(50)
                .HasColumnName("plant");
            entity.Property(e => e.ScheduleOfTraining)
                .HasMaxLength(100)
                .HasColumnName("Schedule_Of_Training");
            entity.Property(e => e.SendEmail).HasColumnName("Send_Email");
            entity.Property(e => e.ToTime).HasColumnName("To_Time");
            entity.Property(e => e.TrainedBy)
                .HasMaxLength(50)
                .HasColumnName("Trained_By");
            entity.Property(e => e.TrainingFrequency)
                .HasMaxLength(50)
                .HasColumnName("Training_Frequency");
            entity.Property(e => e.VirtualMeetingLink)
                .HasMaxLength(50)
                .HasColumnName("Virtual_Meeting_Link");
            entity.Property(e => e.VirtualMeetingPassword)
                .HasMaxLength(50)
                .HasColumnName("Virtual_Meeting_Password");
            entity.Property(e => e.VirtualMeetingTool)
                .HasMaxLength(50)
                .HasColumnName("Virtual_Meeting_Tool");
        });

        modelBuilder.Entity<ItapprovedVendor>(entity =>
        {
            entity.ToTable("ITApprovedVendors");

            entity.Property(e => e.AdditionalNotes).HasColumnName("Additional_Notes");
            entity.Property(e => e.AreWeWorkingWithThisVendor).HasColumnName("Are_WE_Working_With_This_Vendor");
            entity.Property(e => e.Attachments).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.ContactPersonEmailId)
                .HasMaxLength(50)
                .HasColumnName("Contact_Person_EmailId");
            entity.Property(e => e.ContactPersonMobileNo)
                .HasMaxLength(50)
                .HasColumnName("Contact_Person_MobileNo");
            entity.Property(e => e.ContactPersonName)
                .HasMaxLength(50)
                .HasColumnName("Contact_Person_Name");
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CustomerClientDetails).HasColumnName("Customer_Client_Details");
            entity.Property(e => e.Details).HasMaxLength(200);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.NdaCdaSigned)
                .HasMaxLength(50)
                .HasColumnName("NDA_CDA_Signed");
            entity.Property(e => e.Plant).HasMaxLength(50);
            entity.Property(e => e.ReferredBy)
                .HasMaxLength(50)
                .HasColumnName("Referred_By");
            entity.Property(e => e.SapVendorCode)
                .HasMaxLength(10)
                .HasColumnName("SAP_Vendor_Code");
            entity.Property(e => e.ServiceSupplies)
                .HasMaxLength(200)
                .HasColumnName("Service_Supplies");
            entity.Property(e => e.SourcedFrom)
                .HasMaxLength(100)
                .HasColumnName("Sourced_From");
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.TypeOfVendor).HasMaxLength(50);
            entity.Property(e => e.VendorName)
                .HasMaxLength(100)
                .HasColumnName("Vendor_Name");
            entity.Property(e => e.Website).HasMaxLength(50);
        });

        modelBuilder.Entity<ItemCodeModification>(entity =>
        {
            entity.ToTable("ItemCodeModification");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ItemCode).HasMaxLength(50);
            entity.Property(e => e.LastApprover).HasMaxLength(50);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.PendingApprover).HasMaxLength(50);
            entity.Property(e => e.RequestDate).HasColumnType("datetime");
            entity.Property(e => e.RequestNo).HasMaxLength(10);
            entity.Property(e => e.RequestedBy).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<ItemCodeRequest>(entity =>
        {
            entity.ToTable("item_code_request");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdditionalTest).HasColumnName("ADDITIONAL_TEST");
            entity.Property(e => e.ApiName).HasColumnName("apiName");
            entity.Property(e => e.ApiVendorName).HasColumnName("apiVendorName");
            entity.Property(e => e.ApproveDate)
                .HasColumnType("datetime")
                .HasColumnName("approve_date");
            entity.Property(e => e.ApproveType)
                .HasMaxLength(50)
                .HasColumnName("Approve_Type");
            entity.Property(e => e.ApproximateValue)
                .HasMaxLength(50)
                .HasColumnName("APPROXIMATE_VALUE");
            entity.Property(e => e.ArtWorkValidity).HasColumnType("datetime");
            entity.Property(e => e.ArtworkNo)
                .HasMaxLength(20)
                .HasColumnName("ARTWORK_NO");
            entity.Property(e => e.AvailableDmf)
                .HasMaxLength(100)
                .HasColumnName("availableDMF");
            entity.Property(e => e.BatchCode)
                .HasMaxLength(10)
                .HasColumnName("BATCH_CODE");
            entity.Property(e => e.BrandId).HasColumnName("BRAND_ID");
            entity.Property(e => e.Company)
                .HasMaxLength(100)
                .HasColumnName("company");
            entity.Property(e => e.ComponentMake)
                .HasMaxLength(80)
                .HasColumnName("Component_MAKE");
            entity.Property(e => e.CosGradeAndNo).HasColumnName("COS_GRADE_AND_NO");
            entity.Property(e => e.CountryId)
                .HasMaxLength(3)
                .HasColumnName("COUNTRY_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.CustomerName).HasColumnName("CUSTOMER_NAME");
            entity.Property(e => e.DetailedJustification).HasColumnName("DETAILED_JUSTIFICATION");
            entity.Property(e => e.DetailedSpecification).HasColumnName("DETAILED_SPECIFICATION");
            entity.Property(e => e.Dimension)
                .HasMaxLength(100)
                .HasColumnName("DIMENSION");
            entity.Property(e => e.DivisionId)
                .HasMaxLength(2)
                .HasColumnName("DIVISION_ID");
            entity.Property(e => e.DmfGradeId).HasColumnName("DMF_GRADE_ID");
            entity.Property(e => e.DomesticOrExports)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DOMESTIC_OR_EXPORTS");
            entity.Property(e => e.DutyElement)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DUTY_ELEMENT");
            entity.Property(e => e.EMicroRefReqNo)
                .HasMaxLength(50)
                .HasColumnName("eMicroRefReqNo");
            entity.Property(e => e.EquipIntended)
                .HasMaxLength(40)
                .HasColumnName("equip_Intended");
            entity.Property(e => e.EquipmentMake)
                .HasMaxLength(80)
                .HasColumnName("EQUIPMENT_MAKE");
            entity.Property(e => e.EquipmentName)
                .HasMaxLength(80)
                .HasColumnName("EQUIPMENT_NAME");
            entity.Property(e => e.ExcepientsDetails).HasColumnName("excepientsDetails");
            entity.Property(e => e.ExcipientsCheck)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("excipientsCheck");
            entity.Property(e => e.ExistDmfno)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("existDMFNo");
            entity.Property(e => e.ExistLegacyCode)
                .HasMaxLength(100)
                .HasColumnName("existLegacyCode");
            entity.Property(e => e.ExistingItemCode)
                .HasMaxLength(50)
                .HasColumnName("EXISTING_ITEM_CODE");
            entity.Property(e => e.ExistingSapDescription)
                .HasMaxLength(100)
                .HasColumnName("existingSapDescription");
            entity.Property(e => e.ExistingSapItemCode)
                .HasMaxLength(20)
                .HasColumnName("EXISTING_SAP_ITEM_CODE");
            entity.Property(e => e.FgSapProductCode)
                .HasMaxLength(18)
                .HasColumnName("FG_SAP_PRODUCT_CODE");
            entity.Property(e => e.FinishedProductCode).HasColumnName("finishedProductCode");
            entity.Property(e => e.FirstAlphaRaw)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("firstAlphaRaw");
            entity.Property(e => e.GenericName)
                .HasMaxLength(80)
                .HasColumnName("GENERIC_NAME");
            entity.Property(e => e.GlobalSerReq)
                .HasMaxLength(50)
                .HasColumnName("global_ser_req");
            entity.Property(e => e.GrossWeight).HasColumnName("GROSS_WEIGHT");
            entity.Property(e => e.HsnCode)
                .HasMaxLength(50)
                .HasColumnName("HSN_Code");
            entity.Property(e => e.ImmediatePackMat).HasColumnName("immediatePack_Mat");
            entity.Property(e => e.ImmediatePackMatCheck)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("immediatePack_MatCheck");
            entity.Property(e => e.IsArtworkRevision)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IS_ARTWORK_REVISION");
            entity.Property(e => e.IsAsset)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("is_asset");
            entity.Property(e => e.IsCoated)
                .HasMaxLength(100)
                .HasColumnName("is_coated");
            entity.Property(e => e.IsDmfMaterial)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IS_DMF_MATERIAL");
            entity.Property(e => e.IsEquipment)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IS_EQUIPMENT");
            entity.Property(e => e.IsNew)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IS_NEW");
            entity.Property(e => e.IsNewEquipment)
                .HasMaxLength(10)
                .HasColumnName("IS_NEW_Equipment");
            entity.Property(e => e.IsNewFacility)
                .HasMaxLength(10)
                .HasColumnName("IS_NEW_Facility");
            entity.Property(e => e.IsNewFurniture)
                .HasMaxLength(10)
                .HasColumnName("IS_NEW_Furniture");
            entity.Property(e => e.IsSasFormAvailable)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IS_SAS_FORM_AVAILABLE");
            entity.Property(e => e.IsSpare)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IS_SPARE");
            entity.Property(e => e.IsSpareRequired)
                .HasMaxLength(10)
                .HasColumnName("IS_Spare_required");
            entity.Property(e => e.IsVendorSpecificMaterial)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IS_VENDOR_SPECIFIC_MATERIAL");
            entity.Property(e => e.ItemAvailable)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("item_available");
            entity.Property(e => e.ItemCodeExisting).HasColumnName("ItemCode_existing");
            entity.Property(e => e.ItemCodeProposed).HasColumnName("ItemCode_Proposed");
            entity.Property(e => e.ItemFromMultipleVendors)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("itemFromMultipleVendors");
            entity.Property(e => e.ItemspecificVendor)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("itemspecificVendor");
            entity.Property(e => e.LastApprover)
                .HasMaxLength(100)
                .HasColumnName("last_approver");
            entity.Property(e => e.LocationId)
                .HasMaxLength(4)
                .HasColumnName("LOCATION_ID");
            entity.Property(e => e.MachineName)
                .HasMaxLength(40)
                .HasColumnName("MACHINE_NAME");
            entity.Property(e => e.ManufactMatch)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("manufact_match");
            entity.Property(e => e.ManufactureAddress).HasColumnName("manufactureAddress");
            entity.Property(e => e.ManufacturedAt)
                .HasMaxLength(50)
                .HasColumnName("MANUFACTURED_AT");
            entity.Property(e => e.ManufacturingFormula).HasColumnName("manufacturing_formula");
            entity.Property(e => e.Market).HasColumnName("MARKET");
            entity.Property(e => e.MarketCustCount).HasColumnName("market_cust_count");
            entity.Property(e => e.MatchSpecification)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("matchSpecification");
            entity.Property(e => e.MaterialGrade)
                .HasMaxLength(30)
                .HasColumnName("MATERIAL_GRADE");
            entity.Property(e => e.MaterialGroupId)
                .HasMaxLength(9)
                .HasColumnName("MATERIAL_GROUP_ID");
            entity.Property(e => e.MaterialLongName).HasColumnName("MATERIAL_LONG_NAME");
            entity.Property(e => e.MaterialPricing)
                .HasMaxLength(2)
                .HasColumnName("Material_Pricing");
            entity.Property(e => e.MaterialShortName).HasColumnName("MATERIAL_SHORT_NAME");
            entity.Property(e => e.MaterialTypeId)
                .HasMaxLength(4)
                .HasColumnName("MATERIAL_TYPE_ID");
            entity.Property(e => e.MaterialUsedIn)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MATERIAL_USED_IN");
            entity.Property(e => e.Message)
                .HasMaxLength(500)
                .HasColumnName("message");
            entity.Property(e => e.MessageType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Message_Type");
            entity.Property(e => e.MfgrName).HasColumnName("MFGR_NAME");
            entity.Property(e => e.MfrDate)
                .HasColumnType("datetime")
                .HasColumnName("MFR_DATE");
            entity.Property(e => e.MfrNo)
                .HasMaxLength(20)
                .HasColumnName("MFR_NO");
            entity.Property(e => e.Moc)
                .HasMaxLength(25)
                .HasColumnName("moc");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DATE");
            entity.Property(e => e.Molecules)
                .HasMaxLength(500)
                .HasColumnName("molecules");
            entity.Property(e => e.NetWeight).HasColumnName("NET_WEIGHT");
            entity.Property(e => e.NewCustomerName).HasColumnName("NEW_CUSTOMER_NAME");
            entity.Property(e => e.NewLegacyCode)
                .HasMaxLength(100)
                .HasColumnName("newLegacyCode");
            entity.Property(e => e.NewPackSize).HasColumnName("NEW_PACK_SIZE");
            entity.Property(e => e.OemPartNo)
                .HasMaxLength(80)
                .HasColumnName("OEM_PartNo");
            entity.Property(e => e.PackSize)
                .IsUnicode(false)
                .HasColumnName("PACK_SIZE");
            entity.Property(e => e.PackTypeId)
                .HasMaxLength(3)
                .HasColumnName("PACK_TYPE_ID");
            entity.Property(e => e.PackingMaterialGroup)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PACKING_MATERIAL_GROUP");
            entity.Property(e => e.PendingApprover).HasColumnName("pending_approver");
            entity.Property(e => e.PharmacopGrade)
                .HasMaxLength(50)
                .HasColumnName("PHARMACOP_GRADE");
            entity.Property(e => e.PharmacopName).HasColumnName("PHARMACOP_NAME");
            entity.Property(e => e.PharmacopSpecification).HasColumnName("PHARMACOP_SPECIFICATION");
            entity.Property(e => e.PoNumber)
                .HasMaxLength(10)
                .HasColumnName("PO_NUMBER");
            entity.Property(e => e.PrNumber)
                .HasMaxLength(10)
                .HasColumnName("PR_NUMBER");
            entity.Property(e => e.ProdInspMemo)
                .HasMaxLength(18)
                .HasColumnName("PROD_INSP_MEMO");
            entity.Property(e => e.ProductMatch)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("product_match");
            entity.Property(e => e.ProductName).HasColumnName("PRODUCT_NAME");
            entity.Property(e => e.PunchesOrDies).HasColumnName("punches_or_Dies");
            entity.Property(e => e.PunchesOrDiesMatch)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("punches_or_Dies_match");
            entity.Property(e => e.PurchaseGroupId)
                .HasMaxLength(4)
                .HasColumnName("PURCHASE_GROUP_ID");
            entity.Property(e => e.PurposeId).HasColumnName("PURPOSE_ID");
            entity.Property(e => e.QcSpecification)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("qcSpecification");
            entity.Property(e => e.Qualitycomplyspecification)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("qualitycomplyspecification");
            entity.Property(e => e.Range)
                .HasMaxLength(30)
                .HasColumnName("range");
            entity.Property(e => e.Rating)
                .HasMaxLength(30)
                .HasColumnName("rating");
            entity.Property(e => e.ReasonType)
                .HasMaxLength(100)
                .HasColumnName("REASON_TYPE");
            entity.Property(e => e.RecordStatus)
                .HasMaxLength(10)
                .HasColumnName("record_status");
            entity.Property(e => e.RejectedFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("rejected_flag");
            entity.Property(e => e.ReportUrl)
                .HasMaxLength(200)
                .HasColumnName("REPORT_URL");
            entity.Property(e => e.ReqMeetVendorReq)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("reqMeetVendorReq");
            entity.Property(e => e.RequestDate)
                .HasColumnType("datetime")
                .HasColumnName("REQUEST_DATE");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(20)
                .HasColumnName("REQUEST_NO");
            entity.Property(e => e.RequestedBy)
                .HasMaxLength(50)
                .HasColumnName("REQUESTED_BY");
            entity.Property(e => e.RequiredDmf)
                .HasMaxLength(100)
                .HasColumnName("requiredDMF");
            entity.Property(e => e.RetestDays).HasColumnName("RETEST_DAYS");
            entity.Property(e => e.RetestDaysType)
                .HasMaxLength(50)
                .HasColumnName("RETEST_DAYS_TYPE");
            entity.Property(e => e.RevisedArtworkCode)
                .HasMaxLength(100)
                .HasColumnName("revisedArtworkCode");
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.SaleableOrSample)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SALEABLE_OR_SAMPLE");
            entity.Property(e => e.SalesPackId)
                .HasMaxLength(20)
                .HasColumnName("SALES_PACK_ID");
            entity.Property(e => e.SalesUnitOfMeasId)
                .HasMaxLength(3)
                .HasColumnName("SALES_UNIT_OF_MEAS_ID");
            entity.Property(e => e.SameMarCustCount)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Same_mar_cust_count");
            entity.Property(e => e.SapAppStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SAP_APP_Status");
            entity.Property(e => e.SapApprovedDate)
                .HasColumnType("datetime")
                .HasColumnName("SAP_Approved_Date");
            entity.Property(e => e.SapCodeCoated)
                .HasMaxLength(100)
                .HasColumnName("sap_code_coated");
            entity.Property(e => e.SapCodeCore)
                .HasMaxLength(100)
                .HasColumnName("sap_code_core");
            entity.Property(e => e.SapCodeExistCoated)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sap_code_exist_coated");
            entity.Property(e => e.SapCodeExistCore)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sap_code_exist_core");
            entity.Property(e => e.SapCodeExists)
                .HasMaxLength(50)
                .HasColumnName("SAP_CODE_EXISTS");
            entity.Property(e => e.SapCodeNo)
                .HasMaxLength(100)
                .HasColumnName("SAP_CODE_NO");
            entity.Property(e => e.SapCosGradeNo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sapCosGradeNo");
            entity.Property(e => e.SapCreatedBy)
                .HasMaxLength(100)
                .HasColumnName("SAP_CREATED_BY");
            entity.Property(e => e.SapCreationDate)
                .HasColumnType("datetime")
                .HasColumnName("SAP_CREATION_DATE");
            entity.Property(e => e.SapDutyElement)
                .HasMaxLength(100)
                .HasColumnName("sapDutyElement");
            entity.Property(e => e.SapMaterialCodeLists)
                .HasMaxLength(100)
                .HasColumnName("sapMaterialCodeLists");
            entity.Property(e => e.SapMaterialTypeId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sapMaterialTypeId");
            entity.Property(e => e.SapMessage)
                .HasMaxLength(500)
                .HasColumnName("SAP_Message");
            entity.Property(e => e.SapMfgrName)
                .HasMaxLength(100)
                .HasColumnName("sapMfgrName");
            entity.Property(e => e.SapSiteOfManufacture).HasColumnName("sapSiteOfManufacture");
            entity.Property(e => e.SapStatus)
                .HasMaxLength(10)
                .HasColumnName("SAP_Status");
            entity.Property(e => e.SapStatusFlag)
                .HasDefaultValue(0)
                .HasColumnName("sap_statusFlag");
            entity.Property(e => e.SerializationType)
                .HasMaxLength(100)
                .HasColumnName("Serialization_type");
            entity.Property(e => e.SerializedFromDate)
                .HasMaxLength(100)
                .HasColumnName("Serialized_from_date");
            entity.Property(e => e.ServiceCateId)
                .HasMaxLength(4)
                .HasColumnName("SERVICE_CATE_ID");
            entity.Property(e => e.ShelfLife).HasColumnName("SHELF_LIFE");
            entity.Property(e => e.ShelfLifeType)
                .HasMaxLength(50)
                .HasColumnName("SHELF_LIFE_TYPE");
            entity.Property(e => e.SiteOfManufacture).HasColumnName("SITE_OF_MANUFACTURE");
            entity.Property(e => e.SpecialApi).HasColumnName("specialAPI");
            entity.Property(e => e.SpecificationAdditionalTest).HasColumnName("specificationAdditionalTest");
            entity.Property(e => e.SpecificationNo)
                .HasMaxLength(100)
                .HasColumnName("specificationNo");
            entity.Property(e => e.StandardBatchSize).HasColumnName("STANDARD_BATCH_SIZE");
            entity.Property(e => e.StdBatchSizeUom)
                .HasMaxLength(3)
                .HasColumnName("STD_BATCH_SIZE_UOM");
            entity.Property(e => e.Storage)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.StorageCondition)
                .HasMaxLength(2)
                .HasColumnName("STORAGE_CONDITION");
            entity.Property(e => e.StorageConditionother).HasMaxLength(200);
            entity.Property(e => e.StorageLocationId)
                .HasMaxLength(4)
                .HasColumnName("STORAGE_LOCATION_ID");
            entity.Property(e => e.StrengthId)
                .HasMaxLength(3)
                .HasColumnName("STRENGTH_ID");
            entity.Property(e => e.Synonym)
                .HasMaxLength(80)
                .HasColumnName("SYNONYM");
            entity.Property(e => e.TargetWeight).HasColumnName("TARGET_WEIGHT");
            entity.Property(e => e.TargetWeightCoated)
                .HasMaxLength(100)
                .HasColumnName("target_weight_coated");
            entity.Property(e => e.TargetWeightCore)
                .HasMaxLength(100)
                .HasColumnName("target_weight_core");
            entity.Property(e => e.TaxClassification)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Tax_Classification");
            entity.Property(e => e.TempCondition)
                .HasMaxLength(2)
                .HasColumnName("TEMP_CONDITION");
            entity.Property(e => e.TestingSpecMatch)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("testingSpec_match");
            entity.Property(e => e.TestingSpecification).HasColumnName("Testing_Specification");
            entity.Property(e => e.TherapeuticSegmentId)
                .HasMaxLength(3)
                .HasColumnName("THERAPEUTIC_SEGMENT_ID");
            entity.Property(e => e.ToBeUsedInProducts).HasColumnName("TO_BE_USED_IN_PRODUCTS");
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.TypeOfMaterial)
                .HasMaxLength(50)
                .HasColumnName("Type_Of_Material");
            entity.Property(e => e.UnitOfMeasId)
                .HasMaxLength(3)
                .HasColumnName("UNIT_OF_MEAS_ID");
            entity.Property(e => e.Url).HasColumnName("URL");
            entity.Property(e => e.UtilizingDept)
                .HasMaxLength(80)
                .HasColumnName("UTILIZING_DEPT");
            entity.Property(e => e.ValuationClass)
                .HasMaxLength(4)
                .HasColumnName("VALUATION_CLASS");
            entity.Property(e => e.VendorReqMatch)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("vendorReqMatch");
            entity.Property(e => e.VendorSpecific).HasColumnName("vendorSpecific");
            entity.Property(e => e.WeightUom)
                .HasMaxLength(3)
                .HasColumnName("WEIGHT_UOM");
        });

        modelBuilder.Entity<ItemcodeExtenstionRequest>(entity =>
        {
            entity.ToTable("Itemcode_extenstion_request");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApproveDate)
                .HasColumnType("datetime")
                .HasColumnName("approve_date");
            entity.Property(e => e.ApproveType)
                .HasMaxLength(50)
                .HasColumnName("APPROVE_TYPE");
            entity.Property(e => e.CodeExtendedBy).HasMaxLength(50);
            entity.Property(e => e.CodeExtendedOn).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.EMicroRefReqNo)
                .HasMaxLength(50)
                .HasColumnName("eMicroRefReqNo");
            entity.Property(e => e.ExistingSapNo)
                .HasMaxLength(100)
                .HasColumnName("existing_sapNo");
            entity.Property(e => e.ExtendedStorageLocation1)
                .HasMaxLength(50)
                .HasColumnName("EXTENDED_STORAGE_LOCATION_1");
            entity.Property(e => e.ExtendedToPlant1)
                .HasMaxLength(4)
                .HasColumnName("EXTENDED_TO_PLANT_1");
            entity.Property(e => e.FromStorageLocation)
                .HasMaxLength(50)
                .HasColumnName("FROM_STORAGE_LOCATION");
            entity.Property(e => e.HsnCode)
                .HasMaxLength(50)
                .HasColumnName("HSN_CODE");
            entity.Property(e => e.LastApprover)
                .HasMaxLength(100)
                .HasColumnName("last_approver");
            entity.Property(e => e.MaterialCode1)
                .HasMaxLength(100)
                .HasColumnName("MATERIAL_CODE_1");
            entity.Property(e => e.MaterialCode2)
                .HasMaxLength(100)
                .HasColumnName("MATERIAL_CODE_2");
            entity.Property(e => e.MaterialShortName)
                .HasMaxLength(100)
                .HasColumnName("MATERIAL_SHORT_NAME");
            entity.Property(e => e.MaterialTypeId)
                .HasMaxLength(5)
                .HasColumnName("MATERIAL_TYPE_ID");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DATE");
            entity.Property(e => e.PendingApprover)
                .HasMaxLength(500)
                .HasColumnName("pending_approver");
            entity.Property(e => e.Plant1)
                .HasMaxLength(4)
                .HasColumnName("PLANT_1");
            entity.Property(e => e.Plant2)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("PLANT_2");
            entity.Property(e => e.RejectedFlag)
                .HasMaxLength(50)
                .HasColumnName("rejected_flag");
            entity.Property(e => e.RequestDate)
                .HasColumnType("datetime")
                .HasColumnName("REQUEST_DATE");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(10)
                .HasColumnName("REQUEST_NO");
            entity.Property(e => e.SapcreaterFlag)
                .HasMaxLength(50)
                .HasColumnName("SAPCreater_Flag");
            entity.Property(e => e.StorageLocationId1)
                .HasMaxLength(50)
                .HasColumnName("STORAGE_LOCATION_ID_1");
            entity.Property(e => e.ToStorageLocation)
                .HasMaxLength(50)
                .HasColumnName("TO_STORAGE_LOCATION");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("TYPE");
        });

        modelBuilder.Entity<ItportalAuthorisedUserTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ITPortalAuthorisedUserTable");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("createdBy");
            entity.Property(e => e.CreatedOn).HasColumnName("createdOn");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .HasColumnName("modifiedBy");
            entity.Property(e => e.ModifiedOn).HasColumnName("modifiedOn");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("userId");
        });

        modelBuilder.Entity<ItportalContact>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ITPortalContacts");

            entity.Property(e => e.Attendance).HasMaxLength(10);
            entity.Property(e => e.BriefResponsibility).HasMaxLength(100);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Designation).HasMaxLength(50);
            entity.Property(e => e.EmailId).HasMaxLength(50);
            entity.Property(e => e.EmployeeName).HasMaxLength(50);
            entity.Property(e => e.EmployeeNo).HasMaxLength(10);
            entity.Property(e => e.Hod)
                .HasMaxLength(50)
                .HasColumnName("HOD");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.InterComNo).HasMaxLength(4);
            entity.Property(e => e.MobileNo).HasMaxLength(10);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Photo).HasMaxLength(50);
            entity.Property(e => e.ReportingManager).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.SittingLocation).HasMaxLength(50);
        });

        modelBuilder.Entity<ItsolutionsLikesAndDisLikesTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ITSolutionLikesAndDisLikesTable");

            entity.ToTable("ITSolutionsLikesAndDisLikesTable");

            entity.Property(e => e.LikedOrDisLikedBy).HasMaxLength(50);
            entity.Property(e => e.LikedOrDisLikedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<Itsop>(entity =>
        {
            entity.ToTable("ITSOP");

            entity.Property(e => e.Attachments).HasMaxLength(50);
            entity.Property(e => e.BriefDescription)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Plant)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<JobWorkD>(entity =>
        {
            entity.ToTable("JOB_WORK_D");

            entity.Property(e => e.Amount).HasColumnType("decimal(30, 3)");
            entity.Property(e => e.BatchNo).HasMaxLength(50);
            entity.Property(e => e.ChallenNo)
                .HasMaxLength(50)
                .HasColumnName("Challen_No");
            entity.Property(e => e.DoneBy).HasMaxLength(50);
            entity.Property(e => e.DoneOn).HasColumnType("datetime");
            entity.Property(e => e.FkJobWorkM).HasColumnName("Fk_Job_work_M");
            entity.Property(e => e.HsnCode)
                .HasMaxLength(20)
                .HasColumnName("HSN_Code");
            entity.Property(e => e.ItemCode)
                .HasMaxLength(50)
                .HasColumnName("Item_Code");
            entity.Property(e => e.ItemDesc).HasColumnName("Item_Desc");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.PackingDetails)
                .HasMaxLength(250)
                .HasColumnName("Packing_Details");
            entity.Property(e => e.Plant).HasMaxLength(10);
            entity.Property(e => e.Qty).HasColumnType("decimal(10, 3)");
            entity.Property(e => e.Rate).HasColumnType("decimal(25, 3)");
            entity.Property(e => e.TotalDcValue)
                .HasMaxLength(50)
                .HasColumnName("Total_DC_Value");
            entity.Property(e => e.Uom)
                .HasMaxLength(10)
                .HasColumnName("UOM");
        });

        modelBuilder.Entity<JobWorkM>(entity =>
        {
            entity.ToTable("JOB_WORK_M");

            entity.Property(e => e.BillingAddress).HasColumnName("Billing_Address");
            entity.Property(e => e.ChallenDate)
                .HasColumnType("datetime")
                .HasColumnName("Challen_Date");
            entity.Property(e => e.ChallenNo)
                .HasMaxLength(50)
                .HasColumnName("Challen_No");
            entity.Property(e => e.DoneBy).HasMaxLength(50);
            entity.Property(e => e.DoneOn).HasColumnType("datetime");
            entity.Property(e => e.EWayBillNo)
                .HasMaxLength(50)
                .HasColumnName("E_Way_Bill_No");
            entity.Property(e => e.LrDate)
                .HasColumnType("datetime")
                .HasColumnName("LR_Date");
            entity.Property(e => e.LrNo)
                .HasMaxLength(100)
                .HasColumnName("LR_No");
            entity.Property(e => e.ModeOfTransport).HasMaxLength(50);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Pieces).HasMaxLength(50);
            entity.Property(e => e.PlaceOfSupply)
                .HasMaxLength(250)
                .HasColumnName("Place_of_Supply");
            entity.Property(e => e.Plant).HasMaxLength(10);
            entity.Property(e => e.ShippingAddress).HasColumnName("Shipping_Address");
            entity.Property(e => e.TransporterName)
                .HasMaxLength(250)
                .HasColumnName("Transporter_Name");
            entity.Property(e => e.VehicleNo)
                .HasMaxLength(50)
                .HasColumnName("Vehicle_No");
        });

        modelBuilder.Entity<KraCurrentYear>(entity =>
        {
            entity.ToTable("KRA_Current_Year");

            entity.Property(e => e.AssessmentAppraisee).HasColumnName("Assessment_Appraisee");
            entity.Property(e => e.AssessmentAppraiser).HasColumnName("Assessment_Appraiser");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FkAssesmentId).HasColumnName("FK_Assesment_Id");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.KraName)
                .IsUnicode(false)
                .HasColumnName("KRA_Name");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.TargetDate).HasColumnName("Target_Date");
            entity.Property(e => e.Task).IsUnicode(false);

            entity.HasOne(d => d.FkAssesment).WithMany(p => p.KraCurrentYears)
                .HasForeignKey(d => d.FkAssesmentId)
                .HasConstraintName("FK_KRA_Current_Year_Assesment_Master");
        });

        modelBuilder.Entity<KraNextYear>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_KRA_Detail");

            entity.ToTable("KRA_Next_Year");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FkAssesmentId).HasColumnName("FK_Assesment_Id");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.KraName)
                .IsUnicode(false)
                .HasColumnName("KRA_Name");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.TargetDate).HasColumnName("Target_Date");
            entity.Property(e => e.Task).IsUnicode(false);

            entity.HasOne(d => d.FkAssesment).WithMany(p => p.KraNextYears)
                .HasForeignKey(d => d.FkAssesmentId)
                .HasConstraintName("FK_KRA_Next_Year_Assesment_Master");
        });

        modelBuilder.Entity<LaRulesM>(entity =>
        {
            entity.ToTable("LA_Rules_M");

            entity.Property(e => e.AllowanceAmount).HasMaxLength(50);
            entity.Property(e => e.ApplyForgotSwipe).HasColumnName("Apply_ForgotSwipe");
            entity.Property(e => e.ApplyPermissionAfter)
                .HasMaxLength(10)
                .HasColumnName("Apply_Permission_after");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DeletedReason).HasMaxLength(150);
            entity.Property(e => e.LeaveApplyAfter)
                .HasMaxLength(10)
                .HasColumnName("Leave_apply_after");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.OdApplyAfter)
                .HasMaxLength(10)
                .HasColumnName("OD_apply_after");
            entity.Property(e => e.PermissionCountType)
                .HasMaxLength(50)
                .HasColumnName("Permission_count_type");
            entity.Property(e => e.RuleId).HasMaxLength(20);
            entity.Property(e => e.ShiftCode).HasMaxLength(20);
            entity.Property(e => e.WorkHours).HasMaxLength(10);

            entity.HasOne(d => d.EmpcatNavigation).WithMany(p => p.LaRulesMs)
                .HasForeignKey(d => d.Empcat)
                .HasConstraintName("FK_LA_Rules_M_emp_category_master");

            entity.HasOne(d => d.PaygroupNavigation).WithMany(p => p.LaRulesMs)
                .HasForeignKey(d => d.Paygroup)
                .HasConstraintName("FK_LA_Rules_M_Paygroup_Master");

            entity.HasOne(d => d.PlantNavigation).WithMany(p => p.LaRulesMs)
                .HasForeignKey(d => d.Plant)
                .HasConstraintName("FK_LA_Rules_M_Plant_Master");
        });

        modelBuilder.Entity<LanguageM>(entity =>
        {
            entity.ToTable("Language_M");

            entity.HasIndex(e => e.Language, "UQ_Language_M").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(5);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Language).HasMaxLength(100);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<LeaveApplyRule>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LEAVE_APPLY_RULE");

            entity.Property(e => e.Location).HasMaxLength(20);
        });

        modelBuilder.Entity<LeaveDetail>(entity =>
        {
            entity.ToTable("leave_details");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApprovedDate)
                .HasColumnType("datetime")
                .HasColumnName("approved_date");
            entity.Property(e => e.ApprovelStatus)
                .HasMaxLength(50)
                .HasColumnName("Approvel_Status");
            entity.Property(e => e.ApproverId)
                .HasMaxLength(50)
                .HasColumnName("Approver_id");
            entity.Property(e => e.Cancelflag).HasColumnName("cancelflag");
            entity.Property(e => e.ContactNo).HasMaxLength(50);
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.DesignationId).HasColumnName("designation_id");
            entity.Property(e => e.Documents)
                .HasMaxLength(500)
                .HasColumnName("documents");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            entity.Property(e => e.EndDuration)
                .HasMaxLength(50)
                .HasColumnName("end_duration");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("firstname");
            entity.Property(e => e.ForwardedEmpId)
                .HasMaxLength(50)
                .HasColumnName("Forwarded_emp_id");
            entity.Property(e => e.HrId).HasColumnName("HR_id");
            entity.Property(e => e.LastApprover).HasColumnName("Last_approver");
            entity.Property(e => e.LeaveStatus)
                .HasMaxLength(500)
                .HasColumnName("leave_status");
            entity.Property(e => e.LeaveType)
                .HasMaxLength(500)
                .HasColumnName("leave_type");
            entity.Property(e => e.LvBalence)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("lv_balence");
            entity.Property(e => e.NoOfDays)
                .HasMaxLength(500)
                .HasColumnName("no_of_days");
            entity.Property(e => e.PendingApprover).HasColumnName("Pending_approver");
            entity.Property(e => e.PersonResponsible).HasMaxLength(50);
            entity.Property(e => e.PlantId).HasColumnName("plant_id");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.ReasonType)
                .HasMaxLength(100)
                .HasColumnName("reasonType");
            entity.Property(e => e.RecordStatus)
                .HasMaxLength(500)
                .HasColumnName("record_status");
            entity.Property(e => e.RejectedDate)
                .HasColumnType("datetime")
                .HasColumnName("rejected_date");
            entity.Property(e => e.ReqId)
                .HasMaxLength(50)
                .HasColumnName("Req_Id");
            entity.Property(e => e.SapAppStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SAP_APP_Status");
            entity.Property(e => e.SapApprovedDate)
                .HasColumnType("datetime")
                .HasColumnName("SAP_Approved_Date");
            entity.Property(e => e.SapMessage)
                .HasMaxLength(500)
                .HasColumnName("SAP_Message");
            entity.Property(e => e.SapStatus)
                .HasMaxLength(10)
                .HasColumnName("SAP_Status");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");
            entity.Property(e => e.StartDuration)
                .HasMaxLength(500)
                .HasColumnName("start_duration");
            entity.Property(e => e.StateId).HasColumnName("state_id");
            entity.Property(e => e.SubmitDate)
                .HasMaxLength(50)
                .HasColumnName("submit_date");
            entity.Property(e => e.UserId)
                .HasMaxLength(500)
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<LeaveReason>(entity =>
        {
            entity.ToTable("LEAVE_REASON");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DetailedReason)
                .HasMaxLength(255)
                .HasColumnName("Detailed_Reason");
            entity.Property(e => e.LeavType)
                .HasMaxLength(50)
                .HasColumnName("Leav_type");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Reason).HasMaxLength(255);
        });

        modelBuilder.Entity<LeaveStructure>(entity =>
        {
            entity.ToTable("Leave_Structure");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Aedtm)
                .HasColumnType("datetime")
                .HasColumnName("AEDTM");
            entity.Property(e => e.Applicablewith).HasColumnName("APPLICABLEWITH");
            entity.Property(e => e.AutoApproveAfterDays).HasMaxLength(10);
            entity.Property(e => e.Awothltyp).HasColumnName("AWOTHLTYP");
            entity.Property(e => e.Bukrs)
                .HasMaxLength(4)
                .HasColumnName("BUKRS");
            entity.Property(e => e.Cldm).HasColumnName("CLDM");
            entity.Property(e => e.Cputm)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("CPUTM");
            entity.Property(e => e.Crdat)
                .HasColumnType("datetime")
                .HasColumnName("CRDAT");
            entity.Property(e => e.CreatedBy).HasMaxLength(20);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Gesch)
                .HasMaxLength(1)
                .HasColumnName("GESCH");
            entity.Property(e => e.Lacclt)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("LACCLT");
            entity.Property(e => e.Laccum).HasColumnName("LACCUM");
            entity.Property(e => e.Ladv).HasColumnName("LADV");
            entity.Property(e => e.Ladvday)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("LADVDAY");
            entity.Property(e => e.Lattlt)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("LATTLT");
            entity.Property(e => e.Leavetypes).HasColumnName("LEAVETYPES");
            entity.Property(e => e.Leavtxt)
                .HasMaxLength(20)
                .HasColumnName("LEAVTXT");
            entity.Property(e => e.Leavtyp)
                .HasMaxLength(7)
                .HasColumnName("LEAVTYP");
            entity.Property(e => e.Lencash).HasColumnName("LENCASH");
            entity.Property(e => e.Lenclt)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("LENCLT");
            entity.Property(e => e.Lhalfyr)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("LHALFYR");
            entity.Property(e => e.Lhdallow).HasColumnName("LHDALLOW");
            entity.Property(e => e.Lihol).HasColumnName("LIHOL");
            entity.Property(e => e.Lmaxadv)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("LMAXADV");
            entity.Property(e => e.Lmaxalw)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("LMAXALW");
            entity.Property(e => e.Lmaxtime).HasColumnName("LMAXTIME");
            entity.Property(e => e.Lminalw)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("LMINALW");
            entity.Property(e => e.Lmindur)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("LMINDUR");
            entity.Property(e => e.Lnodays)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("LNODAYS");
            entity.Property(e => e.Lpiadv).HasColumnName("LPIADV");
            entity.Property(e => e.Lwkend).HasColumnName("LWKEND");
            entity.Property(e => e.Mandt)
                .HasMaxLength(3)
                .HasColumnName("MANDT");
            entity.Property(e => e.ModifiedBy).HasMaxLength(20);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Month)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("MONTH");
            entity.Property(e => e.Paygroup).HasColumnName("PAYGROUP");
            entity.Property(e => e.Staffcat).HasColumnName("STAFFCAT");
            entity.Property(e => e.Uname)
                .HasMaxLength(12)
                .HasColumnName("UNAME");
            entity.Property(e => e.Werks)
                .HasMaxLength(4)
                .HasColumnName("WERKS");
        });

        modelBuilder.Entity<LicenseTypeSoftware>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Licence_Type_Software");

            entity.ToTable("License_Type_Software");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LicenseType)
                .HasMaxLength(50)
                .HasColumnName("License_Type");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Location");

            entity.Property(e => e.AdvancePl).HasColumnName("advancePL");
            entity.Property(e => e.ApplyAfterForgetSwipe).HasColumnName("Apply_after_ForgetSwipe");
            entity.Property(e => e.ApplyAfterLeave).HasColumnName("Apply_after_Leave");
            entity.Property(e => e.ApplyAfterOd).HasColumnName("Apply_after_OD");
            entity.Property(e => e.ApplyAfterPermission).HasColumnName("Apply_after_Permission");
            entity.Property(e => e.ApplyBeforePlleave).HasColumnName("Apply_before_PLLeave");
            entity.Property(e => e.CombinationLeave).HasColumnName("combinationLeave");
            entity.Property(e => e.CompOffDays).HasColumnName("Comp_off_Days");
            entity.Property(e => e.CompOffHod).HasColumnName("Comp_off_HOD");
            entity.Property(e => e.CumulativeReport).HasColumnName("Cumulative_report");
            entity.Property(e => e.Flate)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ForgotSwipe).HasColumnName("Forgot_swipe");
            entity.Property(e => e.Ftotal).HasMaxLength(50);
            entity.Property(e => e.ItemCodeRequestFlag)
                .HasDefaultValue(false)
                .HasColumnName("Item_CodeRequestFlag");
            entity.Property(e => e.Land1)
                .HasMaxLength(50)
                .HasColumnName("LAND1");
            entity.Property(e => e.LateCount).HasColumnName("Late_count");
            entity.Property(e => e.LocGroup)
                .HasMaxLength(100)
                .HasColumnName("Loc_Group");
            entity.Property(e => e.LocGrpId)
                .HasMaxLength(10)
                .HasColumnName("Loc_Grp_ID");
            entity.Property(e => e.LocHead)
                .HasMaxLength(100)
                .HasColumnName("Loc_Head");
            entity.Property(e => e.LocationAddress)
                .HasMaxLength(100)
                .HasColumnName("LOCATION_ADDRESS");
            entity.Property(e => e.LocationCode)
                .HasMaxLength(10)
                .HasColumnName("LOCATION_CODE");
            entity.Property(e => e.Locid).HasColumnName("LOCID");
            entity.Property(e => e.Locname)
                .HasMaxLength(50)
                .HasColumnName("LOCNAME");
            entity.Property(e => e.MarkAtt).HasColumnName("Mark_att");
            entity.Property(e => e.OndutyRequest).HasColumnName("ondutyRequest");
            entity.Property(e => e.PMaxMin).HasColumnName("P_MAX_MIN");
            entity.Property(e => e.PMinimumMin).HasColumnName("P_MINIMUM_MIN");
            entity.Property(e => e.PStartTime)
                .HasMaxLength(50)
                .HasColumnName("P_START_TIME");
            entity.Property(e => e.PTotalMinutes).HasColumnName("P_TOTAL_MINUTES");
            entity.Property(e => e.PermissionCount).HasColumnName("Permission_count");
            entity.Property(e => e.PermissionCountYearly).HasColumnName("Permission_count_yearly");
            entity.Property(e => e.PermissionHrs).HasColumnName("Permission_Hrs");
            entity.Property(e => e.PermissionType)
                .HasMaxLength(50)
                .HasColumnName("PERMISSION_TYPE");
            entity.Property(e => e.PinCode).HasColumnName("PIN_CODE");
        });

        modelBuilder.Entity<LocationGateMaster>(entity =>
        {
            entity.ToTable("Location_Gate_Master");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FklocationId).HasColumnName("FKLocationId");
            entity.Property(e => e.GateNo).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Temp1).HasMaxLength(500);
            entity.Property(e => e.Temp2).HasMaxLength(500);
            entity.Property(e => e.Temp3).HasMaxLength(500);
            entity.Property(e => e.Temp4).HasMaxLength(500);
            entity.Property(e => e.Temp5).HasMaxLength(500);

            entity.HasOne(d => d.Fklocation).WithMany(p => p.LocationGateMasters)
                .HasForeignKey(d => d.FklocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKLocationId");
        });

        modelBuilder.Entity<LocationMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Pk_Loc_Master");

            entity.ToTable("Location_Master");

            entity.Property(e => e.Country).HasMaxLength(10);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Locid).HasColumnName("LOCID");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.StateId)
                .HasMaxLength(10)
                .HasColumnName("StateID");
        });

        modelBuilder.Entity<LockoutMaster>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.EmployeeId });

            entity.ToTable("Lockout_Master");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.EmployeeId).HasMaxLength(50);
            entity.Property(e => e.LockoutDate)
                .HasColumnType("datetime")
                .HasColumnName("Lockout_Date");
            entity.Property(e => e.LockoutFlag)
                .HasDefaultValue(false)
                .HasColumnName("Lockout_Flag");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<LopReimbursement>(entity =>
        {
            entity.ToTable("LOP_Reimbursement");

            entity.Property(e => e.EmployeeId).HasMaxLength(15);
            entity.Property(e => e.FromDate).HasColumnType("datetime");
            entity.Property(e => e.LastApprover).HasMaxLength(50);
            entity.Property(e => e.PendingApprover).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.SubmittedBy).HasMaxLength(50);
            entity.Property(e => e.SubmittedDate).HasColumnType("datetime");
            entity.Property(e => e.ToDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<LvApplyRule>(entity =>
        {
            entity.ToTable("lv_apply_rules");

            entity.Property(e => e.AdvancePl).HasColumnName("advancePL");
            entity.Property(e => e.ApplyAfterForgetSwipe).HasColumnName("Apply_after_ForgetSwipe");
            entity.Property(e => e.ApplyAfterLeave).HasColumnName("Apply_after_Leave");
            entity.Property(e => e.ApplyAfterOd).HasColumnName("Apply_after_OD");
            entity.Property(e => e.ApplyAfterPermission).HasColumnName("Apply_after_Permission");
            entity.Property(e => e.ApplyBeforePlleave).HasColumnName("Apply_before_PLLeave");
            entity.Property(e => e.CombinationLeave).HasColumnName("combinationLeave");
            entity.Property(e => e.CompOffDays).HasColumnName("Comp_off_Days");
            entity.Property(e => e.CompOffHod).HasColumnName("Comp_off_HOD");
            entity.Property(e => e.CumulativeReport).HasColumnName("Cumulative_report");
            entity.Property(e => e.Flate)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ForgotSwipe).HasColumnName("Forgot_swipe");
            entity.Property(e => e.Ftotal).HasMaxLength(50);
            entity.Property(e => e.ItemCodeRequestFlag).HasColumnName("Item_CodeRequestFlag");
            entity.Property(e => e.Land1)
                .HasMaxLength(50)
                .HasColumnName("LAND1");
            entity.Property(e => e.LateCount).HasColumnName("Late_count");
            entity.Property(e => e.LocationAddress)
                .HasMaxLength(100)
                .HasColumnName("LOCATION_ADDRESS");
            entity.Property(e => e.LocationCode)
                .HasMaxLength(10)
                .HasColumnName("LOCATION_CODE");
            entity.Property(e => e.Locid).HasColumnName("LOCID");
            entity.Property(e => e.Locname)
                .HasMaxLength(50)
                .HasColumnName("LOCNAME");
            entity.Property(e => e.MarkAtt).HasColumnName("Mark_att");
            entity.Property(e => e.OndutyRequest).HasColumnName("ondutyRequest");
            entity.Property(e => e.PMaxMin).HasColumnName("P_MAX_MIN");
            entity.Property(e => e.PMinimumMin).HasColumnName("P_MINIMUM_MIN");
            entity.Property(e => e.PStartTime)
                .HasMaxLength(50)
                .HasColumnName("P_START_TIME");
            entity.Property(e => e.PTotalMinutes).HasColumnName("P_TOTAL_MINUTES");
            entity.Property(e => e.PermissionCount).HasColumnName("Permission_count");
            entity.Property(e => e.PermissionCountYearly).HasColumnName("Permission_count_yearly");
            entity.Property(e => e.PermissionHrs).HasColumnName("Permission_Hrs");
            entity.Property(e => e.PermissionType)
                .HasMaxLength(50)
                .HasColumnName("PERMISSION_TYPE");
            entity.Property(e => e.PinCode).HasColumnName("PIN_CODE");
        });

        modelBuilder.Entity<LvReason>(entity =>
        {
            entity.HasKey(e => e.LeavId);

            entity.ToTable("lv_reason");

            entity.Property(e => e.LeavId).HasColumnName("leavId");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LeavType)
                .HasMaxLength(100)
                .HasColumnName("leavType");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<LvTypeD>(entity =>
        {
            entity.ToTable("lv_type_d");

            entity.Property(e => e.LvAvailed).HasColumnName("lv_availed");
            entity.Property(e => e.LvAwtBal).HasColumnName("lv_awtBal");
            entity.Property(e => e.LvCalyear).HasColumnName("lv_calyear");
            entity.Property(e => e.LvClbal).HasColumnName("lv_clbal");
            entity.Property(e => e.LvEmpcode)
                .HasMaxLength(50)
                .HasColumnName("lv_empcode");
            entity.Property(e => e.LvOpbal).HasColumnName("lv_opbal");
            entity.Property(e => e.LvTypeid).HasColumnName("lv_typeid");
            entity.Property(e => e.SapApprovedDate)
                .HasColumnType("datetime")
                .HasColumnName("SAP_Approved_Date");
            entity.Property(e => e.SapMessage)
                .HasMaxLength(500)
                .HasColumnName("SAP_Message");
            entity.Property(e => e.SapStatus)
                .HasMaxLength(10)
                .HasColumnName("SAP_Status");
        });

        modelBuilder.Entity<LvTypeM>(entity =>
        {
            entity.ToTable("lv_type_m");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LvShrt)
                .HasMaxLength(7)
                .HasColumnName("lv_shrt");
            entity.Property(e => e.LvType)
                .HasMaxLength(35)
                .HasColumnName("lv_type");
            entity.Property(e => e.LvTypeid).HasColumnName("lv_typeid");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<MaritalM>(entity =>
        {
            entity.ToTable("Marital_M");

            entity.HasIndex(e => e.Name, "UQ_Marital_M").IsUnique();

            entity.Property(e => e.CreatedBy).HasMaxLength(20);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(20);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<MastersStructureInput>(entity =>
        {
            entity.ToTable("Masters_Structure_Input");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BreadCrumb)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Field1)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Field10)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Field11)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Field12)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Field2)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Field3)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Field4)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Field5)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Field6)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Field7)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Field8)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Field9)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FkFormId).HasColumnName("FK_FormId");
            entity.Property(e => e.Header)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.SubHeader)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.FkForm).WithMany(p => p.MastersStructureInputs)
                .HasForeignKey(d => d.FkFormId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Masters_Structure_Input_Form_Master");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.ToTable("Material");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(40);
            entity.Property(e => e.FkMaterialType).HasColumnName("fkMaterialType");
            entity.Property(e => e.MaterialCode).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.FkMaterialTypeNavigation).WithMany(p => p.Materials)
                .HasForeignKey(d => d.FkMaterialType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Material_Material_Type");
        });

        modelBuilder.Entity<MaterialGroup>(entity =>
        {
            entity.ToTable("MATERIAL_GROUP");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Ltxt)
                .HasMaxLength(60)
                .HasColumnName("LTXT");
            entity.Property(e => e.MaterialGroupId)
                .HasMaxLength(9)
                .HasColumnName("MATERIAL_GROUP_ID");
            entity.Property(e => e.MaterialType).HasColumnName("MATERIAL_TYPE");
            entity.Property(e => e.Stxt)
                .HasMaxLength(60)
                .HasColumnName("STXT");
        });

        modelBuilder.Entity<MaterialMaster>(entity =>
        {
            entity.ToTable("Material_Master");

            entity.Property(e => e.DomesticOrExports).HasMaxLength(10);
            entity.Property(e => e.HsnCode)
                .HasMaxLength(50)
                .HasColumnName("HSN_Code");
            entity.Property(e => e.Market).HasMaxLength(10);
            entity.Property(e => e.MaterialGroup)
                .HasMaxLength(50)
                .HasColumnName("Material_Group");
            entity.Property(e => e.MaterialGroupId)
                .HasMaxLength(10)
                .HasColumnName("Material_group_Id");
            entity.Property(e => e.MaterialLongName)
                .HasMaxLength(100)
                .HasColumnName("Material_Long_Name");
            entity.Property(e => e.MaterialShortName)
                .HasMaxLength(100)
                .HasColumnName("Material_Short_Name");
            entity.Property(e => e.MaterialType)
                .HasMaxLength(10)
                .HasColumnName("Material_Type");
            entity.Property(e => e.MaterialTypeId).HasColumnName("Material_Type_Id");
            entity.Property(e => e.PgGroup)
                .HasMaxLength(50)
                .HasColumnName("PG_Group");
            entity.Property(e => e.PlantCode)
                .HasMaxLength(5)
                .HasColumnName("Plant_Code");
            entity.Property(e => e.SapCodeExists)
                .HasMaxLength(5)
                .HasColumnName("SAP_CODE_EXISTS");
            entity.Property(e => e.SapCodeNo)
                .HasMaxLength(50)
                .HasColumnName("SAP_CODE_NO");
            entity.Property(e => e.StorageLocation)
                .HasMaxLength(50)
                .HasColumnName("Storage_Location");
            entity.Property(e => e.Uom)
                .HasMaxLength(50)
                .HasColumnName("UOM");
        });

        modelBuilder.Entity<MaterialPricingGroup>(entity =>
        {
            entity.ToTable("Material_Pricing_Group");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastModifiedBy).HasMaxLength(50);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.MatPriceGrp).HasMaxLength(5);
        });

        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.ToTable("Material_Type");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(40);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Type).HasMaxLength(500);
        });

        modelBuilder.Entity<MedClaimContactDetail>(entity =>
        {
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Designation).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Level).HasMaxLength(80);
            entity.Property(e => e.MobileNo).HasMaxLength(50);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<MedHeadApprover>(entity =>
        {
            entity.Property(e => e.EmployeeId).HasMaxLength(50);
            entity.Property(e => e.Location).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        modelBuilder.Entity<MedInputCategory>(entity =>
        {
            entity.ToTable("MedInput_Category");

            entity.Property(e => e.Category).HasMaxLength(250);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<MedServiceBrand>(entity =>
        {
            entity.ToTable("MedService_BRAND");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BrandCode)
                .HasMaxLength(50)
                .HasColumnName("BRAND_CODE");
            entity.Property(e => e.BrandDesc)
                .HasMaxLength(100)
                .HasColumnName("BRAND_DESC");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<MedServiceRequestHistory>(entity =>
        {
            entity.ToTable("MedService_Request_History");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApproverName).HasMaxLength(50);
            entity.Property(e => e.Comments)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Department).HasMaxLength(50);
            entity.Property(e => e.Designation).HasMaxLength(50);
            entity.Property(e => e.DoneBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.DoneOn).HasColumnType("datetime");
            entity.Property(e => e.ProcessType).HasMaxLength(100);
            entity.Property(e => e.RequestNo).HasMaxLength(20);
            entity.Property(e => e.RevertVersion).HasMaxLength(5);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.TransactionType).HasMaxLength(50);
        });

        modelBuilder.Entity<MedclaimDependantDetail>(entity =>
        {
            entity.ToTable("Medclaim_Dependant_Details");

            entity.Property(e => e.DependantName).HasMaxLength(80);
            entity.Property(e => e.EmployeeId).HasMaxLength(10);
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.MediclaimNo).HasMaxLength(50);
            entity.Property(e => e.Relationship).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<MediServiceRequest>(entity =>
        {
            entity.ToTable("MediService_request");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApproveDate)
                .HasColumnType("datetime")
                .HasColumnName("approve_date");
            entity.Property(e => e.ApproveType)
                .HasMaxLength(50)
                .HasColumnName("APPROVE_TYPE");
            entity.Property(e => e.ApprvrStatus)
                .HasMaxLength(50)
                .HasColumnName("Apprvr_Status");
            entity.Property(e => e.Brand).HasMaxLength(200);
            entity.Property(e => e.Category).HasMaxLength(100);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.Details).HasMaxLength(500);
            entity.Property(e => e.Division).HasMaxLength(50);
            entity.Property(e => e.FinalDocDate)
                .HasColumnType("datetime")
                .HasColumnName("Final_Doc_Date");
            entity.Property(e => e.FinalDocNo).HasColumnName("Final_Doc_No");
            entity.Property(e => e.FinalSerialNo)
                .HasMaxLength(50)
                .HasColumnName("Final_Serial_No");
            entity.Property(e => e.InputType).HasMaxLength(50);
            entity.Property(e => e.LastApprover)
                .HasMaxLength(100)
                .HasColumnName("last_approver");
            entity.Property(e => e.Location).HasMaxLength(4);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DATE");
            entity.Property(e => e.PendingApprover)
                .HasMaxLength(500)
                .HasColumnName("pending_approver");
            entity.Property(e => e.Product).HasMaxLength(80);
            entity.Property(e => e.RejectedFlag)
                .HasMaxLength(50)
                .HasColumnName("rejected_flag");
            entity.Property(e => e.RequestDate)
                .HasColumnType("datetime")
                .HasColumnName("REQUEST_DATE");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(10)
                .HasColumnName("REQUEST_NO");
            entity.Property(e => e.ReviewerAssignFlag)
                .HasDefaultValue(0)
                .HasColumnName("Reviewer_AssignFlag");
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.SubmitedDate)
                .HasColumnType("datetime")
                .HasColumnName("Submited_Date");
        });

        modelBuilder.Entity<MeetingParticipant>(entity =>
        {
            entity.HasKey(e => e.ParticipantId);

            entity.Property(e => e.Attendance).HasMaxLength(50);
            entity.Property(e => e.Department).HasMaxLength(80);
            entity.Property(e => e.EmailId).HasMaxLength(80);
            entity.Property(e => e.EmployeeId).HasMaxLength(50);
            entity.Property(e => e.MobileNo).HasMaxLength(50);
            entity.Property(e => e.Mode).HasMaxLength(50);
            entity.Property(e => e.ParticipantName).HasMaxLength(80);
            entity.Property(e => e.ParticipantType).HasMaxLength(50);

            entity.HasOne(d => d.Meeting).WithMany(p => p.MeetingParticipants)
                .HasForeignKey(d => d.MeetingId)
                .HasConstraintName("FK_MeetingParticipants_MinutesOfMeeting");
        });

        modelBuilder.Entity<MeetingSummary>(entity =>
        {
            entity.HasKey(e => e.SummaryId);

            entity.ToTable("MeetingSummary");

            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Meeting).WithMany(p => p.MeetingSummaries)
                .HasForeignKey(d => d.MeetingId)
                .HasConstraintName("FK_MeetingSummary_MinutesOfMeeting");
        });

        modelBuilder.Entity<MessageBoard>(entity =>
        {
            entity.ToTable("Message_Board");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(600)
                .IsUnicode(false);
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("End_Date");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("Start_Date");
            entity.Property(e => e.Url)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MicroLabsInvoiceMaster>(entity =>
        {
            entity.ToTable("MicroLabs_Invoice_Master");

            entity.Property(e => e.CustomerCode).HasMaxLength(50);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InvoiceDate)
                .HasColumnType("datetime")
                .HasColumnName("Invoice_Date");
            entity.Property(e => e.InvoiceNo)
                .HasMaxLength(50)
                .HasColumnName("Invoice_No");
            entity.Property(e => e.MaterialCode).HasMaxLength(50);
            entity.Property(e => e.MaterialDescription).IsUnicode(false);
            entity.Property(e => e.NoCases).HasColumnName("No_Cases");
            entity.Property(e => e.Qty).HasColumnName("QTY");
            entity.Property(e => e.Uom)
                .HasMaxLength(50)
                .HasColumnName("UOM");
        });

        modelBuilder.Entity<MicroLabsPoMaster>(entity =>
        {
            entity.ToTable("MicroLabs_PO_Master");

            entity.Property(e => e.MaterialCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MaterialDescription).IsUnicode(false);
            entity.Property(e => e.PoNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PO_No");
            entity.Property(e => e.Qty).HasColumnName("QTY");
            entity.Property(e => e.SupplierCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SupplierCountry)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SupplierName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SupplierPlace)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Uom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UOM");
        });

        modelBuilder.Entity<MinutesOfMeeting>(entity =>
        {
            entity.HasKey(e => e.MeetingId);

            entity.ToTable("MinutesOfMeeting");

            entity.Property(e => e.Archived).HasDefaultValue(false);
            entity.Property(e => e.CreatorEmailId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CreatorEmailID");
            entity.Property(e => e.LocationType).HasMaxLength(50);
            entity.Property(e => e.MeetingAgenda).IsUnicode(false);
            entity.Property(e => e.MeetingDate).HasColumnType("datetime");
            entity.Property(e => e.MeetingFrom).HasColumnType("datetime");
            entity.Property(e => e.MeetingLocation).HasMaxLength(100);
            entity.Property(e => e.MeetingPurpose)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.MeetingTo).HasColumnType("datetime");
            entity.Property(e => e.MeetingType).HasMaxLength(150);
            entity.Property(e => e.Mode).HasMaxLength(50);
            entity.Property(e => e.NextMeetingDate).HasColumnType("datetime");
            entity.Property(e => e.Project)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RecordedBy).HasMaxLength(50);
            entity.Property(e => e.Room).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<MomActionItem>(entity =>
        {
            entity.ToTable("MOM_ActionItems");

            entity.Property(e => e.ActionItem).HasMaxLength(150);
            entity.Property(e => e.Department).HasMaxLength(50);
            entity.Property(e => e.EmailId).HasMaxLength(80);
            entity.Property(e => e.EmployeeNo).HasMaxLength(50);
            entity.Property(e => e.MobileNo).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(80);
            entity.Property(e => e.Priority).HasMaxLength(50);
            entity.Property(e => e.Responsibility).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Tcd)
                .HasColumnType("datetime")
                .HasColumnName("TCD");
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Meeting).WithMany(p => p.MomActionItems)
                .HasForeignKey(d => d.MeetingId)
                .HasConstraintName("FK_MOM_ActionItems_MinutesOfMeeting");
        });

        modelBuilder.Entity<MomMeetingType>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MOM_MeetingType");

            entity.Property(e => e.MeetingType)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MomMode>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MOM_Mode");

            entity.Property(e => e.Mode)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MoreLink>(entity =>
        {
            entity.ToTable("MoreLinks", "HR");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Icon).HasMaxLength(50);
            entity.Property(e => e.LinkText).HasMaxLength(100);
            entity.Property(e => e.LinkUrl).HasMaxLength(500);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.MoreLinkCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MoreLinks_CreatedById");

            entity.HasOne(d => d.ModifiedBy).WithMany(p => p.MoreLinkModifiedBies)
                .HasForeignKey(d => d.ModifiedById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MoreLinks_ModifiedById");
        });

        modelBuilder.Entity<MultiLoginExceptionUser>(entity =>
        {
            entity.ToTable("MultiLogin_Exception_Users");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(10)
                .HasColumnName("EmployeeID");
            entity.Property(e => e.FkDepartmentId).HasColumnName("FK_DepartmentId");
            entity.Property(e => e.FkDesignationId).HasColumnName("Fk_DesignationId");
            entity.Property(e => e.FullName)
                .HasMaxLength(250)
                .HasColumnName("Full_Name");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<NationalityM>(entity =>
        {
            entity.ToTable("Nationality_M");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.NatId)
                .HasMaxLength(6)
                .HasColumnName("Nat_Id");
            entity.Property(e => e.Nationality).HasMaxLength(100);
        });

        modelBuilder.Entity<NatureofChange>(entity =>
        {
            entity.HasKey(e => e.NatureofChangeId).HasName("PK_IT.NatureofChangeType");

            entity.ToTable("NatureofChange", "IT");

            entity.Property(e => e.NatureofChangeId).HasColumnName("NatureofChangeID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.NatureofChange1)
                .HasMaxLength(500)
                .HasColumnName("NatureofChange");
        });

        modelBuilder.Entity<NewCandidate>(entity =>
        {
            entity.ToTable("New_Candidate");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CurrentLocation)
                .HasMaxLength(100)
                .HasColumnName("Current_location");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.HardSkill)
                .HasMaxLength(500)
                .HasColumnName("Hard_skill");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.JoiningDate).HasColumnType("datetime");
            entity.Property(e => e.LastCompany)
                .HasMaxLength(100)
                .HasColumnName("Last_company");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MiddelName).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PanNumber)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Passport).HasMaxLength(50);
            entity.Property(e => e.PassportNumber)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.PersonalEmail).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.PreviousLocation)
                .HasMaxLength(100)
                .HasColumnName("Previous_location");
            entity.Property(e => e.RedirectUrl).HasMaxLength(500);
            entity.Property(e => e.RelativeExp).HasColumnName("Relative_Exp");
            entity.Property(e => e.ReportingManager).HasColumnName("Reporting_Manager");
            entity.Property(e => e.SecondLastCompany)
                .HasMaxLength(100)
                .HasColumnName("Second_Last_company");
            entity.Property(e => e.SoftSkill)
                .HasMaxLength(500)
                .HasColumnName("Soft_skill");
            entity.Property(e => e.VisaIsActive).HasColumnName("Visa_IsActive");
            entity.Property(e => e.VisaNumber).HasMaxLength(50);
            entity.Property(e => e.YearExp).HasColumnName("Year_Exp");
        });

        modelBuilder.Entity<NewSalaryBreakup>(entity =>
        {
            entity.ToTable("New_Salary_Breakup");

            entity.Property(e => e.BaseLocation)
                .HasMaxLength(500)
                .HasColumnName("Base_location");
            entity.Property(e => e.Basic)
                .HasMaxLength(500)
                .HasDefaultValueSql("((0.00))");
            entity.Property(e => e.Bonus)
                .HasMaxLength(500)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.BooksPeriodicals)
                .HasMaxLength(500)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Books_Periodicals");
            entity.Property(e => e.CarFuel)
                .HasMaxLength(500)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Car_Fuel");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CurrentDesignation)
                .HasMaxLength(500)
                .HasColumnName("Current_Designation");
            entity.Property(e => e.Dept).HasMaxLength(500);
            entity.Property(e => e.DriveReim)
                .HasMaxLength(500)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Drive_Reim");
            entity.Property(e => e.EffectiveDate).HasColumnName("Effective_Date");
            entity.Property(e => e.EsiEmployer)
                .HasMaxLength(500)
                .HasDefaultValueSql("((0))")
                .HasColumnName("ESI_Employer");
            entity.Property(e => e.FixedAnnualCtc)
                .HasMaxLength(500)
                .HasDefaultValueSql("((0.00))")
                .HasColumnName("Fixed_Annual_CTC");
            entity.Property(e => e.FkAssessmentId).HasColumnName("Fk_Assessment_Id");
            entity.Property(e => e.FkCalenderId).HasColumnName("Fk_Calender_Id");
            entity.Property(e => e.FkEmpId).HasColumnName("Fk_Emp_Id");
            entity.Property(e => e.FkEmployeeId)
                .HasMaxLength(50)
                .HasColumnName("Fk_Employee_Id");
            entity.Property(e => e.Gender).HasMaxLength(500);
            entity.Property(e => e.GrossMedicalClaim)
                .HasMaxLength(500)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Gross_Medical_Claim");
            entity.Property(e => e.Hra)
                .HasMaxLength(500)
                .HasDefaultValueSql("((0))")
                .HasColumnName("HRA");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Lta)
                .HasMaxLength(500)
                .HasDefaultValueSql("((0))")
                .HasColumnName("LTA");
            entity.Property(e => e.Meal)
                .HasMaxLength(500)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.MonthlyGross)
                .HasMaxLength(500)
                .HasDefaultValueSql("((0.00))")
                .HasColumnName("Monthly_Gross");
            entity.Property(e => e.PfEmployee)
                .HasMaxLength(500)
                .HasDefaultValueSql("((0))")
                .HasColumnName("PF_Employee");
            entity.Property(e => e.PfEmployer)
                .HasMaxLength(500)
                .HasDefaultValueSql("((0))")
                .HasColumnName("PF_Employer");
            entity.Property(e => e.Remarks).HasMaxLength(4000);
            entity.Property(e => e.RevisedDesignation)
                .HasMaxLength(500)
                .HasColumnName("Revised_Designation");
            entity.Property(e => e.SoftwareAllowance)
                .HasMaxLength(500)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Software_Allowance");
            entity.Property(e => e.Telephone)
                .HasMaxLength(500)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.Temp10).HasMaxLength(500);
            entity.Property(e => e.Temp11).HasMaxLength(500);
            entity.Property(e => e.Temp12).HasMaxLength(500);
            entity.Property(e => e.Temp13).HasMaxLength(500);
            entity.Property(e => e.Temp14).HasMaxLength(500);
            entity.Property(e => e.Temp15).HasMaxLength(500);
            entity.Property(e => e.Temp3).HasMaxLength(500);
            entity.Property(e => e.Temp4).HasMaxLength(500);
            entity.Property(e => e.Temp5).HasMaxLength(500);
            entity.Property(e => e.Temp6).HasMaxLength(500);
            entity.Property(e => e.Temp7).HasMaxLength(500);
            entity.Property(e => e.Temp8).HasMaxLength(500);
            entity.Property(e => e.Temp9).HasMaxLength(500);
            entity.Property(e => e.VariablePay)
                .HasMaxLength(500)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Variable_Pay");

            entity.HasOne(d => d.FkAssessment).WithMany(p => p.NewSalaryBreakups)
                .HasForeignKey(d => d.FkAssessmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_New_Salary_Breakup_Assesment_Master");
        });

        modelBuilder.Entity<NewUserLogin>(entity =>
        {
            entity.ToTable("New_UserLogin");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AcessLevel).HasMaxLength(50);
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Designation).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FailedPasswordCount).HasColumnName("FailedPAsswordCount");
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");
            entity.Property(e => e.MiddleName).HasMaxLength(100);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.RedirectUrl).HasMaxLength(500);
            entity.Property(e => e.SubRoleId).HasColumnName("Sub_RoleId");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .HasColumnName("UserID");
        });

        modelBuilder.Entity<NpdApprover>(entity =>
        {
            entity.ToTable("NPD_Approvers");

            entity.Property(e => e.ApproverId)
                .HasMaxLength(10)
                .HasColumnName("Approver_ID");
            entity.Property(e => e.ApproverName)
                .HasMaxLength(100)
                .HasColumnName("Approver_Name");
            entity.Property(e => e.Department).HasMaxLength(100);
            entity.Property(e => e.EmailId)
                .HasMaxLength(100)
                .HasColumnName("Email_id");
            entity.Property(e => e.ReqType)
                .HasMaxLength(50)
                .HasColumnName("Req_Type");
        });

        modelBuilder.Entity<NpdCmdDetail>(entity =>
        {
            entity.ToTable("NPD_CMD_details");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApprvrStatus)
                .HasMaxLength(50)
                .HasColumnName("apprvr_Status");
            entity.Property(e => e.Division)
                .HasMaxLength(80)
                .HasColumnName("division");
            entity.Property(e => e.Location)
                .HasMaxLength(10)
                .HasColumnName("location");
            entity.Property(e => e.PdfreadStatus)
                .HasMaxLength(10)
                .HasColumnName("pdfreadStatus");
            entity.Property(e => e.RemarksCmd)
                .HasMaxLength(500)
                .HasColumnName("remarksCMD");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(20)
                .HasColumnName("request_no");
            entity.Property(e => e.SubmitedBy)
                .HasMaxLength(80)
                .HasColumnName("submited_by");
            entity.Property(e => e.SubmitedDate)
                .HasColumnType("datetime")
                .HasColumnName("submited_date");
        });

        modelBuilder.Entity<NpdCompetitorBrand>(entity =>
        {
            entity.ToTable("NPD_competitorBrands");

            entity.Property(e => e.CompetitorBrand)
                .HasMaxLength(200)
                .HasColumnName("competitor_brand");
            entity.Property(e => e.CompetitorDetails)
                .HasMaxLength(200)
                .HasColumnName("competitor_details");
            entity.Property(e => e.CompetitorExistingmarketshare)
                .HasMaxLength(200)
                .HasColumnName("competitor_existingmarketshare");
            entity.Property(e => e.CompetitorMrp)
                .HasMaxLength(200)
                .HasColumnName("competitor_mrp");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(50)
                .HasColumnName("REQUEST_NO");
        });

        modelBuilder.Entity<NpdCqaDeptDetail>(entity =>
        {
            entity.ToTable("NPD_cqa_dept_details");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActualSampleTradePsCarton)
                .HasMaxLength(80)
                .HasColumnName("actual_sample_trade_ps_carton");
            entity.Property(e => e.ApprvrStatus)
                .HasMaxLength(50)
                .HasColumnName("apprvr_Status");
            entity.Property(e => e.Attachments).HasColumnName("attachments");
            entity.Property(e => e.CeilingPrice)
                .HasMaxLength(80)
                .HasColumnName("ceiling_price");
            entity.Property(e => e.Cqacost).HasDefaultValue(0);
            entity.Property(e => e.Division)
                .HasMaxLength(80)
                .HasColumnName("division");
            entity.Property(e => e.FinalRecommendation).HasColumnName("finalRecommendation");
            entity.Property(e => e.LocalFdaLicense)
                .HasMaxLength(500)
                .HasColumnName("local_FDA_license");
            entity.Property(e => e.Location)
                .HasMaxLength(10)
                .HasColumnName("location");
            entity.Property(e => e.NpdReferenceNo)
                .HasMaxLength(80)
                .HasColumnName("npd_reference_no");
            entity.Property(e => e.PendingApprover)
                .HasMaxLength(50)
                .HasColumnName("pending_approver");
            entity.Property(e => e.ReferenceDate)
                .HasMaxLength(150)
                .HasColumnName("reference_date");
            entity.Property(e => e.ReferenceNoGivenBy)
                .HasMaxLength(80)
                .HasColumnName("reference_no_given_by");
            entity.Property(e => e.Remarks).HasColumnName("remarks");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(20)
                .HasColumnName("request_no");
            entity.Property(e => e.SubmitedBy)
                .HasMaxLength(80)
                .HasColumnName("submited_by");
            entity.Property(e => e.SubmitedDate)
                .HasColumnType("datetime")
                .HasColumnName("submited_date");
            entity.Property(e => e.Timeline)
                .HasMaxLength(500)
                .HasColumnName("timeline");
            entity.Property(e => e.TradePsArtworkPrintApproval)
                .HasMaxLength(80)
                .HasColumnName("trade_ps_artwork_print_approval");
            entity.Property(e => e.WhetherCoveredUnderBannedDrugDcg)
                .HasMaxLength(500)
                .HasColumnName("whether_covered_under_banned_drug_DCG");
            entity.Property(e => e.WhetherNewDrugRequiringDcgPermission)
                .HasMaxLength(500)
                .HasColumnName("whether_new_drug_requiring_DCG_permission");
        });

        modelBuilder.Entity<NpdDistributionDeptDetail>(entity =>
        {
            entity.ToTable("NPD_distribution_dept_details");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApprvrStatus)
                .HasMaxLength(50)
                .HasColumnName("apprvr_Status");
            entity.Property(e => e.Division)
                .HasMaxLength(80)
                .HasColumnName("division");
            entity.Property(e => e.FinalRecommendation).HasColumnName("finalRecommendation");
            entity.Property(e => e.Location)
                .HasMaxLength(10)
                .HasColumnName("location");
            entity.Property(e => e.RemarksDistribution)
                .HasMaxLength(500)
                .HasColumnName("remarksDistribution");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(20)
                .HasColumnName("request_no");
            entity.Property(e => e.ReviewDistribution).HasColumnName("reviewDistribution");
            entity.Property(e => e.SubmitedBy)
                .HasMaxLength(80)
                .HasColumnName("submited_by");
            entity.Property(e => e.SubmitedDate)
                .HasColumnType("datetime")
                .HasColumnName("submited_date");
        });

        modelBuilder.Entity<NpdHodDetail>(entity =>
        {
            entity.ToTable("NPD_hod_details");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cqacost)
                .HasMaxLength(50)
                .HasColumnName("cqacost");
            entity.Property(e => e.Division)
                .HasMaxLength(80)
                .HasColumnName("division");
            entity.Property(e => e.Drugdevelopmentcost)
                .HasMaxLength(80)
                .HasColumnName("drugdevelopmentcost");
            entity.Property(e => e.Equipmentcost)
                .HasMaxLength(80)
                .HasColumnName("equipmentcost");
            entity.Property(e => e.FinalRecommendationHod)
                .HasMaxLength(80)
                .HasColumnName("finalRecommendationHOD");
            entity.Property(e => e.FinalRecommendationSubmitedDate)
                .HasColumnType("datetime")
                .HasColumnName("final_RecommendationSubmitedDate");
            entity.Property(e => e.FinalrecommendationHoddate)
                .HasMaxLength(80)
                .HasColumnName("finalrecommendationHODDate");
            entity.Property(e => e.Hodremarks).HasColumnName("hodremarks");
            entity.Property(e => e.Location)
                .HasMaxLength(10)
                .HasColumnName("location");
            entity.Property(e => e.Regulatoryapprovalcost)
                .HasMaxLength(50)
                .HasColumnName("regulatoryapprovalcost");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(20)
                .HasColumnName("request_no");
            entity.Property(e => e.SubmitedBy)
                .HasMaxLength(80)
                .HasColumnName("submited_by");
            entity.Property(e => e.SubmitedDate)
                .HasColumnType("datetime")
                .HasColumnName("submited_date");
            entity.Property(e => e.Totaldevelopmenttime)
                .HasMaxLength(80)
                .HasColumnName("totaldevelopmenttime");
            entity.Property(e => e.Totalgrandcost)
                .HasMaxLength(50)
                .HasColumnName("totalgrandcost");
        });

        modelBuilder.Entity<NpdIprDeptDetail>(entity =>
        {
            entity.ToTable("NPD_ipr_dept_details");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApprvrStatus)
                .HasMaxLength(50)
                .HasColumnName("apprvr_Status");
            entity.Property(e => e.Attachments).HasColumnName("attachments");
            entity.Property(e => e.Division)
                .HasMaxLength(80)
                .HasColumnName("division");
            entity.Property(e => e.FinalRecommendation).HasColumnName("finalRecommendation");
            entity.Property(e => e.Location)
                .HasMaxLength(10)
                .HasColumnName("location");
            entity.Property(e => e.PatentStatus)
                .HasMaxLength(80)
                .HasColumnName("patent_status");
            entity.Property(e => e.PendingApprover)
                .HasMaxLength(50)
                .HasColumnName("pending_approver");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(20)
                .HasColumnName("request_no");
            entity.Property(e => e.SubmitedBy)
                .HasMaxLength(80)
                .HasColumnName("submited_by");
            entity.Property(e => e.SubmitedDate)
                .HasMaxLength(80)
                .HasColumnName("submited_date");
        });

        modelBuilder.Entity<NpdMasterDetail>(entity =>
        {
            entity.ToTable("npd_master_details");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdditionalInformationIfRequired).HasColumnName("additional_information_if_required");
            entity.Property(e => e.ApproveType)
                .HasMaxLength(50)
                .HasColumnName("APPROVE_TYPE");
            entity.Property(e => e.ApprvrStatus)
                .HasMaxLength(50)
                .HasColumnName("Apprvr_Status");
            entity.Property(e => e.Attachments).HasColumnName("attachments");
            entity.Property(e => e.BrandName)
                .HasMaxLength(80)
                .HasColumnName("brand_name");
            entity.Property(e => e.BrandSearch)
                .HasMaxLength(80)
                .HasColumnName("brand_search");
            entity.Property(e => e.BrandValue)
                .HasMaxLength(80)
                .HasColumnName("brand_value");
            entity.Property(e => e.CompititorBrand)
                .HasMaxLength(80)
                .HasColumnName("compititor_brand");
            entity.Property(e => e.CompititorBrandsCount)
                .HasMaxLength(80)
                .HasColumnName("compititor_brands_count");
            entity.Property(e => e.CompititorSample)
                .HasMaxLength(80)
                .HasColumnName("compititor_sample");
            entity.Property(e => e.Composition)
                .HasMaxLength(500)
                .HasColumnName("composition");
            entity.Property(e => e.Division)
                .HasMaxLength(80)
                .HasColumnName("division");
            entity.Property(e => e.DosageDetails)
                .HasMaxLength(500)
                .HasColumnName("dosage_details");
            entity.Property(e => e.DosageForm)
                .HasMaxLength(80)
                .HasColumnName("dosage_form");
            entity.Property(e => e.ExpectedMarketShareYear1)
                .HasMaxLength(80)
                .HasColumnName("expected_market_share_year_1");
            entity.Property(e => e.ExpectedMarketShareYear2)
                .HasMaxLength(80)
                .HasColumnName("expected_market_share_year_2");
            entity.Property(e => e.ExpectedMarketShareYear3)
                .HasMaxLength(80)
                .HasColumnName("expected_market_share_year_3");
            entity.Property(e => e.FinalDocDate)
                .HasColumnType("datetime")
                .HasColumnName("Final_Doc_Date");
            entity.Property(e => e.FinalDocNo).HasColumnName("Final_Doc_No");
            entity.Property(e => e.FinalSerialNo)
                .HasMaxLength(50)
                .HasColumnName("Final_Serial_No");
            entity.Property(e => e.GenericName)
                .HasMaxLength(80)
                .HasColumnName("generic_name");
            entity.Property(e => e.Growth)
                .HasMaxLength(50)
                .HasColumnName("growth");
            entity.Property(e => e.JustificationLaunch).HasColumnName("justification_launch");
            entity.Property(e => e.LaunchReq)
                .HasMaxLength(80)
                .HasColumnName("launch_req");
            entity.Property(e => e.Location)
                .HasMaxLength(10)
                .HasColumnName("location");
            entity.Property(e => e.MarketInfoGlobal)
                .HasMaxLength(500)
                .HasColumnName("market_info_global");
            entity.Property(e => e.MarketInfoIndia)
                .HasMaxLength(500)
                .HasColumnName("market_info_india");
            entity.Property(e => e.MarketShare)
                .HasMaxLength(80)
                .HasColumnName("market_share");
            entity.Property(e => e.NpdCmdDetailsSubmitFlag)
                .HasDefaultValue(0)
                .HasColumnName("npd_CMD_details_submit_flag");
            entity.Property(e => e.NpdCqaDeptDetailsSubmitFlag)
                .HasDefaultValue(0)
                .HasColumnName("npd_cqa_dept_details_submit_flag");
            entity.Property(e => e.NpdDistributionDeptDetailsSubmitFlag)
                .HasDefaultValue(0)
                .HasColumnName("npd_distribution_dept_details_submit_flag");
            entity.Property(e => e.NpdHodFinalstageSubmitFlag)
                .HasDefaultValue(0)
                .HasColumnName("npd_hod_finalstage_submit_flag");
            entity.Property(e => e.NpdHodInitialstageSubmitFlag)
                .HasDefaultValue(0)
                .HasColumnName("npd_hod_initialstage_submit_flag");
            entity.Property(e => e.NpdIprDeptDetailsSubmitFlag)
                .HasDefaultValue(0)
                .HasColumnName("npd_ipr_dept_details_submit_flag");
            entity.Property(e => e.NpdMedicalDeptDetailsSubmitFlag)
                .HasDefaultValue(0)
                .HasColumnName("npd_medical_dept_details_submit_flag");
            entity.Property(e => e.NpdOtherDeptDetailsSubmitFlag)
                .HasDefaultValue(0)
                .HasColumnName("npd_other_dept_details_submit_flag");
            entity.Property(e => e.NpdRndDeptDetailsSubmitFlag)
                .HasDefaultValue(0)
                .HasColumnName("npd_rnd_dept_details_submit_flag");
            entity.Property(e => e.NpdStrategicDeptDetailsSubmitFlag)
                .HasDefaultValue(0)
                .HasColumnName("npd_strategic_dept_details_submit_flag");
            entity.Property(e => e.NpdSupplychainDeptDetailsSubmitFlag)
                .HasDefaultValue(0)
                .HasColumnName("npd_supplychain_dept_details_submit_flag");
            entity.Property(e => e.OriginatorBrandSales).HasColumnName("originator_brand_sales");
            entity.Property(e => e.PackingConfig)
                .HasMaxLength(500)
                .HasColumnName("packing_config");
            entity.Property(e => e.PhysicianSample)
                .HasMaxLength(80)
                .HasColumnName("physician_sample");
            entity.Property(e => e.PhysicianSampleQuantity)
                .HasMaxLength(80)
                .HasColumnName("physician_sample_quantity");
            entity.Property(e => e.PostLaunchReq)
                .HasMaxLength(80)
                .HasColumnName("post_launch_req");
            entity.Property(e => e.ProposedPacking)
                .HasMaxLength(500)
                .HasColumnName("proposed_packing");
            entity.Property(e => e.ProposedmicroPrice).HasColumnName("proposedmicro_price");
            entity.Property(e => e.RequestDate)
                .HasColumnType("datetime")
                .HasColumnName("request_date");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(50)
                .HasColumnName("request_no");
            entity.Property(e => e.RequestedBy)
                .HasMaxLength(80)
                .HasColumnName("requested_by");
            entity.Property(e => e.SalePack)
                .HasMaxLength(80)
                .HasColumnName("sale_pack");
            entity.Property(e => e.SalesForecastUnitsMonth1)
                .HasMaxLength(80)
                .HasColumnName("sales_forecast_units__month_1");
            entity.Property(e => e.SalesForecastUnitsMonth2)
                .HasMaxLength(80)
                .HasColumnName("sales_forecast_units__month_2");
            entity.Property(e => e.SalesForecastUnitsMonth3)
                .HasMaxLength(80)
                .HasColumnName("sales_forecast_units__month_3");
            entity.Property(e => e.SalesForecastUnitsQtr2)
                .HasMaxLength(80)
                .HasColumnName("sales_forecast_units__qtr_2");
            entity.Property(e => e.SalesForecastUnitsQtr3)
                .HasMaxLength(80)
                .HasColumnName("sales_forecast_units__qtr_3");
            entity.Property(e => e.SalesForecastUnitsQtr4)
                .HasMaxLength(80)
                .HasColumnName("sales_forecast_units__qtr_4");
            entity.Property(e => e.SalesForecastUnitsYear1)
                .HasMaxLength(80)
                .HasColumnName("sales_forecast_units__year_1");
            entity.Property(e => e.SalesForecastUnitsYear2)
                .HasMaxLength(80)
                .HasColumnName("sales_forecast_units__year_2");
            entity.Property(e => e.SalesForecastUnitsYear3)
                .HasMaxLength(80)
                .HasColumnName("sales_forecast_units__year_3");
            entity.Property(e => e.SalesForecastValueYear1)
                .HasMaxLength(80)
                .HasColumnName("sales_forecast_value__year_1");
            entity.Property(e => e.SalesForecastValueYear2)
                .HasMaxLength(80)
                .HasColumnName("sales_forecast_value__year_2");
            entity.Property(e => e.SalesForecastValueYear3)
                .HasMaxLength(80)
                .HasColumnName("sales_forecast_value__year_3");
            entity.Property(e => e.SaleunitPackSize)
                .HasMaxLength(80)
                .HasColumnName("saleunit_pack_size");
            entity.Property(e => e.SaleunitPerCarton)
                .HasMaxLength(80)
                .HasColumnName("saleunit_per_carton");
            entity.Property(e => e.SaleunitsPerShipper)
                .HasMaxLength(80)
                .HasColumnName("saleunits_per_shipper");
            entity.Property(e => e.SpecificFormulationDevelopmentRequirement)
                .HasMaxLength(500)
                .HasColumnName("specific_formulation_development_requirement");
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.Strength)
                .HasMaxLength(80)
                .HasColumnName("strength");
            entity.Property(e => e.SubmitedDate)
                .HasColumnType("datetime")
                .HasColumnName("Submited_Date");
            entity.Property(e => e.TotalMarketDrug)
                .HasMaxLength(80)
                .HasColumnName("total_market_drug");
        });

        modelBuilder.Entity<NpdMedicalDeptDetail>(entity =>
        {
            entity.ToTable("NPD_medical_dept_details");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApprvrStatus)
                .HasMaxLength(50)
                .HasColumnName("apprvr_Status");
            entity.Property(e => e.Attachments).HasColumnName("attachments");
            entity.Property(e => e.Commentsmedical).HasColumnName("commentsmedical");
            entity.Property(e => e.DcgiApprovalDetails)
                .HasMaxLength(500)
                .HasColumnName("dcgi_approval_details");
            entity.Property(e => e.DcgiRegulatoryApprovalCost)
                .HasMaxLength(500)
                .HasColumnName("dcgi_regulatory_approval_cost");
            entity.Property(e => e.DcgiTimelineForApproval)
                .HasMaxLength(500)
                .HasColumnName("dcgi_timeline_for_approval");
            entity.Property(e => e.Division)
                .HasMaxLength(80)
                .HasColumnName("division");
            entity.Property(e => e.DrugRationale).HasColumnName("drug_rationale");
            entity.Property(e => e.FinalRecommendation)
                .HasMaxLength(500)
                .HasColumnName("final_recommendation");
            entity.Property(e => e.Location)
                .HasMaxLength(10)
                .HasColumnName("location");
            entity.Property(e => e.PendingApprover)
                .HasMaxLength(50)
                .HasColumnName("pending_approver");
            entity.Property(e => e.ProductPatentExpiry)
                .HasMaxLength(500)
                .HasColumnName("product_patent_expiry");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(20)
                .HasColumnName("request_no");
            entity.Property(e => e.SubmitedBy)
                .HasMaxLength(80)
                .HasColumnName("submited_by");
            entity.Property(e => e.SubmitedDate)
                .HasColumnType("datetime")
                .HasColumnName("submited_date");
        });

        modelBuilder.Entity<NpdRndDeptDetail>(entity =>
        {
            entity.ToTable("NPD_rnd_dept_details");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApiSourceAvailability)
                .HasMaxLength(500)
                .HasColumnName("api_source_availability");
            entity.Property(e => e.ApprvrStatus)
                .HasMaxLength(50)
                .HasColumnName("apprvr_Status");
            entity.Property(e => e.DevelopmentCost)
                .HasMaxLength(80)
                .HasColumnName("development_cost");
            entity.Property(e => e.Division)
                .HasMaxLength(80)
                .HasColumnName("division");
            entity.Property(e => e.FinalRecommendation).HasColumnName("finalRecommendation");
            entity.Property(e => e.FormulationShelfLifeMonths)
                .HasMaxLength(80)
                .HasColumnName("formulation_shelf_life_months");
            entity.Property(e => e.Location)
                .HasMaxLength(10)
                .HasColumnName("location");
            entity.Property(e => e.RemarksRnd).HasColumnName("remarksRND");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(20)
                .HasColumnName("request_no");
            entity.Property(e => e.SpecialEquipmentCost)
                .HasMaxLength(80)
                .HasColumnName("special_equipment_cost");
            entity.Property(e => e.SubmitedBy)
                .HasMaxLength(80)
                .HasColumnName("submited_by");
            entity.Property(e => e.SubmitedDate)
                .HasColumnType("datetime")
                .HasColumnName("submited_date");
            entity.Property(e => e.SuggestedPlantCommercialisation)
                .HasMaxLength(500)
                .HasColumnName("suggested_plant_commercialisation");
            entity.Property(e => e.TotalTimlineCompleteProject)
                .HasMaxLength(500)
                .HasColumnName("total_timline_complete_project");
        });

        modelBuilder.Entity<NpdStrategicDeptDetail>(entity =>
        {
            entity.ToTable("NPD_strategic_dept_details");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApprvrStatus)
                .HasMaxLength(50)
                .HasColumnName("apprvr_Status");
            entity.Property(e => e.CommentsInlicensingApplicable)
                .HasMaxLength(80)
                .HasColumnName("comments_inlicensing_applicable");
            entity.Property(e => e.Division)
                .HasMaxLength(80)
                .HasColumnName("division");
            entity.Property(e => e.FinalRecommendation).HasColumnName("finalRecommendation");
            entity.Property(e => e.Location)
                .HasMaxLength(10)
                .HasColumnName("location");
            entity.Property(e => e.OverallStrategicFit)
                .HasMaxLength(500)
                .HasColumnName("overall_strategic_fit");
            entity.Property(e => e.RemarksStrategicmarketing).HasColumnName("remarksStrategicmarketing");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(20)
                .HasColumnName("request_no");
            entity.Property(e => e.SubmitedBy)
                .HasMaxLength(80)
                .HasColumnName("submited_by");
            entity.Property(e => e.SubmitedDate)
                .HasColumnType("datetime")
                .HasColumnName("submited_date");
        });

        modelBuilder.Entity<NpdSupplychainDeptDetail>(entity =>
        {
            entity.ToTable("NPD_supplychain_dept_details");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApprvrStatus)
                .HasMaxLength(50)
                .HasColumnName("apprvr_Status");
            entity.Property(e => e.DcgiApprovalStatus)
                .HasMaxLength(80)
                .HasColumnName("dcgi_approval_status");
            entity.Property(e => e.Division)
                .HasMaxLength(80)
                .HasColumnName("division");
            entity.Property(e => e.FinalRecommendation).HasColumnName("finalRecommendation");
            entity.Property(e => e.ForAnnual)
                .HasMaxLength(500)
                .HasColumnName("for_annual");
            entity.Property(e => e.ForFirstCommercialLaunch)
                .HasMaxLength(500)
                .HasColumnName("for_first_commercial_launch");
            entity.Property(e => e.LocalStateDrugLicense)
                .HasMaxLength(80)
                .HasColumnName("local_state_drug_license");
            entity.Property(e => e.Location)
                .HasMaxLength(10)
                .HasColumnName("location");
            entity.Property(e => e.ManufacturingLocationInhouse)
                .HasMaxLength(500)
                .HasColumnName("manufacturing_location_inhouse");
            entity.Property(e => e.PendingApprover)
                .HasMaxLength(50)
                .HasColumnName("pending_approver");
            entity.Property(e => e.PreNegotiatedTransferPrice)
                .HasMaxLength(500)
                .HasColumnName("pre_negotiated_transfer_price");
            entity.Property(e => e.RecommendedOutsourcedThirdPartyLocation)
                .HasMaxLength(500)
                .HasColumnName("recommended_outsourced_third_party_location");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(20)
                .HasColumnName("request_no");
            entity.Property(e => e.SubmitedBy)
                .HasMaxLength(80)
                .HasColumnName("submited_by");
            entity.Property(e => e.SubmitedDate)
                .HasColumnType("datetime")
                .HasColumnName("submited_date");
            entity.Property(e => e.SupplyChainRemarks).HasColumnName("supplyChainRemarks");
            entity.Property(e => e.TimelineDevelopmentCommercialisation)
                .HasMaxLength(500)
                .HasColumnName("timeline_development_commercialisation");
        });

        modelBuilder.Entity<OfferAttachment>(entity =>
        {
            entity.ToTable("OfferAttachments", "HR");

            entity.Property(e => e.FileName).HasMaxLength(200);
            entity.Property(e => e.FilePath).HasMaxLength(500);

            entity.HasOne(d => d.Offer).WithMany(p => p.OfferAttachments)
                .HasForeignKey(d => d.OfferId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OfferAttachments_OfferDetails");
        });

        modelBuilder.Entity<OfferDetail>(entity =>
        {
            entity.HasKey(e => e.OfferId);

            entity.ToTable("OfferDetails", "HR");

            entity.Property(e => e.AdditionalDetails).HasMaxLength(500);
            entity.Property(e => e.AddressLine1).HasMaxLength(50);
            entity.Property(e => e.AddressLine2).HasMaxLength(50);
            entity.Property(e => e.AddressLine3).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EmailSentDate).HasColumnType("datetime");
            entity.Property(e => e.Epsapplicable)
                .HasMaxLength(5)
                .HasColumnName("EPSApplicable");
            entity.Property(e => e.Esiapplicable)
                .HasMaxLength(5)
                .HasColumnName("ESIApplicable");
            entity.Property(e => e.FirstName).HasMaxLength(500);
            entity.Property(e => e.Gender).HasMaxLength(500);
            entity.Property(e => e.Guid).HasMaxLength(50);
            entity.Property(e => e.Initial).HasMaxLength(500);
            entity.Property(e => e.InterviewedBy).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(500);
            entity.Property(e => e.Mattest).HasColumnName("MATTest");
            entity.Property(e => e.MiddleName).HasMaxLength(500);
            entity.Property(e => e.MobileNo).HasMaxLength(20);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.OfferNo).HasMaxLength(50);
            entity.Property(e => e.OfferedSalary).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.OtherEmails).HasMaxLength(200);
            entity.Property(e => e.PackageType).HasMaxLength(20);
            entity.Property(e => e.PersonalEmailId).HasMaxLength(100);
            entity.Property(e => e.Pfapplicable)
                .HasMaxLength(5)
                .HasColumnName("PFApplicable");
            entity.Property(e => e.PinCode).HasMaxLength(6);
            entity.Property(e => e.PreJoiningEmailSentDate).HasColumnType("datetime");
            entity.Property(e => e.PreJoiningInitiation).HasMaxLength(50);
            entity.Property(e => e.PresentCtc)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PresentCTC");
            entity.Property(e => e.PresentEmployer).HasMaxLength(100);
            entity.Property(e => e.RefDetails).HasMaxLength(50);
            entity.Property(e => e.RefEmployeeNo).HasMaxLength(20);
            entity.Property(e => e.ReferenceThru).HasMaxLength(50);
            entity.Property(e => e.ReplacingEmployeeNumber).HasMaxLength(20);
            entity.Property(e => e.SalaryType).HasMaxLength(20);
            entity.Property(e => e.SalesAmount).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Status).HasMaxLength(100);
            entity.Property(e => e.TentativeJoiningDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(500);
            entity.Property(e => e.TotalExperience).HasColumnType("decimal(6, 2)");

            entity.HasOne(d => d.ApprovingManager).WithMany(p => p.OfferDetailApprovingManagers)
                .HasForeignKey(d => d.ApprovingManagerId)
                .HasConstraintName("FK_OfferDetails_ApprovingManagerId");

            entity.HasOne(d => d.Designation).WithMany(p => p.OfferDetails)
                .HasForeignKey(d => d.DesignationId)
                .HasConstraintName("FK_Designation_Designation_Master");

            entity.HasOne(d => d.EmployeeCategory).WithMany(p => p.OfferDetails)
                .HasForeignKey(d => d.EmployeeCategoryid)
                .HasConstraintName("FK_EmployeeCategory_emp_Category_Master");

            entity.HasOne(d => d.Location).WithMany(p => p.OfferDetails)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK_Location_Location_Master");

            entity.HasOne(d => d.Paygroup).WithMany(p => p.OfferDetails)
                .HasForeignKey(d => d.PaygroupId)
                .HasConstraintName("FK_PayGroup_Paygroup_Master");

            entity.HasOne(d => d.Plant).WithMany(p => p.OfferDetails)
                .HasForeignKey(d => d.PlantId)
                .HasConstraintName("FK_Plant_Plant_Master");

            entity.HasOne(d => d.ReportingManager).WithMany(p => p.OfferDetailReportingManagers)
                .HasForeignKey(d => d.ReportingManagerId)
                .HasConstraintName("FK_OfferDetails_ReportingManagerId");

            entity.HasOne(d => d.Role).WithMany(p => p.OfferDetails)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Role_Role_Master");

            entity.HasOne(d => d.State).WithMany(p => p.OfferDetails)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_State_State_Master");
        });

        modelBuilder.Entity<OfferEmailNotification>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OfferEmailNotifications", "HR");

            entity.Property(e => e.EmailId).HasMaxLength(500);
            entity.Property(e => e.EmailType).HasMaxLength(50);
            entity.Property(e => e.OfferEmailNotificationId).ValueGeneratedOnAdd();
            entity.Property(e => e.StateId).HasMaxLength(10);
        });

        modelBuilder.Entity<OfferSalaryDetail>(entity =>
        {
            entity.HasKey(e => e.OfferSalaryDetailsId);

            entity.ToTable("OfferSalaryDetails", "HR");

            entity.Property(e => e.OfferedSalary).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PackageType).HasMaxLength(20);
            entity.Property(e => e.SalaryType).HasMaxLength(20);

            entity.HasOne(d => d.Offer).WithMany(p => p.OfferSalaryDetails)
                .HasForeignKey(d => d.OfferId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OfferSalaryDetails_OfferDetails");
        });

        modelBuilder.Entity<OfferSalaryHeadDetail>(entity =>
        {
            entity.HasKey(e => e.OfferSalaryHeadDetailsId);

            entity.ToTable("OfferSalaryHeadDetails", "HR");

            entity.Property(e => e.Amount).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.AnnualAmount).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.Offer).WithMany(p => p.OfferSalaryHeadDetails)
                .HasForeignKey(d => d.OfferId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OfferSalaryHeadDetails_OfferDetails");

            entity.HasOne(d => d.SalaryHead).WithMany(p => p.OfferSalaryHeadDetails)
                .HasForeignKey(d => d.SalaryHeadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OfferSalaryHeadDetails_Salary_Structure");
        });

        modelBuilder.Entity<OnDutyDetail>(entity =>
        {
            entity.ToTable("OnDuty_details");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApprovedDate)
                .HasColumnType("datetime")
                .HasColumnName("approved_date");
            entity.Property(e => e.ApproverId)
                .HasMaxLength(50)
                .HasColumnName("Approver_id");
            entity.Property(e => e.ApproverStatus)
                .HasMaxLength(50)
                .HasColumnName("Approver_Status");
            entity.Property(e => e.Area).HasMaxLength(100);
            entity.Property(e => e.Cancelflag).HasColumnName("cancelflag");
            entity.Property(e => e.Comments).HasColumnName("comments");
            entity.Property(e => e.ContactNo).HasMaxLength(50);
            entity.Property(e => e.Documents)
                .HasMaxLength(100)
                .HasColumnName("documents");
            entity.Property(e => e.Duration)
                .HasMaxLength(50)
                .HasColumnName("duration");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.EndDuration)
                .HasMaxLength(50)
                .HasColumnName("end_duration");
            entity.Property(e => e.EndTime).HasColumnName("endTime");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .HasColumnName("firstname");
            entity.Property(e => e.ForwardedEmpId)
                .HasMaxLength(50)
                .HasColumnName("Forwarded_emp_id");
            entity.Property(e => e.HrId).HasColumnName("HR_id");
            entity.Property(e => e.InTime).HasMaxLength(100);
            entity.Property(e => e.LastApprover)
                .HasMaxLength(50)
                .HasColumnName("Last_approver");
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .HasColumnName("location");
            entity.Property(e => e.NoOfDays)
                .HasMaxLength(50)
                .HasColumnName("no_of_days");
            entity.Property(e => e.OnDutyStatus)
                .HasMaxLength(50)
                .HasColumnName("OnDuty_status");
            entity.Property(e => e.OnDutyType)
                .HasMaxLength(50)
                .HasColumnName("onDuty_Type");
            entity.Property(e => e.OutTime).HasMaxLength(100);
            entity.Property(e => e.PendingApprover)
                .HasMaxLength(50)
                .HasColumnName("Pending_approver");
            entity.Property(e => e.PersonResponsible).HasMaxLength(50);
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.RecordStatus)
                .HasMaxLength(50)
                .HasColumnName("record_status");
            entity.Property(e => e.RejectedDate)
                .HasColumnType("datetime")
                .HasColumnName("rejected_date");
            entity.Property(e => e.RequestNo).HasColumnName("request_no");
            entity.Property(e => e.SapApprovedDate)
                .HasColumnType("datetime")
                .HasColumnName("SAP_Approved_Date");
            entity.Property(e => e.SapMessage)
                .HasMaxLength(500)
                .HasColumnName("SAP_Message");
            entity.Property(e => e.SapStatus)
                .HasMaxLength(10)
                .HasColumnName("SAP_Status");
            entity.Property(e => e.SecurityId)
                .HasMaxLength(50)
                .HasColumnName("Security_Id");
            entity.Property(e => e.SecurityStatus).HasColumnName("Security_Status");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.StartTime).HasColumnName("startTime");
            entity.Property(e => e.SubmitDate)
                .HasColumnType("datetime")
                .HasColumnName("submit_date");
            entity.Property(e => e.TravelNo).HasColumnName("travel_no");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<OnDutyEmpDocument>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("onDuty_emp_documents");

            entity.Property(e => e.FileName)
                .HasMaxLength(500)
                .HasColumnName("file_name");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.OnDutyType)
                .HasMaxLength(100)
                .HasColumnName("onDuty_Type");
            entity.Property(e => e.RequestNo).HasColumnName("request_no");
            entity.Property(e => e.UserId)
                .HasMaxLength(500)
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<OverTimeDetail>(entity =>
        {
            entity.ToTable("OVER_TIME_DETAILS");

            entity.Property(e => e.Applicabale).HasMaxLength(4);
            entity.Property(e => e.ApprvdDate).HasColumnType("datetime");
            entity.Property(e => e.ApprvrStatus).HasMaxLength(20);
            entity.Property(e => e.Cancelflag)
                .HasDefaultValue(0)
                .HasColumnName("cancelflag");
            entity.Property(e => e.LastApprover).HasColumnName("Last_approver");
            entity.Property(e => e.NoHrs)
                .HasMaxLength(10)
                .HasColumnName("NoHRS");
            entity.Property(e => e.PendingApprover).HasColumnName("Pending_approver");
            entity.Property(e => e.Pernr).HasMaxLength(50);
            entity.Property(e => e.ReqNo).HasColumnName("Req_no");
            entity.Property(e => e.RequestedBy).HasMaxLength(50);
            entity.Property(e => e.RequestedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<OverallRatingDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_OverallPerformanceRating");

            entity.ToTable("Overall_Rating_Details");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FeedbackComments).IsUnicode(false);
            entity.Property(e => e.FkAssesmentId).HasColumnName("FK_Assesment_Id");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Rating)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RatingEmp)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.FkAssesment).WithMany(p => p.OverallRatingDetails)
                .HasForeignKey(d => d.FkAssesmentId)
                .HasConstraintName("FK_Overall_Rating_Details_Assesment_Master");
        });

        modelBuilder.Entity<OverallRatingMaster>(entity =>
        {
            entity.ToTable("Overall_Rating_Master");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FkCalenderId).HasColumnName("FK_Calender_Id");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Rating)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.FkCalender).WithMany(p => p.OverallRatingMasters)
                .HasForeignKey(d => d.FkCalenderId)
                .HasConstraintName("FK_Overall_Rating_Master_Calendar_Master");
        });

        modelBuilder.Entity<PackSize>(entity =>
        {
            entity.ToTable("PACK_SIZE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.PackSizeCode)
                .HasMaxLength(50)
                .HasColumnName("PACK_SIZE_CODE");
            entity.Property(e => e.PackSizeDesc)
                .HasMaxLength(100)
                .HasColumnName("PACK_SIZE_DESC");
        });

        modelBuilder.Entity<PackType>(entity =>
        {
            entity.ToTable("PACK_TYPE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.PTypeCode)
                .HasMaxLength(50)
                .HasColumnName("P_TYPE_CODE");
            entity.Property(e => e.PTypeDesc)
                .HasMaxLength(100)
                .HasColumnName("P_TYPE_DESC");
        });

        modelBuilder.Entity<PackageMaterialGroup>(entity =>
        {
            entity.ToTable("PACKAGE_MATERIAL_GROUP");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(50);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.PackingMaterialGroupId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PACKING_MATERIAL_GROUP_ID");
            entity.Property(e => e.PackingMaterialGroupName)
                .HasMaxLength(500)
                .HasColumnName("PACKING_MATERIAL_GROUP_NAME");
        });

        modelBuilder.Entity<PartnerDetail>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AadharPanLinkStatus)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.AuthDesignation)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.AuthorisedBy)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.CurrentYearturnOverStatus)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.DelFlag).HasColumnName("Del_Flag");
            entity.Property(e => e.ItrackNumForP1)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("ITRAckNumForP1");
            entity.Property(e => e.ItrackNumForP2)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("ITRAckNumForP2");
            entity.Property(e => e.ItrackYearForP1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ITRAckYearForP1");
            entity.Property(e => e.ItrackYearForP2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ITRAckYearForP2");
            entity.Property(e => e.ItrfiledPre2YearsStatus)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ITRFiledPre2YearsStatus");
            entity.Property(e => e.ItrfillingDateForP1).HasColumnName("ITRFillingDateForP1");
            entity.Property(e => e.ItrfillingDateForP2).HasColumnName("ITRFillingDateForP2");
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Pan)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Remarks)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TdslimitP1).HasColumnName("TDSLimitP1");
            entity.Property(e => e.TdslimitP2).HasColumnName("TDSLimitP2");
            entity.Property(e => e.TdslimitStatusP1)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("TDSLimitStatusP1");
            entity.Property(e => e.TdslimitStatusP2)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("TDSLimitStatusP2");
            entity.Property(e => e.TurnOverproofPath)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UpdateFlag).HasColumnName("Update_Flag");
            entity.Property(e => e.UploadProofPathForP1)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UploadProofPathForP2)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Vccode)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("VCcode");
            entity.Property(e => e.Vcname)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("VCName");
        });

        modelBuilder.Entity<PartnerMasterDetail>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Address1)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Address2)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Address3)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DelFlag).HasColumnName("Del_Flag");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Pan)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Pin)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdateFlag).HasColumnName("Update_Flag");
            entity.Property(e => e.Vccode).HasColumnName("VCcode");
            entity.Property(e => e.Vcname)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("VCName");
        });

        modelBuilder.Entity<PasswordPolicyMaster>(entity =>
        {
            entity.ToTable("PasswordPolicy_Master");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<PaygroupMaster>(entity =>
        {
            entity.ToTable("Paygroup_Master");

            entity.Property(e => e.Aoemail).HasColumnName("AOEMAIL");
            entity.Property(e => e.CostCenter).HasMaxLength(50);
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("EMail");
            entity.Property(e => e.Glno)
                .HasMaxLength(50)
                .HasColumnName("GLNo");
            entity.Property(e => e.Group).HasMaxLength(100);
            entity.Property(e => e.GroupHead).HasMaxLength(100);
            entity.Property(e => e.LongDesc)
                .HasMaxLength(200)
                .HasColumnName("Long_Desc");
            entity.Property(e => e.Ofemail).HasColumnName("OFEMAIL");
            entity.Property(e => e.Plant).HasMaxLength(50);
            entity.Property(e => e.PrintName).HasMaxLength(50);
            entity.Property(e => e.SapDivison)
                .HasMaxLength(10)
                .HasColumnName("SAP_Divison");
            entity.Property(e => e.ShortDesc)
                .HasMaxLength(100)
                .HasColumnName("Short_desc");
        });

        modelBuilder.Entity<PaymentTermM>(entity =>
        {
            entity.HasKey(e => e.PaymentTermId);

            entity.ToTable("PAYMENT_TERM_M");

            entity.Property(e => e.PaymentTermId).HasColumnName("PAYMENT_TERM_ID");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(50);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.PaymentTermCode)
                .HasMaxLength(5)
                .HasColumnName("PAYMENT_TERM_CODE");
            entity.Property(e => e.PaymentTermName)
                .HasMaxLength(50)
                .HasColumnName("PAYMENT_TERM_NAME");
        });

        modelBuilder.Entity<PayslipRequest>(entity =>
        {
            entity.HasKey(e => e.ReqId).HasName("PK_PAYSLIP_REQUEST_1");

            entity.ToTable("PAYSLIP_REQUEST");

            entity.Property(e => e.ReqId).HasColumnName("Req_id");
            entity.Property(e => e.ReqBy)
                .HasMaxLength(50)
                .HasColumnName("Req_By");
            entity.Property(e => e.ReqDate)
                .HasColumnType("datetime")
                .HasColumnName("Req_date");
            entity.Property(e => e.ReqType)
                .HasMaxLength(50)
                .HasColumnName("Req_Type");
            entity.Property(e => e.SapApprovedDate)
                .HasColumnType("datetime")
                .HasColumnName("SAP_Approved_Date");
            entity.Property(e => e.SapMessage)
                .HasMaxLength(500)
                .HasColumnName("SAP_Message");
            entity.Property(e => e.SapSentFlag)
                .HasDefaultValue(false)
                .HasColumnName("SAP_SENT_FLAG");
            entity.Property(e => e.SapStatus)
                .HasMaxLength(100)
                .HasColumnName("SAP_Status");
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<PermissionDetail>(entity =>
        {
            entity.ToTable("Permission_details");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApprovedDate)
                .HasColumnType("datetime")
                .HasColumnName("approved_date");
            entity.Property(e => e.ApproverId)
                .HasMaxLength(50)
                .HasColumnName("Approver_id");
            entity.Property(e => e.ApproverStatus)
                .HasMaxLength(50)
                .HasColumnName("Approver_Status");
            entity.Property(e => e.AttendanceStatus).HasColumnName("attendance_status");
            entity.Property(e => e.AvailMinutes).HasColumnName("avail_minutes");
            entity.Property(e => e.Cancelflag).HasColumnName("cancelflag");
            entity.Property(e => e.Comments)
                .HasMaxLength(50)
                .HasColumnName("comments");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.EndTime).HasColumnName("endTime");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("firstname");
            entity.Property(e => e.ForwardedEmpId)
                .HasMaxLength(50)
                .HasColumnName("Forwarded_emp_id");
            entity.Property(e => e.HrId).HasColumnName("HR_id");
            entity.Property(e => e.InTime).HasMaxLength(50);
            entity.Property(e => e.LastApprover)
                .HasMaxLength(50)
                .HasColumnName("Last_approver");
            entity.Property(e => e.OutTime).HasMaxLength(50);
            entity.Property(e => e.PendingApprover)
                .HasMaxLength(50)
                .HasColumnName("Pending_approver");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.RejectedDate)
                .HasColumnType("datetime")
                .HasColumnName("rejected_date");
            entity.Property(e => e.RequestNo).HasColumnName("request_no");
            entity.Property(e => e.SecurityId)
                .HasMaxLength(50)
                .HasColumnName("Security_Id");
            entity.Property(e => e.SecurityStatus).HasColumnName("Security_Status");
            entity.Property(e => e.StartTime).HasColumnName("startTime");
            entity.Property(e => e.SubmitDate)
                .HasColumnType("datetime")
                .HasColumnName("Submit_Date");
            entity.Property(e => e.SwipeType)
                .HasMaxLength(10)
                .HasColumnName("swipe_type");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<PermissionMaster>(entity =>
        {
            entity.ToTable("Permission_master");

            entity.Property(e => e.PerAvailed).HasColumnName("per_availed");
            entity.Property(e => e.PerAwtBal).HasColumnName("per_awtBal");
            entity.Property(e => e.PerCalyear).HasColumnName("per_calyear");
            entity.Property(e => e.PerClbal).HasColumnName("per_clbal");
            entity.Property(e => e.PerEmpcode)
                .HasMaxLength(50)
                .HasColumnName("per_empcode");
            entity.Property(e => e.PerOpbal).HasColumnName("per_opbal");
            entity.Property(e => e.SapApprovedDate)
                .HasColumnType("datetime")
                .HasColumnName("SAP_Approved_Date");
            entity.Property(e => e.SapMessage)
                .HasMaxLength(500)
                .HasColumnName("SAP_Message");
            entity.Property(e => e.SapStatus)
                .HasMaxLength(10)
                .HasColumnName("SAP_Status");
        });

        modelBuilder.Entity<PharmaGrade>(entity =>
        {
            entity.ToTable("PHARMA_GRADE");

            entity.Property(e => e.PharmaGradeId)
                .ValueGeneratedNever()
                .HasColumnName("PHARMA_GRADE_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.PharmaGradeDesc)
                .HasMaxLength(500)
                .HasColumnName("PHARMA_GRADE_DESC");
        });

        modelBuilder.Entity<PlantAddress>(entity =>
        {
            entity.ToTable("Plant_Address");

            entity.Property(e => e.AcNoAltrpayee).HasMaxLength(255);
            entity.Property(e => e.Accountingclerk).HasMaxLength(255);
            entity.Property(e => e.Addressnotes).HasMaxLength(255);
            entity.Property(e => e.Attachment).HasMaxLength(255);
            entity.Property(e => e.City).HasMaxLength(255);
            entity.Property(e => e.ContactPersonName).HasMaxLength(255);
            entity.Property(e => e.Country).HasMaxLength(255);
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.Createdon).HasColumnType("datetime");
            entity.Property(e => e.Cstno)
                .HasMaxLength(255)
                .HasColumnName("CSTNo");
            entity.Property(e => e.Currency).HasMaxLength(255);
            entity.Property(e => e.DeletionIndicator).HasMaxLength(255);
            entity.Property(e => e.Eccnumber)
                .HasMaxLength(255)
                .HasColumnName("ECCNumber");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(255)
                .HasColumnName("EMailAddress");
            entity.Property(e => e.ExciseRegistration).HasMaxLength(255);
            entity.Property(e => e.Fax).HasMaxLength(255);
            entity.Property(e => e.Gstinindicator)
                .HasMaxLength(255)
                .HasColumnName("GSTINIndicator");
            entity.Property(e => e.Gstinnumber)
                .HasMaxLength(255)
                .HasColumnName("GSTINNumber");
            entity.Property(e => e.Incoterms).HasMaxLength(255);
            entity.Property(e => e.IncotermsDesc).HasMaxLength(255);
            entity.Property(e => e.Mobile).HasMaxLength(255);
            entity.Property(e => e.Pannumber)
                .HasMaxLength(255)
                .HasColumnName("PANNumber");
            entity.Property(e => e.PayTermsDesc).HasMaxLength(255);
            entity.Property(e => e.Phonenumber).HasMaxLength(255);
            entity.Property(e => e.Pocreated)
                .HasMaxLength(255)
                .HasColumnName("POCreated");
            entity.Property(e => e.PostCode).HasMaxLength(255);
            entity.Property(e => e.ReconAccGeneralL)
                .HasMaxLength(255)
                .HasColumnName("ReconAccGeneral_L");
            entity.Property(e => e.Region).HasMaxLength(255);
            entity.Property(e => e.RegionCode).HasMaxLength(255);
            entity.Property(e => e.SchemaGroup).HasMaxLength(255);
            entity.Property(e => e.SearchTerm1).HasMaxLength(255);
            entity.Property(e => e.SearchTerm2).HasMaxLength(255);
            entity.Property(e => e.ServiceTaxReg).HasMaxLength(255);
            entity.Property(e => e.SrvBasedInvVer).HasMaxLength(255);
            entity.Property(e => e.Street).HasMaxLength(255);
            entity.Property(e => e.StreetHouseNumbe)
                .HasMaxLength(255)
                .HasColumnName("Street_House_Numbe");
            entity.Property(e => e.StreetHouseNumbe1)
                .HasMaxLength(255)
                .HasColumnName("Street_House_Numbe1");
            entity.Property(e => e.TaxNumber2)
                .HasMaxLength(255)
                .HasColumnName("TaxNumber_2");
            entity.Property(e => e.Telephone).HasMaxLength(255);
            entity.Property(e => e.Terms).HasMaxLength(255);
            entity.Property(e => e.VatRegNo)
                .HasMaxLength(255)
                .HasColumnName("VAT_Reg_No");
            entity.Property(e => e.VendorCode).HasMaxLength(255);
            entity.Property(e => e.VendorEsicno)
                .HasMaxLength(255)
                .HasColumnName("VendorESICNo");
            entity.Property(e => e.VendorName).HasMaxLength(255);
            entity.Property(e => e.VendorName2).HasMaxLength(255);
            entity.Property(e => e.Vendoraccountgroup).HasMaxLength(255);
            entity.Property(e => e.WtaxCode)
                .HasMaxLength(255)
                .HasColumnName("WTaxCode");
            entity.Property(e => e.WtaxDescription)
                .HasMaxLength(255)
                .HasColumnName("WTaxDescription");
            entity.Property(e => e.Wtaxtype)
                .HasMaxLength(255)
                .HasColumnName("WTaxtype");
        });

        modelBuilder.Entity<PlantHead>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PLANT_HE__3214EC07DB242659");

            entity.ToTable("PLANT_HEAD");

            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EmailId).HasMaxLength(100);
            entity.Property(e => e.Head)
                .HasMaxLength(100)
                .HasColumnName("HEAD");
            entity.Property(e => e.ModifiedBy).HasMaxLength(100);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Pernr)
                .HasMaxLength(50)
                .HasColumnName("PERNR");
            entity.Property(e => e.Plant).HasMaxLength(20);
        });

        modelBuilder.Entity<PlantHeadCompOt>(entity =>
        {
            entity.ToTable("PLANT_HEAD_COMP_OT");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EmailId).HasMaxLength(100);
            entity.Property(e => e.Head)
                .HasMaxLength(100)
                .HasColumnName("HEAD");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.PayGrp).HasColumnName("Pay_grp");
            entity.Property(e => e.Pernr)
                .HasMaxLength(50)
                .HasColumnName("PERNR");
            entity.Property(e => e.Plant).HasMaxLength(20);
        });

        modelBuilder.Entity<PlantMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Location_Master");

            entity.ToTable("Plant_Master");

            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.LocGroup)
                .HasMaxLength(100)
                .HasColumnName("LOC_Group");
            entity.Property(e => e.LocHead)
                .HasMaxLength(100)
                .HasColumnName("LOC_Head");
            entity.Property(e => e.Locid).HasColumnName("LOCID");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.PrintName).HasMaxLength(100);
        });

        modelBuilder.Entity<PlantsAssignedForUserId>(entity =>
        {
            entity.ToTable("PlantsAssignedForUserId");

            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
            entity.Property(e => e.Uid).HasColumnName("UId");

            entity.HasOne(d => d.Location).WithMany(p => p.PlantsAssignedForUserIds)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlantsAssignedForUserId_Location_Master");

            entity.HasOne(d => d.UidNavigation).WithMany(p => p.PlantsAssignedForUserIds)
                .HasForeignKey(d => d.Uid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlantsAssignedForUserId_UserIdRequest");
        });

        modelBuilder.Entity<PnPeriodMaster>(entity =>
        {
            entity.ToTable("PN_Period_Master");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<PriceGroup>(entity =>
        {
            entity.ToTable("PRICE_GROUP");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(50);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.PGroupId)
                .HasMaxLength(5)
                .HasColumnName("P_GROUP_ID");
            entity.Property(e => e.PGroupName)
                .HasMaxLength(50)
                .HasColumnName("P_GROUP_NAME");
        });

        modelBuilder.Entity<PriceList>(entity =>
        {
            entity.ToTable("PRICE_LIST");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(50);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.PListId)
                .HasMaxLength(5)
                .HasColumnName("P_List_ID");
            entity.Property(e => e.PListName)
                .HasMaxLength(50)
                .HasColumnName("P_LIST_NAME");
        });

        modelBuilder.Entity<PrintTemplate>(entity =>
        {
            entity.ToTable("PrintTemplate", "HR");

            entity.Property(e => e.TemplateName).HasMaxLength(50);
            entity.Property(e => e.TemplateType).HasMaxLength(20);
        });

        modelBuilder.Entity<PrintTemplatePpcMapping>(entity =>
        {
            entity.ToTable("PrintTemplate_PPC_Mapping", "HR");

            entity.Property(e => e.PrintTemplatePpcmappingId).HasColumnName("PrintTemplatePPCMappingId");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.PrintTemplatePpcMappingCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PrintTemplate_PPC_Mapping_CreatedBy");

            entity.HasOne(d => d.EmployeeCategory).WithMany(p => p.PrintTemplatePpcMappings)
                .HasForeignKey(d => d.EmployeeCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PrintTemplate_PPC_Mapping_emp_Category_Master");

            entity.HasOne(d => d.ModifiedBy).WithMany(p => p.PrintTemplatePpcMappingModifiedBies)
                .HasForeignKey(d => d.ModifiedById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PrintTemplate_PPC_Mapping_ModifiedBy");

            entity.HasOne(d => d.PayGroup).WithMany(p => p.PrintTemplatePpcMappings)
                .HasForeignKey(d => d.PayGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PrintTemplate_PPC_Mapping_Paygroup_Master");

            entity.HasOne(d => d.Plant).WithMany(p => p.PrintTemplatePpcMappings)
                .HasForeignKey(d => d.PlantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PrintTemplate_PPC_Mapping_Plant_Master");

            entity.HasOne(d => d.PrintTemplate).WithMany(p => p.PrintTemplatePpcMappings)
                .HasForeignKey(d => d.PrintTemplateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PrintTemplate_PPC_Mapping_PrintTemplate");
        });

        modelBuilder.Entity<PrintingLog>(entity =>
        {
            entity.ToTable("PrintingLog");

            entity.Property(e => e.PrintedBy).HasMaxLength(200);
            entity.Property(e => e.PrintedOn).HasColumnType("datetime");
            entity.Property(e => e.Process).HasMaxLength(100);
            entity.Property(e => e.RequestNo).HasMaxLength(50);
        });

        modelBuilder.Entity<Priority>(entity =>
        {
            entity.ToTable("Priority", "IT");

            entity.Property(e => e.PriorityId).HasColumnName("PriorityID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.PriorityName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProcessMaster>(entity =>
        {
            entity.HasKey(e => e.ProcessId).HasName("PK_WorkFlowProcess");

            entity.ToTable("ProcessMaster");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(40);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.ProcessName).HasMaxLength(40);
        });

        modelBuilder.Entity<ProdAllRequestHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_All_Request_History");

            entity.Property(e => e.ActualApprover).HasMaxLength(50);
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.LastApprover).HasMaxLength(50);
            entity.Property(e => e.PendingApprover).HasMaxLength(50);
            entity.Property(e => e.RequestNo).HasMaxLength(50);
            entity.Property(e => e.RequestStatus).HasMaxLength(100);
            entity.Property(e => e.RequestType).HasMaxLength(50);
            entity.Property(e => e.RequestedBy).HasMaxLength(50);
            entity.Property(e => e.RequestedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProdApprovalTransaction>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_ApprovalTransactions");

            entity.Property(e => e.Comments).IsUnicode(false);
            entity.Property(e => e.DoneBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.DoneOn).HasColumnType("datetime");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.KeyValue).HasMaxLength(80);
            entity.Property(e => e.ParallelApprover1).HasMaxLength(50);
            entity.Property(e => e.ParallelApprover2).HasMaxLength(50);
            entity.Property(e => e.ParallelApprover3).HasMaxLength(50);
            entity.Property(e => e.ParallelApprover4).HasMaxLength(50);
            entity.Property(e => e.ParallelApprover5).HasMaxLength(100);
            entity.Property(e => e.ProcessType).HasMaxLength(100);
            entity.Property(e => e.RequestNo).HasMaxLength(20);
        });

        modelBuilder.Entity<ProdCustomerMasterM>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_CUSTOMER_MASTER_M");

            entity.Property(e => e.AccountClerkId)
                .HasMaxLength(5)
                .HasColumnName("ACCOUNT_CLERK_ID");
            entity.Property(e => e.AccountGroupId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ACCOUNT_GROUP_ID");
            entity.Property(e => e.Address1)
                .HasMaxLength(100)
                .HasColumnName("ADDRESS1");
            entity.Property(e => e.Address2)
                .HasMaxLength(100)
                .HasColumnName("ADDRESS2");
            entity.Property(e => e.Address3)
                .HasMaxLength(100)
                .HasColumnName("ADDRESS3");
            entity.Property(e => e.Address4)
                .HasMaxLength(100)
                .HasColumnName("ADDRESS4");
            entity.Property(e => e.ApproveDate)
                .HasColumnType("datetime")
                .HasColumnName("approve_date");
            entity.Property(e => e.ApproveStatus)
                .HasMaxLength(30)
                .HasColumnName("Approve_Status");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .HasColumnName("CITY");
            entity.Property(e => e.CountryId)
                .HasMaxLength(5)
                .HasColumnName("COUNTRY_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.CstNo)
                .HasMaxLength(40)
                .HasColumnName("CST_NO");
            entity.Property(e => e.CurrencyId)
                .HasMaxLength(5)
                .HasColumnName("CURRENCY_ID");
            entity.Property(e => e.CustomerGroup)
                .HasMaxLength(5)
                .HasColumnName("Customer_Group");
            entity.Property(e => e.CustomerType)
                .HasMaxLength(10)
                .HasColumnName("Customer_Type");
            entity.Property(e => e.CutomerCode)
                .HasMaxLength(200)
                .HasColumnName("cutomer_code");
            entity.Property(e => e.Dlno1)
                .HasMaxLength(40)
                .HasColumnName("DLNO1");
            entity.Property(e => e.Dlno2)
                .HasMaxLength(40)
                .HasColumnName("DLNO2");
            entity.Property(e => e.EccNo)
                .HasMaxLength(40)
                .HasColumnName("ECC_No");
            entity.Property(e => e.EmailId)
                .HasMaxLength(80)
                .HasColumnName("EMAIL_ID");
            entity.Property(e => e.ExciseDivision)
                .HasMaxLength(40)
                .HasColumnName("Excise_Division");
            entity.Property(e => e.ExciseRange)
                .HasMaxLength(40)
                .HasColumnName("Excise_Range");
            entity.Property(e => e.ExciseRegNo)
                .HasMaxLength(40)
                .HasColumnName("Excise_Reg_No");
            entity.Property(e => e.FaxNo)
                .HasMaxLength(20)
                .HasColumnName("FAX_NO");
            entity.Property(e => e.GstinNumber).HasColumnName("GSTIN_Number");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsRegdExciseCustomer).HasColumnName("IS_REGD_EXCISE_Customer");
            entity.Property(e => e.IsRegdExciseVendor).HasColumnName("IS_REGD_EXCISE_VENDOR");
            entity.Property(e => e.LandlineNo)
                .HasMaxLength(20)
                .HasColumnName("LANDLINE_NO");
            entity.Property(e => e.LastApprover)
                .HasMaxLength(200)
                .HasColumnName("last_approver");
            entity.Property(e => e.LstNo)
                .HasMaxLength(40)
                .HasColumnName("LST_NO");
            entity.Property(e => e.MobileNo)
                .HasMaxLength(20)
                .HasColumnName("MOBILE_NO");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(30)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DATE");
            entity.Property(e => e.Name)
                .HasMaxLength(80)
                .HasColumnName("NAME");
            entity.Property(e => e.PanNo)
                .HasMaxLength(40)
                .HasColumnName("PAN_No");
            entity.Property(e => e.PaymentTermId)
                .HasMaxLength(5)
                .HasColumnName("PAYMENT_TERM_ID");
            entity.Property(e => e.PendingApprover)
                .HasMaxLength(200)
                .HasColumnName("pending_approver");
            entity.Property(e => e.Pincode)
                .HasMaxLength(10)
                .HasColumnName("PINCODE");
            entity.Property(e => e.PlantCode)
                .HasMaxLength(50)
                .HasColumnName("plant_code");
            entity.Property(e => e.PriceGroup)
                .HasMaxLength(5)
                .HasColumnName("Price_Group");
            entity.Property(e => e.PriceList)
                .HasMaxLength(5)
                .HasColumnName("Price_List");
            entity.Property(e => e.RejectedFlag)
                .HasMaxLength(50)
                .HasColumnName("rejected_flag");
            entity.Property(e => e.RequestDate)
                .HasColumnType("datetime")
                .HasColumnName("REQUEST_DATE");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(20)
                .HasColumnName("REQUEST_NO");
            entity.Property(e => e.RequestedBy)
                .HasMaxLength(30)
                .HasColumnName("REQUESTED_BY");
            entity.Property(e => e.SapCodeExists)
                .HasMaxLength(50)
                .HasColumnName("SAP_CODE_EXISTS");
            entity.Property(e => e.SapCodeNo)
                .HasMaxLength(100)
                .HasColumnName("SAP_CODE_NO");
            entity.Property(e => e.SapCreatedBy)
                .HasMaxLength(50)
                .HasColumnName("SAP_CREATED_BY");
            entity.Property(e => e.SapCreationDate)
                .HasColumnType("datetime")
                .HasColumnName("SAP_CREATION_DATE");
            entity.Property(e => e.ServiceTaxRegistrationNo)
                .HasMaxLength(40)
                .HasColumnName("Service_Tax_Registration_No");
            entity.Property(e => e.State)
                .HasMaxLength(5)
                .HasColumnName("STATE");
            entity.Property(e => e.TaxType)
                .HasMaxLength(5)
                .HasColumnName("Tax_Type");
            entity.Property(e => e.TdsCode)
                .HasMaxLength(5)
                .HasColumnName("TDS_CODE");
            entity.Property(e => e.TinNo)
                .HasMaxLength(40)
                .HasColumnName("TIN_NO");
            entity.Property(e => e.ViewType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("VIEW_TYPE");
        });

        modelBuilder.Entity<ProdDepartmentMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_Department_Master");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(600)
                .IsUnicode(false);
            entity.Property(e => e.FkParentId).HasColumnName("FK_ParentId");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProdDesignationMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_Designation_Master");

            entity.Property(e => e.AtemId).HasColumnName("ATEM_ID");
            entity.Property(e => e.Bandid).HasColumnName("BANDID");
            entity.Property(e => e.Cooff).HasColumnName("COOFF");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(600)
                .IsUnicode(false);
            entity.Property(e => e.Dsgid).HasColumnName("DSGID");
            entity.Property(e => e.FkParentId).HasColumnName("FK_ParentId");
            entity.Property(e => e.Gradeid).HasColumnName("GRADEID");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(55)
                .IsUnicode(false);
            entity.Property(e => e.Ot).HasColumnName("OT");
        });

        modelBuilder.Entity<ProdEmployeeAddress>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_Employee_Address");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CurrentAddress)
                .HasMaxLength(500)
                .HasColumnName("Current_Address");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.EmgContactName)
                .HasMaxLength(50)
                .HasColumnName("Emg_Contact_Name");
            entity.Property(e => e.EmgContactNumber)
                .HasMaxLength(50)
                .HasColumnName("Emg_Contact_Number");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(50)
                .HasColumnName("Employee_ID");
            entity.Property(e => e.FkEmpId).HasColumnName("FK_Emp_ID");
            entity.Property(e => e.GuardianName)
                .HasMaxLength(50)
                .HasColumnName("Guardian_Name");
            entity.Property(e => e.GuardianPhone)
                .HasMaxLength(50)
                .HasColumnName("Guardian_Phone");
            entity.Property(e => e.GuardianRelation)
                .HasMaxLength(50)
                .HasColumnName("Guardian_Relation");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ModuleEnableId).HasColumnName("Module_enableId");
            entity.Property(e => e.NomineeName)
                .HasMaxLength(50)
                .HasColumnName("Nominee_Name");
            entity.Property(e => e.NomineePhone)
                .HasMaxLength(50)
                .HasColumnName("Nominee_Phone");
            entity.Property(e => e.PermanentAddress)
                .HasMaxLength(500)
                .HasColumnName("Permanent_Address");
            entity.Property(e => e.PersonalEmail).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
        });

        modelBuilder.Entity<ProdEmployeeMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_Employee_Master");

            entity.Property(e => e.BaseLocation)
                .HasMaxLength(50)
                .HasColumnName("Base_Location");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Designation).HasMaxLength(100);
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Dol)
                .HasColumnType("datetime")
                .HasColumnName("DOL");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(10)
                .HasColumnName("Employee_ID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(1000)
                .HasColumnName("First_Name");
            entity.Property(e => e.FkAddressId).HasColumnName("FK_Address_ID");
            entity.Property(e => e.FkApprovalTemplateId).HasColumnName("FK_Approval_Template_ID");
            entity.Property(e => e.FkCompetency).HasColumnName("FK_Competency");
            entity.Property(e => e.FkDepartment).HasColumnName("FK_Department");
            entity.Property(e => e.FkDesignation).HasColumnName("FK_Designation");
            entity.Property(e => e.FkManager).HasColumnName("FK_Manager");
            entity.Property(e => e.FkOtherDetailsId).HasColumnName("FK_Other_Details_ID");
            entity.Property(e => e.FkParentId).HasColumnName("FK_Parent_ID");
            entity.Property(e => e.FkParentIdCount).HasColumnName("FK_Parent_ID_Count");
            entity.Property(e => e.FkPayroll).HasColumnName("FK_Payroll");
            entity.Property(e => e.FkProfileId).HasColumnName("FK_Profile_Id");
            entity.Property(e => e.FkProjectId).HasColumnName("FK_Project_ID");
            entity.Property(e => e.FkReportingManager).HasColumnName("FK_Reporting_Manager");
            entity.Property(e => e.FkRoleId).HasColumnName("FK_Role_ID");
            entity.Property(e => e.FkSbuId).HasColumnName("FK_SBU_Id");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(200)
                .HasColumnName("Img_Url");
            entity.Property(e => e.JoiningDate).HasColumnType("datetime");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.RedirectUrl).HasMaxLength(500);
        });

        modelBuilder.Entity<ProdEmployeeOtherDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_Employee_other_details");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CurrentLocation)
                .HasMaxLength(100)
                .HasColumnName("Current_location");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(10)
                .HasColumnName("Employee_ID");
            entity.Property(e => e.FkEmpId).HasColumnName("FK_Emp_ID");
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.HardSkill)
                .HasMaxLength(500)
                .HasColumnName("Hard_skill");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(200)
                .HasColumnName("Img_Url");
            entity.Property(e => e.LastCompany)
                .HasMaxLength(100)
                .HasColumnName("Last_company");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PanNumber)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.PassportNumber).HasMaxLength(50);
            entity.Property(e => e.PreviousLocation)
                .HasMaxLength(100)
                .HasColumnName("Previous_location");
            entity.Property(e => e.Qualification).HasMaxLength(100);
            entity.Property(e => e.RelativeExp).HasColumnName("Relative_Exp");
            entity.Property(e => e.SecondLastCompany)
                .HasMaxLength(100)
                .HasColumnName("Second_Last_company");
            entity.Property(e => e.SoftSkill)
                .HasMaxLength(500)
                .HasColumnName("Soft_skill");
            entity.Property(e => e.VisaIsActive).HasColumnName("Visa_IsActive");
            entity.Property(e => e.VisaNumber).HasMaxLength(50);
            entity.Property(e => e.YearExp).HasColumnName("Year_Exp");
            entity.Property(e => e.YearOfPassing)
                .HasMaxLength(50)
                .HasColumnName("Year_of_passing");
        });

        modelBuilder.Entity<ProdGateOutwardD>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_GATE_OUTWARD_D");

            entity.Property(e => e.Close)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CLOSE");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.DelFlg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("DEL_FLG");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DELETED_BY");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("DELETED_DATE");
            entity.Property(e => e.ExpReturnDate)
                .HasColumnType("datetime")
                .HasColumnName("EXP_RETURN_DATE");
            entity.Property(e => e.FinYear)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("FIN_YEAR");
            entity.Property(e => e.FkgateOutwardM).HasColumnName("FKGATE_OUTWARD_M");
            entity.Property(e => e.GoGateno)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("GO_GATENO");
            entity.Property(e => e.GoNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("GO_NO");
            entity.Property(e => e.InItemDesc)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("IN_ITEM_DESC");
            entity.Property(e => e.InQty)
                .HasColumnType("numeric(10, 3)")
                .HasColumnName("IN_QTY");
            entity.Property(e => e.ItemCode)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("ITEM_CODE");
            entity.Property(e => e.ItemCodeP)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("ITEM_CODE_P");
            entity.Property(e => e.ItemDesc)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("ITEM_DESC");
            entity.Property(e => e.ItemDescP)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ITEM_DESC_P");
            entity.Property(e => e.ItemNo).HasColumnName("ITEM_NO");
            entity.Property(e => e.Mandt)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("MANDT");
            entity.Property(e => e.MaterialType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MATERIAL_TYPE");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DATE");
            entity.Property(e => e.NoOfCases).HasColumnName("NO_OF_CASES");
            entity.Property(e => e.PlantId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("PLANT_ID");
            entity.Property(e => e.PoNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PO_NO");
            entity.Property(e => e.Qty)
                .HasColumnType("numeric(10, 3)")
                .HasColumnName("QTY");
            entity.Property(e => e.Remarks)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("REMARKS");
            entity.Property(e => e.Uom)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("UOM");
        });

        modelBuilder.Entity<ProdGateOutwardM>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_GATE_OUTWARD_M");

            entity.Property(e => e.ApprovedBy).HasMaxLength(50);
            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.Comments)
                .IsUnicode(false)
                .HasColumnName("comments");
            entity.Property(e => e.CourierDate)
                .HasColumnType("datetime")
                .HasColumnName("Courier_Date");
            entity.Property(e => e.CourierName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Courier_Name");
            entity.Property(e => e.CourierNum)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Courier_Num");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.DcDate)
                .HasColumnType("datetime")
                .HasColumnName("DC_DATE");
            entity.Property(e => e.DcNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DC_NO");
            entity.Property(e => e.DelFlg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("DEL_FLG");
            entity.Property(e => e.DelReason)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DEL_REASON");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DELETED_BY");
            entity.Property(e => e.DeletedDate)
                .HasColumnType("datetime")
                .HasColumnName("DELETED_DATE");
            entity.Property(e => e.Deliverymode)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("DELIVERYMODE");
            entity.Property(e => e.Deliveryperson)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DELIVERYPERSON");
            entity.Property(e => e.DestinationNm)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESTINATION_NM");
            entity.Property(e => e.DocDate)
                .HasColumnType("datetime")
                .HasColumnName("DOC_DATE");
            entity.Property(e => e.DocNo)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("DOC_NO");
            entity.Property(e => e.DriverName).HasMaxLength(100);
            entity.Property(e => e.ExpOutTime)
                .HasColumnType("datetime")
                .HasColumnName("EXP_OUT_TIME");
            entity.Property(e => e.ExpReturnDate)
                .HasColumnType("datetime")
                .HasColumnName("EXP_RETURN_DATE");
            entity.Property(e => e.FinYear)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("FIN_YEAR");
            entity.Property(e => e.GoDate)
                .HasColumnType("datetime")
                .HasColumnName("GO_DATE");
            entity.Property(e => e.GoFlg)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("GO_FLG");
            entity.Property(e => e.GoGateno)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("GO_GATENO");
            entity.Property(e => e.GoNo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("GO_NO");
            entity.Property(e => e.GoType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("GO_TYPE");
            entity.Property(e => e.LrNo).HasMaxLength(100);
            entity.Property(e => e.Mandt)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("MANDT");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DATE");
            entity.Property(e => e.OutDate)
                .HasColumnType("datetime")
                .HasColumnName("OUT_DATE");
            entity.Property(e => e.OutTime)
                .HasColumnType("datetime")
                .HasColumnName("OUT_TIME");
            entity.Property(e => e.PendingWith).HasMaxLength(50);
            entity.Property(e => e.PersonName)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("PERSON_NAME");
            entity.Property(e => e.PlantId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("PLANT_ID");
            entity.Property(e => e.Recid)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("RECID");
            entity.Property(e => e.Remarks)
                .IsUnicode(false)
                .HasColumnName("REMARKS");
            entity.Property(e => e.SendingDeptNm)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("SENDING_DEPT_NM");
            entity.Property(e => e.SendingPerson)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("SENDING_PERSON");
            entity.Property(e => e.SendingReason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SENDING_REASON");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.TransporterName).HasMaxLength(100);
            entity.Property(e => e.Vehicleno)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("VEHICLENO");
        });

        modelBuilder.Entity<ProdGigoapprovalTransaction>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_GIGOApprovalTransactions");

            entity.Property(e => e.ApprovedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ApprovedOn).HasColumnType("datetime");
            entity.Property(e => e.Comments)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Department)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Gonumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("GONumber");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.KeyValue)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MainApprover)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ParallelApprover1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ParallelApprover2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ParallelApprover3)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ParallelApprover4)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ParallelApprover5)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TransactionType)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProdGigoapprover>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_GIGOApprovers");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Department)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Gotype)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("GOType");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.KeyValue)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.MainApprover)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MaterialType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Pa1emailEnabled).HasColumnName("PA1EmailEnabled");
            entity.Property(e => e.Pa2emailEnabled).HasColumnName("PA2EmailEnabled");
            entity.Property(e => e.Pa3emailEnabled).HasColumnName("PA3EmailEnabled");
            entity.Property(e => e.Pa4emailEnabled).HasColumnName("PA4EmailEnabled");
            entity.Property(e => e.Pa5emailEnabled).HasColumnName("PA5EmailEnabled");
            entity.Property(e => e.ParallelApprover1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ParallelApprover2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ParallelApprover3)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ParallelApprover4)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ParallelApprover5)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Plant)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProdItemCodeModification>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_ItemCodeModification");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ItemCode).HasMaxLength(50);
            entity.Property(e => e.LastApprover).HasMaxLength(50);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.PendingApprover).HasMaxLength(50);
            entity.Property(e => e.RequestDate).HasColumnType("datetime");
            entity.Property(e => e.RequestNo).HasMaxLength(10);
            entity.Property(e => e.RequestedBy).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<ProdItemCodeRequest>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_Item_Code_Request");

            entity.Property(e => e.AdditionalTest).HasColumnName("ADDITIONAL_TEST");
            entity.Property(e => e.ApiName).HasColumnName("apiName");
            entity.Property(e => e.ApiVendorName).HasColumnName("apiVendorName");
            entity.Property(e => e.ApproveDate)
                .HasColumnType("datetime")
                .HasColumnName("approve_date");
            entity.Property(e => e.ApproveType)
                .HasMaxLength(50)
                .HasColumnName("Approve_Type");
            entity.Property(e => e.ApproximateValue)
                .HasMaxLength(50)
                .HasColumnName("APPROXIMATE_VALUE");
            entity.Property(e => e.ArtWorkValidity).HasColumnType("datetime");
            entity.Property(e => e.ArtworkNo)
                .HasMaxLength(20)
                .HasColumnName("ARTWORK_NO");
            entity.Property(e => e.AvailableDmf)
                .HasMaxLength(100)
                .HasColumnName("availableDMF");
            entity.Property(e => e.BatchCode)
                .HasMaxLength(10)
                .HasColumnName("BATCH_CODE");
            entity.Property(e => e.BrandId).HasColumnName("BRAND_ID");
            entity.Property(e => e.Company)
                .HasMaxLength(100)
                .HasColumnName("company");
            entity.Property(e => e.ComponentMake)
                .HasMaxLength(80)
                .HasColumnName("Component_MAKE");
            entity.Property(e => e.CosGradeAndNo).HasColumnName("COS_GRADE_AND_NO");
            entity.Property(e => e.CountryId)
                .HasMaxLength(3)
                .HasColumnName("COUNTRY_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.CustomerName).HasColumnName("CUSTOMER_NAME");
            entity.Property(e => e.DetailedJustification).HasColumnName("DETAILED_JUSTIFICATION");
            entity.Property(e => e.DetailedSpecification).HasColumnName("DETAILED_SPECIFICATION");
            entity.Property(e => e.Dimension)
                .HasMaxLength(100)
                .HasColumnName("DIMENSION");
            entity.Property(e => e.DivisionId)
                .HasMaxLength(2)
                .HasColumnName("DIVISION_ID");
            entity.Property(e => e.DmfGradeId).HasColumnName("DMF_GRADE_ID");
            entity.Property(e => e.DomesticOrExports)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DOMESTIC_OR_EXPORTS");
            entity.Property(e => e.DutyElement)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DUTY_ELEMENT");
            entity.Property(e => e.EMicroRefReqNo)
                .HasMaxLength(10)
                .HasColumnName("eMicroRefReqNo");
            entity.Property(e => e.EquipIntended)
                .HasMaxLength(40)
                .HasColumnName("equip_Intended");
            entity.Property(e => e.EquipmentMake)
                .HasMaxLength(80)
                .HasColumnName("EQUIPMENT_MAKE");
            entity.Property(e => e.EquipmentName)
                .HasMaxLength(80)
                .HasColumnName("EQUIPMENT_NAME");
            entity.Property(e => e.ExcepientsDetails).HasColumnName("excepientsDetails");
            entity.Property(e => e.ExcipientsCheck)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("excipientsCheck");
            entity.Property(e => e.ExistDmfno)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("existDMFNo");
            entity.Property(e => e.ExistLegacyCode)
                .HasMaxLength(100)
                .HasColumnName("existLegacyCode");
            entity.Property(e => e.ExistingItemCode)
                .HasMaxLength(50)
                .HasColumnName("EXISTING_ITEM_CODE");
            entity.Property(e => e.ExistingSapDescription)
                .HasMaxLength(100)
                .HasColumnName("existingSapDescription");
            entity.Property(e => e.ExistingSapItemCode)
                .HasMaxLength(20)
                .HasColumnName("EXISTING_SAP_ITEM_CODE");
            entity.Property(e => e.FgSapProductCode)
                .HasMaxLength(18)
                .HasColumnName("FG_SAP_PRODUCT_CODE");
            entity.Property(e => e.FinishedProductCode).HasColumnName("finishedProductCode");
            entity.Property(e => e.FirstAlphaRaw)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("firstAlphaRaw");
            entity.Property(e => e.GenericName).HasColumnName("GENERIC_NAME");
            entity.Property(e => e.GlobalSerReq)
                .HasMaxLength(50)
                .HasColumnName("global_ser_req");
            entity.Property(e => e.GrossWeight).HasColumnName("GROSS_WEIGHT");
            entity.Property(e => e.HsnCode)
                .HasMaxLength(50)
                .HasColumnName("HSN_Code");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.ImmediatePackMat).HasColumnName("immediatePack_Mat");
            entity.Property(e => e.ImmediatePackMatCheck)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("immediatePack_MatCheck");
            entity.Property(e => e.IsArtworkRevision)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IS_ARTWORK_REVISION");
            entity.Property(e => e.IsAsset)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("is_asset");
            entity.Property(e => e.IsCoated)
                .HasMaxLength(100)
                .HasColumnName("is_coated");
            entity.Property(e => e.IsDmfMaterial)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IS_DMF_MATERIAL");
            entity.Property(e => e.IsEquipment)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IS_EQUIPMENT");
            entity.Property(e => e.IsNew)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IS_NEW");
            entity.Property(e => e.IsNewEquipment)
                .HasMaxLength(10)
                .HasColumnName("IS_NEW_Equipment");
            entity.Property(e => e.IsNewFacility)
                .HasMaxLength(10)
                .HasColumnName("IS_NEW_Facility");
            entity.Property(e => e.IsNewFurniture)
                .HasMaxLength(10)
                .HasColumnName("IS_NEW_Furniture");
            entity.Property(e => e.IsSasFormAvailable)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IS_SAS_FORM_AVAILABLE");
            entity.Property(e => e.IsSpare)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IS_SPARE");
            entity.Property(e => e.IsSpareRequired)
                .HasMaxLength(10)
                .HasColumnName("IS_Spare_required");
            entity.Property(e => e.IsVendorSpecificMaterial)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IS_VENDOR_SPECIFIC_MATERIAL");
            entity.Property(e => e.ItemAvailable)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("item_available");
            entity.Property(e => e.ItemCodeExisting).HasColumnName("ItemCode_existing");
            entity.Property(e => e.ItemCodeProposed).HasColumnName("ItemCode_Proposed");
            entity.Property(e => e.ItemFromMultipleVendors)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("itemFromMultipleVendors");
            entity.Property(e => e.ItemspecificVendor)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("itemspecificVendor");
            entity.Property(e => e.LastApprover)
                .HasMaxLength(100)
                .HasColumnName("last_approver");
            entity.Property(e => e.LocationId)
                .HasMaxLength(4)
                .HasColumnName("LOCATION_ID");
            entity.Property(e => e.MachineName)
                .HasMaxLength(40)
                .HasColumnName("MACHINE_NAME");
            entity.Property(e => e.ManufactMatch)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("manufact_match");
            entity.Property(e => e.ManufactureAddress).HasColumnName("manufactureAddress");
            entity.Property(e => e.ManufacturedAt)
                .HasMaxLength(50)
                .HasColumnName("MANUFACTURED_AT");
            entity.Property(e => e.ManufacturingFormula).HasColumnName("manufacturing_formula");
            entity.Property(e => e.Market).HasColumnName("MARKET");
            entity.Property(e => e.MarketCustCount).HasColumnName("market_cust_count");
            entity.Property(e => e.MatchSpecification)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("matchSpecification");
            entity.Property(e => e.MaterialGrade)
                .HasMaxLength(30)
                .HasColumnName("MATERIAL_GRADE");
            entity.Property(e => e.MaterialGroupId)
                .HasMaxLength(9)
                .HasColumnName("MATERIAL_GROUP_ID");
            entity.Property(e => e.MaterialLongName).HasColumnName("MATERIAL_LONG_NAME");
            entity.Property(e => e.MaterialPricing)
                .HasMaxLength(2)
                .HasColumnName("Material_Pricing");
            entity.Property(e => e.MaterialShortName).HasColumnName("MATERIAL_SHORT_NAME");
            entity.Property(e => e.MaterialTypeId)
                .HasMaxLength(4)
                .HasColumnName("MATERIAL_TYPE_ID");
            entity.Property(e => e.MaterialUsedIn)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MATERIAL_USED_IN");
            entity.Property(e => e.Message)
                .HasMaxLength(500)
                .HasColumnName("message");
            entity.Property(e => e.MessageType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Message_Type");
            entity.Property(e => e.MfgrName).HasColumnName("MFGR_NAME");
            entity.Property(e => e.MfrDate)
                .HasColumnType("datetime")
                .HasColumnName("MFR_DATE");
            entity.Property(e => e.MfrNo)
                .HasMaxLength(20)
                .HasColumnName("MFR_NO");
            entity.Property(e => e.Moc)
                .HasMaxLength(25)
                .HasColumnName("moc");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DATE");
            entity.Property(e => e.Molecules)
                .HasMaxLength(500)
                .HasColumnName("molecules");
            entity.Property(e => e.NetWeight).HasColumnName("NET_WEIGHT");
            entity.Property(e => e.NewCustomerName).HasColumnName("NEW_CUSTOMER_NAME");
            entity.Property(e => e.NewLegacyCode)
                .HasMaxLength(100)
                .HasColumnName("newLegacyCode");
            entity.Property(e => e.NewPackSize).HasColumnName("NEW_PACK_SIZE");
            entity.Property(e => e.OemPartNo)
                .HasMaxLength(80)
                .HasColumnName("OEM_PartNo");
            entity.Property(e => e.PackSize)
                .IsUnicode(false)
                .HasColumnName("PACK_SIZE");
            entity.Property(e => e.PackTypeId)
                .HasMaxLength(3)
                .HasColumnName("PACK_TYPE_ID");
            entity.Property(e => e.PackingMaterialGroup)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PACKING_MATERIAL_GROUP");
            entity.Property(e => e.PendingApprover).HasColumnName("pending_approver");
            entity.Property(e => e.PharmacopGrade)
                .HasMaxLength(50)
                .HasColumnName("PHARMACOP_GRADE");
            entity.Property(e => e.PharmacopName).HasColumnName("PHARMACOP_NAME");
            entity.Property(e => e.PharmacopSpecification).HasColumnName("PHARMACOP_SPECIFICATION");
            entity.Property(e => e.PoNumber)
                .HasMaxLength(10)
                .HasColumnName("PO_NUMBER");
            entity.Property(e => e.PrNumber)
                .HasMaxLength(10)
                .HasColumnName("PR_NUMBER");
            entity.Property(e => e.ProdInspMemo)
                .HasMaxLength(18)
                .HasColumnName("PROD_INSP_MEMO");
            entity.Property(e => e.ProductMatch)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("product_match");
            entity.Property(e => e.ProductName).HasColumnName("PRODUCT_NAME");
            entity.Property(e => e.PunchesOrDies).HasColumnName("punches_or_Dies");
            entity.Property(e => e.PunchesOrDiesMatch)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("punches_or_Dies_match");
            entity.Property(e => e.PurchaseGroupId)
                .HasMaxLength(4)
                .HasColumnName("PURCHASE_GROUP_ID");
            entity.Property(e => e.PurposeId).HasColumnName("PURPOSE_ID");
            entity.Property(e => e.QcSpecification)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("qcSpecification");
            entity.Property(e => e.Qualitycomplyspecification)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("qualitycomplyspecification");
            entity.Property(e => e.Range)
                .HasMaxLength(30)
                .HasColumnName("range");
            entity.Property(e => e.Rating)
                .HasMaxLength(30)
                .HasColumnName("rating");
            entity.Property(e => e.ReasonType)
                .HasMaxLength(100)
                .HasColumnName("REASON_TYPE");
            entity.Property(e => e.RecordStatus)
                .HasMaxLength(10)
                .HasColumnName("record_status");
            entity.Property(e => e.RejectedFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("rejected_flag");
            entity.Property(e => e.ReportUrl)
                .HasMaxLength(200)
                .HasColumnName("REPORT_URL");
            entity.Property(e => e.ReqMeetVendorReq)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("reqMeetVendorReq");
            entity.Property(e => e.RequestDate)
                .HasColumnType("datetime")
                .HasColumnName("REQUEST_DATE");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(20)
                .HasColumnName("REQUEST_NO");
            entity.Property(e => e.RequestedBy)
                .HasMaxLength(50)
                .HasColumnName("REQUESTED_BY");
            entity.Property(e => e.RequiredDmf)
                .HasMaxLength(100)
                .HasColumnName("requiredDMF");
            entity.Property(e => e.RetestDays).HasColumnName("RETEST_DAYS");
            entity.Property(e => e.RetestDaysType)
                .HasMaxLength(50)
                .HasColumnName("RETEST_DAYS_TYPE");
            entity.Property(e => e.RevisedArtworkCode)
                .HasMaxLength(100)
                .HasColumnName("revisedArtworkCode");
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.SaleableOrSample)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SALEABLE_OR_SAMPLE");
            entity.Property(e => e.SalesPackId)
                .HasMaxLength(20)
                .HasColumnName("SALES_PACK_ID");
            entity.Property(e => e.SalesUnitOfMeasId)
                .HasMaxLength(3)
                .HasColumnName("SALES_UNIT_OF_MEAS_ID");
            entity.Property(e => e.SameMarCustCount)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Same_mar_cust_count");
            entity.Property(e => e.SapAppStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SAP_APP_Status");
            entity.Property(e => e.SapApprovedDate)
                .HasColumnType("datetime")
                .HasColumnName("SAP_Approved_Date");
            entity.Property(e => e.SapCodeCoated)
                .HasMaxLength(100)
                .HasColumnName("sap_code_coated");
            entity.Property(e => e.SapCodeCore)
                .HasMaxLength(100)
                .HasColumnName("sap_code_core");
            entity.Property(e => e.SapCodeExistCoated)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sap_code_exist_coated");
            entity.Property(e => e.SapCodeExistCore)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sap_code_exist_core");
            entity.Property(e => e.SapCodeExists)
                .HasMaxLength(50)
                .HasColumnName("SAP_CODE_EXISTS");
            entity.Property(e => e.SapCodeNo)
                .HasMaxLength(100)
                .HasColumnName("SAP_CODE_NO");
            entity.Property(e => e.SapCosGradeNo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sapCosGradeNo");
            entity.Property(e => e.SapCreatedBy)
                .HasMaxLength(100)
                .HasColumnName("SAP_CREATED_BY");
            entity.Property(e => e.SapCreationDate)
                .HasColumnType("datetime")
                .HasColumnName("SAP_CREATION_DATE");
            entity.Property(e => e.SapDutyElement)
                .HasMaxLength(100)
                .HasColumnName("sapDutyElement");
            entity.Property(e => e.SapMaterialCodeLists)
                .HasMaxLength(100)
                .HasColumnName("sapMaterialCodeLists");
            entity.Property(e => e.SapMaterialTypeId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sapMaterialTypeId");
            entity.Property(e => e.SapMessage)
                .HasMaxLength(500)
                .HasColumnName("SAP_Message");
            entity.Property(e => e.SapMfgrName)
                .HasMaxLength(100)
                .HasColumnName("sapMfgrName");
            entity.Property(e => e.SapSiteOfManufacture).HasColumnName("sapSiteOfManufacture");
            entity.Property(e => e.SapStatus)
                .HasMaxLength(10)
                .HasColumnName("SAP_Status");
            entity.Property(e => e.SapStatusFlag).HasColumnName("sap_statusFlag");
            entity.Property(e => e.SerializationType)
                .HasMaxLength(100)
                .HasColumnName("Serialization_type");
            entity.Property(e => e.SerializedFromDate)
                .HasMaxLength(100)
                .HasColumnName("Serialized_from_date");
            entity.Property(e => e.ServiceCateId)
                .HasMaxLength(4)
                .HasColumnName("SERVICE_CATE_ID");
            entity.Property(e => e.ShelfLife).HasColumnName("SHELF_LIFE");
            entity.Property(e => e.ShelfLifeType)
                .HasMaxLength(50)
                .HasColumnName("SHELF_LIFE_TYPE");
            entity.Property(e => e.SiteOfManufacture).HasColumnName("SITE_OF_MANUFACTURE");
            entity.Property(e => e.SpecialApi).HasColumnName("specialAPI");
            entity.Property(e => e.SpecificationAdditionalTest).HasColumnName("specificationAdditionalTest");
            entity.Property(e => e.SpecificationNo)
                .HasMaxLength(100)
                .HasColumnName("specificationNo");
            entity.Property(e => e.StandardBatchSize).HasColumnName("STANDARD_BATCH_SIZE");
            entity.Property(e => e.StdBatchSizeUom)
                .HasMaxLength(3)
                .HasColumnName("STD_BATCH_SIZE_UOM");
            entity.Property(e => e.Storage).HasMaxLength(50);
            entity.Property(e => e.StorageCondition)
                .HasMaxLength(2)
                .HasColumnName("STORAGE_CONDITION");
            entity.Property(e => e.StorageConditionother).HasMaxLength(200);
            entity.Property(e => e.StorageLocationId)
                .HasMaxLength(4)
                .HasColumnName("STORAGE_LOCATION_ID");
            entity.Property(e => e.StrengthId)
                .HasMaxLength(3)
                .HasColumnName("STRENGTH_ID");
            entity.Property(e => e.Synonym)
                .HasMaxLength(80)
                .HasColumnName("SYNONYM");
            entity.Property(e => e.TargetWeight).HasColumnName("TARGET_WEIGHT");
            entity.Property(e => e.TargetWeightCoated)
                .HasMaxLength(100)
                .HasColumnName("target_weight_coated");
            entity.Property(e => e.TargetWeightCore)
                .HasMaxLength(100)
                .HasColumnName("target_weight_core");
            entity.Property(e => e.TaxClassification)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Tax_Classification");
            entity.Property(e => e.TempCondition)
                .HasMaxLength(2)
                .HasColumnName("TEMP_CONDITION");
            entity.Property(e => e.TestingSpecMatch)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("testingSpec_match");
            entity.Property(e => e.TestingSpecification).HasColumnName("Testing_Specification");
            entity.Property(e => e.TherapeuticSegmentId)
                .HasMaxLength(3)
                .HasColumnName("THERAPEUTIC_SEGMENT_ID");
            entity.Property(e => e.ToBeUsedInProducts).HasColumnName("TO_BE_USED_IN_PRODUCTS");
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.TypeOfMaterial)
                .HasMaxLength(50)
                .HasColumnName("Type_Of_Material");
            entity.Property(e => e.UnitOfMeasId)
                .HasMaxLength(3)
                .HasColumnName("UNIT_OF_MEAS_ID");
            entity.Property(e => e.Url).HasColumnName("URL");
            entity.Property(e => e.UtilizingDept)
                .HasMaxLength(80)
                .HasColumnName("UTILIZING_DEPT");
            entity.Property(e => e.ValuationClass)
                .HasMaxLength(4)
                .HasColumnName("VALUATION_CLASS");
            entity.Property(e => e.VendorReqMatch)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("vendorReqMatch");
            entity.Property(e => e.VendorSpecific).HasColumnName("vendorSpecific");
            entity.Property(e => e.WeightUom)
                .HasMaxLength(3)
                .HasColumnName("WEIGHT_UOM");
        });

        modelBuilder.Entity<ProdItemcodeExtenstionRequest>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_Itemcode_extenstion_request");

            entity.Property(e => e.ApproveDate)
                .HasColumnType("datetime")
                .HasColumnName("approve_date");
            entity.Property(e => e.ApproveType)
                .HasMaxLength(50)
                .HasColumnName("APPROVE_TYPE");
            entity.Property(e => e.CodeExtendedBy).HasMaxLength(50);
            entity.Property(e => e.CodeExtendedOn).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.EMicroRefReqNo)
                .HasMaxLength(10)
                .HasColumnName("eMicroRefReqNo");
            entity.Property(e => e.ExistingSapNo)
                .HasMaxLength(100)
                .HasColumnName("existing_sapNo");
            entity.Property(e => e.ExtendedStorageLocation1)
                .HasMaxLength(50)
                .HasColumnName("EXTENDED_STORAGE_LOCATION_1");
            entity.Property(e => e.ExtendedToPlant1)
                .HasMaxLength(4)
                .HasColumnName("EXTENDED_TO_PLANT_1");
            entity.Property(e => e.FromStorageLocation)
                .HasMaxLength(50)
                .HasColumnName("FROM_STORAGE_LOCATION");
            entity.Property(e => e.HsnCode)
                .HasMaxLength(50)
                .HasColumnName("HSN_CODE");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LastApprover)
                .HasMaxLength(100)
                .HasColumnName("last_approver");
            entity.Property(e => e.MaterialCode1)
                .HasMaxLength(100)
                .HasColumnName("MATERIAL_CODE_1");
            entity.Property(e => e.MaterialCode2)
                .HasMaxLength(100)
                .HasColumnName("MATERIAL_CODE_2");
            entity.Property(e => e.MaterialShortName)
                .HasMaxLength(100)
                .HasColumnName("MATERIAL_SHORT_NAME");
            entity.Property(e => e.MaterialTypeId)
                .HasMaxLength(5)
                .HasColumnName("MATERIAL_TYPE_ID");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DATE");
            entity.Property(e => e.PendingApprover)
                .HasMaxLength(500)
                .HasColumnName("pending_approver");
            entity.Property(e => e.Plant1)
                .HasMaxLength(4)
                .HasColumnName("PLANT_1");
            entity.Property(e => e.Plant2)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("PLANT_2");
            entity.Property(e => e.RejectedFlag)
                .HasMaxLength(50)
                .HasColumnName("rejected_flag");
            entity.Property(e => e.RequestDate)
                .HasColumnType("datetime")
                .HasColumnName("REQUEST_DATE");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(10)
                .HasColumnName("REQUEST_NO");
            entity.Property(e => e.SapcreaterFlag)
                .HasMaxLength(50)
                .HasColumnName("SAPCreater_Flag");
            entity.Property(e => e.StorageLocationId1)
                .HasMaxLength(50)
                .HasColumnName("STORAGE_LOCATION_ID_1");
            entity.Property(e => e.ToStorageLocation)
                .HasMaxLength(50)
                .HasColumnName("TO_STORAGE_LOCATION");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("TYPE");
        });

        modelBuilder.Entity<ProdLockoutMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_Lockout_Master");

            entity.Property(e => e.EmployeeId).HasMaxLength(50);
            entity.Property(e => e.LockoutDate)
                .HasColumnType("datetime")
                .HasColumnName("Lockout_Date");
            entity.Property(e => e.LockoutFlag).HasColumnName("Lockout_Flag");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProdMaterial>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_Material");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(40);
            entity.Property(e => e.FkMaterialType).HasColumnName("fkMaterialType");
            entity.Property(e => e.MaterialCode).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProdMaterialMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_Material_Master");

            entity.Property(e => e.DomesticOrExports).HasMaxLength(50);
            entity.Property(e => e.HsnCode)
                .HasMaxLength(100)
                .HasColumnName("HSN_Code");
            entity.Property(e => e.Market).HasMaxLength(50);
            entity.Property(e => e.MaterialGroup)
                .HasMaxLength(150)
                .HasColumnName("Material_Group");
            entity.Property(e => e.MaterialGroupId)
                .HasMaxLength(100)
                .HasColumnName("Material_group_Id");
            entity.Property(e => e.MaterialLongName)
                .HasMaxLength(250)
                .HasColumnName("Material_Long_Name");
            entity.Property(e => e.MaterialShortName)
                .HasMaxLength(250)
                .HasColumnName("Material_Short_Name");
            entity.Property(e => e.MaterialType)
                .HasMaxLength(10)
                .HasColumnName("Material_Type");
            entity.Property(e => e.MaterialTypeId).HasColumnName("Material_Type_Id");
            entity.Property(e => e.PgGroup)
                .HasMaxLength(100)
                .HasColumnName("PG_Group");
            entity.Property(e => e.PlantCode)
                .HasMaxLength(100)
                .HasColumnName("Plant_Code");
            entity.Property(e => e.SapCodeExists)
                .HasMaxLength(5)
                .HasColumnName("SAP_CODE_EXISTS");
            entity.Property(e => e.SapCodeNo)
                .HasMaxLength(50)
                .HasColumnName("SAP_CODE_NO");
            entity.Property(e => e.StorageLocation)
                .HasMaxLength(100)
                .HasColumnName("Storage_Location");
            entity.Property(e => e.Uom)
                .HasMaxLength(100)
                .HasColumnName("UOM");
        });

        modelBuilder.Entity<ProdPlantMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_Plant_Master");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Locid).HasColumnName("LOCID");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(500);
        });

        modelBuilder.Entity<ProdProfileFormMaintenance>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_Profile_Form_Maintenance");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FkFormId).HasColumnName("FK_FormId");
            entity.Property(e => e.FkProfileId).HasColumnName("FK_ProfileId");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProdProfileMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_Profile_Master");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProdRoleMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_Role_Master");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.RoleId).HasColumnName("Role_Id");
            entity.Property(e => e.RoleLtxt)
                .HasMaxLength(80)
                .HasColumnName("Role_ltxt");
            entity.Property(e => e.RoleStxt)
                .HasMaxLength(50)
                .HasColumnName("Role_Stxt");
        });

        modelBuilder.Entity<ProdServiceMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_SERVICE_MASTER");

            entity.Property(e => e.AppSatus)
                .HasMaxLength(500)
                .HasColumnName("app_satus");
            entity.Property(e => e.AppValue)
                .HasMaxLength(500)
                .HasColumnName("app_value");
            entity.Property(e => e.ApproveDate)
                .HasColumnType("datetime")
                .HasColumnName("approve_date");
            entity.Property(e => e.Attachment)
                .HasMaxLength(500)
                .HasColumnName("attachment");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.DetailedDesc)
                .HasMaxLength(500)
                .HasColumnName("detailed_desc");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Justification).HasColumnName("justification");
            entity.Property(e => e.LastApprover)
                .HasMaxLength(100)
                .HasColumnName("last_approver");
            entity.Property(e => e.MachineName)
                .HasMaxLength(500)
                .HasColumnName("machine_name");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DATE");
            entity.Property(e => e.PendingApprover)
                .HasMaxLength(100)
                .HasColumnName("pending_approver");
            entity.Property(e => e.PlantCode)
                .HasMaxLength(5)
                .HasColumnName("plant_code");
            entity.Property(e => e.PurchaseGroup)
                .HasMaxLength(500)
                .HasColumnName("purchase_group");
            entity.Property(e => e.Purpose)
                .HasMaxLength(500)
                .HasColumnName("purpose");
            entity.Property(e => e.RejectedFlag)
                .HasMaxLength(50)
                .HasColumnName("rejected_flag");
            entity.Property(e => e.RequestDate)
                .HasColumnType("datetime")
                .HasColumnName("request_date");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(20)
                .HasColumnName("request_no");
            entity.Property(e => e.RequestedBy)
                .HasMaxLength(500)
                .HasColumnName("requested_by");
            entity.Property(e => e.SacCode)
                .HasMaxLength(50)
                .HasColumnName("SAC_Code");
            entity.Property(e => e.SapCodeExists)
                .HasMaxLength(50)
                .HasColumnName("SAP_CODE_EXISTS");
            entity.Property(e => e.SapCodeNo)
                .HasMaxLength(100)
                .HasColumnName("SAP_CODE_NO");
            entity.Property(e => e.SapCreatedBy)
                .HasMaxLength(50)
                .HasColumnName("SAP_CREATED_BY");
            entity.Property(e => e.SapCreationDate)
                .HasColumnType("datetime")
                .HasColumnName("SAP_CREATION_DATE");
            entity.Property(e => e.ServiceCatagory)
                .HasMaxLength(500)
                .HasColumnName("service_catagory");
            entity.Property(e => e.ServiceDescription).HasColumnName("service_description");
            entity.Property(e => e.ServiceGroup)
                .HasMaxLength(500)
                .HasColumnName("service_group");
            entity.Property(e => e.StorageLocation)
                .HasMaxLength(500)
                .HasColumnName("storage_location");
            entity.Property(e => e.Uom)
                .HasMaxLength(500)
                .HasColumnName("uom");
            entity.Property(e => e.ValuationClass)
                .HasMaxLength(500)
                .HasColumnName("valuation_class");
            entity.Property(e => e.WhereUsed)
                .HasMaxLength(500)
                .HasColumnName("where_used");
        });

        modelBuilder.Entity<ProdSoftware>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_Softwares");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(50);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(10);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.SoftwareType).HasMaxLength(20);
        });

        modelBuilder.Entity<ProdSoftwaresRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_Softwares_Roles");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.LastModifiedBy).HasMaxLength(50);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(50);
            entity.Property(e => e.Role)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Sid).HasColumnName("SId");
        });

        modelBuilder.Entity<ProdUserGroupsMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_USER_GROUPS_MASTER");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(600)
                .IsUnicode(false);
            entity.Property(e => e.FkSoftwareId).HasColumnName("FK_SoftwareId");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProdUserIdEquipmentDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_UserIdEquipmentDetails");

            entity.Property(e => e.AreaorLocation).HasMaxLength(150);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EquipmentId).HasMaxLength(150);
            entity.Property(e => e.EquipmentName).HasMaxLength(150);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RequestNo).HasMaxLength(20);
            entity.Property(e => e.Sid).HasColumnName("SId");
        });

        modelBuilder.Entity<ProdUserIdMasterDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_UserID_Master_Details");

            entity.Property(e => e.AreaorLocation).HasMaxLength(150);
            entity.Property(e => e.Category).HasMaxLength(100);
            entity.Property(e => e.EmployeeId).HasMaxLength(50);
            entity.Property(e => e.EquipmentId).HasMaxLength(150);
            entity.Property(e => e.EquipmentName).HasMaxLength(100);
            entity.Property(e => e.LastApprover).HasMaxLength(50);
            entity.Property(e => e.PendingApprover).HasMaxLength(50);
            entity.Property(e => e.Salutation)
                .HasMaxLength(50)
                .HasColumnName("salutation");
            entity.Property(e => e.Sid).HasColumnName("SId");
            entity.Property(e => e.SoftwareType).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .HasColumnName("UserID");
        });

        modelBuilder.Entity<ProdUserIdRequest>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_UserIdRequest");

            entity.Property(e => e.AccessDurtion).HasMaxLength(20);
            entity.Property(e => e.AccessOnMobile).HasMaxLength(20);
            entity.Property(e => e.AccessType).HasMaxLength(20);
            entity.Property(e => e.AdId)
                .HasMaxLength(20)
                .HasColumnName("AD_ID");
            entity.Property(e => e.AllottedUserId)
                .HasMaxLength(50)
                .HasColumnName("AllottedUserID");
            entity.Property(e => e.AllowOutsideComm).HasMaxLength(20);
            entity.Property(e => e.ApplicationName).HasMaxLength(50);
            entity.Property(e => e.AssetDetails)
                .HasMaxLength(100)
                .HasColumnName("Asset_details");
            entity.Property(e => e.Catogery).HasMaxLength(50);
            entity.Property(e => e.CommonOrIndividualId).HasMaxLength(50);
            entity.Property(e => e.ComputerizedSystemId).HasMaxLength(100);
            entity.Property(e => e.ComputerizedSystemName).HasMaxLength(150);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DateOfTraining).HasMaxLength(150);
            entity.Property(e => e.DepartmentId).HasMaxLength(100);
            entity.Property(e => e.DiscontinuationId).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(80);
            entity.Property(e => e.EmailBackup).HasMaxLength(20);
            entity.Property(e => e.EmailIdUpdate).HasMaxLength(50);
            entity.Property(e => e.EmpType).HasMaxLength(20);
            entity.Property(e => e.ExistingId).HasMaxLength(50);
            entity.Property(e => e.ExistingUserProfie).HasMaxLength(250);
            entity.Property(e => e.Fileservername).HasMaxLength(120);
            entity.Property(e => e.GeneralRole).HasMaxLength(150);
            entity.Property(e => e.Hostname).HasMaxLength(50);
            entity.Property(e => e.IpAddress)
                .HasMaxLength(20)
                .HasColumnName("IP_Address");
            entity.Property(e => e.IpType)
                .HasMaxLength(20)
                .HasColumnName("Ip_Type");
            entity.Property(e => e.JdAcceptedByUser).HasColumnName("JD_Accepted_By_User");
            entity.Property(e => e.JdApproved).HasColumnName("JD_Approved");
            entity.Property(e => e.JdIntiated).HasColumnName("JD_Intiated");
            entity.Property(e => e.Jddocument).HasColumnName("JDDocument");
            entity.Property(e => e.LastApprover).HasMaxLength(50);
            entity.Property(e => e.LicenseType).HasMaxLength(20);
            entity.Property(e => e.LocationId).HasColumnName("LOCATION_ID");
            entity.Property(e => e.MailandTeamsAccess).HasMaxLength(20);
            entity.Property(e => e.MobileNo).HasMaxLength(20);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.NewRoleInQams).HasColumnName("NewRoleInQAMS");
            entity.Property(e => e.NewRoleUpdated).HasMaxLength(250);
            entity.Property(e => e.NoOfIps)
                .HasMaxLength(20)
                .HasColumnName("NO_of_Ips");
            entity.Property(e => e.OfficeSuite).HasMaxLength(20);
            entity.Property(e => e.OnBehalfEmp).HasMaxLength(20);
            entity.Property(e => e.PendingApprover).HasMaxLength(50);
            entity.Property(e => e.PrefferedEmail).HasMaxLength(50);
            entity.Property(e => e.PresentRoleInQams).HasColumnName("PresentRoleInQAMS");
            entity.Property(e => e.ReasonForReset).HasMaxLength(50);
            entity.Property(e => e.ReasonForUnlock).HasMaxLength(50);
            entity.Property(e => e.ReleivedDate)
                .HasColumnType("datetime")
                .HasColumnName("Releived_Date");
            entity.Property(e => e.ReportingManagerEmail).HasMaxLength(50);
            entity.Property(e => e.RequestDate)
                .HasColumnType("datetime")
                .HasColumnName("REQUEST_DATE");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(10)
                .HasColumnName("Request_No");
            entity.Property(e => e.RequestType)
                .HasMaxLength(50)
                .HasColumnName("Request_Type");
            entity.Property(e => e.RequesterId)
                .HasMaxLength(20)
                .HasColumnName("RequesterID");
            entity.Property(e => e.Requestfor).HasMaxLength(50);
            entity.Property(e => e.RequiredSoftwares).HasMaxLength(80);
            entity.Property(e => e.Salutation)
                .HasMaxLength(5)
                .HasColumnName("salutation");
            entity.Property(e => e.Sid).HasColumnName("SId");
            entity.Property(e => e.SoftwareType).HasMaxLength(20);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TemporaryPassword)
                .HasMaxLength(50)
                .HasColumnName("Temporary_Password");
            entity.Property(e => e.TemporaryPasswordConveyed).HasColumnName("Temporary_Password_Conveyed");
            entity.Property(e => e.UpdatedDesignation).HasMaxLength(150);
            entity.Property(e => e.UpdatedReporting).HasMaxLength(150);
            entity.Property(e => e.UsbFromDate)
                .HasColumnType("datetime")
                .HasColumnName("USB_FromDate");
            entity.Property(e => e.UsbTodate)
                .HasColumnType("datetime")
                .HasColumnName("USB_Todate");
            entity.Property(e => e.UserAddedToRequestedPlants).HasColumnName("User_Added_To_Requested_Plants");
            entity.Property(e => e.UserAddedToSubGroup).HasColumnName("User_Added_To_SubGroup");
            entity.Property(e => e.UserAddedToTheRequestedRepositoryDomain).HasColumnName("User_Added_To_The_Requested_Repository_Domain");
            entity.Property(e => e.UserProfiles).HasMaxLength(250);
            entity.Property(e => e.ValidFrom).HasColumnType("datetime");
            entity.Property(e => e.VendorName).HasMaxLength(50);
        });

        modelBuilder.Entity<ProdUserMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_User_Master");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(50)
                .HasColumnName("Employee_ID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First_Name");
            entity.Property(e => e.FkCompanyId).HasColumnName("FK_Company_Id");
            entity.Property(e => e.FkDepartmentId).HasColumnName("Fk_Department_id");
            entity.Property(e => e.FkDesignationId).HasColumnName("Fk_Designation_Id");
            entity.Property(e => e.FkEmpId).HasColumnName("FK_Emp_Id");
            entity.Property(e => e.FkProfileId).HasColumnName("Fk_Profile_id");
            entity.Property(e => e.FkRoleId).HasColumnName("Fk_Role_id");
            entity.Property(e => e.FkSubroleId).HasColumnName("Fk_Subrole_id");
            entity.Property(e => e.FkUrlId).HasColumnName("Fk_Url_id");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Full_Name");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(200)
                .HasColumnName("Img_Url");
            entity.Property(e => e.LastLoginDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Last_Login_date_time");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last_Name");
            entity.Property(e => e.LastPassword)
                .HasMaxLength(250)
                .HasColumnName("Last_Password");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.PasswordResetToken)
                .HasMaxLength(50)
                .HasColumnName("Password_reset_token");
            entity.Property(e => e.PhoneNumber).HasColumnName("Phone_Number");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TokenExpiryDate)
                .HasColumnType("datetime")
                .HasColumnName("Token_expiry_date");
        });

        modelBuilder.Entity<ProdUserPlantMaintenance>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_User_Plant_Maintenance");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FkEmpId).HasColumnName("FK_Emp_Id");
            entity.Property(e => e.FkPlantId).HasColumnName("FK_PlantId");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProdUserSubgroupsMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_USER_SUBGROUPS_MASTER");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(600)
                .IsUnicode(false);
            entity.Property(e => e.FkSoftwareId).HasColumnName("FK_SoftwareId");
            entity.Property(e => e.FkUserGroupId).HasColumnName("FK_UserGroupId");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProdVendorMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_Vendor_Master");

            entity.Property(e => e.AccountClerkId)
                .HasMaxLength(20)
                .HasColumnName("ACCOUNT_CLERK_ID");
            entity.Property(e => e.AccountGroupId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ACCOUNT_GROUP_ID");
            entity.Property(e => e.Address1).HasColumnName("ADDRESS1");
            entity.Property(e => e.Address2).HasColumnName("ADDRESS2");
            entity.Property(e => e.Address3).HasColumnName("ADDRESS3");
            entity.Property(e => e.Address4).HasColumnName("ADDRESS4");
            entity.Property(e => e.ApproveDate)
                .HasColumnType("datetime")
                .HasColumnName("approve_date");
            entity.Property(e => e.ApproveStatus)
                .HasMaxLength(500)
                .HasColumnName("Approve_Status");
            entity.Property(e => e.Attachments)
                .HasMaxLength(500)
                .HasColumnName("attachments");
            entity.Property(e => e.City)
                .HasMaxLength(40)
                .HasColumnName("CITY");
            entity.Property(e => e.Commissionerate)
                .HasMaxLength(40)
                .HasColumnName("COMMISSIONERATE");
            entity.Property(e => e.CountryId)
                .HasMaxLength(3)
                .HasColumnName("COUNTRY_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.CstNo)
                .HasMaxLength(40)
                .HasColumnName("CST_NO");
            entity.Property(e => e.CurrencyId)
                .HasMaxLength(4)
                .HasColumnName("CURRENCY_ID");
            entity.Property(e => e.EccNo)
                .HasMaxLength(40)
                .HasColumnName("ECC_No");
            entity.Property(e => e.EmailId)
                .HasMaxLength(40)
                .HasColumnName("EMAIL_ID");
            entity.Property(e => e.ExciseDivision)
                .HasMaxLength(40)
                .HasColumnName("Excise_Division");
            entity.Property(e => e.ExciseRange)
                .HasMaxLength(40)
                .HasColumnName("Excise_Range");
            entity.Property(e => e.ExciseRegNo)
                .HasMaxLength(40)
                .HasColumnName("Excise_Reg_No");
            entity.Property(e => e.FaxNo)
                .HasMaxLength(16)
                .HasColumnName("FAX_NO");
            entity.Property(e => e.GstinNumber)
                .HasMaxLength(50)
                .HasColumnName("GSTIN_Number");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsApprovedVendor).HasColumnName("IS_APPROVED_VENDOR");
            entity.Property(e => e.IsEligibleForTds).HasColumnName("IS_ELIGIBLE_FOR_TDS");
            entity.Property(e => e.IsRegdExciseVendor).HasColumnName("IS_REGD_EXCISE_VENDOR");
            entity.Property(e => e.LandlineNo)
                .HasMaxLength(16)
                .HasColumnName("LANDLINE_NO");
            entity.Property(e => e.LastApprover)
                .HasMaxLength(100)
                .HasColumnName("last_approver");
            entity.Property(e => e.LocationId)
                .HasMaxLength(50)
                .HasColumnName("LOCATION_ID");
            entity.Property(e => e.LstNo)
                .HasMaxLength(40)
                .HasColumnName("LST_NO");
            entity.Property(e => e.MobileNo)
                .HasMaxLength(16)
                .HasColumnName("MOBILE_NO");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DATE");
            entity.Property(e => e.Name).HasColumnName("NAME");
            entity.Property(e => e.PanNo)
                .HasMaxLength(40)
                .HasColumnName("PAN_No");
            entity.Property(e => e.PaymentTermId)
                .HasMaxLength(4)
                .HasColumnName("PAYMENT_TERM_ID");
            entity.Property(e => e.PendingApprover)
                .HasMaxLength(100)
                .HasColumnName("pending_approver");
            entity.Property(e => e.Pincode)
                .HasMaxLength(10)
                .HasColumnName("PINCODE");
            entity.Property(e => e.ReconcilationActId)
                .HasMaxLength(6)
                .HasColumnName("RECONCILATION_ACT_ID");
            entity.Property(e => e.RejectedFlag)
                .HasMaxLength(50)
                .HasColumnName("rejected_flag");
            entity.Property(e => e.RequestDate)
                .HasColumnType("datetime")
                .HasColumnName("REQUEST_DATE");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(20)
                .HasColumnName("REQUEST_NO");
            entity.Property(e => e.RequestedBy)
                .HasMaxLength(50)
                .HasColumnName("REQUESTED_BY");
            entity.Property(e => e.SapCodeExists)
                .HasMaxLength(50)
                .HasColumnName("SAP_CODE_EXISTS");
            entity.Property(e => e.SapCodeNo)
                .HasMaxLength(100)
                .HasColumnName("SAP_CODE_NO");
            entity.Property(e => e.SapCreatedBy)
                .HasMaxLength(100)
                .HasColumnName("SAP_CREATED_BY");
            entity.Property(e => e.SapCreationDate)
                .HasColumnType("datetime")
                .HasColumnName("SAP_CREATION_DATE");
            entity.Property(e => e.ServiceTaxRegistrationNo)
                .HasMaxLength(40)
                .HasColumnName("Service_Tax_Registration_No");
            entity.Property(e => e.State)
                .HasMaxLength(10)
                .HasColumnName("STATE");
            entity.Property(e => e.TdsCode)
                .HasMaxLength(40)
                .HasColumnName("TDS_CODE");
            entity.Property(e => e.TinNo)
                .HasMaxLength(40)
                .HasColumnName("TIN_NO");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("TITLE");
            entity.Property(e => e.Type).HasMaxLength(500);
            entity.Property(e => e.TypeOfVendor)
                .HasMaxLength(500)
                .HasColumnName("Type_Of_Vendor");
            entity.Property(e => e.VendorCat).HasMaxLength(50);
            entity.Property(e => e.VendorSubCat).HasMaxLength(50);
            entity.Property(e => e.ViewType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("VIEW_TYPE");
        });

        modelBuilder.Entity<ProdVendorMasterDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_Vendor_Master_Details");

            entity.Property(e => e.Aenam)
                .HasMaxLength(150)
                .HasColumnName("AENAM");
            entity.Property(e => e.Bezei)
                .HasMaxLength(150)
                .HasColumnName("BEZEI");
            entity.Property(e => e.Country)
                .HasMaxLength(150)
                .HasColumnName("COUNTRY");
            entity.Property(e => e.Ernam)
                .HasMaxLength(150)
                .HasColumnName("ERNAM");
            entity.Property(e => e.Ersda)
                .HasMaxLength(150)
                .HasColumnName("ERSDA");
            entity.Property(e => e.HouseNum1)
                .HasMaxLength(150)
                .HasColumnName("HOUSE_NUM1");
            entity.Property(e => e.Ktokk)
                .HasMaxLength(100)
                .HasColumnName("KTOKK");
            entity.Property(e => e.Laeda)
                .HasMaxLength(150)
                .HasColumnName("LAEDA");
            entity.Property(e => e.Landx)
                .HasMaxLength(150)
                .HasColumnName("LANDX");
            entity.Property(e => e.Lifn2)
                .HasMaxLength(150)
                .HasColumnName("LIFN2");
            entity.Property(e => e.Lifnr)
                .HasMaxLength(50)
                .HasColumnName("LIFNR");
            entity.Property(e => e.Location)
                .HasMaxLength(150)
                .HasColumnName("LOCATION");
            entity.Property(e => e.McCity1)
                .HasMaxLength(150)
                .HasColumnName("MC_CITY1");
            entity.Property(e => e.Name1)
                .HasMaxLength(150)
                .HasColumnName("NAME1");
            entity.Property(e => e.Name2)
                .HasMaxLength(150)
                .HasColumnName("NAME2");
            entity.Property(e => e.PostCode1)
                .HasMaxLength(150)
                .HasColumnName("POST_CODE1");
            entity.Property(e => e.Region)
                .HasMaxLength(150)
                .HasColumnName("REGION");
            entity.Property(e => e.Sperq)
                .HasMaxLength(150)
                .HasColumnName("SPERQ");
            entity.Property(e => e.Stcd3)
                .HasMaxLength(150)
                .HasColumnName("STCD3");
            entity.Property(e => e.StrSuppl1)
                .HasMaxLength(150)
                .HasColumnName("STR_SUPPL1");
            entity.Property(e => e.StrSuppl2)
                .HasMaxLength(150)
                .HasColumnName("STR_SUPPL2");
            entity.Property(e => e.StrSuppl3)
                .HasMaxLength(150)
                .HasColumnName("STR_SUPPL3");
            entity.Property(e => e.Street)
                .HasMaxLength(150)
                .HasColumnName("STREET");
        });

        modelBuilder.Entity<ProdVmsApprovalM>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_VMS_Approval_M");

            entity.Property(e => e.ApprovalType).HasMaxLength(50);
            entity.Property(e => e.ApproverId)
                .HasMaxLength(10)
                .HasColumnName("Approver_Id");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Dept)
                .HasMaxLength(10)
                .HasColumnName("dept");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Plant).HasMaxLength(5);
        });

        modelBuilder.Entity<ProdWorkflowApprover>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_WorkflowApprovers");

            entity.Property(e => e.ApproverId)
                .HasMaxLength(100)
                .HasColumnName("Approver_Id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Dept).HasMaxLength(50);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.KeyValue).HasMaxLength(200);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.ParllelApprover1)
                .HasMaxLength(100)
                .HasColumnName("Parllel_Approver_1");
            entity.Property(e => e.ParllelApprover2)
                .HasMaxLength(100)
                .HasColumnName("Parllel_Approver_2");
            entity.Property(e => e.ParllelApprover3)
                .HasMaxLength(100)
                .HasColumnName("Parllel_Approver_3");
            entity.Property(e => e.ParllelApprover4)
                .HasMaxLength(100)
                .HasColumnName("Parllel_Approver_4");
            entity.Property(e => e.ParllelApprover5)
                .HasMaxLength(100)
                .HasColumnName("Parllel_Approver_5");
            entity.Property(e => e.Role).HasMaxLength(100);
        });

        modelBuilder.Entity<ProdWorkflowApprovers1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROD_WorkflowApprovers1");

            entity.Property(e => e.ApproverId)
                .HasMaxLength(100)
                .HasColumnName("Approver_Id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Dept).HasMaxLength(50);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.KeyValue).HasMaxLength(200);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.ParllelApprover1)
                .HasMaxLength(100)
                .HasColumnName("Parllel_Approver_1");
            entity.Property(e => e.ParllelApprover2)
                .HasMaxLength(100)
                .HasColumnName("Parllel_Approver_2");
            entity.Property(e => e.ParllelApprover3)
                .HasMaxLength(100)
                .HasColumnName("Parllel_Approver_3");
            entity.Property(e => e.ParllelApprover4)
                .HasMaxLength(100)
                .HasColumnName("Parllel_Approver_4");
            entity.Property(e => e.ParllelApprover5)
                .HasMaxLength(100)
                .HasColumnName("Parllel_Approver_5");
            entity.Property(e => e.Role).HasMaxLength(100);
        });

        modelBuilder.Entity<ProfileFormMaintenance>(entity =>
        {
            entity.ToTable("Profile_Form_Maintenance");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FkFormId).HasColumnName("FK_FormId");
            entity.Property(e => e.FkProfileId).HasColumnName("FK_ProfileId");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.FkForm).WithMany(p => p.ProfileFormMaintenances)
                .HasForeignKey(d => d.FkFormId)
                .HasConstraintName("FK_Profile_Form_Maintenance_Form_Master");

            entity.HasOne(d => d.FkProfile).WithMany(p => p.ProfileFormMaintenances)
                .HasForeignKey(d => d.FkProfileId)
                .HasConstraintName("FK_Profile_Form_Maintenance_Profile_Master");
        });

        modelBuilder.Entity<ProfileMaster>(entity =>
        {
            entity.ToTable("Profile_Master");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProjMember>(entity =>
        {
            entity.HasKey(e => e.ProjMemberId).HasName("PK_IT.ProjMember");

            entity.ToTable("ProjMember", "IT");

            entity.Property(e => e.ProjMemberId).HasColumnName("ProjMemberID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.EndDt).HasColumnType("datetime");
            entity.Property(e => e.IsAccountable).HasColumnName("isAccountable");
            entity.Property(e => e.IsConsulted).HasColumnName("isConsulted");
            entity.Property(e => e.IsInformed).HasColumnName("isInformed");
            entity.Property(e => e.IsResponsible).HasColumnName("isResponsible");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProjectMgmtId).HasColumnName("ProjectMgmtID");
            entity.Property(e => e.StartDt).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProjMilestone>(entity =>
        {
            entity.HasKey(e => e.ProjMilestoneId).HasName("PK_IT.ProjMilestone");

            entity.ToTable("ProjMilestone", "IT");

            entity.Property(e => e.ProjMilestoneId).HasColumnName("ProjMilestoneID");
            entity.Property(e => e.ActualEndDt).HasColumnType("datetime");
            entity.Property(e => e.ActualStartDt).HasColumnType("datetime");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.EndDt).HasColumnType("datetime");
            entity.Property(e => e.MilestoneDesc).HasMaxLength(2000);
            entity.Property(e => e.MilestoneTitle).HasMaxLength(500);
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProjectMgmtId).HasColumnName("ProjectMgmtID");
            entity.Property(e => e.StartDt).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProjTask>(entity =>
        {
            entity.HasKey(e => e.ProjTaskId).HasName("PK_IT.ProjTask");

            entity.ToTable("ProjTask", "IT");

            entity.Property(e => e.ProjTaskId).HasColumnName("ProjTaskID");
            entity.Property(e => e.ActualEndDt).HasColumnType("datetime");
            entity.Property(e => e.ActualStartDt).HasColumnType("datetime");
            entity.Property(e => e.Attachment).HasMaxLength(500);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.EndDt).HasColumnType("datetime");
            entity.Property(e => e.MainProjTaskId).HasColumnName("MainProjTaskID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProjMilestoneId).HasColumnName("ProjMilestoneID");
            entity.Property(e => e.ProjectMgmtId).HasColumnName("ProjectMgmtID");
            entity.Property(e => e.StartDt).HasColumnType("datetime");
            entity.Property(e => e.TaskDesc).HasMaxLength(2000);
            entity.Property(e => e.TaskTitle).HasMaxLength(500);
        });

        modelBuilder.Entity<ProjectCategory>(entity =>
        {
            entity.ToTable("Project_Category");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.ProjectCategory1)
                .HasMaxLength(500)
                .HasColumnName("Project_category");
        });

        modelBuilder.Entity<ProjectCode>(entity =>
        {
            entity.ToTable("Project_Code");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DeptId).HasDefaultValue(0);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.ProjectCode1)
                .HasMaxLength(200)
                .HasColumnName("Project_Code");
        });

        modelBuilder.Entity<ProjectMaster>(entity =>
        {
            entity.ToTable("Project_Master");

            entity.Property(e => e.Code)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(600)
                .IsUnicode(false);
            entity.Property(e => e.FkParentId).HasColumnName("FK_ParentId");
            entity.Property(e => e.FkProjectManager).HasColumnName("FK_Project_Manager");
            entity.Property(e => e.FkTeamLead).HasColumnName("FK_Team_Lead");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProjectMgmt>(entity =>
        {
            entity.HasKey(e => e.ProjectMgmtId).HasName("PK_IT.ProjectMgmt");

            entity.ToTable("ProjectMgmt", "IT");

            entity.Property(e => e.ProjectMgmtId).HasColumnName("ProjectMgmtID");
            entity.Property(e => e.ActualEndDt).HasColumnType("datetime");
            entity.Property(e => e.ActualStartDt).HasColumnType("datetime");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.EndDt).HasColumnType("datetime");
            entity.Property(e => e.IsStrict).HasColumnName("isStrict");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ProjectDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ProjectName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.StartDt).HasColumnType("datetime");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<ProposedAction>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Action).IsUnicode(false);
            entity.Property(e => e.Attachments).IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DepartmentResponsible).IsUnicode(false);
            entity.Property(e => e.EmactivityId).HasColumnName("EMActivityId");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Remarks).IsUnicode(false);
            entity.Property(e => e.StageStatus)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Tcd)
                .HasColumnType("datetime")
                .HasColumnName("TCD");
        });

        modelBuilder.Entity<PurchaseGroup>(entity =>
        {
            entity.ToTable("PURCHASE_GROUP");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.PurchaseGroupDesc)
                .HasMaxLength(100)
                .HasColumnName("PURCHASE_GROUP_DESC");
            entity.Property(e => e.PurchaseGroupId)
                .HasMaxLength(10)
                .HasColumnName("PURCHASE_GROUP_ID");
        });

        modelBuilder.Entity<PurposeTravel>(entity =>
        {
            entity.ToTable("Purpose_Travel");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Purpose).HasMaxLength(50);
        });

        modelBuilder.Entity<RaGrade>(entity =>
        {
            entity.ToTable("RA_Grade");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(500);
        });

        modelBuilder.Entity<RaRequest>(entity =>
        {
            entity.ToTable("RA_Request");

            entity.Property(e => e.AdditionalDoc).HasMaxLength(250);
            entity.Property(e => e.ApiManufacturer)
                .HasMaxLength(250)
                .HasColumnName("API_Manufacturer");
            entity.Property(e => e.ApiName)
                .HasMaxLength(100)
                .HasColumnName("API_Name");
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DmfQueryDoc).HasColumnName("DMF_Query_Doc");
            entity.Property(e => e.DmfVersion)
                .HasMaxLength(100)
                .HasColumnName("DMF_Version");
            entity.Property(e => e.DocumentRequired).HasMaxLength(250);
            entity.Property(e => e.DocumentShared)
                .HasMaxLength(100)
                .HasColumnName("Document_Shared");
            entity.Property(e => e.Grade).HasMaxLength(100);
            entity.Property(e => e.LastApprover).HasMaxLength(50);
            entity.Property(e => e.ManufacturingSite).HasMaxLength(250);
            entity.Property(e => e.ModifiedBy).HasMaxLength(100);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.PendingWith).HasMaxLength(50);
            entity.Property(e => e.Product).HasMaxLength(100);
            entity.Property(e => e.Purpose).HasMaxLength(100);
            entity.Property(e => e.RequestDate).HasColumnType("datetime");
            entity.Property(e => e.RequestNo).HasMaxLength(50);
            entity.Property(e => e.RequestedBy).HasMaxLength(50);
            entity.Property(e => e.RequiredBy).HasColumnType("datetime");
            entity.Property(e => e.SharedBy).HasMaxLength(50);
            entity.Property(e => e.SharedOn).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(100);
        });

        modelBuilder.Entity<RatingMaster>(entity =>
        {
            entity.ToTable("Rating_Master");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Definition).IsUnicode(false);
            entity.Property(e => e.FkCalendarId).HasColumnName("FK_Calendar_Id");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Scale).IsUnicode(false);

            entity.HasOne(d => d.FkCalendar).WithMany(p => p.RatingMasters)
                .HasForeignKey(d => d.FkCalendarId)
                .HasConstraintName("FK_Rating_Master_Calendar_Master");
        });

        modelBuilder.Entity<ReconciliationAccountM>(entity =>
        {
            entity.ToTable("RECONCILIATION_ACCOUNT_M");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(50);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.MasterTypeId).HasColumnName("MASTER_TYPE_ID");
            entity.Property(e => e.ReconciliationAccountId)
                .HasMaxLength(6)
                .HasColumnName("RECONCILIATION_ACCOUNT_ID");
            entity.Property(e => e.ReconciliationAccountName)
                .HasMaxLength(50)
                .HasColumnName("RECONCILIATION_ACCOUNT_NAME");
        });

        modelBuilder.Entity<Reference>(entity =>
        {
            entity.HasKey(e => e.ReferenceId).HasName("PK_IT.Reference");

            entity.ToTable("Reference", "IT");

            entity.Property(e => e.ReferenceId).HasColumnName("ReferenceID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ReferenceName).HasMaxLength(50);
        });

        modelBuilder.Entity<ReferenceTyp>(entity =>
        {
            entity.HasKey(e => e.ReferenceTypeId).HasName("PK_IT.ReferenceTyp");

            entity.ToTable("ReferenceTyp", "IT");

            entity.Property(e => e.ReferenceTypeId).HasColumnName("ReferenceTypeID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ReferenceType).HasMaxLength(50);
        });

        modelBuilder.Entity<RegularizationRequest>(entity =>
        {
            entity.ToTable("Regularization_Request");

            entity.Property(e => e.ApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.Comments).HasMaxLength(50);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.LastApprover).HasMaxLength(50);
            entity.Property(e => e.PendingApprover).HasMaxLength(50);
            entity.Property(e => e.ReasonType).HasMaxLength(50);
            entity.Property(e => e.RejectedDate).HasColumnType("datetime");
            entity.Property(e => e.RequestDate).HasColumnType("datetime");
            entity.Property(e => e.RequestedBy).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.SwipeType).HasMaxLength(10);
            entity.Property(e => e.Time).HasMaxLength(20);
            entity.Property(e => e.UserId).HasMaxLength(50);
        });

        modelBuilder.Entity<RelationshipM>(entity =>
        {
            entity.ToTable("Relationship_M");

            entity.HasIndex(e => e.Relationship, "UQ_Relationship_M").IsUnique();

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Gender).HasMaxLength(20);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Relationship).HasMaxLength(100);
        });

        modelBuilder.Entity<ReligionM>(entity =>
        {
            entity.ToTable("Religion_M");

            entity.HasIndex(e => e.Religion, "UQ_Religion_M").IsUnique();

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Religion).HasMaxLength(100);
        });

        modelBuilder.Entity<ReportDailyWise>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Report_Daily_wise");

            entity.Property(e => e.AttendanceLockFlag).HasColumnName("AttendanceLock_Flag");
            entity.Property(e => e.CompOff).HasMaxLength(10);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Created_date");
            entity.Property(e => e.Early).HasMaxLength(10);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.InTime).HasColumnName("In_time");
            entity.Property(e => e.Late).HasMaxLength(10);
            entity.Property(e => e.Location).HasMaxLength(50);
            entity.Property(e => e.Ot)
                .HasMaxLength(10)
                .HasColumnName("OT");
            entity.Property(e => e.OutTime).HasColumnName("Out_time");
            entity.Property(e => e.Pernr).HasMaxLength(50);
            entity.Property(e => e.Shift).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Total).HasMaxLength(10);
        });

        modelBuilder.Entity<ReportingGroupM>(entity =>
        {
            entity.ToTable("Reporting_Group_M");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.ReportingGroupLt)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ReportingGroupLT");
            entity.Property(e => e.ReportingGroupSt)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ReportingGroupST");
        });

        modelBuilder.Entity<RepositoryDomain>(entity =>
        {
            entity.ToTable("REPOSITORY_DOMAINS");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(600)
                .IsUnicode(false);
            entity.Property(e => e.FkSoftwareId).HasColumnName("Fk_SoftwareId");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.HasOne(d => d.FkSoftware).WithMany(p => p.RepositoryDomains)
                .HasForeignKey(d => d.FkSoftwareId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_REPOSITORY_DOMAINS_Softwares");
        });

        modelBuilder.Entity<RequiredUserRole>(entity =>
        {
            entity.Property(e => e.RoleId).HasColumnName("Role_Id");
            entity.Property(e => e.Uid).HasColumnName("UId");

            entity.HasOne(d => d.Role).WithMany(p => p.RequiredUserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RequiredUserRoles_Softwares_Roles");

            entity.HasOne(d => d.UidNavigation).WithMany(p => p.RequiredUserRoles)
                .HasForeignKey(d => d.Uid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RequiredUserRoles_UserIdRequest");
        });

        modelBuilder.Entity<RiskPlan>(entity =>
        {
            entity.HasKey(e => e.ItriskId);

            entity.ToTable("RiskPlan", "IT");

            entity.Property(e => e.ItriskId).HasColumnName("ITRiskID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CommunicationDays)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.CommunicationPlan).HasMaxLength(2000);
            entity.Property(e => e.CommunicationPlanAttachment).IsUnicode(false);
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.TestPlan).HasMaxLength(2000);
            entity.Property(e => e.TestPlanAttachment).IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.RiskPlans)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RiskPlan_Category");

            entity.HasOne(d => d.Support).WithMany(p => p.RiskPlans)
                .HasForeignKey(d => d.SupportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RiskPlan_Support");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Role1)
                .HasMaxLength(100)
                .HasColumnName("Role");
            entity.Property(e => e.RoleId).HasColumnName("Role_id");
        });

        modelBuilder.Entity<RoleMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Role_Master_1");

            entity.ToTable("Role_Master");

            entity.HasIndex(e => e.RoleId, "IX_Role_Master").IsUnique();

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.RoleId).HasColumnName("Role_Id");
            entity.Property(e => e.RoleLtxt)
                .HasMaxLength(80)
                .HasColumnName("Role_ltxt");
            entity.Property(e => e.RoleStxt)
                .HasMaxLength(50)
                .HasColumnName("Role_Stxt");
        });

        modelBuilder.Entity<RoomBooking>(entity =>
        {
            entity.ToTable("RoomBooking");

            entity.Property(e => e.AdminApprovalDate).HasColumnType("datetime");
            entity.Property(e => e.AdminComments).IsUnicode(false);
            entity.Property(e => e.AdminEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AdminName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CancelComments).IsUnicode(false);
            entity.Property(e => e.Comments).IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EmpDesignation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmpEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmpName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Fkpurpose).HasColumnName("FKPurpose");
            entity.Property(e => e.FromDate).HasColumnType("datetime");
            entity.Property(e => e.ManagerApprovalDate).HasColumnType("datetime");
            entity.Property(e => e.ManagerComments).IsUnicode(false);
            entity.Property(e => e.ManagerEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ManagerName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ToDate).HasColumnType("datetime");

            entity.HasOne(d => d.FkpurposeNavigation).WithMany(p => p.RoomBookings)
                .HasForeignKey(d => d.Fkpurpose)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKBookPurpose");
        });

        modelBuilder.Entity<RoomFacility>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FkFacilityId).HasColumnName("Fk_FacilityId");
            entity.Property(e => e.FkRoomId).HasColumnName("Fk_RoomId");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.FkFacility).WithMany(p => p.RoomFacilities)
                .HasForeignKey(d => d.FkFacilityId)
                .HasConstraintName("Fk_FacilityId");

            entity.HasOne(d => d.FkRoom).WithMany(p => p.RoomFacilities)
                .HasForeignKey(d => d.FkRoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_RoomId");
        });

        modelBuilder.Entity<RoomFacilityMaster>(entity =>
        {
            entity.ToTable("RoomFacility_Master");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RoomMaster>(entity =>
        {
            entity.ToTable("Room_Master");

            entity.Property(e => e.AdminApproval).HasColumnName("Admin_Approval");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.FkLocation).HasColumnName("Fk_Location");
            entity.Property(e => e.FkType).HasColumnName("Fk_Type");
            entity.Property(e => e.ManagerApproval).HasColumnName("Manager_Approval");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(500);

            entity.HasOne(d => d.FkLocationNavigation).WithMany(p => p.RoomMasters)
                .HasForeignKey(d => d.FkLocation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Location");

            entity.HasOne(d => d.FkTypeNavigation).WithMany(p => p.RoomMasters)
                .HasForeignKey(d => d.FkType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Type");
        });

        modelBuilder.Entity<RoomPicture>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.FileName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FkRoomMasterId).HasColumnName("Fk_RoomMasterID");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Path)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.FkRoomMaster).WithMany(p => p.RoomPictures)
                .HasForeignKey(d => d.FkRoomMasterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_RoomMasterID");
        });

        modelBuilder.Entity<RoomTypeMaster>(entity =>
        {
            entity.ToTable("RoomType_Master");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Type).HasMaxLength(500);
        });

        modelBuilder.Entity<SalaryStructure>(entity =>
        {
            entity.ToTable("Salary_Structure");

            entity.Property(e => e.Client)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.ComponentpartofCtc)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ComponentpartofCTC");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DescriptionInPaySlip)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.EligibleforBonusPayment)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EligibleforEsideduction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EligibleforESIDeduction");
            entity.Property(e => e.EligibleforGratuityCalculation)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EligibleforItdeduction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EligibleforITDeduction");
            entity.Property(e => e.EligibleforItprojectionCalculation)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EligibleforITProjectionCalculation");
            entity.Property(e => e.EligibleforPfdeduction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EligibleforPFDeduction");
            entity.Property(e => e.EligibleforPtdeduction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EligibleforPTDeduction");
            entity.Property(e => e.GroupingSalaryHeadsforItprocessing)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("GroupingSalaryHeadsforITProcessing");
            entity.Property(e => e.InvestmentCode)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Lwpisapplicable)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LWPIsapplicable");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.PerquisiteId).HasColumnName("PerquisiteID");
            entity.Property(e => e.SalaryLt)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("SalaryLT");
            entity.Property(e => e.SalaryPayableFrequency)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SalarySt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SalaryST");
            entity.Property(e => e.SalaryType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ShowSalaryinPaySlip)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<SbuMaster>(entity =>
        {
            entity.ToTable("SBU_Master");

            entity.Property(e => e.Code)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(600)
                .IsUnicode(false);
            entity.Property(e => e.FkParentId).HasColumnName("FK_ParentId");
            entity.Property(e => e.HeadEmpId).HasColumnName("Head_Emp_Id");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ServiceCategory>(entity =>
        {
            entity.ToTable("Service_Category");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.SerCatCode)
                .HasMaxLength(20)
                .HasColumnName("SER_CAT_CODE");
            entity.Property(e => e.SerCatDesc)
                .HasMaxLength(100)
                .HasColumnName("SER_CAT_DESC");
        });

        modelBuilder.Entity<ServiceCitrix>(entity =>
        {
            entity.HasKey(e => e.ServiceCitrixId).HasName("PK_IT_ServiceCitrix");

            entity.ToTable("ServiceCitrix", "IT");

            entity.Property(e => e.ServiceCitrixId).HasColumnName("ServiceCitrixID");
            entity.Property(e => e.ApprovedLevel1On).HasColumnType("datetime");
            entity.Property(e => e.ApprovedLevel2On).HasColumnType("datetime");
            entity.Property(e => e.ApprovedLevel3On).HasColumnType("datetime");
            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.AssignedOn).HasColumnType("datetime");
            entity.Property(e => e.Attachment).HasMaxLength(100);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.ProposedResolutionOn).HasColumnType("datetime");
            entity.Property(e => e.Remarks).HasMaxLength(3000);
            entity.Property(e => e.ResolutionDt).HasColumnType("datetime");
            entity.Property(e => e.ResolutionRemarks).HasMaxLength(3000);
            entity.Property(e => e.Service).HasMaxLength(50);
            entity.Property(e => e.ServiceCode).HasMaxLength(50);
            entity.Property(e => e.ShotDesc).HasMaxLength(200);
            entity.Property(e => e.Source).HasMaxLength(100);
            entity.Property(e => e.Srdate)
                .HasColumnType("datetime")
                .HasColumnName("SRDate");
            entity.Property(e => e.Srdesc)
                .HasMaxLength(2000)
                .HasColumnName("SRDesc");
            entity.Property(e => e.SrraiseFor).HasColumnName("SRRaiseFor");
            entity.Property(e => e.Status).HasMaxLength(10);
        });

        modelBuilder.Entity<ServiceGroup>(entity =>
        {
            entity.HasKey(e => e.GroupId);

            entity.ToTable("SERVICE_GROUP");

            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(50);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Stxt)
                .HasMaxLength(100)
                .HasColumnName("STXT");
        });

        modelBuilder.Entity<ServiceMaster>(entity =>
        {
            entity.ToTable("SERVICE_MASTER");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppSatus)
                .HasMaxLength(500)
                .HasColumnName("app_satus");
            entity.Property(e => e.AppValue)
                .HasMaxLength(500)
                .HasColumnName("app_value");
            entity.Property(e => e.ApproveDate)
                .HasColumnType("datetime")
                .HasColumnName("approve_date");
            entity.Property(e => e.Attachment)
                .HasMaxLength(500)
                .HasColumnName("attachment");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.DetailedDesc)
                .HasMaxLength(500)
                .HasColumnName("detailed_desc");
            entity.Property(e => e.Justification).HasColumnName("justification");
            entity.Property(e => e.LastApprover)
                .HasMaxLength(100)
                .HasColumnName("last_approver");
            entity.Property(e => e.MachineName)
                .HasMaxLength(500)
                .HasColumnName("machine_name");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DATE");
            entity.Property(e => e.PendingApprover)
                .HasMaxLength(100)
                .HasColumnName("pending_approver");
            entity.Property(e => e.PlantCode)
                .HasMaxLength(5)
                .HasColumnName("plant_code");
            entity.Property(e => e.PurchaseGroup)
                .HasMaxLength(500)
                .HasColumnName("purchase_group");
            entity.Property(e => e.Purpose)
                .HasMaxLength(500)
                .HasColumnName("purpose");
            entity.Property(e => e.RejectedFlag)
                .HasMaxLength(50)
                .HasColumnName("rejected_flag");
            entity.Property(e => e.RequestDate)
                .HasColumnType("datetime")
                .HasColumnName("request_date");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(20)
                .HasColumnName("request_no");
            entity.Property(e => e.RequestedBy)
                .HasMaxLength(500)
                .HasColumnName("requested_by");
            entity.Property(e => e.SacCode)
                .HasMaxLength(50)
                .HasColumnName("SAC_Code");
            entity.Property(e => e.SapCodeExists)
                .HasMaxLength(50)
                .HasColumnName("SAP_CODE_EXISTS");
            entity.Property(e => e.SapCodeNo)
                .HasMaxLength(100)
                .HasColumnName("SAP_CODE_NO");
            entity.Property(e => e.SapCreatedBy)
                .HasMaxLength(50)
                .HasColumnName("SAP_CREATED_BY");
            entity.Property(e => e.SapCreationDate)
                .HasColumnType("datetime")
                .HasColumnName("SAP_CREATION_DATE");
            entity.Property(e => e.ServiceCatagory)
                .HasMaxLength(500)
                .HasColumnName("service_catagory");
            entity.Property(e => e.ServiceDescription).HasColumnName("service_description");
            entity.Property(e => e.ServiceGroup)
                .HasMaxLength(500)
                .HasColumnName("service_group");
            entity.Property(e => e.StorageLocation)
                .HasMaxLength(500)
                .HasColumnName("storage_location");
            entity.Property(e => e.Uom)
                .HasMaxLength(500)
                .HasColumnName("uom");
            entity.Property(e => e.ValuationClass)
                .HasMaxLength(500)
                .HasColumnName("valuation_class");
            entity.Property(e => e.WhereUsed)
                .HasMaxLength(500)
                .HasColumnName("where_used");
        });

        modelBuilder.Entity<ServiceMasterChange>(entity =>
        {
            entity.Property(e => e.LastApprover).HasMaxLength(200);
            entity.Property(e => e.ModifiedBy).HasMaxLength(200);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.PendingApprover).HasMaxLength(200);
            entity.Property(e => e.PlantCode).HasMaxLength(10);
            entity.Property(e => e.PurchaseGroup).HasMaxLength(200);
            entity.Property(e => e.RequestedBy).HasMaxLength(200);
            entity.Property(e => e.RequestedDate).HasColumnType("datetime");
            entity.Property(e => e.SacCode)
                .HasMaxLength(50)
                .HasColumnName("SAC_Code");
            entity.Property(e => e.ServiceCategory).HasMaxLength(200);
            entity.Property(e => e.ServiceCode).HasMaxLength(50);
            entity.Property(e => e.ServiceGroup).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Uom)
                .HasMaxLength(100)
                .HasColumnName("UOM");
            entity.Property(e => e.ValuationClass).HasMaxLength(200);
        });

        modelBuilder.Entity<Signatory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Signatory", "HR");

            entity.Property(e => e.ImageUrl).HasMaxLength(200);
            entity.Property(e => e.SignatoryId).ValueGeneratedOnAdd();
            entity.Property(e => e.SignatoryType).HasMaxLength(50);

            entity.HasOne(d => d.Employee).WithMany()
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Signatory_Employee_Master");
        });

        modelBuilder.Entity<Sla>(entity =>
        {
            entity.HasKey(e => e.Itslaid);

            entity.ToTable("SLA", "IT");

            entity.Property(e => e.Itslaid).HasColumnName("ITSLAID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.ClassificationId).HasColumnName("ClassificationID");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.WaitTimeUnit)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WaitTimeUnitEscal1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WaitTimeUnitEscal2)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Slas)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SLA_Category");

            entity.HasOne(d => d.Classification).WithMany(p => p.Slas)
                .HasForeignKey(d => d.ClassificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SLA_ITClassification");

            entity.HasOne(d => d.Plant).WithMany(p => p.Slas)
                .HasForeignKey(d => d.PlantId)
                .HasConstraintName("FK_SLA_Plant_Master");

            entity.HasOne(d => d.Support).WithMany(p => p.Slas)
                .HasForeignKey(d => d.SupportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SLA_Support");
        });

        modelBuilder.Entity<SoftSkillMaster>(entity =>
        {
            entity.ToTable("SoftSkill_Master");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.FkAssesmentId).HasColumnName("FK_Assesment_Id");
            entity.Property(e => e.FkCalendarId).HasColumnName("FK_CalendarId");
            entity.Property(e => e.FkRoleId).HasColumnName("FK_Role_Id");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Skills).IsUnicode(false);

            entity.HasOne(d => d.FkAssesment).WithMany(p => p.SoftSkillMasters)
                .HasForeignKey(d => d.FkAssesmentId)
                .HasConstraintName("FK_SoftSkill_Master_Assesment_Master");

            entity.HasOne(d => d.FkCalendar).WithMany(p => p.SoftSkillMasters)
                .HasForeignKey(d => d.FkCalendarId)
                .HasConstraintName("FK_SoftSkill_Master_Calendar_Master");

            entity.HasOne(d => d.FkRole).WithMany(p => p.SoftSkillMasters)
                .HasForeignKey(d => d.FkRoleId)
                .HasConstraintName("FK_SoftSkill_Master_Profile_Master");
        });

        modelBuilder.Entity<Software>(entity =>
        {
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(50);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(10);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.SoftwareType).HasMaxLength(20);
        });

        modelBuilder.Entity<SoftwareCategoryMaster>(entity =>
        {
            entity.ToTable("SoftwareCategoryMaster");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.SoftwareCategory)
                .HasMaxLength(50)
                .HasColumnName("Software_Category");
        });

        modelBuilder.Entity<SoftwareModule>(entity =>
        {
            entity.ToTable("SOFTWARE_MODULES");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(600)
                .IsUnicode(false);
            entity.Property(e => e.FkSoftwareId).HasColumnName("Fk_SoftwareId");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.HasOne(d => d.FkSoftware).WithMany(p => p.SoftwareModules)
                .HasForeignKey(d => d.FkSoftwareId)
                .HasConstraintName("FK_SOFTWARE_MODULES_Softwares");
        });

        modelBuilder.Entity<SoftwareUserProfile>(entity =>
        {
            entity.ToTable("SOFTWARE_USER_PROFILES");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(600)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SoftwaresRole>(entity =>
        {
            entity.ToTable("Softwares_Roles");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.LastModifiedBy).HasMaxLength(50);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(5);
            entity.Property(e => e.Role).HasMaxLength(250);
            entity.Property(e => e.Sid).HasColumnName("SId");

            entity.HasOne(d => d.SidNavigation).WithMany(p => p.SoftwaresRoles)
                .HasForeignKey(d => d.Sid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Softwares_Roles_Softwares");
        });

        modelBuilder.Entity<Stage10Emreview>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Stage10EMReviews");

            entity.Property(e => e.ApprovalComments).IsUnicode(false);
            entity.Property(e => e.Attachments).IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.QaemployeeId)
                .IsUnicode(false)
                .HasColumnName("QAEmployeeID");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ReturnComments).IsUnicode(false);
            entity.Property(e => e.StageStatus)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Stage11Closure>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Attachments).IsUnicode(false);
            entity.Property(e => e.ClosureComments).IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceRecordDetails).IsUnicode(false);
            entity.Property(e => e.ReturnComments).IsUnicode(false);
            entity.Property(e => e.SpocemployeeId)
                .IsUnicode(false)
                .HasColumnName("SPOCEmployeeID");
            entity.Property(e => e.StageStatus)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Stage12ClosureVerification>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Attachments).IsUnicode(false);
            entity.Property(e => e.ClosureVerificationComments).IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.QaemployeeId)
                .IsUnicode(false)
                .HasColumnName("QAEmployeeID");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ReturnComments).IsUnicode(false);
            entity.Property(e => e.StageStatus)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Stage1DiscrepancyRequest>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Attachments).IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.CreatorEmailId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CreatorEmailID");
            entity.Property(e => e.CreatorName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Discrepancy).IsUnicode(false);
            entity.Property(e => e.EquipmentId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EquipmentID");
            entity.Property(e => e.EquipmentName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.OtherDetails).IsUnicode(false);
            entity.Property(e => e.PendingWith)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PendingWithEmailId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PendingWithEmailID");
            entity.Property(e => e.PendingWithName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ReportedPlant)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ReportedUsername)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RequestStatus)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RequestType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RequirementDetails)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SiteQaapprovalDate)
                .HasColumnType("datetime")
                .HasColumnName("SiteQAApprovalDate");
            entity.Property(e => e.SiteQaapprovalStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SiteQAApprovalStatus");
            entity.Property(e => e.SiteQaapproverComments)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SiteQAApproverComments");
            entity.Property(e => e.SiteQaapproverEmployeeId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SiteQAApproverEmployeeID");
            entity.Property(e => e.SiteQaattachments)
                .IsUnicode(false)
                .HasColumnName("SiteQAAttachments");
            entity.Property(e => e.SiteQareturnComments)
                .IsUnicode(false)
                .HasColumnName("SiteQAReturnComments");
            entity.Property(e => e.SoftwareName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SoftwareVersion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.StageStatus)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Stage2Spocassessment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Stage2SPOCAssessments");

            entity.Property(e => e.ActionTaken).IsUnicode(false);
            entity.Property(e => e.Attachments).IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Impact).IsUnicode(false);
            entity.Property(e => e.IsRepeatIssue)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IssueIntimatedToOtherSites)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.PreviousActionsSummary).IsUnicode(false);
            entity.Property(e => e.PreviousReferenceNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ReturnComments).IsUnicode(false);
            entity.Property(e => e.SiteCodes).IsUnicode(false);
            entity.Property(e => e.SpocapprovalDate)
                .HasColumnType("datetime")
                .HasColumnName("SPOCApprovalDate");
            entity.Property(e => e.SpocemployeeId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SPOCEmployeeID");
            entity.Property(e => e.StageStatus)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.VerificationofEvs)
                .IsUnicode(false)
                .HasColumnName("VerificationofEVS");
        });

        modelBuilder.Entity<Stage3VendorAssessment>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AssessmentBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Attachments).IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SpocemployeeId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SPOCEmployeeID");
            entity.Property(e => e.StageStatus)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.VendorAssessmentDate).HasColumnType("datetime");
            entity.Property(e => e.VendorAssessmentDetails).IsUnicode(false);
            entity.Property(e => e.VendorEmployeeId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("VendorEmployeeID");
            entity.Property(e => e.VendorReferenceNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Stage4ImpactAssessment>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Attachments).IsUnicode(false);
            entity.Property(e => e.ChangeControlReferenceNumber).IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DeviationReferenceNumber).IsUnicode(false);
            entity.Property(e => e.DiscrepancyCategory).IsUnicode(false);
            entity.Property(e => e.Environments).IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ImpactAssessment).IsUnicode(false);
            entity.Property(e => e.IsChangeControlRequired).IsUnicode(false);
            entity.Property(e => e.IsFurtherValidationRequired).IsUnicode(false);
            entity.Property(e => e.IssueImpactOn).IsUnicode(false);
            entity.Property(e => e.Justification).IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.OtherIssueDetails).IsUnicode(false);
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ReturnComments).IsUnicode(false);
            entity.Property(e => e.RootCauseDetails).IsUnicode(false);
            entity.Property(e => e.SpocemployeeId)
                .IsUnicode(false)
                .HasColumnName("SPOCEmployeeID");
            entity.Property(e => e.StageStatus)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Stage5Qaapproval>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Stage5QAApprovals");

            entity.Property(e => e.Attachments).IsUnicode(false);
            entity.Property(e => e.Comments).IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.QaemployeeId)
                .IsUnicode(false)
                .HasColumnName("QAEmployeeID");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ReturnComments).IsUnicode(false);
            entity.Property(e => e.StageStatus)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Stage6Implementation>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Attachments).IsUnicode(false);
            entity.Property(e => e.Comments).IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ReturnComments).IsUnicode(false);
            entity.Property(e => e.SpocemployeeId)
                .IsUnicode(false)
                .HasColumnName("SPOCEmployeeID");
            entity.Property(e => e.StageStatus)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Stage7Emproposal>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Stage7EMProposals");

            entity.Property(e => e.Attachments).IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Justification).IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.ProposalRequired).IsUnicode(false);
            entity.Property(e => e.QaemployeeId)
                .IsUnicode(false)
                .HasColumnName("QAEmployeeID");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ReturnComments).IsUnicode(false);
            entity.Property(e => e.StageStatus)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.VerificationComments).IsUnicode(false);
        });

        modelBuilder.Entity<Stage8QaheadApproval>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Stage8QAHeadApprovals");

            entity.Property(e => e.ApprovalComments).IsUnicode(false);
            entity.Property(e => e.Attachments).IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.QaheadEmployeeId)
                .IsUnicode(false)
                .HasColumnName("QAHeadEmployeeID");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ReturnComments).IsUnicode(false);
            entity.Property(e => e.StageStatus)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Stage9EffectivenessMonitoring>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Stage9EffectivenessMonitoring");

            entity.Property(e => e.Attachments).IsUnicode(false);
            entity.Property(e => e.Comments).IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ReturnComments).IsUnicode(false);
            entity.Property(e => e.SpocemployeeId)
                .IsUnicode(false)
                .HasColumnName("SPOCEmployeeID");
            entity.Property(e => e.StageStatus)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.ToTable("State");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Bezei)
                .HasMaxLength(50)
                .HasColumnName("BEZEI");
            entity.Property(e => e.Bland)
                .HasMaxLength(10)
                .HasColumnName("BLAND");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Land1)
                .HasMaxLength(5)
                .HasColumnName("LAND1");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(50);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<StateMaster>(entity =>
        {
            entity.ToTable("State_Master");

            entity.Property(e => e.Code)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StorageCondition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_STORAGE_CONDITION_1");

            entity.ToTable("STORAGE_CONDITION");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Ltxt)
                .HasMaxLength(500)
                .HasColumnName("LTXT");
            entity.Property(e => e.StoCondCode)
                .HasMaxLength(10)
                .HasColumnName("STO_COND_CODE");
            entity.Property(e => e.Stxt)
                .HasMaxLength(500)
                .HasColumnName("STXT");
        });

        modelBuilder.Entity<StorageLocation>(entity =>
        {
            entity.ToTable("STORAGE_LOCATION");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.MatType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MAT_TYPE");
            entity.Property(e => e.StorageLocationId)
                .HasMaxLength(4)
                .HasColumnName("STORAGE_LOCATION_ID");
            entity.Property(e => e.StorageLocationName)
                .HasMaxLength(500)
                .HasColumnName("STORAGE_LOCATION_NAME");
        });

        modelBuilder.Entity<Strength>(entity =>
        {
            entity.ToTable("STRENGTH");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.StrengthCode)
                .HasMaxLength(50)
                .HasColumnName("STRENGTH_CODE");
            entity.Property(e => e.StrengthDesc)
                .HasMaxLength(100)
                .HasColumnName("STRENGTH_DESC");
        });

        modelBuilder.Entity<SubDeptMaster>(entity =>
        {
            entity.ToTable("SubDept_Master");

            entity.Property(e => e.CeatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.SdptidLtxt)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SDPTID_LTXT");
            entity.Property(e => e.SdptidStxt)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SDPTID_STXT");

            entity.HasOne(d => d.Department).WithMany(p => p.SubDeptMasters)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubDept_Master_Department_Master");
        });

        modelBuilder.Entity<SubRole>(entity =>
        {
            entity.ToTable("Sub_Roles");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.FkSuperRoleId).HasColumnName("FK_Super_Role_ID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Role).HasMaxLength(100);
        });

        modelBuilder.Entity<SupplierMaster>(entity =>
        {
            entity.ToTable("Supplier_Master");

            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Place)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PlaceCode)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Support>(entity =>
        {
            entity.ToTable("Support", "IT");

            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Image).IsUnicode(false);
            entity.Property(e => e.ParentId).HasColumnName("ParentID");
            entity.Property(e => e.SupportName)

                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Url)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("URL");
        });

        modelBuilder.Entity<SupportTeam>(entity =>
        {
            entity.ToTable("SupportTeam", "IT");

            entity.Property(e => e.SupportTeamId).HasColumnName("SupportTeamID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Designation).HasMaxLength(100);
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Dol)
                .HasColumnType("datetime")
                .HasColumnName("DOL");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(1000)
                .HasColumnName("First_Name");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(200)
                .HasColumnName("Img_Url");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Role).HasMaxLength(100);
        });

        modelBuilder.Entity<SupportTeamAssgn>(entity =>
        {
            entity.ToTable("SupportTeamAssgn", "IT");

            entity.Property(e => e.SupportTeamAssgnId).HasColumnName("SupportTeamAssgnID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.ClassificationId).HasColumnName("ClassificationID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");
            entity.Property(e => e.IsApprover).HasColumnName("isApprover");
            entity.Property(e => e.IsChangeAnalyst).HasColumnName("isChangeAnalyst");
            entity.Property(e => e.IsSuperAdmin).HasColumnName("isSuperAdmin");
            entity.Property(e => e.IsSupportEngineer).HasColumnName("isSupportEngineer");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.SupportTeamId).HasColumnName("SupportTeamID");
        });

        modelBuilder.Entity<SysLandscape>(entity =>
        {
            entity.HasKey(e => e.SysLandscapeId).HasName("PK_IT.SysLandscape");

            entity.ToTable("SysLandscape", "IT");

            entity.Property(e => e.SysLandscapeId).HasColumnName("SysLandscapeID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ClassificationId).HasColumnName("ClassificationID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.SysLandscape1)
                .HasMaxLength(50)
                .HasColumnName("SysLandscape");

            entity.HasOne(d => d.Category).WithMany(p => p.SysLandscapes)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SysLandscape_Category");

            entity.HasOne(d => d.Classification).WithMany(p => p.SysLandscapes)
                .HasForeignKey(d => d.ClassificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SysLandscape_Classification");

            entity.HasOne(d => d.Support).WithMany(p => p.SysLandscapes)
                .HasForeignKey(d => d.SupportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SysLandscape_Support");
        });

        modelBuilder.Entity<TaskAttachment>(entity =>
        {
            entity.Property(e => e.FileName).HasMaxLength(200);
            entity.Property(e => e.FilePath).HasMaxLength(500);

            entity.HasOne(d => d.Task).WithMany(p => p.TaskAttachments)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskAttachments_TaskManager");
        });

        modelBuilder.Entity<TaskManager>(entity =>
        {
            entity.ToTable("TaskManager");

            entity.Property(e => e.ActualClosureDate).HasColumnType("datetime");
            entity.Property(e => e.ChangeRequestName).HasMaxLength(250);
            entity.Property(e => e.ClosureReasonType).HasMaxLength(50);
            entity.Property(e => e.DeletedBy).HasMaxLength(100);
            entity.Property(e => e.DeletedOn).HasColumnType("datetime");
            entity.Property(e => e.DeletedReason).HasMaxLength(100);
            entity.Property(e => e.Momdate)
                .HasColumnType("datetime")
                .HasColumnName("MOMDate");
            entity.Property(e => e.Mompurpose)
                .HasMaxLength(250)
                .HasColumnName("MOMPurpose");
            entity.Property(e => e.ProjectName).HasMaxLength(250);
            entity.Property(e => e.RemainderBeforeDays).HasMaxLength(50);
            entity.Property(e => e.TaskAssigType).HasMaxLength(50);
            entity.Property(e => e.TaskAssignedOn).HasColumnType("datetime");
            entity.Property(e => e.TaskAssignedToName).HasMaxLength(100);
            entity.Property(e => e.TaskClosedBy).HasMaxLength(100);
            entity.Property(e => e.TaskName).HasMaxLength(150);
            entity.Property(e => e.TaskStatus).HasMaxLength(50);
            entity.Property(e => e.Tcd)
                .HasColumnType("datetime")
                .HasColumnName("TCD");
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.TaskAssignedByNavigation).WithMany(p => p.TaskManagerTaskAssignedByNavigations)
                .HasForeignKey(d => d.TaskAssignedBy)
                .HasConstraintName("FK_TaskManager_Employee_Master1");

            entity.HasOne(d => d.TaskAssignedToNavigation).WithMany(p => p.TaskManagerTaskAssignedToNavigations)
                .HasForeignKey(d => d.TaskAssignedTo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskManager_Employee_Master");
        });

        modelBuilder.Entity<TaxClass>(entity =>
        {
            entity.HasKey(e => e.TClassId);

            entity.ToTable("TAX_CLASS");

            entity.Property(e => e.TClassId)
                .ValueGeneratedNever()
                .HasColumnName("T_CLASS_ID");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(50);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.TClassName)
                .HasMaxLength(50)
                .HasColumnName("T_CLASS_NAME");
        });

        modelBuilder.Entity<TblDepartmentHeadGroup>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_DepartmentHeadGroup");

            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Createdby).HasMaxLength(50);
            entity.Property(e => e.Department).HasMaxLength(100);
            entity.Property(e => e.EmpNo)
                .HasMaxLength(100)
                .HasColumnName("Emp_No");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Modifiedby).HasMaxLength(100);
            entity.Property(e => e.Paygroup).HasMaxLength(100);
        });

        modelBuilder.Entity<TblHrPolicyList>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_HrPolicy_List");

            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Createdby).HasMaxLength(50);
            entity.Property(e => e.HrPolicyName).HasMaxLength(100);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Modifiedby).HasMaxLength(100);
        });

        modelBuilder.Entity<TblInhouseMagizne>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_InhouseMagizne");

            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Createdby).HasMaxLength(100);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.MagizneName).HasMaxLength(100);
            entity.Property(e => e.MagizneUrl)
                .HasMaxLength(500)
                .HasColumnName("MagizneURL");
            entity.Property(e => e.MagizneYear).HasMaxLength(100);
            entity.Property(e => e.Modifiedby).HasMaxLength(100);
            entity.Property(e => e.Modifiedon).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblManagementDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tbl_Management_Details");

            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Createdby).HasMaxLength(100);
            entity.Property(e => e.Designation).HasMaxLength(100);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Modifiedby).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Photopath).HasMaxLength(250);
        });

        modelBuilder.Entity<TblSeniorManagementDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tbl_SeniorManagement_Details");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Createdby).HasMaxLength(100);
            entity.Property(e => e.Designation).HasMaxLength(100);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Modifiedby).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Photopath).HasMaxLength(250);
            entity.Property(e => e.Role).HasMaxLength(100);
        });

        modelBuilder.Entity<TblUserLog>(entity =>
        {
            entity.ToTable("tblUser_Log");

            entity.Property(e => e.Activity).HasMaxLength(20);
            entity.Property(e => e.Application).HasMaxLength(50);
            entity.Property(e => e.DoneOn)
                .HasColumnType("datetime")
                .HasColumnName("Done_On");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(15)
                .HasColumnName("Employee_Id");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(40)
                .IsFixedLength()
                .HasColumnName("IP_Address");
        });

        modelBuilder.Entity<TdTravelBalance>(entity =>
        {
            entity.HasKey(e => e.AccSubmittedReferenceNoId);

            entity.ToTable("Td_Travel_Balance");

            entity.Property(e => e.AccSubmittedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AccSubmittedDate).HasColumnType("datetime");
            entity.Property(e => e.Remarks).IsUnicode(false);
            entity.Property(e => e.Supportings)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TdTravelExpenseDetail>(entity =>
        {
            entity.ToTable("TD_TravelExpenseDetails");

            entity.Property(e => e.CheckInFavourOf)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Division)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EventDate).HasColumnType("datetime");
            entity.Property(e => e.Gender)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.HotelName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
            entity.Property(e => e.InvoiceNo)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Remarks).IsUnicode(false);
            entity.Property(e => e.Supportings).IsUnicode(false);
            entity.Property(e => e.TypeOfEvent)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TypeOfGuest)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VendorCity)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VendorName)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TdTravelPaymentDetail>(entity =>
        {
            entity.ToTable("Td_TravelPaymentDetails");

            entity.Property(e => e.ChequeIssuedTo)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TdTypeOfEvent>(entity =>
        {
            entity.ToTable("Td_TypeOfEvents");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.TypeOfEvent)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TdVendorMaster>(entity =>
        {
            entity.ToTable("Td_VendorMaster");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CITY");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Sapid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SAPID");
            entity.Property(e => e.VendorCode)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TdsSectionM>(entity =>
        {
            entity.ToTable("TDS_SECTION_M");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(50);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.TdsSectionDesc)
                .HasMaxLength(100)
                .HasColumnName("TDS_SECTION_DESC");
            entity.Property(e => e.TdsSectionId)
                .HasMaxLength(5)
                .HasColumnName("TDS_SECTION_ID");
        });

        modelBuilder.Entity<Temp1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("temp_1");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FkEmpId).HasColumnName("FK_Emp_Id");
            entity.Property(e => e.FkPlantId).HasColumnName("FK_PlantId");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TempCondition>(entity =>
        {
            entity.HasKey(e => e.TempConId);

            entity.ToTable("TEMP_CONDITION");

            entity.Property(e => e.TempConId).HasColumnName("TEMP_CON_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.TempConDesc)
                .HasMaxLength(500)
                .HasColumnName("TEMP_CON_DESC");
        });

        modelBuilder.Entity<TempEmpLeaveDocument>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("temp_emp_leave_documents");

            entity.Property(e => e.FileName)
                .HasMaxLength(500)
                .HasColumnName("file_name");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.LeaveType)
                .HasMaxLength(100)
                .HasColumnName("leave_type");
            entity.Property(e => e.ReqNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("req_no");
            entity.Property(e => e.UserId)
                .HasMaxLength(500)
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<TempVendorMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("temp_vendor_Master");

            entity.Property(e => e.City).HasMaxLength(255);
            entity.Property(e => e.Name1)
                .HasMaxLength(255)
                .HasColumnName("Name 1");
            entity.Property(e => e.Vendor).HasMaxLength(255);
        });

        modelBuilder.Entity<TestEmail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Test_Email");

            entity.Property(e => e.Email)
                .HasMaxLength(500)
                .HasColumnName("email");
            entity.Property(e => e.EmpId)
                .HasMaxLength(50)
                .HasColumnName("Emp_id");
        });

        modelBuilder.Entity<TestTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TestTable");

            entity.Property(e => e.Class)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("class");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TestTable1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TestTable1");

            entity.Property(e => e.Class)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("class");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TherapeuticSegment>(entity =>
        {
            entity.ToTable("THERAPEUTIC_SEGMENT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.TherSegCode)
                .HasMaxLength(50)
                .HasColumnName("THER_SEG_CODE");
            entity.Property(e => e.TherSegDesc)
                .HasMaxLength(100)
                .HasColumnName("THER_SEG_DESC");
        });

        modelBuilder.Entity<TimeSheetActivity>(entity =>
        {
            entity.ToTable("TimeSheetActivity");

            entity.Property(e => e.ActivityType).HasMaxLength(100);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId).HasMaxLength(50);
            entity.Property(e => e.FromTime).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.ProjectCategory).HasMaxLength(200);
            entity.Property(e => e.ProjectCode).HasMaxLength(100);
            entity.Property(e => e.TaskDate)
                .HasColumnType("datetime")
                .HasColumnName("Task_Date");
            entity.Property(e => e.Time).HasColumnType("numeric(10, 3)");
            entity.Property(e => e.ToTime).HasColumnType("datetime");
            entity.Property(e => e.TotalTime).HasMaxLength(10);
            entity.Property(e => e.WorkedOn).HasMaxLength(200);
            entity.Property(e => e.WorkedWith).HasMaxLength(200);
        });

        modelBuilder.Entity<TourPlan>(entity =>
        {
            entity.ToTable("TourPlan");

            entity.Property(e => e.ApprovedDate)
                .HasColumnType("datetime")
                .HasColumnName("Approved_Date");
            entity.Property(e => e.ApproverStatus)
                .HasMaxLength(20)
                .HasColumnName("Approver_Status");
            entity.Property(e => e.Comments).HasMaxLength(80);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Details).HasMaxLength(100);
            entity.Property(e => e.Duration).HasMaxLength(10);
            entity.Property(e => e.LastApprover)
                .HasMaxLength(20)
                .HasColumnName("Last_approver");
            entity.Property(e => e.PendingApprover)
                .HasMaxLength(20)
                .HasColumnName("Pending_Approver");
            entity.Property(e => e.RejectedDate)
                .HasColumnType("datetime")
                .HasColumnName("Rejected_Date");
            entity.Property(e => e.ReqBy)
                .HasMaxLength(50)
                .HasColumnName("Req_By");
            entity.Property(e => e.ReqOn)
                .HasColumnType("datetime")
                .HasColumnName("Req_On");
            entity.Property(e => e.TypeOfWork)
                .HasMaxLength(50)
                .HasColumnName("Type_Of_Work");
        });

        modelBuilder.Entity<TrainingDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TrainingNeeds");

            entity.ToTable("Training_Detail");

            entity.Property(e => e.AttendedCurrentYear)
                .IsUnicode(false)
                .HasColumnName("Attended_Current_Year");
            entity.Property(e => e.AttendedNextYear)
                .IsUnicode(false)
                .HasColumnName("Attended_Next_Year");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FkAssesmentId).HasColumnName("FK_Assesment_Id");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.FkAssesment).WithMany(p => p.TrainingDetails)
                .HasForeignKey(d => d.FkAssesmentId)
                .HasConstraintName("FK_Training_Detail_Assesment_Master");
        });

        modelBuilder.Entity<TypeOfGuest>(entity =>
        {
            entity.ToTable("TypeOfGuest");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.TypeOfGuest1)
                .HasMaxLength(50)
                .HasColumnName("Type Of Guest");
        });

        modelBuilder.Entity<UidrequestType>(entity =>
        {
            entity.ToTable("UIDRequestType");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.UserIdtype).HasColumnName("UserIDType");
        });

        modelBuilder.Entity<UidrequestTypeConfig>(entity =>
        {
            entity.ToTable("UIDRequestTypeConfig");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Sid).HasColumnName("SId");
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<UnitMesurement>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UNIT_MESUREMENT");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Uom)
                .HasMaxLength(10)
                .HasColumnName("UOM");
        });

        modelBuilder.Entity<UnlockPasswordResetHistory>(entity =>
        {
            entity.ToTable("Unlock_PasswordReset_History");

            entity.Property(e => e.ActivityType).HasMaxLength(100);
            entity.Property(e => e.DoneBy).HasMaxLength(50);
            entity.Property(e => e.DoneOn).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(15)
                .HasColumnName("Employee_Id");
            entity.Property(e => e.Remarks).HasMaxLength(250);
        });

        modelBuilder.Entity<UomMaster>(entity =>
        {
            entity.ToTable("UOM_Master");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Uom)
                .HasMaxLength(10)
                .HasColumnName("UOM");
        });

        modelBuilder.Entity<UrlMaster>(entity =>
        {
            entity.ToTable("URL_Master");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.UrlPath)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("URL_Path");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.EmployeeId);

            entity.Property(e => e.EmployeeId).HasMaxLength(50);
            entity.Property(e => e.Doj)
                .HasColumnType("datetime")
                .HasColumnName("DOJ");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.PwdAnswer)
                .HasMaxLength(100)
                .HasColumnName("Pwd_Answer");
            entity.Property(e => e.PwdQuestion)
                .HasMaxLength(200)
                .HasColumnName("Pwd_Question");
        });

        modelBuilder.Entity<UserDeptMaintenance>(entity =>
        {
            entity.ToTable("User_Dept_Maintenance");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.FkDeptId).HasColumnName("FK_DeptId");
            entity.Property(e => e.FkEmpId).HasColumnName("FK_Emp_Id");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.FkDept).WithMany(p => p.UserDeptMaintenances)
                .HasForeignKey(d => d.FkDeptId)
                .HasConstraintName("FK_User_Dept_Maintenance_User_Dept_Maintenance");

            entity.HasOne(d => d.FkEmp).WithMany(p => p.UserDeptMaintenances)
                .HasForeignKey(d => d.FkEmpId)
                .HasConstraintName("FK_User_Dept_Maintenance_Employee_Master");
        });

        modelBuilder.Entity<UserGroupsMaster>(entity =>
        {
            entity.ToTable("USER_GROUPS_MASTER");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(600)
                .IsUnicode(false);
            entity.Property(e => e.FkSoftwareId).HasColumnName("FK_SoftwareId");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.HasOne(d => d.FkSoftware).WithMany(p => p.UserGroupsMasters)
                .HasForeignKey(d => d.FkSoftwareId)
                .HasConstraintName("FK_USER_GROUPS_MASTER_Softwares");
        });

        modelBuilder.Entity<UserIdEquipmentDetail>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AreaorLocation).HasMaxLength(150);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EquipmentId).HasMaxLength(150);
            entity.Property(e => e.EquipmentName).HasMaxLength(150);
            entity.Property(e => e.RequestNo).HasMaxLength(20);
            entity.Property(e => e.Sid).HasColumnName("SId");

            entity.HasOne(d => d.Req).WithMany(p => p.UserIdEquipmentDetails)
                .HasForeignKey(d => d.ReqId)
                .HasConstraintName("FK_UserIdEquipmentDetails_UserIdRequest");

            entity.HasOne(d => d.SidNavigation).WithMany(p => p.UserIdEquipmentDetails)
                .HasForeignKey(d => d.Sid)
                .HasConstraintName("FK_UserIdEquipmentDetails_Softwares");
        });

        modelBuilder.Entity<UserIdMasterDetail>(entity =>
        {
            entity.ToTable("UserId_Master_Details");

            entity.Property(e => e.AreaorLocation).HasMaxLength(150);
            entity.Property(e => e.Category).HasMaxLength(100);
            entity.Property(e => e.EmployeeId).HasMaxLength(50);
            entity.Property(e => e.EquipmentId).HasMaxLength(150);
            entity.Property(e => e.EquipmentName).HasMaxLength(100);
            entity.Property(e => e.LastApprover).HasMaxLength(50);
            entity.Property(e => e.PendingApprover).HasMaxLength(50);
            entity.Property(e => e.Salutation)
                .HasMaxLength(50)
                .HasColumnName("salutation");
            entity.Property(e => e.Sid).HasColumnName("SId");
            entity.Property(e => e.SoftwareRole).HasMaxLength(50);
            entity.Property(e => e.SoftwareType).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .HasColumnName("UserID");

            entity.HasOne(d => d.Location).WithMany(p => p.UserIdMasterDetails)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK_UserId_Master_Details_Location_Master");

            entity.HasOne(d => d.SidNavigation).WithMany(p => p.UserIdMasterDetails)
                .HasForeignKey(d => d.Sid)
                .HasConstraintName("FK_UserId_Master_Details_Softwares");
        });

        modelBuilder.Entity<UserIdRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_UserIdRequest1");

            entity.ToTable("UserIdRequest");

            entity.Property(e => e.AccessDurtion).HasMaxLength(20);
            entity.Property(e => e.AccessOnMobile).HasMaxLength(20);
            entity.Property(e => e.AccessType).HasMaxLength(20);
            entity.Property(e => e.AdId)
                .HasMaxLength(20)
                .HasColumnName("AD_ID");
            entity.Property(e => e.AllottedUserId)
                .HasMaxLength(50)
                .HasColumnName("AllottedUserID");
            entity.Property(e => e.AllowOutsideComm).HasMaxLength(20);
            entity.Property(e => e.ApplicationName).HasMaxLength(50);
            entity.Property(e => e.AssetDetails)
                .HasMaxLength(100)
                .HasColumnName("Asset_details");
            entity.Property(e => e.CaretakerEmployeeId)
                .HasMaxLength(20)
                .HasColumnName("CaretakerEmployeeID");
            entity.Property(e => e.CaretakerForId)
                .HasMaxLength(20)
                .HasColumnName("CaretakerForID");
            entity.Property(e => e.CaretakerValidFrom).HasColumnType("datetime");
            entity.Property(e => e.CaretakerValidTo).HasColumnType("datetime");
            entity.Property(e => e.Catogery).HasMaxLength(50);
            entity.Property(e => e.CommonOrIndividualId).HasMaxLength(50);
            entity.Property(e => e.ComputerizedSystemId).HasMaxLength(100);
            entity.Property(e => e.ComputerizedSystemName).HasMaxLength(150);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DateOfTraining).HasMaxLength(150);
            entity.Property(e => e.DepartmentId).HasMaxLength(100);
            entity.Property(e => e.DiscontinuationId).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(80);
            entity.Property(e => e.EmailBackup).HasMaxLength(20);
            entity.Property(e => e.EmailIdUpdate).HasMaxLength(50);
            entity.Property(e => e.EmpType).HasMaxLength(20);
            entity.Property(e => e.ExistingId).HasMaxLength(50);
            entity.Property(e => e.ExistingUserProfie).HasMaxLength(250);
            entity.Property(e => e.ExternalCompany).HasMaxLength(255);
            entity.Property(e => e.ExternalName).HasMaxLength(255);
            entity.Property(e => e.ExternalPasswordResetDone).HasMaxLength(100);
            entity.Property(e => e.ExternalValidFrom).HasColumnType("datetime");
            entity.Property(e => e.ExternalValidTo).HasColumnType("datetime");
            entity.Property(e => e.Fileservername).HasMaxLength(120);
            entity.Property(e => e.GenericMasterId)
                .HasMaxLength(50)
                .HasColumnName("GenericMasterID");
            entity.Property(e => e.GenericPasswordResetDone).HasMaxLength(100);
            entity.Property(e => e.GenericUserId)
                .HasMaxLength(255)
                .HasColumnName("GenericUserID");
            entity.Property(e => e.GenericValidFrom).HasColumnType("datetime");
            entity.Property(e => e.GenericValidTo).HasColumnType("datetime");
            entity.Property(e => e.Hostname).HasMaxLength(50);
            entity.Property(e => e.IpAddress)
                .HasMaxLength(20)
                .HasColumnName("IP_Address");
            entity.Property(e => e.IpType)
                .HasMaxLength(20)
                .HasColumnName("Ip_Type");
            entity.Property(e => e.JdAcceptedByUser).HasColumnName("JD_Accepted_By_User");
            entity.Property(e => e.JdApproved).HasColumnName("JD_Approved");
            entity.Property(e => e.JdIntiated).HasColumnName("JD_Intiated");
            entity.Property(e => e.Jddocument).HasColumnName("JDDocument");
            entity.Property(e => e.LastApprover).HasMaxLength(50);
            entity.Property(e => e.LicenseType).HasMaxLength(20);
            entity.Property(e => e.LocationId).HasColumnName("LOCATION_ID");
            entity.Property(e => e.MailandTeamsAccess).HasMaxLength(20);
            entity.Property(e => e.MobileNo).HasMaxLength(20);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.NewRoleInQams).HasColumnName("NewRoleInQAMS");
            entity.Property(e => e.NoOfIps)
                .HasMaxLength(20)
                .HasColumnName("NO_of_Ips");
            entity.Property(e => e.OfficeSuite).HasMaxLength(20);
            entity.Property(e => e.OnBehalfEmp).HasMaxLength(20);
            entity.Property(e => e.PendingApprover).HasMaxLength(50);
            entity.Property(e => e.PrefferedEmail).HasMaxLength(50);
            entity.Property(e => e.PresentRoleInQams).HasColumnName("PresentRoleInQAMS");
            entity.Property(e => e.ReasonForReset).HasMaxLength(50);
            entity.Property(e => e.ReasonForUnlock).HasMaxLength(50);
            entity.Property(e => e.ReleivedDate)
                .HasColumnType("datetime")
                .HasColumnName("Releived_Date");
            entity.Property(e => e.ReportingManagerEmail).HasMaxLength(50);
            entity.Property(e => e.RequestDate)
                .HasColumnType("datetime")
                .HasColumnName("REQUEST_DATE");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(10)
                .HasColumnName("Request_No");
            entity.Property(e => e.RequestType)
                .HasMaxLength(50)
                .HasColumnName("Request_Type");
            entity.Property(e => e.RequesterId)
                .HasMaxLength(20)
                .HasColumnName("RequesterID");
            entity.Property(e => e.Requestfor).HasMaxLength(50);
            entity.Property(e => e.RequiredSoftwares).HasMaxLength(80);
            entity.Property(e => e.Salutation)
                .HasMaxLength(5)
                .HasColumnName("salutation");
            entity.Property(e => e.Sid).HasColumnName("SId");
            entity.Property(e => e.SoftwareType).HasMaxLength(20);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TemporaryPassword)
                .HasMaxLength(50)
                .HasColumnName("Temporary_Password");
            entity.Property(e => e.TemporaryPasswordConveyed).HasColumnName("Temporary_Password_Conveyed");
            entity.Property(e => e.UpdatedDesignation).HasMaxLength(150);
            entity.Property(e => e.UpdatedReporting).HasMaxLength(150);
            entity.Property(e => e.UsbFromDate)
                .HasColumnType("datetime")
                .HasColumnName("USB_FromDate");
            entity.Property(e => e.UsbTodate)
                .HasColumnType("datetime")
                .HasColumnName("USB_Todate");
            entity.Property(e => e.UserAddedToRequestedPlants).HasColumnName("User_Added_To_Requested_Plants");
            entity.Property(e => e.UserAddedToSubGroup).HasColumnName("User_Added_To_SubGroup");
            entity.Property(e => e.UserAddedToTheRequestedRepositoryDomain).HasColumnName("User_Added_To_The_Requested_Repository_Domain");
            entity.Property(e => e.UserIdtype)
                .HasMaxLength(20)
                .HasColumnName("UserIDType");
            entity.Property(e => e.UserProfiles).HasMaxLength(250);
            entity.Property(e => e.ValidFrom).HasColumnType("datetime");
            entity.Property(e => e.VendorName).HasMaxLength(50);
        });

        modelBuilder.Entity<UserIdRequestOld>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_UserIdRequest");

            entity.ToTable("UserIdRequest_Old", tb => tb.HasTrigger("Trg_UserIdMasterDetails"));

            entity.Property(e => e.AccessDurtion).HasMaxLength(20);
            entity.Property(e => e.AccessOnMobile).HasMaxLength(20);
            entity.Property(e => e.AccessType).HasMaxLength(20);
            entity.Property(e => e.AdId)
                .HasMaxLength(20)
                .HasColumnName("AD_ID");
            entity.Property(e => e.AllottedUserId)
                .HasMaxLength(50)
                .HasColumnName("AllottedUserID");
            entity.Property(e => e.AllowOutsideComm).HasMaxLength(20);
            entity.Property(e => e.ApplicationName).HasMaxLength(50);
            entity.Property(e => e.AssetDetails)
                .HasMaxLength(100)
                .HasColumnName("Asset_details");
            entity.Property(e => e.Catogery).HasMaxLength(50);
            entity.Property(e => e.Comments).HasMaxLength(250);
            entity.Property(e => e.CommonOrIndividualId).HasMaxLength(50);
            entity.Property(e => e.ComputerizedSystemId).HasMaxLength(50);
            entity.Property(e => e.ComputerizedSystemName).HasMaxLength(150);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DateOfTraining).HasMaxLength(80);
            entity.Property(e => e.DepartmentId).HasMaxLength(100);
            entity.Property(e => e.DiscontinuationId).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(80);
            entity.Property(e => e.EmailBackup).HasMaxLength(20);
            entity.Property(e => e.EmailIdUpdate).HasMaxLength(50);
            entity.Property(e => e.EmpType).HasMaxLength(20);
            entity.Property(e => e.ExistingId).HasMaxLength(20);
            entity.Property(e => e.ExistingUserProfie).HasMaxLength(250);
            entity.Property(e => e.Fileservername).HasMaxLength(120);
            entity.Property(e => e.GeneralRole).HasMaxLength(150);
            entity.Property(e => e.Hostname).HasMaxLength(50);
            entity.Property(e => e.IpAddress)
                .HasMaxLength(20)
                .HasColumnName("IP_Address");
            entity.Property(e => e.IpType)
                .HasMaxLength(20)
                .HasColumnName("Ip_Type");
            entity.Property(e => e.JdAcceptedByUser).HasColumnName("JD_Accepted_By_User");
            entity.Property(e => e.JdApproved).HasColumnName("JD_Approved");
            entity.Property(e => e.JdIntiated).HasColumnName("JD_Intiated");
            entity.Property(e => e.Jddocument).HasColumnName("JDDocument");
            entity.Property(e => e.LastApprover).HasMaxLength(50);
            entity.Property(e => e.LicenseType).HasMaxLength(20);
            entity.Property(e => e.LocationId).HasColumnName("LOCATION_ID");
            entity.Property(e => e.MailandTeamsAccess).HasMaxLength(20);
            entity.Property(e => e.MobileNo).HasMaxLength(20);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.NewRoleInQams)
                .HasMaxLength(150)
                .HasColumnName("NewRoleInQAMS");
            entity.Property(e => e.NewRoleUpdated).HasMaxLength(250);
            entity.Property(e => e.NoOfIps)
                .HasMaxLength(20)
                .HasColumnName("NO_of_Ips");
            entity.Property(e => e.OfficeSuite).HasMaxLength(20);
            entity.Property(e => e.OnBehalfEmp).HasMaxLength(20);
            entity.Property(e => e.PendingApprover).HasMaxLength(50);
            entity.Property(e => e.PrefferedEmail).HasMaxLength(50);
            entity.Property(e => e.PresentRoleInQams)
                .HasMaxLength(50)
                .HasColumnName("PresentRoleInQAMS");
            entity.Property(e => e.ReasonForReset).HasMaxLength(50);
            entity.Property(e => e.ReasonForUnlock).HasMaxLength(50);
            entity.Property(e => e.ReleivedDate)
                .HasColumnType("datetime")
                .HasColumnName("Releived_Date");
            entity.Property(e => e.ReportingManagerEmail).HasMaxLength(50);
            entity.Property(e => e.RequestDate)
                .HasColumnType("datetime")
                .HasColumnName("REQUEST_DATE");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(10)
                .HasColumnName("Request_No");
            entity.Property(e => e.RequestType)
                .HasMaxLength(50)
                .HasColumnName("Request_Type");
            entity.Property(e => e.RequesterId)
                .HasMaxLength(20)
                .HasColumnName("RequesterID");
            entity.Property(e => e.Requestfor).HasMaxLength(50);
            entity.Property(e => e.RequiredSoftwares).HasMaxLength(80);
            entity.Property(e => e.Salutation)
                .HasMaxLength(5)
                .HasColumnName("salutation");
            entity.Property(e => e.Sid).HasColumnName("SId");
            entity.Property(e => e.SoftwareType).HasMaxLength(20);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TemporaryPassword)
                .HasMaxLength(50)
                .HasColumnName("Temporary_Password");
            entity.Property(e => e.TemporaryPasswordConveyed).HasColumnName("Temporary_Password_Conveyed");
            entity.Property(e => e.UpdatedDesignation).HasMaxLength(150);
            entity.Property(e => e.UpdatedReporting).HasMaxLength(150);
            entity.Property(e => e.UsbFromDate)
                .HasColumnType("datetime")
                .HasColumnName("USB_FromDate");
            entity.Property(e => e.UsbTodate)
                .HasColumnType("datetime")
                .HasColumnName("USB_Todate");
            entity.Property(e => e.UserAddedToRequestedPlants).HasColumnName("User_Added_To_Requested_Plants");
            entity.Property(e => e.UserAddedToSubGroup).HasColumnName("User_Added_To_SubGroup");
            entity.Property(e => e.UserAddedToTheRequestedRepositoryDomain).HasColumnName("User_Added_To_The_Requested_Repository_Domain");
            entity.Property(e => e.UserProfiles).HasMaxLength(250);
            entity.Property(e => e.ValidFrom).HasColumnType("datetime");
            entity.Property(e => e.VendorName).HasMaxLength(50);

            entity.HasOne(d => d.Location).WithMany(p => p.UserIdRequestOlds)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK_UserIdRequest_UserIdRequest");

            entity.HasOne(d => d.SidNavigation).WithMany(p => p.UserIdRequestOlds)
                .HasForeignKey(d => d.Sid)
                .HasConstraintName("FK_UserIdRequest_Softwares");
        });

        modelBuilder.Entity<UserIdmaster>(entity =>
        {
            entity.ToTable("UserIDMaster");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AreaorLocation).HasMaxLength(150);
            entity.Property(e => e.CaretakerId)
                .HasMaxLength(20)
                .HasColumnName("CaretakerID");
            entity.Property(e => e.CaretakerValidityFrom).HasColumnType("datetime");
            entity.Property(e => e.CaretakerValidityTo).HasColumnType("datetime");
            entity.Property(e => e.Category).HasMaxLength(100);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(50)
                .HasColumnName("EmployeeID");
            entity.Property(e => e.EquipmentId).HasMaxLength(150);
            entity.Property(e => e.EquipmentName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Salutation).HasMaxLength(50);
            entity.Property(e => e.Sid).HasColumnName("SId");
            entity.Property(e => e.SoftwareType).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .HasColumnName("UserID");
        });

        modelBuilder.Entity<UserIdtype>(entity =>
        {
            entity.ToTable("UserIDType");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<UserMaster>(entity =>
        {
            entity.ToTable("User_Master");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(50)
                .HasColumnName("Employee_ID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First_Name");
            entity.Property(e => e.FkCompanyId).HasColumnName("FK_Company_Id");
            entity.Property(e => e.FkDepartmentId).HasColumnName("Fk_Department_id");
            entity.Property(e => e.FkDesignationId).HasColumnName("Fk_Designation_Id");
            entity.Property(e => e.FkEmpId).HasColumnName("FK_Emp_Id");
            entity.Property(e => e.FkProfileId).HasColumnName("Fk_Profile_id");
            entity.Property(e => e.FkRoleId).HasColumnName("Fk_Role_id");
            entity.Property(e => e.FkSubroleId).HasColumnName("Fk_Subrole_id");
            entity.Property(e => e.FkUrlId).HasColumnName("Fk_Url_id");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Full_Name");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(200)
                .HasColumnName("Img_Url");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastLoginDateTime)
                .HasColumnType("datetime")
                .HasColumnName("Last_Login_date_time");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("Last_Name");
            entity.Property(e => e.LastPassword)
                .HasMaxLength(500)
                .HasColumnName("Last_Password");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.PasswordResetToken)
                .HasMaxLength(50)
                .HasColumnName("Password_reset_token");
            entity.Property(e => e.PhoneNumber).HasColumnName("Phone_Number");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TokenExpiryDate)
                .HasColumnType("datetime")
                .HasColumnName("Token_expiry_date");

            entity.HasOne(d => d.FkCompany).WithMany(p => p.UserMasters)
                .HasForeignKey(d => d.FkCompanyId)
                .HasConstraintName("FK_User_Master_Company_Master1");
        });

        modelBuilder.Entity<UserPlantMaintenance>(entity =>
        {
            entity.ToTable("User_Plant_Maintenance");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FkEmpId).HasColumnName("FK_Emp_Id");
            entity.Property(e => e.FkPlantId).HasColumnName("FK_PlantId");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.FkEmp).WithMany(p => p.UserPlantMaintenances)
                .HasForeignKey(d => d.FkEmpId)
                .HasConstraintName("FK_User_Plant_Maintenance_Employee_Master");

            entity.HasOne(d => d.FkPlant).WithMany(p => p.UserPlantMaintenances)
                .HasForeignKey(d => d.FkPlantId)
                .HasConstraintName("FK_User_Plant_Maintenance_Location_Master");
        });

        modelBuilder.Entity<UserProfileMaintenance>(entity =>
        {
            entity.ToTable("User_profile_maintenance");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FkProfileId).HasColumnName("FK_Profile_ID");
            entity.Property(e => e.FkUserId).HasColumnName("FK_User_ID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<UserSubgroupsMaster>(entity =>
        {
            entity.ToTable("USER_SUBGROUPS_MASTER");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(600)
                .IsUnicode(false);
            entity.Property(e => e.FkSoftwareId).HasColumnName("FK_SoftwareId");
            entity.Property(e => e.FkUserGroupId).HasColumnName("FK_UserGroupId");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.HasOne(d => d.FkSoftware).WithMany(p => p.UserSubgroupsMasters)
                .HasForeignKey(d => d.FkSoftwareId)
                .HasConstraintName("FK_USER_SUBGROUPS_MASTER_Softwares");

            entity.HasOne(d => d.FkUserGroup).WithMany(p => p.UserSubgroupsMasters)
                .HasForeignKey(d => d.FkUserGroupId)
                .HasConstraintName("FK_USER_SUBGROUPS_MASTER_USER_GROUPS_MASTER");
        });

        modelBuilder.Entity<ValuationClass>(entity =>
        {
            entity.ToTable("VALUATION_CLASS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.MatType)
                .HasMaxLength(50)
                .HasColumnName("MAT_TYPE");
            entity.Property(e => e.ValuationDesc)
                .HasMaxLength(500)
                .HasColumnName("VALUATION_DESC");
            entity.Property(e => e.ValuationId)
                .HasMaxLength(50)
                .HasColumnName("VALUATION_ID");
        });

        modelBuilder.Entity<VendorMaster>(entity =>
        {
            entity.ToTable("vendor_master");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AccountClerkId)
                .HasMaxLength(20)
                .HasColumnName("ACCOUNT_CLERK_ID");
            entity.Property(e => e.AccountGroupId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ACCOUNT_GROUP_ID");
            entity.Property(e => e.Address1).HasColumnName("ADDRESS1");
            entity.Property(e => e.Address2).HasColumnName("ADDRESS2");
            entity.Property(e => e.Address3).HasColumnName("ADDRESS3");
            entity.Property(e => e.Address4).HasColumnName("ADDRESS4");
            entity.Property(e => e.ApproveDate)
                .HasColumnType("datetime")
                .HasColumnName("approve_date");
            entity.Property(e => e.ApproveStatus)
                .HasMaxLength(500)
                .HasColumnName("Approve_Status");
            entity.Property(e => e.Attachments)
                .HasMaxLength(500)
                .HasColumnName("attachments");
            entity.Property(e => e.City)
                .HasMaxLength(40)
                .HasColumnName("CITY");
            entity.Property(e => e.Commissionerate)
                .HasMaxLength(40)
                .HasColumnName("COMMISSIONERATE");
            entity.Property(e => e.CountryId)
                .HasMaxLength(3)
                .HasColumnName("COUNTRY_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_DATE");
            entity.Property(e => e.CstNo)
                .HasMaxLength(40)
                .HasColumnName("CST_NO");
            entity.Property(e => e.CurrencyId)
                .HasMaxLength(4)
                .HasColumnName("CURRENCY_ID");
            entity.Property(e => e.EccNo)
                .HasMaxLength(40)
                .HasColumnName("ECC_No");
            entity.Property(e => e.EmailId)
                .HasMaxLength(40)
                .HasColumnName("EMAIL_ID");
            entity.Property(e => e.ExciseDivision)
                .HasMaxLength(40)
                .HasColumnName("Excise_Division");
            entity.Property(e => e.ExciseRange)
                .HasMaxLength(40)
                .HasColumnName("Excise_Range");
            entity.Property(e => e.ExciseRegNo)
                .HasMaxLength(40)
                .HasColumnName("Excise_Reg_No");
            entity.Property(e => e.FaxNo)
                .HasMaxLength(16)
                .HasColumnName("FAX_NO");
            entity.Property(e => e.GstinNumber)
                .HasMaxLength(50)
                .HasColumnName("GSTIN_Number");
            entity.Property(e => e.IsApprovedVendor).HasColumnName("IS_APPROVED_VENDOR");
            entity.Property(e => e.IsEligibleForTds).HasColumnName("IS_ELIGIBLE_FOR_TDS");
            entity.Property(e => e.IsRegdExciseVendor).HasColumnName("IS_REGD_EXCISE_VENDOR");
            entity.Property(e => e.LandlineNo)
                .HasMaxLength(16)
                .HasColumnName("LANDLINE_NO");
            entity.Property(e => e.LastApprover)
                .HasMaxLength(100)
                .HasColumnName("last_approver");
            entity.Property(e => e.LocationId)
                .HasMaxLength(50)
                .HasColumnName("LOCATION_ID");
            entity.Property(e => e.LstNo)
                .HasMaxLength(40)
                .HasColumnName("LST_NO");
            entity.Property(e => e.MobileNo)
                .HasMaxLength(16)
                .HasColumnName("MOBILE_NO");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_DATE");
            entity.Property(e => e.Name).HasColumnName("NAME");
            entity.Property(e => e.PanNo)
                .HasMaxLength(40)
                .HasColumnName("PAN_No");
            entity.Property(e => e.PaymentTermId)
                .HasMaxLength(4)
                .HasColumnName("PAYMENT_TERM_ID");
            entity.Property(e => e.PendingApprover)
                .HasMaxLength(100)
                .HasColumnName("pending_approver");
            entity.Property(e => e.Pincode)
                .HasMaxLength(10)
                .HasColumnName("PINCODE");
            entity.Property(e => e.ReconcilationActId)
                .HasMaxLength(6)
                .HasColumnName("RECONCILATION_ACT_ID");
            entity.Property(e => e.RejectedFlag)
                .HasMaxLength(50)
                .HasColumnName("rejected_flag");
            entity.Property(e => e.RequestDate)
                .HasColumnType("datetime")
                .HasColumnName("REQUEST_DATE");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(20)
                .HasColumnName("REQUEST_NO");
            entity.Property(e => e.RequestedBy)
                .HasMaxLength(50)
                .HasColumnName("REQUESTED_BY");
            entity.Property(e => e.SapCodeExists)
                .HasMaxLength(50)
                .HasColumnName("SAP_CODE_EXISTS");
            entity.Property(e => e.SapCodeNo)
                .HasMaxLength(100)
                .HasColumnName("SAP_CODE_NO");
            entity.Property(e => e.SapCreatedBy)
                .HasMaxLength(100)
                .HasColumnName("SAP_CREATED_BY");
            entity.Property(e => e.SapCreationDate)
                .HasColumnType("datetime")
                .HasColumnName("SAP_CREATION_DATE");
            entity.Property(e => e.ServiceTaxRegistrationNo)
                .HasMaxLength(40)
                .HasColumnName("Service_Tax_Registration_No");
            entity.Property(e => e.State)
                .HasMaxLength(10)
                .HasColumnName("STATE");
            entity.Property(e => e.TdsCode)
                .HasMaxLength(40)
                .HasColumnName("TDS_CODE");
            entity.Property(e => e.TinNo)
                .HasMaxLength(40)
                .HasColumnName("TIN_NO");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("TITLE");
            entity.Property(e => e.Type).HasMaxLength(500);
            entity.Property(e => e.TypeOfVendor)
                .HasMaxLength(500)
                .HasColumnName("Type_Of_Vendor");
            entity.Property(e => e.VendorCat).HasMaxLength(50);
            entity.Property(e => e.VendorSubCat).HasMaxLength(50);
            entity.Property(e => e.ViewType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("VIEW_TYPE");
        });

        modelBuilder.Entity<VendorMasterChange>(entity =>
        {
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.LastApprover).HasMaxLength(100);
            entity.Property(e => e.ModifiedBy).HasMaxLength(100);
            entity.Property(e => e.PendingApprover).HasMaxLength(100);
            entity.Property(e => e.Plant).HasMaxLength(100);
            entity.Property(e => e.RequestedBy).HasMaxLength(50);
            entity.Property(e => e.RequestedDate).HasColumnType("datetime");
            entity.Property(e => e.State).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.VendorCode).HasMaxLength(50);
            entity.Property(e => e.VendorName).HasMaxLength(100);
        });

        modelBuilder.Entity<VendorMasterDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Vendor_Master_Details");

            entity.Property(e => e.Aenam)
                .HasMaxLength(150)
                .HasColumnName("AENAM");
            entity.Property(e => e.Bezei)
                .HasMaxLength(150)
                .HasColumnName("BEZEI");
            entity.Property(e => e.Country)
                .HasMaxLength(150)
                .HasColumnName("COUNTRY");
            entity.Property(e => e.Ernam)
                .HasMaxLength(150)
                .HasColumnName("ERNAM");
            entity.Property(e => e.Ersda)
                .HasMaxLength(150)
                .HasColumnName("ERSDA");
            entity.Property(e => e.HouseNum1)
                .HasMaxLength(150)
                .HasColumnName("HOUSE_NUM1");
            entity.Property(e => e.Ktokk)
                .HasMaxLength(100)
                .HasColumnName("KTOKK");
            entity.Property(e => e.Laeda)
                .HasMaxLength(150)
                .HasColumnName("LAEDA");
            entity.Property(e => e.Landx)
                .HasMaxLength(150)
                .HasColumnName("LANDX");
            entity.Property(e => e.Lifn2)
                .HasMaxLength(150)
                .HasColumnName("LIFN2");
            entity.Property(e => e.Lifnr)
                .HasMaxLength(50)
                .HasColumnName("LIFNR");
            entity.Property(e => e.Location)
                .HasMaxLength(150)
                .HasColumnName("LOCATION");
            entity.Property(e => e.McCity1)
                .HasMaxLength(150)
                .HasColumnName("MC_CITY1");
            entity.Property(e => e.Name1)
                .HasMaxLength(150)
                .HasColumnName("NAME1");
            entity.Property(e => e.Name2)
                .HasMaxLength(150)
                .HasColumnName("NAME2");
            entity.Property(e => e.PostCode1)
                .HasMaxLength(150)
                .HasColumnName("POST_CODE1");
            entity.Property(e => e.Region)
                .HasMaxLength(150)
                .HasColumnName("REGION");
            entity.Property(e => e.Sperq)
                .HasMaxLength(150)
                .HasColumnName("SPERQ");
            entity.Property(e => e.Stcd3)
                .HasMaxLength(150)
                .HasColumnName("STCD3");
            entity.Property(e => e.StrSuppl1)
                .HasMaxLength(150)
                .HasColumnName("STR_SUPPL1");
            entity.Property(e => e.StrSuppl2)
                .HasMaxLength(150)
                .HasColumnName("STR_SUPPL2");
            entity.Property(e => e.StrSuppl3)
                .HasMaxLength(150)
                .HasColumnName("STR_SUPPL3");
            entity.Property(e => e.Street)
                .HasMaxLength(150)
                .HasColumnName("STREET");
        });

        modelBuilder.Entity<VendorType>(entity =>
        {
            entity.ToTable("VENDOR_TYPE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastModifiedBy).HasMaxLength(50);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.VCode)
                .HasMaxLength(5)
                .HasColumnName("V_CODE");
            entity.Property(e => e.VDescription)
                .HasMaxLength(50)
                .HasColumnName("V_Description");
        });

        modelBuilder.Entity<Visitor>(entity =>
        {
            entity.ToTable("Visitor");

            entity.Property(e => e.CompanyName).HasMaxLength(500);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(500);
            entity.Property(e => e.EmployeeEmail).HasMaxLength(500);
            entity.Property(e => e.EndDateTime).HasColumnType("datetime");
            entity.Property(e => e.FkEmployeeId).HasMaxLength(150);
            entity.Property(e => e.FkEmployeeName).HasMaxLength(500);
            entity.Property(e => e.FkvisitorPurpose).HasColumnName("FKVisitorPurpose");
            entity.Property(e => e.FkvisitorType).HasColumnName("FKVisitorType");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Mobile).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.OtherPurpose).HasMaxLength(100);

            entity.HasOne(d => d.FkvisitorPurposeNavigation).WithMany(p => p.Visitors)
                .HasForeignKey(d => d.FkvisitorPurpose)
                .HasConstraintName("FKVisitorPurpose");

            entity.HasOne(d => d.FkvisitorTypeNavigation).WithMany(p => p.Visitors)
                .HasForeignKey(d => d.FkvisitorType)
                .HasConstraintName("FKVisitorType");
        });

        modelBuilder.Entity<VisitorBelonging>(entity =>
        {
            entity.ToTable("Visitor_Belongings");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(500);
        });

        modelBuilder.Entity<VisitorImage>(entity =>
        {
            entity.ToTable("Visitor_Image");

            entity.Property(e => e.FkVisitorId).HasColumnName("FK_VisitorID");
            entity.Property(e => e.VisitorImage1)
                .HasColumnType("image")
                .HasColumnName("VisitorImage");

            entity.HasOne(d => d.FkVisitor).WithMany(p => p.VisitorImages)
                .HasForeignKey(d => d.FkVisitorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VisitorID");
        });

        modelBuilder.Entity<VisitorPurpose>(entity =>
        {
            entity.ToTable("VisitorPurpose");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Purpose).HasMaxLength(500);
        });

        modelBuilder.Entity<VisitorType>(entity =>
        {
            entity.ToTable("Visitor_Type");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.VisitorType1)
                .HasMaxLength(500)
                .HasColumnName("Visitor_Type");
        });

        modelBuilder.Entity<VmsApprovalM>(entity =>
        {
            entity.ToTable("VMS_Approval_M");

            entity.Property(e => e.ApprovalType).HasMaxLength(50);
            entity.Property(e => e.ApproverId)
                .HasMaxLength(10)
                .HasColumnName("Approver_Id");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Dept)
                .HasMaxLength(10)
                .HasColumnName("dept");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Plant).HasMaxLength(5);
        });

        modelBuilder.Entity<VmsapproverConfig>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("VMSApproverConfig");

            entity.Property(e => e.ApprovalType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Department)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Plant)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwApproverCr>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ApproverCR ", "IT");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ChangeDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Crcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CRCode");
            entity.Property(e => e.Crdate)
                .HasColumnType("datetime")
                .HasColumnName("CRDate");
            entity.Property(e => e.Crowner)
                .HasMaxLength(1202)
                .HasColumnName("CROwner");
            entity.Property(e => e.CrrequestorName)
                .HasMaxLength(1202)
                .HasColumnName("CRRequestorName");
            entity.Property(e => e.EstimatedCost).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.EstimatedCostCurr)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IsApproved).HasColumnName("isApproved");
            entity.Property(e => e.IsImplemented).HasColumnName("isImplemented");
            entity.Property(e => e.IsReleased).HasColumnName("isReleased");
            entity.Property(e => e.IsSubmitted).HasColumnName("isSubmitted");
            entity.Property(e => e.ItcategoryId).HasColumnName("ITCategoryID");
            entity.Property(e => e.ItclassificationId).HasColumnName("ITClassificationID");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId)
                .HasMaxLength(10)
                .HasColumnName("PlantID");
            entity.Property(e => e.Plantcode).HasColumnName("plantcode");
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.Taskcount).HasColumnName("taskcount");
        });

        modelBuilder.Entity<VwAsset>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Assets", "IT");

            entity.Property(e => e.AssetId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Asset_ID");
            entity.Property(e => e.AssetNo)
                .HasMaxLength(200)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Asset_No");
            entity.Property(e => e.Category)
                .HasMaxLength(200)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.EmpNo)
                .HasMaxLength(200)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(200)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Model)
                .HasMaxLength(200)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Processor)
                .HasMaxLength(200)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.SerialNo)
                .HasMaxLength(200)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("Serial_No");
        });

        modelBuilder.Entity<VwBarchart>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Barchart ", "IT");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypeId).HasColumnName("CategoryTypeID");
            entity.Property(e => e.ClassifcationId).HasColumnName("ClassifcationID");
            entity.Property(e => e.CompletedIdnum).HasColumnName("CompletedIDNum");
            entity.Property(e => e.Crdate)
                .HasColumnType("datetime")
                .HasColumnName("CRDate");
            entity.Property(e => e.Crmonth).HasColumnName("crmonth");
            entity.Property(e => e.Crowner).HasColumnName("CROwner");
            entity.Property(e => e.Itcrid)
                .ValueGeneratedOnAdd()
                .HasColumnName("ITCRID");
            entity.Property(e => e.NonCompletedIdnum).HasColumnName("NonCompletedIDNum");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
        });

        modelBuilder.Entity<VwCategorytype>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Categorytype", "IT");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CategoryType).HasMaxLength(500);
            entity.Property(e => e.CategoryTypeId).HasColumnName("CategoryTypeID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<VwChangeRequest>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ChangeRequest ", "IT");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CategoryType).HasMaxLength(500);
            entity.Property(e => e.CategoryTypeId).HasColumnName("CategoryTypeID");
            entity.Property(e => e.ChangeDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Crcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CRCode");
            entity.Property(e => e.Crdate)
                .HasColumnType("datetime")
                .HasColumnName("CRDate");
            entity.Property(e => e.CrinitiatedFor).HasColumnName("CRInitiatedFor");
            entity.Property(e => e.Crowner)
                .HasMaxLength(1202)
                .HasColumnName("CROwner");
            entity.Property(e => e.Crownerid).HasColumnName("CROwnerid");
            entity.Property(e => e.CrremailNotification).HasColumnName("CRREmailNotification");
            entity.Property(e => e.CrrequestedBy).HasColumnName("CRRequestedBy");
            entity.Property(e => e.CrrequestorName)
                .HasMaxLength(1202)
                .HasColumnName("CRRequestorName");
            entity.Property(e => e.EstimatedCost).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.EstimatedCostCurr)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.InitiatedFor).HasMaxLength(1202);
            entity.Property(e => e.IsApproved).HasColumnName("isApproved");
            entity.Property(e => e.IsImplemented).HasColumnName("isImplemented");
            entity.Property(e => e.IsReleased).HasColumnName("isReleased");
            entity.Property(e => e.IsSubmitted).HasColumnName("isSubmitted");
            entity.Property(e => e.ItcategoryId).HasColumnName("ITCategoryID");
            entity.Property(e => e.ItclassificationId).HasColumnName("ITClassificationID");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.NatureofChange).HasMaxLength(500);
            entity.Property(e => e.PlantId)
                .HasMaxLength(10)
                .HasColumnName("PlantID");
            entity.Property(e => e.Plantcode).HasColumnName("plantcode");
            entity.Property(e => e.PriorityName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RequestorPlant).HasMaxLength(10);
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.SysLandscapeId)
                .HasMaxLength(500)
                .HasColumnName("SysLandscapeID");
            entity.Property(e => e.Taskcount).HasColumnName("taskcount");
        });

        modelBuilder.Entity<VwChangeRequestHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ChangeRequestHistory ", "IT");

            entity.Property(e => e.Crcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CRCode");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CrhistoryDt)
                .HasColumnType("datetime")
                .HasColumnName("CRHistoryDt");
            entity.Property(e => e.CrhistoryId).HasColumnName("CRHistoryID");
            entity.Property(e => e.CrinitiatedFor).HasColumnName("CRInitiatedFor");
            entity.Property(e => e.Crowner).HasColumnName("CROwner");
            entity.Property(e => e.CrrequestedBy).HasColumnName("CRRequestedBy");
            entity.Property(e => e.CrrequestedDt)
                .HasColumnType("datetime")
                .HasColumnName("CRRequestedDt");
            entity.Property(e => e.EventName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.Supptname)
                .HasMaxLength(1200)
                .HasColumnName("supptname");
        });

        modelBuilder.Entity<VwChangeRequestSummary>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ChangeRequestSummary", "IT");

            entity.Property(e => e.AlternateConsidetation)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.BackoutPlan)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Benefits)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.BusinessImpact)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CategoryType).HasMaxLength(500);
            entity.Property(e => e.ChangeControlNo).HasMaxLength(50);
            entity.Property(e => e.ChangeDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Changerequestedby)
                .HasMaxLength(1202)
                .HasColumnName("changerequestedby");
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Crcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CRCode");
            entity.Property(e => e.Crdate)
                .HasColumnType("datetime")
                .HasColumnName("CRDate");
            entity.Property(e => e.Crowner)
                .HasMaxLength(1202)
                .HasColumnName("CROwner");
            entity.Property(e => e.CrrequestedDt)
                .HasColumnType("datetime")
                .HasColumnName("CRRequestedDt");
            entity.Property(e => e.DownTimeFromDate).HasColumnType("datetime");
            entity.Property(e => e.DownTimeToDate).HasColumnType("datetime");
            entity.Property(e => e.EstimatedCost).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.EstimatedCostCurr)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EstimatedEffortUnit).HasMaxLength(50);
            entity.Property(e => e.Gxpplant)
                .HasMaxLength(10)
                .HasColumnName("gxpplant");
            entity.Property(e => e.ImactedFunc).HasMaxLength(50);
            entity.Property(e => e.ImpactNotDoing)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ImpactedDept).HasMaxLength(50);
            entity.Property(e => e.ImpactedLocation).HasMaxLength(50);
            entity.Property(e => e.InitiatedFor).HasMaxLength(1202);
            entity.Property(e => e.IsApproved).HasColumnName("isApproved");
            entity.Property(e => e.IsReleased).HasColumnName("isReleased");
            entity.Property(e => e.ItcategoryId).HasColumnName("ITCategoryID");
            entity.Property(e => e.ItclassificationId).HasColumnName("ITClassificationID");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.NatureofChange).HasMaxLength(500);
            entity.Property(e => e.PlantCode).HasMaxLength(10);
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.ReasonForChange)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceName).HasMaxLength(50);
            entity.Property(e => e.ReferenceType).HasMaxLength(50);
            entity.Property(e => e.RequestorPlant).HasMaxLength(10);
            entity.Property(e => e.RollbackPlan)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.TriggeredBy)
                .HasMaxLength(2000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwChecklist>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Checklist", "IT");

            entity.Property(e => e.ApproverId).HasColumnName("ApproverID");
            entity.Property(e => e.Approvername).HasMaxLength(1101);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ChecklistDesc).HasMaxLength(1500);
            entity.Property(e => e.ChecklistTitle).HasMaxLength(150);
            entity.Property(e => e.ClassificationId).HasColumnName("ClassificationID");
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.ItchecklistId).HasColumnName("ITChecklistID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.Plantname)
                .HasMaxLength(10)
                .HasColumnName("plantname");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<VwCrclosure>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CRClosure", "IT");

            entity.Property(e => e.ClosedDt).HasColumnType("datetime");
            entity.Property(e => e.ClosedStatus).HasMaxLength(150);
            entity.Property(e => e.Itcrid)
                .ValueGeneratedOnAdd()
                .HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
        });

        modelBuilder.Entity<VwCremail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CREmail", "IT");

            entity.Property(e => e.ApprovedByRemarks)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ApprovedByStage)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ApprovedByStatus)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ApprovedDt).HasColumnType("datetime");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ChangeDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Crapprover11C)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover11C");
            entity.Property(e => e.Crapprover11Cemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover11CEmail");
            entity.Property(e => e.Crapprover11CempId).HasColumnName("CRApprover11CEmpID");
            entity.Property(e => e.Crapprover11N)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover11N");
            entity.Property(e => e.Crapprover11Nemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover11NEmail");
            entity.Property(e => e.Crapprover11NempId).HasColumnName("CRApprover11NEmpID");
            entity.Property(e => e.Crapprover11R)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover11R");
            entity.Property(e => e.Crapprover11Remail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover11REmail");
            entity.Property(e => e.Crapprover11RempId).HasColumnName("CRApprover11REmpID");
            entity.Property(e => e.Crapprover12C)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover12C");
            entity.Property(e => e.Crapprover12Cemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover12CEmail");
            entity.Property(e => e.Crapprover12CempId).HasColumnName("CRApprover12CEmpID");
            entity.Property(e => e.Crapprover12N)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover12N");
            entity.Property(e => e.Crapprover12Nemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover12NEmail");
            entity.Property(e => e.Crapprover12NempId).HasColumnName("CRApprover12NEmpID");
            entity.Property(e => e.Crapprover12R)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover12R");
            entity.Property(e => e.Crapprover12Remail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover12REmail");
            entity.Property(e => e.Crapprover12RempId).HasColumnName("CRApprover12REmpID");
            entity.Property(e => e.Crapprover13C)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover13C");
            entity.Property(e => e.Crapprover13Cemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover13CEmail");
            entity.Property(e => e.Crapprover13CempId).HasColumnName("CRApprover13CEmpID");
            entity.Property(e => e.Crapprover13N)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover13N");
            entity.Property(e => e.Crapprover13Nemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover13NEmail");
            entity.Property(e => e.Crapprover13NempId).HasColumnName("CRApprover13NEmpID");
            entity.Property(e => e.Crapprover13R)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover13R");
            entity.Property(e => e.Crapprover13Remail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover13REmail");
            entity.Property(e => e.Crapprover13RempId).HasColumnName("CRApprover13REmpID");
            entity.Property(e => e.Crapprover21C)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover21C");
            entity.Property(e => e.Crapprover21Cemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover21CEmail");
            entity.Property(e => e.Crapprover21CempId).HasColumnName("CRApprover21CEmpID");
            entity.Property(e => e.Crapprover21N)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover21N");
            entity.Property(e => e.Crapprover21Nemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover21NEmail");
            entity.Property(e => e.Crapprover21NempId).HasColumnName("CRApprover21NEmpID");
            entity.Property(e => e.Crapprover21R)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover21R");
            entity.Property(e => e.Crapprover21Remail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover21REmail");
            entity.Property(e => e.Crapprover21RempId).HasColumnName("CRApprover21REmpID");
            entity.Property(e => e.Crapprover22C)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover22C");
            entity.Property(e => e.Crapprover22Cemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover22CEmail");
            entity.Property(e => e.Crapprover22CempId).HasColumnName("CRApprover22CEmpID");
            entity.Property(e => e.Crapprover22N)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover22N");
            entity.Property(e => e.Crapprover22Nemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover22NEmail");
            entity.Property(e => e.Crapprover22NempId).HasColumnName("CRApprover22NEmpID");
            entity.Property(e => e.Crapprover22R)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover22R");
            entity.Property(e => e.Crapprover22Remail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover22REmail");
            entity.Property(e => e.Crapprover22RempId).HasColumnName("CRApprover22REmpID");
            entity.Property(e => e.Crapprover23C)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover23C");
            entity.Property(e => e.Crapprover23Cemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover23CEmail");
            entity.Property(e => e.Crapprover23CempId).HasColumnName("CRApprover23CEmpID");
            entity.Property(e => e.Crapprover23N)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover23N");
            entity.Property(e => e.Crapprover23Nemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover23NEmail");
            entity.Property(e => e.Crapprover23NempId).HasColumnName("CRApprover23NEmpID");
            entity.Property(e => e.Crapprover23R)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover23R");
            entity.Property(e => e.Crapprover23Remail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover23REmail");
            entity.Property(e => e.Crapprover23RempId).HasColumnName("CRApprover23REmpID");
            entity.Property(e => e.Crapprover31C)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover31C");
            entity.Property(e => e.Crapprover31Cemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover31CEmail");
            entity.Property(e => e.Crapprover31CempId).HasColumnName("CRApprover31CEmpID");
            entity.Property(e => e.Crapprover31N)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover31N");
            entity.Property(e => e.Crapprover31Nemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover31NEmail");
            entity.Property(e => e.Crapprover31NempId).HasColumnName("CRApprover31NEmpID");
            entity.Property(e => e.Crapprover31R)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover31R");
            entity.Property(e => e.Crapprover31Remail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover31REmail");
            entity.Property(e => e.Crapprover31RempId).HasColumnName("CRApprover31REmpID");
            entity.Property(e => e.Crapprover32C)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover32C");
            entity.Property(e => e.Crapprover32Cemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover32CEmail");
            entity.Property(e => e.Crapprover32CempId).HasColumnName("CRApprover32CEmpID");
            entity.Property(e => e.Crapprover32N)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover32N");
            entity.Property(e => e.Crapprover32Nemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover32NEmail");
            entity.Property(e => e.Crapprover32NempId).HasColumnName("CRApprover32NEmpID");
            entity.Property(e => e.Crapprover32R)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover32R");
            entity.Property(e => e.Crapprover32Remail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover32REmail");
            entity.Property(e => e.Crapprover32RempId).HasColumnName("CRApprover32REmpID");
            entity.Property(e => e.Crapprover33C)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover33C");
            entity.Property(e => e.Crapprover33Cemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover33CEmail");
            entity.Property(e => e.Crapprover33CempId).HasColumnName("CRApprover33CEmpID");
            entity.Property(e => e.Crapprover33N)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover33N");
            entity.Property(e => e.Crapprover33Nemail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover33NEmail");
            entity.Property(e => e.Crapprover33NempId).HasColumnName("CRApprover33NEmpID");
            entity.Property(e => e.Crapprover33R)
                .HasMaxLength(1202)
                .HasColumnName("CRApprover33R");
            entity.Property(e => e.Crapprover33Remail)
                .HasMaxLength(100)
                .HasColumnName("CRApprover33REmail");
            entity.Property(e => e.Crapprover33RempId).HasColumnName("CRApprover33REmpID");
            entity.Property(e => e.CrapproverBy)
                .HasMaxLength(1202)
                .HasColumnName("CRApproverBy");
            entity.Property(e => e.CrapproverByEmail)
                .HasMaxLength(100)
                .HasColumnName("CRApproverByEmail");
            entity.Property(e => e.CrapproverByEmpId).HasColumnName("CRApproverByEmpID");
            entity.Property(e => e.Crcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CRCode");
            entity.Property(e => e.Crdate)
                .HasColumnType("datetime")
                .HasColumnName("CRDate");
            entity.Property(e => e.Criemail)
                .HasMaxLength(100)
                .HasColumnName("CRIEmail");
            entity.Property(e => e.Criempid).HasColumnName("CRIEmpid");
            entity.Property(e => e.Crinitiator)
                .HasMaxLength(1202)
                .HasColumnName("CRInitiator");
            entity.Property(e => e.Croemail)
                .HasMaxLength(100)
                .HasColumnName("CROEmail");
            entity.Property(e => e.Croempid).HasColumnName("CROEmpid");
            entity.Property(e => e.Crowner)
                .HasMaxLength(1202)
                .HasColumnName("CROwner");
            entity.Property(e => e.Crremail)
                .HasMaxLength(100)
                .HasColumnName("CRREmail");
            entity.Property(e => e.Crrempid).HasColumnName("CRREmpid");
            entity.Property(e => e.CrrequestedBy)
                .HasMaxLength(1202)
                .HasColumnName("CRRequestedBy");
            entity.Property(e => e.Crstatus)
                .HasMaxLength(50)
                .HasColumnName("CRStatus");
            entity.Property(e => e.IsApproved).HasColumnName("isApproved");
            entity.Property(e => e.IsImplemented).HasColumnName("isImplemented");
            entity.Property(e => e.IsReleased).HasColumnName("isReleased");
            entity.Property(e => e.IsSubmitted).HasColumnName("isSubmitted");
            entity.Property(e => e.ItcategoryId).HasColumnName("ITCategoryID");
            entity.Property(e => e.ItclassificationId).HasColumnName("ITClassificationID");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.Plantcode).HasColumnName("plantcode");
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
        });

        modelBuilder.Entity<VwCrfollowup>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CRFollowup", "IT");

            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CrfollowupId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CRFollowupID");
            entity.Property(e => e.FollowupDt).HasColumnType("datetime");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
        });

        modelBuilder.Entity<VwCrlesson>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CRLesson", "IT");

            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CrlessonId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CRLessonID");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.LessonDt).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
        });

        modelBuilder.Entity<VwCrrelease>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CRRelease", "IT");

            entity.Property(e => e.ApprovedDt).HasColumnType("datetime");
            entity.Property(e => e.Attachments).HasMaxLength(500);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CrreleaseId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CRReleaseID");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.ReleaseDt).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<VwCrtaskEmail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CRTaskEmail", "IT");

            entity.Property(e => e.AssgnDesignation).HasMaxLength(100);
            entity.Property(e => e.AssgnEmail).HasMaxLength(100);
            entity.Property(e => e.AssgnRole).HasMaxLength(100);
            entity.Property(e => e.AssignedDt).HasMaxLength(4000);
            entity.Property(e => e.AssignedToName).HasMaxLength(1202);
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ChangeDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Crcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CRCode");
            entity.Property(e => e.Crdate)
                .HasMaxLength(4000)
                .HasColumnName("CRDate");
            entity.Property(e => e.Cridesignation)
                .HasMaxLength(100)
                .HasColumnName("CRIDesignation");
            entity.Property(e => e.Criemail)
                .HasMaxLength(100)
                .HasColumnName("CRIEmail");
            entity.Property(e => e.Criempid).HasColumnName("CRIEmpid");
            entity.Property(e => e.Crinitiator)
                .HasMaxLength(1202)
                .HasColumnName("CRInitiator");
            entity.Property(e => e.Crirole)
                .HasMaxLength(100)
                .HasColumnName("CRIRole");
            entity.Property(e => e.Crodesignation)
                .HasMaxLength(100)
                .HasColumnName("CRODesignation");
            entity.Property(e => e.Croemail)
                .HasMaxLength(100)
                .HasColumnName("CROEmail");
            entity.Property(e => e.Croempid).HasColumnName("CROEmpid");
            entity.Property(e => e.Crorole)
                .HasMaxLength(100)
                .HasColumnName("CRORole");
            entity.Property(e => e.Crowner)
                .HasMaxLength(1202)
                .HasColumnName("CROwner");
            entity.Property(e => e.Crrdesignation)
                .HasMaxLength(100)
                .HasColumnName("CRRDesignation");
            entity.Property(e => e.Crremail)
                .HasMaxLength(100)
                .HasColumnName("CRREmail");
            entity.Property(e => e.Crrempid).HasColumnName("CRREmpid");
            entity.Property(e => e.Crrequestor)
                .HasMaxLength(1202)
                .HasColumnName("CRRequestor");
            entity.Property(e => e.Crrrole)
                .HasMaxLength(100)
                .HasColumnName("CRRRole");
            entity.Property(e => e.Estatus)
                .HasMaxLength(50)
                .HasColumnName("EStatus");
            entity.Property(e => e.ForwardToDesignation).HasMaxLength(100);
            entity.Property(e => e.ForwardToEmail).HasMaxLength(100);
            entity.Property(e => e.ForwardToName).HasMaxLength(1202);
            entity.Property(e => e.ForwardToRole).HasMaxLength(100);
            entity.Property(e => e.ItcategoryId).HasColumnName("ITCategoryID");
            entity.Property(e => e.ItclassificationId).HasColumnName("ITClassificationID");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.PickedDt).HasMaxLength(4000);
            entity.Property(e => e.PickedStatus).HasMaxLength(50);
            entity.Property(e => e.Plantcode).HasColumnName("plantcode");
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.TaskDesc).HasMaxLength(2000);
            entity.Property(e => e.TaskId).HasColumnName("TaskID");
        });

        modelBuilder.Entity<VwCrtemplate>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CRTemplate", "IT");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.CrtemplateDtlsId).HasColumnName("CRTemplateDtlsID");
            entity.Property(e => e.CrtemplateId).HasColumnName("CRTemplateID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.SysLandscapeId).HasColumnName("SysLandscapeID");
            entity.Property(e => e.TaskDesc).HasMaxLength(2000);
            entity.Property(e => e.TaskName).HasMaxLength(500);
            entity.Property(e => e.TemplateName)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwDepartmentHead>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_DepartmentHead");

            entity.Property(e => e.Department)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Designation).HasMaxLength(100);
            entity.Property(e => e.FirstName)
                .HasMaxLength(1000)
                .HasColumnName("First_Name");
            entity.Property(e => e.Paygroup).HasMaxLength(100);
            entity.Property(e => e.Plant).HasMaxLength(10);
        });

        modelBuilder.Entity<VwDepartmentMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_DepartmentMaster", "IT");

            entity.Property(e => e.Description)
                .HasMaxLength(600)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VwDepartmentPlantlist>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_DepartmentPlantlist");

            entity.Property(e => e.Plant).HasMaxLength(10);
        });

        modelBuilder.Entity<VwEmployeeDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_EmployeeDetails", "IT");

            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.DateOfLeaving).HasColumnType("datetime");
            entity.Property(e => e.Department)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeName).HasMaxLength(1502);
            entity.Property(e => e.OfficialEmailId).HasMaxLength(50);
            entity.Property(e => e.PayGroup).HasMaxLength(200);
            entity.Property(e => e.Plantcode).HasMaxLength(10);
            entity.Property(e => e.ReportManagerName).HasMaxLength(1202);
            entity.Property(e => e.Role).HasMaxLength(80);
            entity.Property(e => e.StaffCategory).HasMaxLength(50);
            entity.Property(e => e.TelephoneNo).HasMaxLength(20);
        });

        modelBuilder.Entity<VwEmployeeMaster>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_EmployeeMaster", "IT");

            entity.Property(e => e.Department)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Designation).HasMaxLength(100);
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Dol)
                .HasColumnType("datetime")
                .HasColumnName("DOL");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(10)
                .HasColumnName("Employee_ID");
            entity.Property(e => e.EmployeeName).HasMaxLength(1202);
            entity.Property(e => e.FirstName)
                .HasMaxLength(1000)
                .HasColumnName("First_Name");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(200)
                .HasColumnName("Img_Url");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.PayGroup).HasMaxLength(200);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.Plantcode).HasMaxLength(10);
            entity.Property(e => e.ReportManagerName).HasMaxLength(1202);
            entity.Property(e => e.Role).HasMaxLength(80);
            entity.Property(e => e.StaffCategory).HasMaxLength(50);
        });

        modelBuilder.Entity<VwExecPlan>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ExecPlan", "IT");

            entity.Property(e => e.ActualEndDt).HasColumnType("datetime");
            entity.Property(e => e.ActualStartDt).HasColumnType("datetime");
            entity.Property(e => e.AssignedTo).HasMaxLength(1203);
            entity.Property(e => e.Assignedtoid).HasColumnName("assignedtoid");
            entity.Property(e => e.Attachments).HasMaxLength(500);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.DependSyelanscape).HasMaxLength(50);
            entity.Property(e => e.DependTaskId).HasColumnName("DependTaskID");
            entity.Property(e => e.Depndtask)
                .HasMaxLength(500)
                .HasColumnName("depndtask");
            entity.Property(e => e.EndDt)
                .HasColumnType("datetime")
                .HasColumnName("EndDT");
            entity.Property(e => e.ExecutionStepDesc).HasMaxLength(2000);
            entity.Property(e => e.ExecutionStepName).HasMaxLength(500);
            entity.Property(e => e.ForwardedDt).HasColumnType("datetime");
            entity.Property(e => e.ForwardedTo).HasMaxLength(1202);
            entity.Property(e => e.Forwardedtoid).HasColumnName("forwardedtoid");
            entity.Property(e => e.ItcrexecId).HasColumnName("ITCRExecID");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PickedDt).HasColumnType("datetime");
            entity.Property(e => e.PickedStatus).HasMaxLength(50);
            entity.Property(e => e.ReasonForwarded).HasMaxLength(500);
            entity.Property(e => e.Remarks).HasMaxLength(2000);
            entity.Property(e => e.StartDt).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Sylandscape)
                .HasMaxLength(50)
                .HasColumnName("sylandscape");
        });

        modelBuilder.Entity<VwHead>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_Heads");

            entity.Property(e => e.Designation).HasMaxLength(100);
            entity.Property(e => e.Division).HasMaxLength(100);
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.FirstName)
                .HasMaxLength(1000)
                .HasColumnName("First_Name");
            entity.Property(e => e.Group).HasMaxLength(100);
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        modelBuilder.Entity<VwIssueList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_IssueList", "IT");

            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.AssignedBy).HasMaxLength(1202);
            entity.Property(e => e.AssignedOn).HasColumnType("datetime");
            entity.Property(e => e.AssignedTo).HasMaxLength(1200);
            entity.Property(e => e.Assignedbyid).HasColumnName("assignedbyid");
            entity.Property(e => e.Attachment).HasMaxLength(100);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.CategoryType).HasMaxLength(500);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.GuestCompany).HasMaxLength(500);
            entity.Property(e => e.IssueCode).HasMaxLength(50);
            entity.Property(e => e.IssueDate).HasColumnType("datetime");
            entity.Property(e => e.IssueDesc).HasMaxLength(2000);
            entity.Property(e => e.IssueForGuest).HasMaxLength(500);
            entity.Property(e => e.IssueId).HasColumnName("IssueID");
            entity.Property(e => e.IssueShotDesc).HasMaxLength(200);
            entity.Property(e => e.Issuerisedby)
                .HasMaxLength(1101)
                .HasColumnName("issuerisedby");
            entity.Property(e => e.Issuerisedfor)
                .HasMaxLength(1101)
                .HasColumnName("issuerisedfor");
            entity.Property(e => e.Issuerisedforid).HasColumnName("issuerisedforid");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.Plantname)
                .HasMaxLength(10)
                .HasColumnName("plantname");
            entity.Property(e => e.PriorityName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Priorityid).HasColumnName("priorityid");
            entity.Property(e => e.ProposedResolutionOn).HasColumnType("datetime");
            entity.Property(e => e.Raisedbyid).HasColumnName("raisedbyid");
            entity.Property(e => e.Remarks).HasMaxLength(3000);
            entity.Property(e => e.ResolutionDt).HasColumnType("datetime");
            entity.Property(e => e.ResolutionRemarks).HasMaxLength(3000);
            entity.Property(e => e.Slastatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("slastatus");
            entity.Property(e => e.Source).HasMaxLength(100);
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<VwIssueListHistory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_IssueListHistory", "IT");

            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.AssignedBy).HasMaxLength(1202);
            entity.Property(e => e.AssignedOn).HasColumnType("datetime");
            entity.Property(e => e.AssignedTo).HasMaxLength(1200);
            entity.Property(e => e.Assignedbyid).HasColumnName("assignedbyid");
            entity.Property(e => e.Attachment).HasMaxLength(100);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CategoryTypId).HasColumnName("CategoryTypID");
            entity.Property(e => e.CategoryType).HasMaxLength(500);
            entity.Property(e => e.CreatedDt).HasColumnType("datetime");
            entity.Property(e => e.GuestCompany).HasMaxLength(500);
            entity.Property(e => e.IssueCode).HasMaxLength(50);
            entity.Property(e => e.IssueDate).HasColumnType("datetime");
            entity.Property(e => e.IssueDesc).HasMaxLength(2000);
            entity.Property(e => e.IssueForGuest).HasMaxLength(500);
            entity.Property(e => e.IssueId).HasColumnName("IssueID");
            entity.Property(e => e.IssueShotDesc).HasMaxLength(200);
            entity.Property(e => e.Issuerisedby)
                .HasMaxLength(1101)
                .HasColumnName("issuerisedby");
            entity.Property(e => e.Issuerisedfor)
                .HasMaxLength(1101)
                .HasColumnName("issuerisedfor");
            entity.Property(e => e.Issuerisedforid).HasColumnName("issuerisedforid");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.Plantname)
                .HasMaxLength(10)
                .HasColumnName("plantname");
            entity.Property(e => e.PriorityName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Priorityid).HasColumnName("priorityid");
            entity.Property(e => e.ProposedResolutionOn).HasColumnType("datetime");
            entity.Property(e => e.Raisedbyid).HasColumnName("raisedbyid");
            entity.Property(e => e.Remarks).HasMaxLength(3000);
            entity.Property(e => e.ResolutionDt).HasColumnType("datetime");
            entity.Property(e => e.ResolutionRemarks).HasMaxLength(3000);
            entity.Property(e => e.Slastatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("slastatus");
            entity.Property(e => e.Source).HasMaxLength(100);
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<VwNatureofChange>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_NatureofChange", "IT");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.NatureofChange).HasMaxLength(500);
            entity.Property(e => e.NatureofChangeId).HasColumnName("NatureofChangeID");
        });

        modelBuilder.Entity<VwNewtest>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_newtest");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FkEmpId).HasColumnName("FK_Emp_Id");
            entity.Property(e => e.FkPlantId).HasColumnName("FK_PlantId");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<VwRptcrexecPlan>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_RPTCRExecPlan", "IT");

            entity.Property(e => e.ActualEndDt).HasColumnType("datetime");
            entity.Property(e => e.ActualStartDt).HasColumnType("datetime");
            entity.Property(e => e.AssignedTo).HasMaxLength(1101);
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CategoryType).HasMaxLength(500);
            entity.Property(e => e.CategoryTypeId).HasColumnName("CategoryTypeID");
            entity.Property(e => e.ChangeDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Crcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CRCode");
            entity.Property(e => e.Crdate)
                .HasColumnType("datetime")
                .HasColumnName("CRDate");
            entity.Property(e => e.Crowner)
                .HasMaxLength(1000)
                .HasColumnName("CROwner");
            entity.Property(e => e.DependSyelanscape).HasMaxLength(50);
            entity.Property(e => e.Depndtask)
                .HasMaxLength(2000)
                .HasColumnName("depndtask");
            entity.Property(e => e.EndDt)
                .HasColumnType("datetime")
                .HasColumnName("EndDT");
            entity.Property(e => e.ForwardedTo).HasMaxLength(1101);
            entity.Property(e => e.ItcategoryId).HasColumnName("ITCategoryID");
            entity.Property(e => e.ItclassificationId).HasColumnName("ITClassificationID");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.NatureofChange).HasMaxLength(500);
            entity.Property(e => e.PlantId).HasColumnName("plantId");
            entity.Property(e => e.Plantstartdate)
                .HasColumnType("datetime")
                .HasColumnName("plantstartdate");
            entity.Property(e => e.PriorityName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.Supportname).HasMaxLength(1101);
            entity.Property(e => e.SysLandscape).HasMaxLength(50);
            entity.Property(e => e.TaskId).HasColumnName("TaskID");
        });

        modelBuilder.Entity<VwServiceCitrix>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ServiceCitrix", "IT");

            entity.Property(e => e.ServiceCitrixId).HasColumnName("ServiceCitrixID");
            entity.Property(e => e.ServiceCode).HasMaxLength(50);
            entity.Property(e => e.ShotDesc).HasMaxLength(200);
            entity.Property(e => e.Srdate)
                .HasColumnType("datetime")
                .HasColumnName("SRDate");
            entity.Property(e => e.Srdesc)
                .HasMaxLength(2000)
                .HasColumnName("SRDesc");
            entity.Property(e => e.SrraiseFor)
                .HasMaxLength(1200)
                .HasColumnName("SRRaiseFor");
            entity.Property(e => e.SrraiseForid).HasColumnName("SRRaiseForid");
        });

        modelBuilder.Entity<VwSupportEngineer>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_SupportEngineer ", "IT");

            entity.Property(e => e.Assgigntome).HasColumnName("assgigntome");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ChangeDesc)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Crcode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CRCode");
            entity.Property(e => e.Crdate)
                .HasColumnType("datetime")
                .HasColumnName("CRDate");
            entity.Property(e => e.Crowner)
                .HasMaxLength(1202)
                .HasColumnName("CROwner");
            entity.Property(e => e.CrrequestedBy).HasColumnName("CRRequestedBy");
            entity.Property(e => e.CrrequestorName)
                .HasMaxLength(1202)
                .HasColumnName("CRRequestorName");
            entity.Property(e => e.EstimatedCost).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.EstimatedCostCurr)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.IsApproved).HasColumnName("isApproved");
            entity.Property(e => e.IsImplemented).HasColumnName("isImplemented");
            entity.Property(e => e.IsReleased).HasColumnName("isReleased");
            entity.Property(e => e.IsSubmitted).HasColumnName("isSubmitted");
            entity.Property(e => e.ItcategoryId).HasColumnName("ITCategoryID");
            entity.Property(e => e.ItclassificationId).HasColumnName("ITClassificationID");
            entity.Property(e => e.ItcrexecId).HasColumnName("ITCRExecID");
            entity.Property(e => e.Itcrid).HasColumnName("ITCRID");
            entity.Property(e => e.ModifiedDt).HasColumnType("datetime");
            entity.Property(e => e.PlantId)
                .HasMaxLength(10)
                .HasColumnName("PlantID");
            entity.Property(e => e.Plantcode).HasColumnName("plantcode");
            entity.Property(e => e.Stage).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.Taskcount).HasColumnName("taskcount");
            entity.Property(e => e.Taskstatus).HasMaxLength(50);
        });

        modelBuilder.Entity<VwSupportTeamAll>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_SupportTeamAll ", "IT");

            entity.Property(e => e.Approverstage).HasMaxLength(50);
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ClassificationId).HasColumnName("ClassificationID");
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Designation).HasMaxLength(100);
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Dol)
                .HasColumnType("datetime")
                .HasColumnName("DOL");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(1000)
                .HasColumnName("First_Name");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(200)
                .HasColumnName("Img_Url");
            entity.Property(e => e.IsApprover).HasColumnName("isApprover");
            entity.Property(e => e.Isadmin).HasColumnName("isadmin");
            entity.Property(e => e.Ischangeanalyst).HasColumnName("ischangeanalyst");
            entity.Property(e => e.Issupportengineer).HasColumnName("issupportengineer");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.SupportName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SupportTeamAssgnId).HasColumnName("SupportTeamAssgnID");
            entity.Property(e => e.SupportTeamId).HasColumnName("SupportTeamID");
        });

        modelBuilder.Entity<VwSupportTeamDtl>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_SupportTeamDtls ", "IT");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CategoryTypeId).HasColumnName("CategoryTypeID");
            entity.Property(e => e.ClassificationId).HasColumnName("ClassificationID");
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.Designation).HasMaxLength(100);
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Dol)
                .HasColumnType("datetime")
                .HasColumnName("DOL");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.EmpId).HasColumnName("EmpID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(1000)
                .HasColumnName("First_Name");
            entity.Property(e => e.ImgUrl)
                .HasMaxLength(200)
                .HasColumnName("Img_Url");
            entity.Property(e => e.IsApprover).HasColumnName("isApprover");
            entity.Property(e => e.Isadmin).HasColumnName("isadmin");
            entity.Property(e => e.Ischangeanalyst).HasColumnName("ischangeanalyst");
            entity.Property(e => e.Issupportengineer).HasColumnName("issupportengineer");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .HasColumnName("Middle_Name");
            entity.Property(e => e.PlantId).HasColumnName("PlantID");
            entity.Property(e => e.Role).HasMaxLength(100);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.SupportName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SupportTeamAssgnId).HasColumnName("SupportTeamAssgnID");
            entity.Property(e => e.SupportTeamId).HasColumnName("SupportTeamID");
        });

        modelBuilder.Entity<VwSystemlandscape>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Systemlandscape", "IT");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ClassificationId).HasColumnName("ClassificationID");
            entity.Property(e => e.ClassificationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.PriorityName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.SupportId).HasColumnName("SupportID");
            entity.Property(e => e.SysLandscape).HasMaxLength(50);
            entity.Property(e => e.SysLandscapeId).HasColumnName("SysLandscapeID");
        });

        modelBuilder.Entity<WeightUom>(entity =>
        {
            entity.ToTable("WEIGHT_UOM");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastModifiedBy).HasMaxLength(50);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.WUomCode)
                .HasMaxLength(50)
                .HasColumnName("W_UOM_CODE");
            entity.Property(e => e.WUomDesc)
                .HasMaxLength(100)
                .HasColumnName("W_UOM_DESC");
        });

        modelBuilder.Entity<WorkFlowApprover>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Item_Code_Approvers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApproverId)
                .HasMaxLength(100)
                .HasColumnName("Approver_Id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Dept).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.KeyValue).HasMaxLength(200);
            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.ParllelApprover1)
                .HasMaxLength(100)
                .HasColumnName("Parllel_Approver_1");
            entity.Property(e => e.ParllelApprover2)
                .HasMaxLength(100)
                .HasColumnName("Parllel_Approver_2");
            entity.Property(e => e.ParllelApprover3)
                .HasMaxLength(100)
                .HasColumnName("Parllel_Approver_3");
            entity.Property(e => e.ParllelApprover4)
                .HasMaxLength(100)
                .HasColumnName("Parllel_Approver_4");
            entity.Property(e => e.ParllelApprover5)
                .HasMaxLength(100)
                .HasColumnName("Parllel_Approver_5");
            entity.Property(e => e.Role).HasMaxLength(100);

            entity.HasOne(d => d.Process).WithMany(p => p.WorkFlowApprovers)
                .HasForeignKey(d => d.ProcessId)
                .HasConstraintName("FK_WorkFlowApprovers_WorkFlowProcess");
        });

        modelBuilder.Entity<WorkType>(entity =>
        {
            entity.ToTable("WorkType");

            entity.Property(e => e.CreatedBy).HasMaxLength(20);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(20);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.WorkTypeLongDesc)
                .HasMaxLength(100)
                .HasColumnName("WorkType_LongDesc");
            entity.Property(e => e.WorkTypeShortDesc)
                .HasMaxLength(100)
                .HasColumnName("WorkType_ShortDesc");
        });

        modelBuilder.Entity<WorkingCalendar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ML01CAL");

            entity.ToTable("WorkingCalendar");

            entity.Property(e => e.Apr)
                .HasMaxLength(50)
                .HasColumnName("APR");
            entity.Property(e => e.Aug)
                .HasMaxLength(50)
                .HasColumnName("AUG");
            entity.Property(e => e.Cyear).HasColumnName("CYEAR");
            entity.Property(e => e.Day).HasColumnName("DAY");
            entity.Property(e => e.Dec)
                .HasMaxLength(50)
                .HasColumnName("DEC");
            entity.Property(e => e.Feb)
                .HasMaxLength(50)
                .HasColumnName("FEB");
            entity.Property(e => e.HolidayTypeCode).HasMaxLength(100);
            entity.Property(e => e.Jan)
                .HasMaxLength(50)
                .HasColumnName("JAN");
            entity.Property(e => e.Jul)
                .HasMaxLength(50)
                .HasColumnName("JUL");
            entity.Property(e => e.Jun)
                .HasMaxLength(50)
                .HasColumnName("JUN");
            entity.Property(e => e.Mar)
                .HasMaxLength(50)
                .HasColumnName("MAR");
            entity.Property(e => e.May)
                .HasMaxLength(50)
                .HasColumnName("MAY");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Nov)
                .HasMaxLength(50)
                .HasColumnName("NOV");
            entity.Property(e => e.Oct)
                .HasMaxLength(50)
                .HasColumnName("OCT");
            entity.Property(e => e.Sep)
                .HasMaxLength(50)
                .HasColumnName("SEP");
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.TypeCode).HasMaxLength(50);
            entity.Property(e => e.TypeName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
