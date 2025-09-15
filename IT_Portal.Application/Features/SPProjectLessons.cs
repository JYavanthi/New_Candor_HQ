namespace IT_Portal.Application.Features
{
    public class SPProjectLessons
    {
        public char Flag { get; set; }
        public int PRLessonsID { get; set; }
        public int ProjectID { get; set; }
        public int TemplateID { get; set; }
        public int TaskID { get; set; }
        public int MilestoneID { get; set; }
        public string Category { get; set; }
        public string Lessons_Type { get; set; }
        public string Description { get; set; }
        public string Impact { get; set; }
        public string Recommendation { get; set; }
        public string ProjCloserAccept { get; set; }
        public int CreatedBy { get; set; }
        public List<ProjectTemplateResponse> ProjectTemplateResponseList { get; set; }
    }
}
