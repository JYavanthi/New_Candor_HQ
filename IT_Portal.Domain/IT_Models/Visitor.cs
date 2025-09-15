namespace IT_Portal.Domain.IT_Models;

public partial class Visitor
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? FkEmployeeId { get; set; }

    public string? FkEmployeeName { get; set; }

    public string? EmployeeEmail { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }

    public string? CompanyName { get; set; }

    public string? OtherInformation { get; set; }

    public bool? IsCancelled { get; set; }

    public string? Purpose { get; set; }

    public DateTime? Date { get; set; }

    public TimeOnly? ToTime { get; set; }

    public TimeOnly? FromTime { get; set; }

    public bool? IsApproved { get; set; }

    public bool? IsPreShedualled { get; set; }

    public int? NumberOfPerson { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public string? Temp { get; set; }

    public string? Temp19 { get; set; }

    public string? Temp18 { get; set; }

    public string? Temp17 { get; set; }

    public string? Temp16 { get; set; }

    public string? Temp15 { get; set; }

    public string? Temp14 { get; set; }

    public string? Temp13 { get; set; }

    public string? Temp12 { get; set; }

    public string? Temp11 { get; set; }

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

    public DateTime? EndDateTime { get; set; }

    public int? FkvisitorType { get; set; }

    public int? FkvisitorPurpose { get; set; }

    public string? OtherPurpose { get; set; }

    public virtual ICollection<AdditionalVisitor> AdditionalVisitors { get; set; } = new List<AdditionalVisitor>();

    public virtual ICollection<AmcvisitDetail> AmcvisitDetails { get; set; } = new List<AmcvisitDetail>();

    public virtual ICollection<BelongingsChecklist> BelongingsChecklists { get; set; } = new List<BelongingsChecklist>();

    public virtual VisitorPurpose? FkvisitorPurposeNavigation { get; set; }

    public virtual VisitorType? FkvisitorTypeNavigation { get; set; }

    public virtual ICollection<VisitorImage> VisitorImages { get; set; } = new List<VisitorImage>();
}
