using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.AspNet.Identity;
using Uyelik.API.Models;
using Uyelik.BLL.Repository;
using Uyelik.Entity.Entities;
using Uyelik.Entity.ViewModels;

namespace Uyelik.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MessageController : ApiController
    {
        public ResponseModel GetAllMessages()
        {
            try
            {
                var model = new MessageRepo().GetAll().Select(x => new
                {
                    x.Id,
                    x.Content,
                    x.Level,
                    x.MessageDate,
                    x.SendBy,
                    x.SentTo
                }).ToList();
                return new ResponseModel()
                {
                    success = true,
                    data = model
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    success = false,
                    message = $"Veritabanı bağlantı sorunu: {ex.Message}"
                };
            }
        }
        [Authorize]
        [HttpPost]
        public ResponseModel SendMessage([FromBody]SendMessageViewModel model)
        {
            try
            {
                new MessageRepo().Insert(new Message()
                {
                    Content = model.Content,
                    Level = model.Level,
                    SentTo = model.SentTo,
                    SendBy = HttpContext.Current.User.Identity.GetUserId()
                });
                return new ResponseModel()
                {
                    success = true,
                    message = "Mesajınız iletilmiştir"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    success = false,
                    message = $"Veritabanı bağlantı sorunu: {ex.Message}"
                };
            }
        }
    }
}
