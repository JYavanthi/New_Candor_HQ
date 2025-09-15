namespace IT_Portal.Application.Features
{
    public class SPMemebers
    {
        public string Flag { get; set; }
        public int? PrMemberId { get; set; }
        public int? ProjectMgmtID { get; set; }
        public int? EmpID { get; set; }
        public string Role { get; set; }
        public string Type { get; set; }
        public bool? Responsible { get; set; }
        public bool? Accountable { get; set; }
        public bool? Consulted { get; set; }
        public bool? Informed { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
    }
}