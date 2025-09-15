namespace IT_Portal.Domain.IT_Models;

public partial class Crfollowup
{
    public int CrfollowupId { get; set; }

    public int Itcrid { get; set; }

    public DateTime? FollowupDt { get; set; }

    public int? FollowupToPerson { get; set; }

    public string FollowupComments { get; set; } = null!;

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }

    public virtual ChangeRequest Itcr { get; set; } = null!;
}
