namespace IT_Portal.Domain.IT_Models;

public partial class AssesmentDetail
{
    public int Id { get; set; }

    public int FkAssesmentId { get; set; }

    public int FkSoftSkillId { get; set; }

    public int? AssesmentAppraisee { get; set; }

    public int? AssesmentAppraiser { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual AssesmentMaster FkAssesment { get; set; } = null!;

    public virtual SoftSkillMaster FkSoftSkill { get; set; } = null!;
}
