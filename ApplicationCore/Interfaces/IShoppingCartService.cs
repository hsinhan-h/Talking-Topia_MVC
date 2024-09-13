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
        public bool IsMember(int memberId);
        public bool IsCourse(int courseId);
        public bool HasCartItem(int memberId, int courseId);
        public decimal GetUnitPrice(int courseId, int courseLength);
        public Task<GetAllShoppingCartResult> GetAllShoppingCartAsync(int memberId);
        public Task<int> CreateShoppingCartAsync(int memberId, int courseId, int courseLength, int quantity);
        public void DeleteCartItem(int memberId, int courseId);
    }
}
