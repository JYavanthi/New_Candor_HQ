namespace IT_Portal.Application.Features
{
    public class SPCrfollowUp
    {
        public string Flag { get; set; }

        public int CRFollowupID { get; set; }

        public int ITCRID { get; set; }

        public DateTime? FollowupDt { get; set; }

        public int? FollowupToPerson { get; set; }

        public string? FollowupComments { get; set; }

        public int CreatedBy { get; set; }
    }
}
