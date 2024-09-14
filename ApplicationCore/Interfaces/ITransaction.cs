using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ITransaction : ITransActionAsync
    {
        void BeginTransAction();
        void Commit();
        void Rollback();

    }
}
