namespace IT_Portal.Application.Features
{
    public class SPCheckList
    {

        public string Flag { get; set; }

        public int ITChecklistID { get; set; }

        public int? PlantID { get; set; }

        public string status { get; set; }

        public int? SupportID { get; set; }

        public int? CategoryID { get; set; }

        public int? ClassificationID { get; set; }

        public string ChecklistTitle { get; set; }

        public string ChecklistDesc { get; set; }

        public Boolean? MandatoryFlag { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDt { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDt { get; set; }
    }
}
