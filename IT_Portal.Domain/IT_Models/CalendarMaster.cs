namespace IT_Portal.Domain.IT_Models;

public partial class CalendarMaster
{
    public int Id { get; set; }

    public int FkCompanyId { get; set; }

    public string? FiscalYear { get; set; }

    public int? Period { get; set; }

    public string? Month { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool? CloseMonth { get; set; }

    public bool? CloseYear { get; set; }

    public int? Year { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<AppraisalDetail> AppraisalDetails { get; set; } = new List<AppraisalDetail>();

    public virtual ICollection<AssesmentMaster> AssesmentMasters { get; set; } = new List<AssesmentMaster>();

    public virtual ICollection<OverallRatingMaster> OverallRatingMasters { get; set; } = new List<OverallRatingMaster>();

    public virtual ICollection<RatingMaster> RatingMasters { get; set; } = new List<RatingMaster>();

    public virtual ICollection<SoftSkillMaster> SoftSkillMasters { get; set; } = new List<SoftSkillMaster>();
}
