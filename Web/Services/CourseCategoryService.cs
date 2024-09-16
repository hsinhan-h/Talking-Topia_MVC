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
                from category in _repository.GetAll<CourseCategory>()
                join subject in _repository.GetAll<CourseSubject>()
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


    }
}
