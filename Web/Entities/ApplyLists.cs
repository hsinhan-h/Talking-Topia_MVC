namespace Web.Entities
{
    public class ApplyLists
    {
        public int ApplyID { get; set; }
        public int MemberId { get; set; }
        public DateTime ApplyTime { get; set; }
        public string ApplyStatus { get; set; }
        public DateTime ApproveTime { get; set; }

    }
}
