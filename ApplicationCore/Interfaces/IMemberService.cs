using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IMemberService
    {
        public bool IsMember(int memberId);
        public Task<int> GetMemberId(int memberId);
    }
}
