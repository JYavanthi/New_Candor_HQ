namespace IT_Portal.Application.Features.GetApprover
{
    public class IApproverRemoved
    {
        public int SupportTeamID { get; set; }
        public int PlantID { get; set; }
        public int SupportID { get; set; }
        public int CategoryID { get; set; }
        public int ClassificationID { get; set; }
        public char Approverstage { get; set; }
        public int Level { get; set; }
        public int CreatedBy { get; set; }
    }
}
