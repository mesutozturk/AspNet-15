using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Uyelik.Entity.IdentityModels
{
    public class ApplicationRole:IdentityRole
    {
        [StringLength(200)]
        public string Description { get; set; }
    }
}
