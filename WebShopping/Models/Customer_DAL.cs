using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using WebShopping.Context;

namespace WebShopping.Models
{
    public class Customer_DAL
    {
        Webshop_DBEntities db = new Webshop_DBEntities();

        public List<CustomerAccount> customer_list()
        {
            List<CustomerAccount> ls = db.CustomerAccounts.ToList();
            return ls;
        }
        public Response login(CustomerAccount acc)
        {
            var log = db.CustomerAccounts.Where(x => x.CustomerID.Equals(acc.CustomerID) && x.Password.Equals(acc.Password)).FirstOrDefault();

            if (log == null)
            {
                return new Response { Status = "Invalid", Message = "Invalid User." };
            }
            else
                return new Response { Status = "Success", Message = "Login Successfully" };
        }

        public Response Register(CustomerAccount acc)
        {
            var log = db.CustomerAccounts.Find(acc.CustomerID);
            if (log == null)
            {
                db.CustomerAccounts.Add(acc);
                db.SaveChanges();
                return new Response { Status = "Success", Message = "customer registration Successfully" };
            }
            else
            {
                return new Response { Status = "Invalid", Message = "user id already exists." };
            }

        }

        public Response updatepassword(CustomerAccount acc)
        {
            CustomerAccount ac = db.CustomerAccounts.Find(acc.CustomerID);

            if (ac != null)
            {
                ac.Password = acc.Password;
                db.SaveChanges();
                return new Response { Status = "Success", Message = "password changed" };
            }
            else
            {
                return new Response { Status = "Invalid", Message = "password not changed" };
            }

        }
    }
}