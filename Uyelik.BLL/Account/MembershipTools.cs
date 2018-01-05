using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web;
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
        public static string GetUserName(string id)
        {
            var userManager = NewUserManager();
            var user = userManager.FindById(id);
            if (user != null)
                return user.UserName;
            return "Null";
        }
        public static string GetNameSurname()
        {
           var id= HttpContext.Current.User.Identity.GetUserId();
            if (string.IsNullOrEmpty(id))
             return "Ziyaretçi";
            else
            {
                var userManager = NewUserManager();
                var user = userManager.FindById(id);
                string nameSurname = string.Format("{0} {1}.", user.Name, user.Surname.Substring(0,1));
                return nameSurname;
            }
        }
    }
}
