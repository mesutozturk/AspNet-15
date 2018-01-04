using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Uyelik.Entity.Entities;
using Uyelik.Entity.IdentityModels;

namespace Uyelik.DAL
{
    public class MyContext : IdentityDbContext<ApplicationUser>
    {
        public MyContext()
            :base("name=MyCon")
        {}

        public virtual DbSet<Message> Messages { get; set; }
    }
}
