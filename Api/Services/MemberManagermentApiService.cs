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
        private readonly IRepository<ApplyList> _applyListRepository;


        public MemberManagermentApiService(IRepository<Member> memberRepository, IRepository<Nation> nationRepository, IRepository<ApplyList> applyListRepository)
        {
            _memberRepository = memberRepository;
            _nationRepository = nationRepository;
            _applyListRepository= applyListRepository;
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
        public async Task<List<TutorDataDto>> GetTutorDataList()
        {
            var memberdatainfo = await _memberRepository.ListAsync();
            var applyListinfo = await _applyListRepository.ListAsync();

            var allTutordata =
            from member in memberdatainfo
            join applyList in applyListinfo on member.MemberId equals applyList.MemberId into tutorinfo
            from applyList in tutorinfo.DefaultIfEmpty()
            select new TutorDataDto
            {
                MemberId = member.MemberId,
                FirstName = member.FirstName,
                LastName = member.LastName,
                MemberName = member.LastName + " " + member.FirstName,
                ApplyDateTime = applyList != null ? applyList.ApplyDateTime.ToString("yyyy-MM-dd") : "N/A",
                RejectReason = applyList?.RejectReason ?? "無",
                ApplyStatus = applyList?.ApplyStatus ?? false,
                ApprovedDateTime = applyList?.ApprovedDateTime?.ToString("yyyy-MM-dd") ?? "N/A",
                Istutor = member.IsTutor ? "已成為教師" : "尚未成為教師",
                ResumeStatus = applyList != null && applyList.ApplyStatus
                                ? resumeStatus.已審核.ToString()  
                                : applyList?.RejectReason != null
                                    ? resumeStatus.申請駁回.ToString()
                                    : resumeStatus.未審核.ToString()
            };

            return allTutordata.ToList();
        }


    }
    public enum GenderEnum
    {
        Male = 1,  // 男
        Female = 2 // 女
    }
    public enum resumeStatus
    {
        未審核 = 0,
        已審核 = 1,
        申請駁回 = 2,
    }
}
