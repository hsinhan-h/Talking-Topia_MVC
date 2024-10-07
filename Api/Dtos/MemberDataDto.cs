namespace Api.Dtos
{
    public class MemberDataDto
    {
        //memberid
        public int MemberId { get; set; }
        //First Name & last name
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string MemeberName { get; set; }
        //Nickname
        public string NickName { get; set; }
        //gender
        public string Gender { get; set; }
        //birthday
        public string Birthday { get; set; }
        //phone
        public string Phone { get; set; }
        //email
        public string Email { get; set; }
        //Cdate
        public string Cdate { get; set; }
        //nationid
        public int?  NationId { get; set; }
        public string NationName { get; set; }
    }
}
