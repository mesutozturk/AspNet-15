using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiBLL.Repository;
using WebApiEntities.Models;
using WebApiEntities.ViewModels;

namespace WebApiFundamentals.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CategoryController : ApiController
    {
        [HttpGet]
        // GET: api/Category
        public List<Category> Get()
        {
            //return new CategoryRepo().GetAll()
            //    .Select(x => new CategoryViewModel()
            //    {
            //        CategoryID = x.CategoryID,
            //        CategoryName = x.CategoryName,
            //        Description = x.Description,
            //        Picture = x.Picture
            //    }).ToList();
            return new CategoryRepo().GetAll();
        }
        [HttpGet]
        // GET: api/Category/5
        public Category Get(int id)
        {
            return new CategoryRepo().GetById(id);
        }
        [HttpPost]
        // POST: api/Category
        public object Post([FromBody]Category model)
        {
            try
            {
                new CategoryRepo().Insert(new Category()
                {
                    CategoryName = model.CategoryName,
                    Description = model.Description
                });
                return new
                {
                    success = true,
                    message = "Kategori ekleme işlemi başarılı",
                    data = new CategoryRepo().GetAll()
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    success = false,
                    message = "Kategori ekleme işlemi sırasında bir hata oluştu " + ex.Message
                };
            }
        }

        // PUT: api/Category/5
        [HttpPut]
        public object Put([FromBody]Category model)
        {
            return null;
        }

        // DELETE: api/Category/5
        [HttpDelete]
        public string Delete(int id)
        {
            return $"{id} li kayıt silinmiştir";
        }
    }
}
