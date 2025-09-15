namespace IT_Portal.Application.Features
{
    public class SPCrrelease
    {
        public string Flag { get; set; }

        public int? CRReleaseID { get; set; }

        public int ITCRID { get; set; }

        public int SysLandscape { get; set; }

        public string ReleaseComments { get; set; }

        public int? AssignedTo { get; set; }

        public DateTime? ReleaseDt { get; set; }

        public string? Attachments { get; set; }

        public string? Status { get; set; }

        public string? ApprovedBy { get; set; }

        public DateTime? ApprovedDt { get; set; }

        public int? CreatedBy { get; set; }

    }
}
