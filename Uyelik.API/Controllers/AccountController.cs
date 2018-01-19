using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Uyelik.API.Models;
using Uyelik.BLL.Account;
using Uyelik.BLL.Settings;
using Uyelik.Entity.Enums;
using Uyelik.Entity.IdentityModels;
using Uyelik.Entity.ViewModels;

namespace Uyelik.API.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AccountController : ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<ResponseModel> Register([FromBody]RegisterViewModel model)
        {
            if (model == null)
                return new ResponseModel
                {
                    success = false,
                    message = "Model error"
                };
            try
            {
                var userManager = MembershipTools.NewUserManager();
                var checkUser = userManager.Find(model.Username, model.Password);
                if (checkUser != null)
                    return new ResponseModel()
                    {
                        success = false,
                        message = "Kullanıcı sisteme zaten kayıtlı"
                    };
                var activationCode = Guid.NewGuid().ToString().Replace("-", "");
                var user = new ApplicationUser()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    UserName = model.Username,
                    ActivationCode = activationCode
                };
                var sonuc = userManager.Create(user, model.Password);
                if (sonuc.Succeeded)
                {
                    userManager.AddToRole(user.Id,
                        userManager.Users.Count() == 1
                            ? IdentityRoles.Admin.ToString()
                            : IdentityRoles.Passive.ToString());

                    string siteUrl = "http://localhost:37816/";
                    await SiteSettings.SendMail(new MailModel()
                    {
                        To = user.Email,
                        Subject = "UyelikDB - Aktivasyon",
                        Message = $"Merhaba {user.Name} {user.Surname} <br/>Hesabınızı aktifleştirmek için <b><a href='{siteUrl}/Account/Activation?code={activationCode}'>Aktivasyon Kodu</a></b> tıklayınız."
                    });
                }
                else
                {
                    return new ResponseModel()
                    {
                        success = false,
                        message = "Kayıt işleminde bir hata oldu. Lütfen tekrar deneyin"
                    };
                }
                return new ResponseModel()
                {
                    success = true,
                    message = $"{user.UserName} sisteme kayıt işlemi başarılı"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    success = false,
                    message = $"Kayıt işleminde bir hata oldu. Lütfen tekrar deneyin. {ex.Message}"
                };
            }
        }
    }
}
