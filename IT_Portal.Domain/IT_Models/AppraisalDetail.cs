namespace IT_Portal.Domain.IT_Models;

public partial class AppraisalDetail
{
    public int Id { get; set; }

    public int? FkEmpId { get; set; }

    public string? EmployeeId { get; set; }

    public int? FkCalenderId { get; set; }

    public int? FkManagerId { get; set; }

    public int? FkRecommendationDesignation { get; set; }

    public int? FkAssesmentId { get; set; }

    public int? RecommendationHike { get; set; }

    public int? FixedHike { get; set; }

    public int? VariableHike { get; set; }

    public int? VariableIncentive { get; set; }

    public string? Comments { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public string? SbuComments { get; set; }

    public string? ManagerComments { get; set; }

    public string? CompentcyComments { get; set; }

    public string? ManagementComments { get; set; }

    public string? Temp { get; set; }

    public string? Temp10 { get; set; }

    public string? Temp9 { get; set; }

    public string? Temp8 { get; set; }

    public string? Temp7 { get; set; }

    public string? Temp6 { get; set; }

    public string? Temp5 { get; set; }

    public string? Temp4 { get; set; }

    public string? Temp3 { get; set; }

    public string? Temp2 { get; set; }

    public string? Temp1 { get; set; }

    public virtual AssesmentMaster? FkAssesment { get; set; }

    public virtual CalendarMaster? FkCalender { get; set; }
}
