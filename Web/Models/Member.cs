namespace Web.Models
{
    public class Member
    {
        public int Id { get; set; }
        
        //tutor info
        public string HeadShotImage { get; set; }
        public string NationImage { get; set; }
        public bool IsVerifiedTutor { get; set; }
        public float Ranking { get; set; }
        public int CompletedCourse { get; set; }
        public string[] AvailableTimeSlots { get; set; }  //[["wednesday, "00:00"], ["Thursday", 13:00", ..."//
             
    }
}
