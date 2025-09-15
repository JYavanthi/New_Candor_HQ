namespace IT_Portal.Application.Features
{
    public class SupportMaster
    {
        public int SupportId { get; set; }
        public string SupportName { get; set; }
        public int? ParentId { get; set; }
        public bool? RPM { get; set; }
        public bool? HOD { get; set; }
        public string? Image { get; set; }
        public string? URL { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsVisible { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
    }
}
