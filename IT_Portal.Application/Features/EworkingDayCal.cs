namespace IT_Portal.Application.Features
{
    public class EworkingDayCalReq
    {
        public int empId { get; set; }
        public DateOnly startDate { get; set; }
        public DateOnly endDate { get; set; }
    }
    public class EworkingDayCalRes
    {
        public int workngDays { get; set; }
    }

    public class ErequestPRdate
    {
        public int categoryId { get; set; }
        public int categoryTypeId { get; set; }
    }
}
