using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class MemberService : IMemberService
    {
        private readonly IRepository<Member> _memberRepository;

        public MemberService(IRepository<Member> memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public bool IsMember(int memberId)
        {
            return _memberRepository.Any(m => m.MemberId == memberId);
        }
        public async Task<int> GetMemberId(string userAccount)
        {
            var result = await _memberRepository.FirstOrDefaultAsync(x => x.Email == userAccount);
            return result.MemberId;
        }
    }
}
