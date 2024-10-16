namespace Api.Dtos
{
    public class UpdatePublishingStatusDto
    {
        public int CourseId { get; set; }
        public bool IsEnabled { get; set; }
    }
}
