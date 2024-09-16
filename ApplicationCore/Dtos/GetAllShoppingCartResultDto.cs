using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Dtos
{
    public class GetAllShoppingCartResultDto
    {
        public List<GetAllShoppingCartItem> GetShoppingCartItems { get; set; }
    }
    public class GetAllShoppingCartItem
    {
        public int ShoppingCartId { get; set; }
        public int CourseId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int MemberId { get; set; }
        public short CourseType { get; set; }
        public DateTime? BookingDate { get; set; }
        //public short BookingTime { get; set; }
    }
}
