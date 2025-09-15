namespace IT_Portal.Domain.IT_Models;

public partial class PlantsAssignedForUserId
{
    public int Id { get; set; }

    public int Uid { get; set; }

    public int LocationId { get; set; }

    public virtual PlantMaster Location { get; set; } = null!;

    public virtual UserIdRequestOld UidNavigation { get; set; } = null!;
}
