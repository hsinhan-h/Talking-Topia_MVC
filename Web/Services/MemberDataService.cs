using Web.ViewModels;

namespace Web.Services
{
    public class MemberDataService
    {
        public async Task<MemberProfileViewModel> GetFilteredMemberDataAsync()
        {
            // 一筆假資料
            var memberData = new MemberProfileViewModel
            {
                Account = "abcd45613",
                FirstName = "Eric",
                LastName = "Chung",
                Email = "zxc987654@gmail.com",
                Phone = "0987654321",
                Address = "台北市光復路大同街123號",
            };

           
            var summaryData = new MemberProfileViewModel
            {
                Account = memberData.Account,
                FirstName = memberData.FirstName,
                LastName = memberData.LastName,
                Email = memberData.Email,
                Phone = memberData.Phone,
                Address = memberData.Address,
            };

            return summaryData;
        }
    }
}
