using IT_Portal.Application.Features.SR.SRCommon;

namespace IT_Portal.Application.Features.SR.Domain
{
    public class EdomainRequest
    {
        public char? Flag { get; set; }
        public int? SRDomainID { get; set; }
        public int? SupportID { get; set; }
        public int? SRID { get; set; }
        public string? DomainName { get; set; }
        public string? UsePlant { get; set; }
        public string? UseDepart { get; set; }
        public int? NoofUser { get; set; }
        public string? PurpDomain { get; set; }
        public DateTime? DueDt { get; set; }
        public string? TypeofSSL { get; set; }
        public int? RenewalPeriod { get; set; }
        public string? Justification { get; set; }
        public DateTime? DiscontinationDt { get; set; }
        public string ReqDomainName { get; set; }

        public bool? IsActive { get; set; }


        public SRVariable SRVariable { get; set; }


    }
}
