using Api.Dtos;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace Api.Services
{
    public class DashboardApiService
    {
        private readonly IRepository<Order> _orderReoisitory;
        private readonly IRepository<Member> _memberReoisitory;
        private readonly IRepository<Course> _courseReoisitory;
        private readonly IRepository<Booking> _bookingReoisitory;
        private readonly IRepository<OrderDetail> _orderDetailReoisitory;

        public DashboardApiService(IRepository<Order> orderReoisitory,
                                   IRepository<Member> memberReoisitory,
                                   IRepository<Course> courseReoisitory,
                                   IRepository<Booking> bookingReoisitory,
                                   IRepository<OrderDetail> orderDetailReoisitory)
        {
            _orderReoisitory = orderReoisitory;
            _memberReoisitory = memberReoisitory;
            _courseReoisitory = courseReoisitory;
            _bookingReoisitory = bookingReoisitory;
            _orderDetailReoisitory = orderDetailReoisitory;
        }

        public async Task<List<DashboardDto>> GetAllData()
        {
            var result = new List<DashboardDto>();

            return result;
        }
    }
}
