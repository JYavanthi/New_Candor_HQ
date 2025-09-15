namespace IT_Portal.Domain.IT_Models;

public partial class EmployeeMaster
{
    public int Id { get; set; }

    public string? EmployeeId { get; set; }

    public string? Email { get; set; }

    public int? FkAddressId { get; set; }

    public int? FkOtherDetailsId { get; set; }

    public int? FkProjectId { get; set; }

    public int? FkDesignation { get; set; }

    public int? FkCompetency { get; set; }

    public int? FkDepartment { get; set; }

    public int? FkReportingManager { get; set; }

    public int? FkManager { get; set; }

    public int? FkSbuId { get; set; }

    public int? FkParentId { get; set; }

    public int? FkParentIdCount { get; set; }

    public int? FkApprovalTemplateId { get; set; }

    public int? FkPayroll { get; set; }

    public int? FkProfileId { get; set; }

    public int? FkRoleId { get; set; }

    public string? BaseLocation { get; set; }

    public string? Description { get; set; }

    public int? Interviwer { get; set; }

    public DateTime? JoiningDate { get; set; }

    public string? RedirectUrl { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? ImgUrl { get; set; }

    public string? Designation { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? Dol { get; set; }

    public DateOnly? Dob { get; set; }

    public int? DesigRoleId { get; set; }

    public virtual ICollection<Allertbox> AllertboxCreatedBies { get; set; } = new List<Allertbox>();

    public virtual ICollection<Allertbox> AllertboxModifiedBies { get; set; } = new List<Allertbox>();

    public virtual ICollection<AppointmentOfficialDetail> AppointmentOfficialDetailApprovingManagers { get; set; } = new List<AppointmentOfficialDetail>();

    public virtual ICollection<AppointmentOfficialDetail> AppointmentOfficialDetailReportingManagers { get; set; } = new List<AppointmentOfficialDetail>();

    public virtual ICollection<AppointmentOfficialDetail> AppointmentOfficialDetailSignatories { get; set; } = new List<AppointmentOfficialDetail>();

    public virtual ICollection<ChecklistConfig> ChecklistConfigs { get; set; } = new List<ChecklistConfig>();

    public virtual ICollection<ChecklistItem> ChecklistItemCompletedBies { get; set; } = new List<ChecklistItem>();

    public virtual ICollection<ChecklistItem> ChecklistItemCreatedBies { get; set; } = new List<ChecklistItem>();

    public virtual ICollection<ChecklistItem> ChecklistItemModifiedBies { get; set; } = new List<ChecklistItem>();

    public virtual ICollection<ChecklistItem> ChecklistItemSpocemployees { get; set; } = new List<ChecklistItem>();

    public virtual ICollection<EmailNotificationMapping> EmailNotificationMappings { get; set; } = new List<EmailNotificationMapping>();

    public virtual ICollection<EmpCatMapping> EmpCatMappings { get; set; } = new List<EmpCatMapping>();

    public virtual ICollection<EmpPaygroupMapping> EmpPaygroupMappings { get; set; } = new List<EmpPaygroupMapping>();

    public virtual ICollection<Employee> EmployeeApprovingManagers { get; set; } = new List<Employee>();

    public virtual ICollection<EmployeeAttachment> EmployeeAttachments { get; set; } = new List<EmployeeAttachment>();

    public virtual ICollection<EmployeeConfirmation> EmployeeConfirmationCreatedBies { get; set; } = new List<EmployeeConfirmation>();

    public virtual ICollection<EmployeeConfirmation> EmployeeConfirmationHods { get; set; } = new List<EmployeeConfirmation>();

    public virtual ICollection<EmployeeConfirmation> EmployeeConfirmationModifiedBies { get; set; } = new List<EmployeeConfirmation>();

    public virtual ICollection<EmployeeConfirmation> EmployeeConfirmationSubmitedBies { get; set; } = new List<EmployeeConfirmation>();

    public virtual ICollection<Employee> EmployeeCreatedBies { get; set; } = new List<Employee>();

    public virtual ICollection<EmployeeDocument> EmployeeDocuments { get; set; } = new List<EmployeeDocument>();

    public virtual ICollection<EmployeeInitialAppraisalDetail> EmployeeInitialAppraisalDetailHods { get; set; } = new List<EmployeeInitialAppraisalDetail>();

    public virtual ICollection<EmployeeInitialAppraisalDetail> EmployeeInitialAppraisalDetailInitiatedBies { get; set; } = new List<EmployeeInitialAppraisalDetail>();

    public virtual ICollection<Employee> EmployeeModifiedBies { get; set; } = new List<Employee>();

    public virtual ICollection<Employee> EmployeeReportingManagers { get; set; } = new List<Employee>();

    public virtual ICollection<EmployeeRetirementDetail> EmployeeRetirementDetailCreatedBies { get; set; } = new List<EmployeeRetirementDetail>();

    public virtual ICollection<EmployeeRetirementDetail> EmployeeRetirementDetailModifiedBies { get; set; } = new List<EmployeeRetirementDetail>();

    public virtual ICollection<EmployeeTerminationDetail> EmployeeTerminationDetailCreatedBies { get; set; } = new List<EmployeeTerminationDetail>();

    public virtual ICollection<EmployeeTerminationDetail> EmployeeTerminationDetailModifiedBies { get; set; } = new List<EmployeeTerminationDetail>();

    public virtual ICollection<FileUpload> FileUploads { get; set; } = new List<FileUpload>();

    public virtual DesignationMaster? FkDesignationNavigation { get; set; }

    public virtual ProfileMaster? FkProfile { get; set; }

    public virtual SubRole? FkRole { get; set; }

    public virtual ICollection<MoreLink> MoreLinkCreatedBies { get; set; } = new List<MoreLink>();

    public virtual ICollection<MoreLink> MoreLinkModifiedBies { get; set; } = new List<MoreLink>();

    public virtual ICollection<OfferDetail> OfferDetailApprovingManagers { get; set; } = new List<OfferDetail>();

    public virtual ICollection<OfferDetail> OfferDetailReportingManagers { get; set; } = new List<OfferDetail>();

    public virtual ICollection<PrintTemplatePpcMapping> PrintTemplatePpcMappingCreatedBies { get; set; } = new List<PrintTemplatePpcMapping>();

    public virtual ICollection<PrintTemplatePpcMapping> PrintTemplatePpcMappingModifiedBies { get; set; } = new List<PrintTemplatePpcMapping>();

    public virtual ICollection<TaskManager> TaskManagerTaskAssignedByNavigations { get; set; } = new List<TaskManager>();

    public virtual ICollection<TaskManager> TaskManagerTaskAssignedToNavigations { get; set; } = new List<TaskManager>();

    public virtual ICollection<UserDeptMaintenance> UserDeptMaintenances { get; set; } = new List<UserDeptMaintenance>();

    public virtual ICollection<UserPlantMaintenance> UserPlantMaintenances { get; set; } = new List<UserPlantMaintenance>();
}
