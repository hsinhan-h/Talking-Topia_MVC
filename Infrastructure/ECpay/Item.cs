using Infrastructure.Interfaces.ECpay;

namespace Infrastructure.ECpay
{
    public class Item : IItem
    {
        public string CourseName { get; set; }
        public int UnitPrice { get; set; }
        public int SubPrice { get; set; }
        public int Quantity { get; set; }
        public short CourseType { get; set; }
    }
}