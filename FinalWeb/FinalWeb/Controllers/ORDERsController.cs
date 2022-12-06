using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalWeb.Models;

namespace FinalWeb.Controllers
{
    public class ORDERsController : Controller
    {
        private DevConn db = new DevConn();

        // GET: ORDERs
        public ActionResult Index()
        {
            ViewBag.Order = db.ORDER.ToList();
            //return View(db.ORDER.Where(order => order.AGENTID.Equals(Session["AGENTID"])).ToList());
            return View();
        }

        // GET: ORDERs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Id = id;
            ViewBag.OrderDetail = db.ORDER_DETAIL.ToList();
            ORDER oRDER = db.ORDER.Find(id);
            if (oRDER == null)
            {
                return HttpNotFound();
            }
            return View(oRDER);
        }

        // GET: ORDERs/Create
        public ActionResult Create()
        {
            if (Session["AGENTID"]==null)
            {
                return RedirectToAction("Login","Home");
            }
            ViewBag.Delivery = db.DELIVERY.ToList();
            ViewBag.OrderDetails=db.ORDER_DETAIL.ToList();
            ViewBag.Products=db.PRODUCT.ToList();
            ViewBag.Count = "O000" + db.ORDER.Count().ToString();
            ViewBag.AGENTID = Session["AGENTID"];
            ViewBag.OrderDetail="OD00"+db.ORDER_DETAIL.Count().ToString();
            Session["deliveryFee"] = 0;
            return View();
        }

        // POST: ORDERs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="ODETAIL_ID,ODERID,PRODUCTID,BUYQUANTITY")]ORDER_DETAIL oRDER_detail,
            [Bind(Include = "ORDERID,AGENTID,DELIVERYNOTE_ID,ORDERDATE,ORDERSTATUS,PAYMENTSTATUS,PAYMENTMETHOD")] ORDER oRDER)
        {
            if (ModelState.IsValid)
            {
                List<Cart> li2 = Session["cart"] as List<Cart>;
                List<ORDER_DETAIL>oRDER_DETAILs= new List<ORDER_DETAIL>();
                
                var len = db.ORDER_DETAIL.Count();
                foreach (var p in li2)
                {
                    var deliveryFee = 0;
                    var delivery =db.DELIVERY.Where(deliver => deliver.DELIVERYNOTE_ID.Equals(oRDER.DELIVERYNOTE_ID));
                    foreach (var d in delivery)
                    {
                        deliveryFee = Convert.ToInt32(d.DELIVERYFEE);
                    }
                    Session["total"] = Convert.ToInt32(Session["total"])+deliveryFee;
                    oRDER.Total = Convert.ToInt32(Session["total"]) + deliveryFee;
                    oRDER_detail.ODETAIL_ID = "OD00" + len;
                    oRDER_detail.ORDERID = "O000" + db.ORDER.Count().ToString();
                    oRDER_detail.PRODUCTID = p.ProID;
                    oRDER_detail.BUYQUANTITY = p.qty;
                    Session["deliveryFee"] = deliveryFee;
                    oRDER_DETAILs.Add(new ORDER_DETAIL
                    {
                        ODETAIL_ID= "OD00" + len,
                        PRODUCTID = p.ProID,
                        BUYQUANTITY = p.qty,
                        ORDERID= "O000" + db.ORDER.Count().ToString(),
                    });
                    db.ORDER_DETAIL.AddRange(oRDER_DETAILs);
                    System.Diagnostics.Debug.WriteLine("\n======= ORDER DETAILS ======== \n");
                    foreach(var i in oRDER_DETAILs)
                    {
                        System.Diagnostics.Debug.WriteLine(i.ODETAIL_ID+" "+i.ORDERID+" "+i.PRODUCTID+" "+i.BUYQUANTITY);
                    }    
                    len++;
                    continue;
                }
                //foreach(var i in li2)
                //{
                //    db.PRODUCT.ToList().ForEach(j =>
                //    {
                //        if (j.PRODUCTID.Equals(i.ProID)) {
                //            j.HASSOLD += i.qty;
                //            j.PROQUANTITY-= i.qty;
                //        }
                //    });
                //}    
                //foreach(var i in li2)
                //{
                //    var data=db.PRODUCT.Find(i.ProID);
                //    data.HASSOLD += i.qty;
                //    data.PROQUANTITY-= i.qty;
                //}    
                db.ORDER.Add(oRDER);
                db.SaveChanges();
                li2.Clear();
                Session["item_count"] = 0;
                Session["total"] = 0;
                
                return RedirectToAction("Index");
            }

            return View(oRDER);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
