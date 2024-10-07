using Api.Services;

namespace Api.Dtos
{
    public class TutorDataDto
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string MemberName { get; set; }
        public string Istutor { get; set; }
        public bool ApplyStatus { get; set; }

        public string ApplyDateTime { get; set; }

        public string ApprovedDateTime { get; set; }

        public string RejectReason { get; set; }
        public string ResumeStatus { get; set; }
    }
}
