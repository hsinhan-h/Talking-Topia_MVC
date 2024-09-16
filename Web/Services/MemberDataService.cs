using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Web.Entities;
using Web.Repository;
using Web.ViewModels;
using Infrastructure.Data;

namespace Web.Services
{
    public class MemberDataService
    {
        private readonly IRepository _repository;

        public MemberDataService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<MemberProfileViewModel> GetMemberData(int memberId)
        {
            // 使用 MemberId 查詢會員資料
            var member = await _repository.GetAll<Member>().FirstOrDefaultAsync(m => m.MemberId == memberId);

            if (member == null)
            {
                throw new Exception("找不到會員資料");
            }

            var coursePrefer = await (from mp in _repository.GetAll<MemberPreference>()
                                           join cs in _repository.GetAll<CourseSubject>()
                                               on mp.SubjecId equals cs.SubjectId
                                           join cc in _repository.GetAll<CourseCategory>()
                                               on cs.CourseCategoryId equals cc.CourseCategoryId
                                           where mp.MemberId == member.MemberId
                                           select new CourseListViewModel
                                           {
                                               CategoryName = cc.CategorytName,
                                               SubjectName = cs.SubjectName
                                           }).ToListAsync();

            // 將查詢結果轉換成 ViewModel
            var memberProfile = new MemberProfileViewModel
            {
                ImageUrl = member.HeadShotImage,
                Nickname = member.Nickname,
                //Birthday = member.Birthday ?? DateTime.Now,
                Birthday = (DateTime)(member.Birthday.HasValue ? member.Birthday.Value : (DateTime?)null),

                //Birthday = member.Birthday.HasValue ? member.Birthday.Value : DateTime.MinValue,
                Gender = ((Gender)member.Gender).ToString(),  // 將枚舉轉換為字符串
                Account = member.Account,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Email = member.Email,
                Phone = member.Phone,
                CoursePrefer = coursePrefer
            };

            return memberProfile;
        }

        public async Task UpdateMemberData(MemberProfileViewModel updatedData, int memberId)
        {
            if (updatedData == null)
            {
                throw new ArgumentNullException(nameof(updatedData), "更新資料不能為空");
            }

            var member = await _repository.GetAll<Member>().FirstOrDefaultAsync(m => m.Account == updatedData.Account);

            if (member == null)
            {
                throw new Exception("會員資料未找到");
            }

            // 更新會員的屬性，根據需要檢查欄位是否有效
            member.FirstName = string.IsNullOrWhiteSpace(updatedData.FirstName) ? member.FirstName : updatedData.FirstName;
            member.LastName = string.IsNullOrWhiteSpace(updatedData.LastName) ? member.LastName : updatedData.LastName;
            member.Nickname = string.IsNullOrWhiteSpace(updatedData.Nickname) ? member.Nickname : updatedData.Nickname;

            // 確保 Gender 值有效
            if (Enum.TryParse(typeof(Gender), updatedData.Gender, out var genderValue))
            {
                member.Gender = (short)genderValue;
            }

            // 檢查生日是否有效
            if (updatedData.Birthday != DateTime.MinValue)
            {
                member.Birthday = updatedData.Birthday;
            }

            // 更新其他欄位
            member.Email = string.IsNullOrWhiteSpace(updatedData.Email) ? member.Email : updatedData.Email;
            member.Phone = string.IsNullOrWhiteSpace(updatedData.Phone) ? member.Phone : updatedData.Phone;

            try
            {
                // 保存更新到資料庫
                _repository.Update(member);
                await _repository.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // 錯誤處理: 資料庫更新失敗
                throw new Exception("更新會員資料時發生錯誤", ex);
            }
        }

        public async Task<CourseMainPageViewModel> GetWatchList(int memberId)
        {
            var watchCardInfo = (from watch in _repository.GetAll<WatchList>().AsNoTracking()
                                 join course in _repository.GetAll<Course>().AsNoTracking()
                                 on watch.CourseId equals course.CourseId
                                 join member in _repository.GetAll<Member>().AsNoTracking()
                                 on course.TutorId equals member.MemberId
                                 join nation in _repository.GetAll<Nation>().AsNoTracking()
                                 on member.NationId equals nation.NationId
                                 where watch.FollowerId == memberId
                                 select new TutorRecomCardList
                                 {
                                     CourseId = course.CourseId,
                                     TutorHeadShot = member.HeadShotImage,
                                     NationFlagImg = nation.FlagImage,
                                     CourseTitle = course.Title,
                                     CourseSubTitle = course.SubTitle,
                                     TwentyFiveMinPrice = (int)course.TwentyFiveMinUnitPrice,
                                     FiftyminPrice = (int)course.FiftyMinUnitPrice,
                                     Description = course.Description,
                                 }).ToList();
             
            var recomCardReview = (
               from course in _repository.GetAll<Course>().AsNoTracking()
               join review in _repository.GetAll<Review>().AsNoTracking()
               on course.CourseId equals review.CourseId
               group review by course.CourseId into Review
               select new TutorRecomCardList
               {
                   CourseId = Review.Key,
                   Rating = Review.Any() ? Math.Round(Review.Average(cr => cr.Rating), 2) : 0,
               }).ToList();

            foreach (var card in watchCardInfo)
            {
                var review = recomCardReview.FirstOrDefault(r => r.CourseId == card.CourseId);

                card.Rating = review?.Rating ?? 0;
            }
            var watchlist = new CourseMainPageViewModel
            {
                MemberId = memberId,
                TutorReconmmendCard = watchCardInfo
            };
            return watchlist;
        }



    }

    // 更新會員資料
}
public enum Gender
    {
        Male = 1,
        Female = 2,
        Other = 3
    }


    //public async Task<MemberProfileViewModel> GetMemberData(string account)
    //{
    //    // 兩筆假資料

    //    var memberData = new MemberProfileViewModel
    //    {
    //        ImageUrl = "https://example.com/image.jpg",
    //        Nickname = "Sunny",
    //        Birthday = new DateTime(1990, 5, 12),
    //        Gender = "Female",
    //        Account = "sunny123",
    //        FirstName = "Anna",
    //        LastName = "Wang",
    //        Email = "anna.wang@example.com",
    //        Phone = "0987654321",
    //        CousePrefer = new List<CouseListViewModel>
    //            {
    //                new CouseListViewModel { CategorytName = "Language", SubjectName = "English" },
    //                new CouseListViewModel { CategorytName = "Language", SubjectName = "Japanese" }
    //            },
    //    };

    //    if (memberData == null)
    //    {
    //        throw new Exception("會員資料未找到");
    //    }

    //    // 將找到的會員資料填寫到 ViewModel 中
    //    var result = new MemberProfileViewModel
    //    {
    //        ImageUrl = memberData.ImageUrl,
    //        Nickname = memberData.Nickname,
    //        Birthday = memberData.Birthday,
    //        Gender = memberData.Gender,
    //        Account = memberData.Account,
    //        FirstName = memberData.FirstName,
    //        LastName = memberData.LastName,
    //        Email = memberData.Email,
    //        Phone = memberData.Phone,
    //        CousePrefer = memberData.CousePrefer,

    //    };

    //    return result;
    //}




