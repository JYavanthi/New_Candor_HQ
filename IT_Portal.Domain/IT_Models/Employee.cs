using System;
using System.Collections.Generic;

namespace IT_Portal.Persistence.IT_Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmployeeNo { get; set; } = null!;

    public DateTime? EmpNoGeneratedDate { get; set; }

    public string Status { get; set; } = null!;

    public string EmploymentType { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? Initial { get; set; }

    public int PlantId { get; set; }

    public int PaygroupId { get; set; }

    public int EmployeeCategoryid { get; set; }

    public int CountryId { get; set; }

    public int StateId { get; set; }

    public int LocationId { get; set; }

    public int DesignationId { get; set; }

    public int RoleId { get; set; }

    public int DepartmentId { get; set; }

    public int? SubDepartmentId { get; set; }

    public int? ReportingGroupId { get; set; }

    public int ReportingManagerId { get; set; }

    public int ApprovingManagerId { get; set; }

    public bool IsMetroCity { get; set; }

    public int CorrespondingAddressTypeId { get; set; }

    public DateTime DateOfJoining { get; set; }

    public int ProbationPeriod { get; set; }

    public DateTime DateOfConfirmation { get; set; }

    public int NoticePeriod { get; set; }

    public string? OfficialEmailId { get; set; }

    public string? IsSharedEmailId { get; set; }

    public string? RoomOrBlock { get; set; }

    public string? Floor { get; set; }

    public string? Building { get; set; }

    public string? TelephoneNo { get; set; }

    public string? Extension { get; set; }

    public string? MobileNo { get; set; }

    public decimal? CurrentCtc { get; set; }

    public string? PersonalEmailId { get; set; }

    public bool Active { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? CurrentResponsibilities { get; set; }

    public DateTime? DateOfLeaving { get; set; }

    public string? LeavingType { get; set; }

    public string? CurrentYearKra { get; set; }

    public DateTime? DateOfResignation { get; set; }

    public bool? BulkUpdateDataPushToSap { get; set; }

    public bool? ProfileUpdateDataPushToSap { get; set; }

    public DateTime? ApprenticeCompletionDate { get; set; }

    public int? JobProfileId { get; set; }

    public int? LeavingTypeId { get; set; }

    public int? ContractorId { get; set; }

    public int CreatedById { get; set; }

    public DateTime CreatedDate { get; set; }

    public int ModifiedById { get; set; }

    public DateTime ModifiedDate { get; set; }
}
