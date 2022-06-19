
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
    public class OrdersController : ApiController
    {
        Order_DAL ords = new Order_DAL();
        // GET api/values
        [HttpGet]
        public IEnumerable<Order> ordersList()
        {
            List<Order> ls = ords.orders_list();
            return ls;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void addproduct([FromBody] Order ord)
        {
            ords.addtocart(ord);
        }

        // PUT api/values/5


        // DELETE api/values/5
        [HttpDelete]
        public void deleteProduct(int id)
        {
            ords.deleteproduct(id);
        }
    }
}

