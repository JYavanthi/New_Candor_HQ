namespace IT_Portal.Application.Features
{
    public class EonHoldReason
    {
        public int IssueOnholdCatId { get; set; }

        public int? CategoryId { get; set; }

        public int? CategoryTypeId { get; set; }

        public string? OnholdReason { get; set; }

        public bool? IsActive { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
