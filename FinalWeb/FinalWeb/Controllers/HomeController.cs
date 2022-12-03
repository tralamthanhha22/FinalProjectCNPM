using FinalWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalWeb.Controllers
{
    public class HomeController : Controller
    {
        private DevConn db = new DevConn();
        List<Cart> cartList = new List<Cart>();
        public ActionResult Index()
        {
            ViewBag.Products=db.PRODUCT.ToList();
            if (Session["cart"] != null)
            {
                int x = 0;

                List<Cart> li2 = Session["cart"] as List<Cart>;
                foreach (var item in li2)
                {
                    x += item.bill;

                }
                Session["total"] = x;
                Session["item_count"] = li2.Count();
            }
            //TempData.Keep();

            var query = db.PRODUCT.ToList();
            return View(query);
            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        public ActionResult Login() { return View(); }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "AGENTID,AGENTNAME,AGENTADDRESS,AGENTEMAIL,AGENTPHONE,AGENTPASSWORD")] AGENT aGENT)
        {
            if (ModelState.IsValid)
            {
                var data = db.AGENT.Where(agent => agent.AGENTPASSWORD.Equals(aGENT.AGENTPASSWORD) && agent.AGENTEMAIL.Equals(aGENT.AGENTEMAIL)).ToList();
                if (data.Count() > 0)
                {
                    Session["Fullname"] = data.FirstOrDefault().AGENTNAME;
                    Session["password"] = data.FirstOrDefault().AGENTPASSWORD;
                    Session["email"] = data.FirstOrDefault().AGENTEMAIL;
                    Session["AGENTID"] = data.FirstOrDefault().AGENTID;
                    Session["AGENTPHONE"]=data.FirstOrDefault().AGENTPHONE;
                    Session["AGENTADDRESS"] = data.FirstOrDefault().AGENTADDRESS;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

        public ActionResult AddtoCart(string id)
        {
            var query =db.PRODUCT.Where(x=>x.PRODUCTID.Equals(id)).SingleOrDefault();
            return View(query);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AddtoCart(string id,int qty)
        {
            PRODUCT p = db.PRODUCT.Where(x => x.PRODUCTID.Equals(id)).SingleOrDefault();
            Cart cart = new Cart();
            cart.ProID = id;
            cart.Proname = p.PRONAME;
            cart.ProID = p.PRODUCTID;
            cart.qty = qty;
            cart.Proprice= Convert.ToInt32(p.PROPRICE);
            cart.bill = cart.Proprice * cart.qty;
            cart.ProImg = p.PROIMG;
            if (Session["cart"]==null)
            {
                cartList.Add(cart);
                Session["cart"] = cartList;
            }
            else
            {
                List<Cart> li2 = Session["cart"] as List<Cart>;
                int flag = 0;
                foreach (var item in li2)
                {
                    if (item.ProID == cart.ProID)
                    {
                        item.qty += cart.qty;
                        item.bill += cart.bill;
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    li2.Add(cart);
                    //new item
                }
                Session["cart"] = li2;
            }
            return RedirectToAction("Index");
        }
        public ActionResult CheckOut()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult CheckOut()
        //{
        //    return View();
        //}
        public ActionResult remove(string id)
        {
            if (Session["cart"] == null)
            {
                Session.Remove("total");
                Session.Remove("cart");
            }
            else
            {
                List<Cart> li2 = Session["cart"] as List<Cart>;
                Cart c = li2.Where(x => x.ProID == id).SingleOrDefault();
                li2.Remove(c);
                int s = 0;
                foreach (var item in li2)
                {
                    s += item.bill;
                }
                Session["total"] = s;

            }
            return RedirectToAction("Index");
        }
    }
}