using Web.ViewModels;

namespace Web.Services
{
    public class MemberDataService
    {

        public async Task<MemberProfileViewModel> GetMemberData(string account)
        {
            // 兩筆假資料

            var memberData = new MemberProfileViewModel
            {
                ImageUrl = "https://example.com/image.jpg",
                Nickname = "Sunny",
                Birthday = new DateTime(1990, 5, 12),
                Gender = "Female",
                Account = "sunny123",
                FirstName = "Anna",
                LastName = "Wang",
                Email = "anna.wang@example.com",
                Phone = "0987654321",
                CousePrefer = new List<CouseListViewModel>
                    {
                        new CouseListViewModel { CategorytName = "Language", SubjectName = "English" },
                        new CouseListViewModel { CategorytName = "Language", SubjectName = "Japanese" }
                    },
            };

            if (memberData == null)
            {
                throw new Exception("會員資料未找到");
            }

            // 將找到的會員資料填寫到 ViewModel 中
            var result = new MemberProfileViewModel
            {
                ImageUrl = memberData.ImageUrl,
                Nickname = memberData.Nickname,
                Birthday = memberData.Birthday,
                Gender = memberData.Gender,
                Account = memberData.Account,
                FirstName = memberData.FirstName,
                LastName = memberData.LastName,
                Email = memberData.Email,
                Phone = memberData.Phone,
                CousePrefer = memberData.CousePrefer,

            };

            return result;
        }
    }
}
