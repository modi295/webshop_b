
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShopping.Context;

namespace WebShopping.Models
{
    public class Order_DAL
    {
        Webshop_DBEntities db = new Webshop_DBEntities();
        public List<Order> orders_list()
        {
            List<Order> ls = db.Orders.ToList();
            return ls;
        }

        public void addtocart(Order ord)
        {
            db.Orders.Add(ord);
            db.SaveChanges();


        }
        public void deleteproduct(int id)
        {
            var obj = db.Orders.Find(id);
            if (obj != null)
            {
                db.Orders.Remove(obj);
                db.SaveChanges();
            }
        }
    }
}