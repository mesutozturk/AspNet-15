using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;
using Uyelik.BLL.Account;

namespace Uyelik.API.Auth
{
    public class Saglayici : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            
            var userManager = MembershipTools.NewUserManager();

            var user = userManager.Find(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("Geçersiz istek", "Hatalı kullanıcı bilgisi");
            }
            else
            {
                ClaimsIdentity identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ExternalBearer);

                context.Validated(identity);
            }
        }
    }
}