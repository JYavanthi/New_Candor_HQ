using IT_Portal.Application.Features.SR.SRCommon;

namespace IT_Portal.Application.Features.SR.Software
{
    public class SPSoftware
    {
        public string? Flag { get; set; }
        public int? SRID { get; set; }
        public int? SWID { get; set; }
        public int? SupportID { get; set; }
        public string? SoftwareType { get; set; }
        public int? SoftwareName { get; set; }
        public int? SoftwareVersionName { get; set; }
        public string? VendorName { get; set; }
        public string? InstType { get; set; }
        public string? LicenceType { get; set; }
        public string? Location { get; set; }
        public string? Department { get; set; }
        public int? NoOfUers { get; set; }
        public int? NoOfLicence { get; set; }
        public int? CostPerLicence { get; set; }
        public int? TotalCost { get; set; }
        public bool? AMCAppilcable { get; set; }
        public int? CostForAMC { get; set; }
        public string? ScopeOfAMC { get; set; }
        public bool? IsInstReq { get; set; }
        public int? InstCharge { get; set; }
        public string? DtlsOfInst { get; set; }
        public DateTime? DtlsOfinstDt { get; set; }
        public string? TypeOfDev { get; set; }
        public string? DtlsOfDev { get; set; }
        public bool? IsInterfaceReq { get; set; }
        public string? InterfaceReq { get; set; }
        public string? InterfaceWith { get; set; }
        public bool? IsGxpApp { get; set; }
        public string? NonFunReq { get; set; }
        public string? DtlsOfReq { get; set; }
        public string? WhereHosted { get; set; }
        public string? TypeOfWeb { get; set; }
        public string? UsageBY { get; set; }
        public string? UserAccessFrom { get; set; }
        public string? CurrVersion { get; set; }
        public string? TareVersion { get; set; }
        public string? Brds { get; set; }
        public string? BusJustification { get; set; }
        public string? Justification { get; set; }
        public int NoofUseruse { get; set; }
        public bool? IsActive { get; set; }
        public SRVariable SRVariable { get; set; }
        public List<int> AttachmentIds { get; set; } = new List<int>();
    }
}
