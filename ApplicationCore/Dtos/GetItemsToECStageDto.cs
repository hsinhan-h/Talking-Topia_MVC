namespace ApplicationCore.Dtos
{
    public class GetItemsToECStageDto
    {
        public List<GetItemToECStage> GetItemsToECStage { get; set; }
    }

    public class GetItemToECStage
    {
        public string CourseName { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public short CourseType { get; set; }
    }
}
