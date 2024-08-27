using Web.Entities;

namespace Web.Services
{
    public class ResumeDataService
    {
        public async Task<MemberProfileListViewModel> GetresumeData()
        {
            // 二筆假資料
            var resumedata = new List<MemberProfileViewModel>
            {

                new MemberProfileViewModel
                {
                Account = "Abc!123456",
                SchoolName = "台灣大學",
                StudyStartYear = 2015,
                StudyEndYear = 2019,
                DepartmentName = "資訊工程學系"
                },

                new MemberProfileViewModel
                {
                 Account = "Zxc!123456",
                SchoolName = "中央大學",
                StudyStartYear = 2010,
                StudyEndYear = 2014,
                DepartmentName = "環境工程學系"
                }

            };

            return new MemberProfileListViewModel()
            {
                MemberDataList = resumedata.Where(x => x.Account == "Abc!123456").ToList()
            };

        }
    }
}
