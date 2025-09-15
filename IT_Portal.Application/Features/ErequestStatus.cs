namespace IT_Portal.Application.Features
{
    public class ErequestStatus
    {
        public int IssueId { get; set; }
        public string Status { get; set; }
        public int reasonID { get; set; }
        public EchatBox? ChatsBox { get; set; }
        public int ModifiedBy { get; set; }
        public string ResolutionRemarks { get; set; }
        public int assignTo { get; set; }
    }

    public partial class EchatBox
    {
        public int Id { get; set; }

        public int? IssueId { get; set; }

        public string? TextChat { get; set; }

    }

    public partial class EcommentBoxMessage
    {
        public string userRole { get; set; }
        public string text { get; set; }
        public DateTime timestamp { get; set; }

    }
}
