using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Web.Exceptions;
using Web.Entities;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;



namespace Web.Services
{
    public class AccountService
    {
        private readonly IRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;



        // 使用依賴注入注入 IRepository 和 ILogger
        public AccountService(IRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;

        }

        //public async Task RegisterUserAsync(AccountViewModel model)
        //{
        //    try
        //    {
        //        var existingMember = await _repository.GetAll<Web.Entities.Member>()
        //            .SingleOrDefaultAsync(m => m.Email == model.RegisterViewModel.Email);

        //        if (existingMember != null)
        //        {
        //            throw new UserAlreadyExistsException("該電子郵件已被註冊");
        //        }

        //        var newMember = new Web.Entities.Member
        //        {
        //            Email = model.RegisterViewModel.Email,
        //            Password = model.RegisterViewModel.Password,
        //            FirstName = model.RegisterViewModel.FirstName,
        //            LastName = "N/A",
        //            Birthday = null,
        //            Nickname = "N/A",
        //            Phone = "0912345678",
        //            Cdate = DateTime.Now,
        //            Udate = DateTime.Now,
        //            IsTutor = false,
        //            IsVerifiedTutor = false
        //        };

        //        var passwordHasher = new PasswordHasher<Web.Entities.Member>();
        //        newMember.Password = passwordHasher.HashPassword(newMember, model.RegisterViewModel.Password);

        //        _repository.Create(newMember);
        //        await _repository.SaveChangesAsync();

        //        Console.WriteLine("會員註冊成功");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"註冊失敗，發生錯誤：{ex.Message}");
        //    }
        //}





        // 驗證使用者帳號和密碼


        public async Task RegisterUserAsync(AccountViewModel model)
        {
            try
            {
                // 使用 IsEmailRegisteredAsync 方法檢查 email 是否已經註冊
                if (await IsEmailRegisteredAsync(model.RegisterViewModel.Email))
                {
                    throw new UserAlreadyExistsException("該電子郵件已被註冊");
                }

                var newUser = new Web.Entities.User
                {
                    Name = $"{model.RegisterViewModel.FirstName}", // 使用者名稱
                    Email = model.RegisterViewModel.Email,
                    Password = "" // 這裡可以設定為空字串，或者設定其他值，如果需要加密密碼，請加密處理
                };
                // 使用 IRepository 創建新的 User
                _repository.Create(newUser);
                await _repository.SaveChangesAsync();

                var newMember = new Web.Entities.Member
                {
                    UserId = newUser.Id, // 將剛剛創建的 UserId 設定到 Member 中
                    Email = model.RegisterViewModel.Email,
                    Password = model.RegisterViewModel.Password,
                    FirstName = model.RegisterViewModel.FirstName,
                    LastName = "",
                    Birthday = null,
                    Nickname = "",
                    Phone = "",
                    Cdate = DateTime.Now,
                    Udate = DateTime.Now,
                    IsTutor = false,
                    IsVerifiedTutor = false,
                    
                };

                // 使用 PasswordHasher 進行密碼哈希
                var passwordHasher = new PasswordHasher<Web.Entities.Member>();
                newMember.Password = passwordHasher.HashPassword(newMember, model.RegisterViewModel.Password);

                // 使用 IRepository 創建新的會員
                _repository.Create(newMember);
                await _repository.SaveChangesAsync();

                Console.WriteLine("會員註冊成功");
            }
            catch (UserAlreadyExistsException ex)
            {
                Console.WriteLine($"註冊失敗，原因：{ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"註冊失敗，發生錯誤：{ex.Message}");
                throw;
            }
        }


        //public async Task<Web.Entities.Member> ValidateUserAsync(string email, string password)
        //{
        //    var user = await _repository.GetAll<Web.Entities.Member>().SingleOrDefaultAsync(m => m.Email == email);


        //    if (user == null)
        //    {
        //        // 用戶不存在
        //        return null;
        //    }

        //    // 使用 PasswordHasher 驗證密碼
        //    var passwordHasher = new PasswordHasher<Web.Entities.Member>();
        //    var result = passwordHasher.VerifyHashedPassword(user, user.Password, password);

        //    if (result == PasswordVerificationResult.Success)
        //    {
        //        return user;  // 驗證成功，返回使用者
        //    }

        //    // 密碼不匹配
        //    return null;
        //}


        public async Task<Web.Entities.Member> ValidateUserAsync(string email, string password)
        {
            var user = await _repository.GetAll<Web.Entities.Member>().SingleOrDefaultAsync(m => m.Email == email);

            if (user == null)
            {
                return null; // 用戶不存在
            }

            // 使用 PasswordHasher 驗證密碼
            var passwordHasher = new PasswordHasher<Web.Entities.Member>();
            var result = passwordHasher.VerifyHashedPassword(user, user.Password, password);

            return result == PasswordVerificationResult.Success ? user : null;
        }

        public async Task<bool> IsEmailRegisteredAsync(string email)
        {
            // 檢查 email 是否已經存在
            var existingUser = await _repository.FirstOrDefaultAsync<Web.Entities.Member>(u => u.Email == email);
            return existingUser != null;
        }

        public async Task<Entities.Member> GetMemberByResetTokenAsync(string token)
        {
            // 使用 LINQ 查詢 Member 資料表，找到對應的重設密碼 token 的會員
            return await _repository
                .FirstOrDefaultAsync<Web.Entities.Member>(m => m.ResetPasswordToken == token);
        }
        public async Task UpdateMemberAsync(Entities.Member member)
        {
            // 更新會員資料
            _repository.Update(member);
            await _repository.SaveChangesAsync();
        }
        public async Task<Entities.Member> GetMemberByEmailAsync(string email)
        {
            return await _repository.FirstOrDefaultAsync<Web.Entities.Member>(m => m.Email == email);
        }

        public async Task SignInMemberAsync(Entities.Member member, bool isPersistent = true)
        {
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, member.FirstName),
        new Claim(ClaimTypes.NameIdentifier, member.MemberId.ToString())
    };

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                IsPersistent = isPersistent,
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await _httpContextAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPrincipal,
                authProperties);
        }

        public bool VerifyPassword(string hashedPassword, string enteredPassword)
        {
            var passwordHasher = new PasswordHasher<Entities.Member>();
            return passwordHasher.VerifyHashedPassword(null, hashedPassword, enteredPassword) == PasswordVerificationResult.Success;
        }
    }
}
