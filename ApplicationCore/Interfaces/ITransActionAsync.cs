using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ITransActionAsync
    {
        Task BeginTransActionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
