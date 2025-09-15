namespace IT_Portal.Application.Features
{
    public class EsrPagination
    {

        public int pageNumber { get; set; }
        public int pageSize { get; set; }
    }
    public class EcrFilterRequest
    {
        public List<int>? PlantIds { get; set; }
        public List<int>? Categories { get; set; }
        public int? ClassificationId { get; set; }
        public int? Priority { get; set; }
        public string? Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? RfcChangeNumber { get; set; }
        public int crId { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
    }
}
