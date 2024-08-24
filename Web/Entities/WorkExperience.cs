namespace Web.Entities
{
    public class WorkExperience
    {
        public int WorkExperienceId { get; set; }
        public string WorkExperienceFile { get; set; }
        public DateTime WorkStartDate { get; set; }
        public DateTime WorkEndDate { get; set; }
        public int MemberId { get; set; }

    }
}
