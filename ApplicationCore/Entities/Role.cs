using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Role
    {
    public int Id { get; set; }

    public string Name { get; set; }
        public RoleType RoleType { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
    }
    public enum RoleType
    {
        Normal = 0, // 一般會員
        Tutor = 1, // 教師
        Admin = 2 // 系統管理者
    }
}
