namespace IT_Portal.Application.Features.ServiceCitrix
{
    public class SPServiceCitrixApp
    {
        public string Flag { get; set; }

        public int ServiceCitrixID { get; set; }

        public int? ApprovedLevel1 { get; set; }

        public int? ApprovedLevel1By { get; set; }

        public DateTime? ApprovedLevel1On { get; set; }

        public int? ApprovedLevel2 { get; set; }

        public int? ApprovedLevel2By { get; set; }

        public DateTime? ApprovedLevel2On { get; set; }

        public int? ApprovedLevel3 { get; set; }

        public int? ApprovedLevel3By { get; set; }

        public DateTime? ApprovedLevel3On { get; set; }

        public int? AssignedTo { get; set; }

        public int? AssignedBy { get; set; }

        public DateTime? AssignedOn { get; set; }

        public string? Remarks { get; set; }

        public int? ModifiedBy { get; set; }
    }
}