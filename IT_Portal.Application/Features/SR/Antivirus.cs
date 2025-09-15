using IT_Portal.Application.Features.SR.SRCommon;

namespace IT_Portal.Application.Features.SR
{
    public class Antivirus
    {
        public string Flag { get; set; }
        public int SRID { get; set; }
        public int SupportID { get; set; }
        public int SRAVID { get; set; }
        public string? RequestType { get; set; }
        public string? InstallDts { get; set; }
        public string? UninstallDts { get; set; }
        public string? ExcDts { get; set; }
        public string? IncDts { get; set; }
        public string? Attachment { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }

        public SRVariable SRVariable { get; set; }
    }
}
