namespace IT_Portal.Application.Features
{
    public class SPCRtemplate
    {
        public string Flag { get; set; }

        public int CRTemplateID { get; set; }

        public string TemplateName { get; set; }

        public int CRID { get; set; }

        public int? CRTemplateDtlsID { get; set; }

        public int SupportID { get; set; }

        public int? SysLandscapeID { get; set; }

        public int ClassificationID { get; set; }

        public int CategoryID { get; set; }

        public int CategoryTypID { get; set; }

        public string? TaskName { get; set; }

        public string? TaskDesc { get; set; }

        public int? Priority { get; set; }

        public bool IsActive { get; set; }

        public int CreatedBy { get; set; }

    }
}