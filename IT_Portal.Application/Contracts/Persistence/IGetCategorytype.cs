namespace IT_Portal.Application.Contracts.Persistence
{
    public class IGetCategorytype
    {
        public int CategoryTypeId { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryType { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
