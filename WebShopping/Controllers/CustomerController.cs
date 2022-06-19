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
    public class CustomerController : ApiController
    {
        Customer_DAL cd = new Customer_DAL();
        [HttpPost]
        public Response login(CustomerAccount acc)
        {
            return cd.login(acc);
        }



        [HttpGet]
        public IEnumerable<CustomerAccount> customerList()
        {
            List<CustomerAccount> ls = cd.customer_list();
            return ls;
        }




        public string Get(int id)
        {
            return "value";
        }



        [HttpPost]
        public Response register([FromBody] CustomerAccount acc)
        {
            return cd.Register(acc);
        }

        [HttpPut]
        public Response updatePassword([FromBody] CustomerAccount acc)
        {
            return cd.updatepassword(acc);
        }

        public void Delete(int id)
        {

        }
    }
}