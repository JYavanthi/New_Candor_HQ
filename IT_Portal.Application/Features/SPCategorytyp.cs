namespace IT_Portal.Application.Features
{
    public class SPCategorytyp
    {
        public string Flag { get; set; }

        public int CategoryTypeID { get; set; }

        public int? CategoryID { get; set; }

        public string? CategoryType { get; set; }

        public bool? IsActive { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}