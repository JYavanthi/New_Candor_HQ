namespace IT_Portal.Application.Features
{
    public class SPModule
    {

        public string Flag { get; set; }

        public int SupportID { get; set; }

        public string? SupportName { get; set; }

        public int ParentID { get; set; }

        public bool? IsActive { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
