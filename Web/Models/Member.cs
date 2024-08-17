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
        public Dictionary<string, List<string>> AvailableTimeSlots { get; set; }  //{ {"wednesday", {"08:00", "13:00"}, {"saturday", {"00:00", "12:00", "14:00"}, ... } }//

    }
}
