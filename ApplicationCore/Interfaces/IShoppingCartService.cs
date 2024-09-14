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
        public Task<GetAllShoppingCartResult> GetAllShoppingCartAsync(int memberId);
        public Task<int> CreateShoppingCartAsync(int memberId, int courseId, int courseLength, int quantity);
        public Task<int> CreateShoppingCartAsync(int memberId, int courseId, int courseLength, int quantity, DateTime bookingDate, short bookingTime);
        public void DeleteCartItem(int memberId, int courseId);
    }
}
