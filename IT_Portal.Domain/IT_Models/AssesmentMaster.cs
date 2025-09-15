namespace IT_Portal.Domain.IT_Models;

public partial class AssesmentMaster
{
    public int Id { get; set; }

    public int? FkEmpId { get; set; }

    public int? FkCalendarId { get; set; }

    public string? Name { get; set; }

    public string? EmployeePcpStatus { get; set; }

    public string? JobDescription { get; set; }

    public bool? IsInitiatedByEmployee { get; set; }

    public bool? IsInitiatedBySystem { get; set; }

    public bool? FormStatus { get; set; }

    public bool? IsApprovedByFirstLevel { get; set; }

    public bool? IsApprovedBySecondLevel { get; set; }

    public bool? IsApprovedByThirdLevel { get; set; }

    public bool? IsApprovedByFourthLevel { get; set; }

    public bool? IsApprovedByFifthLevel { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<AppraisalDetail> AppraisalDetails { get; set; } = new List<AppraisalDetail>();

    public virtual ICollection<AssesmentDetail> AssesmentDetails { get; set; } = new List<AssesmentDetail>();

    public virtual ICollection<FileUpload> FileUploads { get; set; } = new List<FileUpload>();

    public virtual CalendarMaster? FkCalendar { get; set; }

    public virtual ICollection<KraCurrentYear> KraCurrentYears { get; set; } = new List<KraCurrentYear>();

    public virtual ICollection<KraNextYear> KraNextYears { get; set; } = new List<KraNextYear>();

    public virtual ICollection<NewSalaryBreakup> NewSalaryBreakups { get; set; } = new List<NewSalaryBreakup>();

    public virtual ICollection<OverallRatingDetail> OverallRatingDetails { get; set; } = new List<OverallRatingDetail>();

    public virtual ICollection<SoftSkillMaster> SoftSkillMasters { get; set; } = new List<SoftSkillMaster>();

    public virtual ICollection<TrainingDetail> TrainingDetails { get; set; } = new List<TrainingDetail>();
}
