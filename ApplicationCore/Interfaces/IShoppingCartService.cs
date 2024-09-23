using ApplicationCore.Dtos;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IShoppingCartService
    {
        public bool HasCartItem(int memberId);
        public bool HasCartItem(int memberId, int courseId);
        public decimal GetUnitPrice(int courseId, int courseLength);
        public Task<GetAllShoppingCartResultDto> GetAllShoppingCartAsync(int memberId);
        public Task<int> CreateShoppingCartAsync(int memberId, int courseId, int courseLength, int quantity);
        public Task<int> CreateShoppingCartAsync(int memberId, int courseId, int courseLength, int quantity, DateTime bookingDate, short bookingTime);
        public void DeleteCartItem(int memberId, int courseId);
        public bool DeleteCartItems(int memberId);
        public void UpdateItem(int memberId, int courseId, int quantity, int courseLength, decimal subTotal);
    }
}
