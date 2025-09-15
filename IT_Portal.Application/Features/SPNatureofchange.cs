namespace IT_Portal.Application.Features
{
    public class SPNatureofchange
    {
        public string Flag { get; set; }

        public int NatureofChangeID { get; set; }

        public int? CategoryID { get; set; }

        public string? NatureofChange { get; set; }

        public bool? IsActive { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
