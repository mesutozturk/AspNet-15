using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Uyelik.DAL;
using Uyelik.Entity.IdentityModels;

namespace Uyelik.BLL.Account
{
    public static class MembershipTools
    {
        public static UserStore<ApplicationUser> NewUserStore()
        {
            return new UserStore<ApplicationUser>(new MyContext());
        }
        public static UserManager<ApplicationUser> NewUserManager()
        {
            return new UserManager<ApplicationUser>(NewUserStore());
        }
        public static RoleStore<ApplicationRole> NewRoleStore()
        {
            return new RoleStore<ApplicationRole>(new MyContext());
        }
        public static RoleManager<ApplicationRole> NewRoleManager()
        {
            return new RoleManager<ApplicationRole>(NewRoleStore());
        }
    }
}
