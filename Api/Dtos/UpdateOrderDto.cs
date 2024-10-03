namespace Api.Dtos
{
    public class UpdateOrderDto
    {
        public int OrderId { get; set; }
        public int MemberId { get; set; }
        public short OrderStatusId { get; set; }
    }
}
