namespace IT_Portal.Application.Features
{
    public class SystemlandscapeSP
    {
        public string Flag { get; set; }

        public int SysLandscapeId { get; set; }

        public int SupportId { get; set; }

        public int CategoryId { get; set; }

        public int ClassificationId { get; set; }

        public string SysLandscape1 { get; set; } = null!;

        public int? PriorityNum { get; set; }

        public bool IsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDt { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDt { get; set; }
    }
}
