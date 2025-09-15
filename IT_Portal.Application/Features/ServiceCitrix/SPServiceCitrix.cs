namespace IT_Portal.Application.Features.ServiceCitrix
{
    public class SPServiceCitrix
    {
        public string Flag { get; set; }

        public int ServiceCitrixID { get; set; }

        public int? RaisedBy { get; set; }

        public DateTime SRDate { get; set; }

        public string ShotDesc { get; set; }

        public string SRDesc { get; set; }

        public int? SRRaiseFor { get; set; }

        public int? PlantID { get; set; }

        public int? AssetID { get; set; }

        public int? CategoryID { get; set; }

        public int? CategoryTypID { get; set; }

        public int? Priority { get; set; }

        public string? Source { get; set; }

        public string? Service { get; set; }

        public string? Attachment { get; set; }

        public string? Status { get; set; }

        public int? CreatedBy { get; set; }
    }
}