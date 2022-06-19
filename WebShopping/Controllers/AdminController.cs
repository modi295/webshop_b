
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebShopping.Context;
using WebShopping.Models;

namespace WebShopping.Controllers
{
    public class AdminController : ApiController
    {
        Admin_DAL ad = new Admin_DAL();
        Product p = new Product();
        Webshop_DBEntities db = new Context.Webshop_DBEntities();


        [HttpPost]
        public Response login(AdminAccount acc)
        {

            return ad.login(acc);
        }



        [HttpGet]
        public IEnumerable<Product> productList()
        {
            List<Product> ls = ad.product_list();
            return ls;
        }

        [HttpPost]
        public Response addproduct([FromBody] Product obj)
        {
            return ad.Register(obj);
        }

        [HttpPut]
        public Response updateProduct([FromBody] Product prd)
        {
            return ad.updateproduct(prd);
        }
        [HttpPut]
        public Response updatePassword([FromBody] AdminAccount acc)
        {
            return ad.updatepassword(acc);
        }

        [HttpDelete]
        public Response deleteProduct(int id)
        {
            return ad.deleteproduct(id);
        }
    }
}