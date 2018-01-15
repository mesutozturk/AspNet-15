using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiBLL.Repository;
using WebApiEntities.Models;

namespace WebApiFundamentals.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductController : ApiController
    {
        //[Route("~/api/Product/{catid}/Get")]

        [HttpGet]
        public List<Product> Get(int catid)
        {
            return new CategoryRepo().GetById(catid).Products.ToList();
        }
    }
}
