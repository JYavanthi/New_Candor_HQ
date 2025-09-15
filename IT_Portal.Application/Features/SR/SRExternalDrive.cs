using IT_Portal.Application.Features.SR.SRCommon;

namespace IT_Portal.Application.Features.SR
{
    public class SRExternalDrive
    {
        public string Flag { get; set; }
        public int? SREDID { get; set; }
        public int? SRID { get; set; }
        public int? SupportID { get; set; }
        public string? ReqType { get; set; }
        public string? ForSelf { get; set; }
        public string? Name { get; set; }
        public string? Designation { get; set; }
        public string? EmpCategory { get; set; }
        public string? Role { get; set; }
        public string? Department { get; set; }
        public string? SubDepartment { get; set; }
        public string? ReportingManager { get; set; }
        public string? HOD { get; set; }
        public string? AccessPath { get; set; }
        public string? AccessType { get; set; }
        public string? AccessRequired { get; set; }
        public string? OnwerEmail { get; set; }
        public string? OnwerPlant { get; set; }
        public string? EmpType { get; set; }
        public string? Justification { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }

        public SRVariable SRVariable { get; set; }


    }
}
