using ApplicationCore.Entities;

namespace Web.Services
{
    public class CourseCategoryService
    {
        private readonly IRepository _repository;

        public CourseCategoryService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CourseCategoryViewModel>> GetCourseCategoriesWithSubjectsAsync()
        {
            var courseCategoriesWithSubjects = await (
                from category in _repository.GetAll<Entities.CourseCategory>()
                join subject in _repository.GetAll<Entities.CourseSubject>()
                on category.CourseCategoryId equals subject.CourseCategoryId into subjectGroup
                select new CourseCategoryViewModel
                {
                    CategoryName = category.CategorytName,
                    Subjects = subjectGroup.Select(s => new CourseSubjectViewModel
                    {
                        SubjectName = s.SubjectName
                    }).ToList()
                }).ToListAsync();
            return courseCategoriesWithSubjects;
        }

        public async Task<CourseCategoryListViewModel> GetCourseCategoryListAsync()
        {
            var courseCategory =
                (from category in _repository.GetAll<Web.Entities.CourseCategory>()
                 select new CourseCategoryVM
                 {
                     CourseCategoryId = category.CourseCategoryId,
                     CategoryName = category.CategorytName,
                 });

            return new CourseCategoryListViewModel
            {
                CourseCategoryList = await courseCategory.ToListAsync(),
            };
        }
    }
}
