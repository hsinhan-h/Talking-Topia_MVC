using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;

namespace Web.Services
{
    public class AccountService
    {
        private readonly IRepository _repository;

        public AccountService(IRepository repository)
        {
            _repository = repository;
        }

        public Member GetUserById(int memberId)
        {
            return _repository.FirstOrDefault<Member>(m => m.MemberId == memberId);
        }

        public void RegisterUser(AccountViewModel model)
        {
            // 檢查是否已經有相同的 Email
            if (_repository.FirstOrDefault<Member>(m => m.Email == model.Email) != null)
            {
                throw new Exception("Email 已經被註冊");
            }

            // 創建新的 Member 物件
            var member = new Member
            {
                Email = model.Email,
                FirstName = model.FirstName,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
            };

            _repository.Create(member);
            _repository.SaveChanges();
        }

        public bool ValidateMember(string email, string password)
        {
            // 從儲存庫中查找使用者
            var member = _repository.FirstOrDefault<Member>(m => m.Email == email);
            if (member != null && BCrypt.Net.BCrypt.Verify(password, member.Password))
            {
                return true;
            }
            return false;
        }
    }

}
