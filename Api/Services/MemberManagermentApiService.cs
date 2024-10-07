using ApplicationCore.Interfaces;
using ApplicationCore.Entities;
using Api.Dtos;
using static System.Net.Mime.MediaTypeNames;

namespace Api.Services
{
    public class MemberManagermentApiService
    {
        private readonly IRepository<Member> _memberRepository;
        private readonly IRepository<Nation> _nationRepository;


        public MemberManagermentApiService(IRepository<Member> memberRepository, IRepository<Nation> nationRepository)
        {
            _memberRepository = memberRepository;
            _nationRepository = nationRepository;
        }



        public async Task<List<MemberDataDto>> GetMemberDataList()
        {
            var memberdatainfo = await _memberRepository.ListAsync();
            var nationdatainfo = await _nationRepository.ListAsync();

            var allmemberdata =
            from member in memberdatainfo
            join nation in nationdatainfo on member.NationId equals nation.NationId into nationinfo
            from nation in nationinfo.DefaultIfEmpty() 
            select new MemberDataDto
            {
                MemberId = member.MemberId,
                FirstName = member.FirstName,
                LastName = member.LastName,
                MemeberName = member.LastName + " " + member.FirstName,
                NickName =member.Nickname,
                Gender = member.Gender == (int)GenderEnum.Male ? "男" : "女",
                Birthday = member.Birthday.ToString(),
                Phone = member.Phone,
                Email = member.Email,
                Cdate = member.Cdate.ToString(),
                NationId = member.NationId,
                NationName = nation != null ? nation.NationName : "Unknown" 
            };

            return allmemberdata.ToList();
        }
        public async Task<bool> UpdateMemberData(MemberDataDto memberDto)
        {
            var member = await _memberRepository.GetByIdAsync(memberDto.MemberId);
            if (member == null)
            {
                return false;
            }
            member.Nickname = memberDto.NickName;
            member.FirstName = memberDto.FirstName;
            member.LastName = memberDto.LastName;
            member.NationId = memberDto.NationId;
            if (memberDto.Gender == "男")
            {
                member.Gender = (short)GenderEnum.Male; 
            }
            else if(memberDto.Gender == "女")
            {
                member.Gender = (short)GenderEnum.Female; 
            }
            member.Birthday = DateTime.Parse(memberDto.Birthday);
            member.Phone = memberDto.Phone;
            member.Email = memberDto.Email;
            member.Cdate = DateTime.Parse(memberDto.Cdate); ;

            // 保存變更
            await _memberRepository.UpdateAsync(member);

            return true; 
        }

        //public async Task<bool> LockMemberAccess(MemberDataDto memberDto)
        //{
        //    var member = await _memberRepository.GetByIdAsync(memberDto.MemberId);
        //    if (member == null)
        //    {
        //        return false;
        //    }
        //    member.IsEmailConfirmed = memberDto.IsEmailConfirmed;
            
        //    await _memberRepository.UpdateAsync(member);

        //    return true; 
        //}
    }
    public enum GenderEnum
    {
        Male = 1,  // 男
        Female = 2 // 女
    }
}
