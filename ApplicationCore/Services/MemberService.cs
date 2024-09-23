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
        private readonly IRepository<WatchList> _watchListRepository;
 
        public MemberService(IRepository<Member> memberRepository, IRepository<WatchList> watchListRepository)
        {
            _memberRepository = memberRepository;
            _watchListRepository = watchListRepository;
        }

        public async Task<bool> GetMemberId(int memberId)
        {
            var result = await _memberRepository.AnyAsync(x => x.MemberId == memberId);            
            return result;
        }

        public int AddWatchList(int memberId, int courseId)
        {
            try 
            {
                var addFollow = new WatchList
                {
                    
                    CourseId = courseId,
                    FollowerId = memberId,
                };
                var addWatchList = _watchListRepository.Add(addFollow);
                if (addFollow is null)
                {
                    throw new Exception("WatchList could not be created");
                }
                return addWatchList.WatchListId;
            }
            catch (Exception ex)
            {
                throw new Exception("WatchList could not be created", ex);
            }

        }

        //public async Task<bool> FollowStatus(int memberId, int courseId)
        //{

        //}


    }
}
