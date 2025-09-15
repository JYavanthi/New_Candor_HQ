namespace IT_Portal.Domain.IT_Models;

public partial class AppointmentOfficialDetail
{
    public int AppointmentOfficialDetailsId { get; set; }

    public string? Title { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? Initial { get; set; }

    public int? CountryId { get; set; }

    public int? StateId { get; set; }

    public int? PlantId { get; set; }

    public int? PaygroupId { get; set; }

    public int? EmployeeCategoryid { get; set; }

    public int? LocationId { get; set; }

    public int? DesignationId { get; set; }

    public int? DepartmentId { get; set; }

    public int? RoleId { get; set; }

    public int? SubDepartmentId { get; set; }

    public int? ReportingGroupId { get; set; }

    public bool IsMetroCity { get; set; }

    public int CorrespondingAddressTypeId { get; set; }

    public DateTime? DateOfJoining { get; set; }

    public int ProbationPeriod { get; set; }

    public DateTime? DateOfConfirmation { get; set; }

    public int NoticePeriod { get; set; }

    public int ReportingManagerId { get; set; }

    public int ApprovingManagerId { get; set; }

    public string? OfficialEmailId { get; set; }

    public string? IsSharedEmailId { get; set; }

    public string? RoomOrBlock { get; set; }

    public string? Floor { get; set; }

    public string? Building { get; set; }

    public string? TelephoneNo { get; set; }

    public string? Extension { get; set; }

    public string MobileNo { get; set; } = null!;

    public int PrintTemplateId { get; set; }

    public int SignatoryId { get; set; }

    public string? Aolocation { get; set; }

    public int AppointmentId { get; set; }

    public virtual AppointmentPersonalDetail Appointment { get; set; } = null!;

    public virtual EmployeeMaster ApprovingManager { get; set; } = null!;

    public virtual AddrTypM CorrespondingAddressType { get; set; } = null!;

    public virtual Country? Country { get; set; }

    public virtual DesignationMaster? Designation { get; set; }

    public virtual EmpCategoryMaster? EmployeeCategory { get; set; }

    public virtual LocationMaster? Location { get; set; }

    public virtual PaygroupMaster? Paygroup { get; set; }

    public virtual PlantMaster? Plant { get; set; }

    public virtual PrintTemplate PrintTemplate { get; set; } = null!;

    public virtual EmployeeMaster ReportingManager { get; set; } = null!;

    public virtual RoleMaster? Role { get; set; }

    public virtual EmployeeMaster Signatory { get; set; } = null!;

    public virtual State? State { get; set; }

    public virtual SubDeptMaster? SubDepartment { get; set; }
}
