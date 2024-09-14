using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Web.Exceptions;



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
                var existingMember = await _repository.GetAll<Member>()
                    .SingleOrDefaultAsync(m => m.Email == model.Email);

                if (existingMember != null)
                {
                    throw new UserAlreadyExistsException("該電子郵件已被註冊");
                }

                var newMember = new Member
                {

                    Email = model.Email,
                    Password = model.Password,
                    FirstName = model.FirstName,
                    LastName = "N/A",
                    Birthday = null,
                    Nickname = "N/A",
                    Phone = "0912345678",
                    Cdate = DateTime.Now,
                    Udate = DateTime.Now,
                    IsTutor = false,
                    IsVerifiedTutor = false
                };

                var passwordHasher = new PasswordHasher<Member>();
                newMember.Password = passwordHasher.HashPassword(newMember, model.Password);

                _repository.Create(newMember);
                await _repository.SaveChangesAsync();

                Console.WriteLine("會員註冊成功");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"註冊失敗，發生錯誤：{ex.Message}");
            }
        }
    }

}
