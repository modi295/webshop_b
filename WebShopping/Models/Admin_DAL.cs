using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShopping.Context;

namespace WebShopping.Models
{
    public class Admin_DAL
    {
        Webshop_DBEntities db = new Webshop_DBEntities();

        public Response login(AdminAccount acc)
        {
            var log = db.AdminAccounts.Where(x => x.AdminID.Equals(acc.AdminID) && x.Password.Equals(acc.Password)).FirstOrDefault();

            if (log == null)
            {
                return new Response { Status = "Invalid", Message = "Invalid User." };
            }
            else
                return new Response { Status = "Success", Message = "Login Successfully" };
        }
        public Response Register(Product obj)
        {
            var log = db.Products.Find(obj.productId);
            if (log == null)
            {
                db.Products.Add(obj);
                db.SaveChanges();
                return new Response { Status = "Success", Message = "product added Successfully" };
            }
            else
            {
                return new Response { Status = "Invalid", Message = "product id already exists." };
            }

        }

        public List<Product> product_list()
        {
            List<Product> ls = db.Products.ToList();
            return ls;
        }

        public Response updateproduct(Product prd)
        {
            Product p = db.Products.Find(prd.productId);
            if (p != null)
            {
                p.productId = prd.productId;
                p.ProductName = prd.ProductName;
                p.productPrice = prd.productPrice;
                p.productCategory = prd.productCategory;
                p.productDescription = prd.productDescription;
                p.productUrl = prd.productUrl;
                db.SaveChanges();
                return new Response { Status = "Success", Message = "product updated" };
            }
            else
            {
                return new Response { Status = "Invalid", Message = "product not updated" };
            }

        }
        public Response updatepassword(AdminAccount acc)
        {
            AdminAccount ac = db.AdminAccounts.Find(acc.AdminID);
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

        public Response deleteproduct(int id)
        {
            var obj = db.Products.Find(id);
            if (obj != null)
            {
                db.Products.Remove(obj);
                db.SaveChanges();
                return new Response { Status = "Success", Message = "product deleted Successfully" };
            }
            else
            {
                return new Response { Status = "Invalid", Message = "Product doesn't exists" };
            }
        }

    }



}