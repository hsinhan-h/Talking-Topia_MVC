using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IMemberService
    {
        public Task<bool> GetMemberId(int memberId);
        public int AddWatchList(int memberId, int courseId);

    }
}
