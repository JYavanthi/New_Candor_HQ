namespace IT_Portal.Application.Features
{
    public class SPSlaMaster
    {

        public string Flag { get; set; }

        public int ITSLAID { get; set; }
        public int CategoryID { get; set; }
        public int ClassificationID { get; set; }
        public int CategoryTypID { get; set; }
        public int SupportID { get; set; }
        public int WaitTime { get; set; }

        public string WaitTimeUnit { get; set; }

        public int AssignedTo { get; set; }

        public int PlantID { get; set; }

        public int Escalation1 { get; set; }

        public int WaitTimeEscal1 { get; set; }

        public string WaitTimeUnitEscal1 { get; set; }
        public int Escalation2 { get; set; }

        public int WaitTimeEscal2 { get; set; }

        public string WaitTimeUnitEscal2 { get; set; }

        public int? CreatedBy { get; set; }
    }
}

//here is the code