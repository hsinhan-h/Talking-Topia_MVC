using Web.ViewModels;

namespace Web.Services
{
    public class BookingService
    {
        public async Task<BookingListViewModel> GetBookingList()
        {
            var booking = new List<BookingViewModel>
            {
               new BookingViewModel
               {
                   BookingId = 1,
                   BookingDate = DateTime.Now.AddDays(-1),
                   Title = "Test",
                   SubTitle = "TestSubTitle",
                   MemberName = "TestMemberName",
                   TotalPriceNTD = 10000,
               },
               new BookingViewModel
               {
                   BookingId = 2,
                   BookingDate = DateTime.Now.AddDays(-2),
                   Title = "Test2",
                   SubTitle = "TestSubTitle2",
                   MemberName = "TestMemberName2",
                   TotalPriceNTD = 20000,
               },
            };

            return new BookingListViewModel()
            {
                BookingList = booking,
            };
        }
    }
}
