namespace IT_Portal.Application.Features
{
    public class proSpTemplate
    {
        public string Flag { get; set; }
        public int PRTemplateID { get; set; }
        public string TemplateName { get; set; }
        public bool? IsActive { get; set; }
        public int CreatedBy { get; set; }
        public List<templateDetails> templateDetailsList { get; set; }
    }
}
