namespace IT_Portal.Application.Features
{
    public class SPCategory
    {
        public string Flag { get; set; }

        public int ITCategoryID { get; set; }

        public int? SupportID { get; set; }

        public string? CategoryName { get; set; }

        public bool? IsActive { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDt { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDt { get; set; }
    }
}
