using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Web.Exceptions;
using Web.Entities;
using ApplicationCore.Entities;



namespace Web.Services
{
    public class AccountService
    {
        private readonly IRepository _repository;


        // 使用依賴注入注入 IRepository 和 ILogger
        public AccountService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task RegisterUserAsync(AccountViewModel model)
        {
            try
            {
                var existingMember = await _repository.GetAll<Web.Entities.Member>()
                    .SingleOrDefaultAsync(m => m.Email == model.RegisterViewModel.Email);

                if (existingMember != null)
                {
                    throw new UserAlreadyExistsException("該電子郵件已被註冊");
                }

                var newMember = new Web.Entities.Member
                {
                    Email = model.RegisterViewModel.Email,
                    Password = model.RegisterViewModel.Password,
                    FirstName = model.RegisterViewModel.FirstName,
                    LastName = "N/A",
                    Birthday = null,
                    Nickname = "N/A",
                    Phone = "0912345678",
                    Cdate = DateTime.Now,
                    Udate = DateTime.Now,
                    IsTutor = false,
                    IsVerifiedTutor = false
                };

                var passwordHasher = new PasswordHasher<Web.Entities.Member>();
                newMember.Password = passwordHasher.HashPassword(newMember, model.RegisterViewModel.Password);

                _repository.Create(newMember);
                await _repository.SaveChangesAsync();

                Console.WriteLine("會員註冊成功");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"註冊失敗，發生錯誤：{ex.Message}");
            }
        }


        // 驗證使用者帳號和密碼
        public async Task<Web.Entities.Member> ValidateUserAsync(string email, string password)
        {
            var user = await _repository.GetAll<Web.Entities.Member>().SingleOrDefaultAsync(m => m.Email == email);


            if (user == null)
            {
                // 用戶不存在
                return null;
            }

            // 使用 PasswordHasher 驗證密碼
            var passwordHasher = new PasswordHasher<Web.Entities.Member>();
            var result = passwordHasher.VerifyHashedPassword(user, user.Password, password);

            if (result == PasswordVerificationResult.Success)
            {
                return user;  // 驗證成功，返回使用者
            }

            // 密碼不匹配
            return null;
        }
    }

}
