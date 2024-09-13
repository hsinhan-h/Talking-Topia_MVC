using ApplicationCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IOrderService
    {
        public Task<GetAllOrderResult> GetAllOrder(int memberId);

    }
}
