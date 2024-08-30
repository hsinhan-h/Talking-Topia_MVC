using Web.ViewModels;

namespace Web.Services
{
    public class MemberDataService
    {
        
        public async Task<MemberProfileListViewModel> GetMemberData(string account)
        {
            // 兩筆假資料

            var memberData = new List<MemberProfileViewModel>
            {
                new MemberProfileViewModel
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
                },
                new MemberProfileViewModel
                {
                    ImageUrl = "https://example.com/image2.jpg",
                    Nickname = "Tommy",
                    Birthday = new DateTime(1985, 8, 24),
                    Gender = "Male",
                    Account = "tommy85",
                    FirstName = "Tomoya",
                    LastName = "Suzuki",
                    Email = "tomoya.suzuki@example.com",
                    Phone = "0978123456",
                    
                    CousePrefer = new List<CouseListViewModel>
                    {
                        new CouseListViewModel { CategorytName = "Technology", SubjectName = "Programming" },
                        new CouseListViewModel { CategorytName = "Technology", SubjectName = "Web Development" }
                    },
                }
            };
            var selectedMember = memberData.FirstOrDefault(x => x.Account == account);

            if (selectedMember == null)
            {
                throw new Exception("會員資料未找到");
            }
           
            // 將找到的會員資料填寫到 ViewModel 中
            var result = new MemberProfileListViewModel
            {
                MemberDataList = new List<MemberProfileViewModel>
                {
                    new MemberProfileViewModel
                    {
                        ImageUrl = selectedMember.ImageUrl,
                        Nickname = selectedMember.Nickname,
                        Birthday = selectedMember.Birthday,
                        Gender = selectedMember.Gender,
                        Account = selectedMember.Account,
                        FirstName = selectedMember.FirstName,
                        LastName = selectedMember.LastName,
                        Email = selectedMember.Email,
                        Phone = selectedMember.Phone,
                        CousePrefer = selectedMember.CousePrefer,
                    }
                }
            };

            return result;
        }   
    }
}
