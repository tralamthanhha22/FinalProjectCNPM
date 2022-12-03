using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalWeb.Models;

namespace FinalWeb.Views
{
    public class DELIVERiesController : Controller
    {
        private DevConn db = new DevConn();

        // GET: DELIVERies
        public ActionResult Index()
        {
            return View(db.DELIVERY.ToList());
        }

        // GET: DELIVERies/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    DELIVERY dELIVERY = db.DELIVERY.Find(id);
        //    if (dELIVERY == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(dELIVERY);
        //}

        // GET: DELIVERies/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: DELIVERies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "DELIVERYNOTE_ID,DELIVERYNAME,DELIVERYFEE,DELIVERYIMG")] DELIVERY dELIVERY)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.DELIVERY.Add(dELIVERY);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(dELIVERY);
        //}

        // GET: DELIVERies/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    DELIVERY dELIVERY = db.DELIVERY.Find(id);
        //    if (dELIVERY == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(dELIVERY);
        //}

        // POST: DELIVERies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "DELIVERYNOTE_ID,DELIVERYNAME,DELIVERYFEE,DELIVERYIMG")] DELIVERY dELIVERY)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(dELIVERY).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(dELIVERY);
        //}

        // GET: DELIVERies/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    DELIVERY dELIVERY = db.DELIVERY.Find(id);
        //    if (dELIVERY == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(dELIVERY);
        //}

        //// POST: DELIVERies/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    DELIVERY dELIVERY = db.DELIVERY.Find(id);
        //    db.DELIVERY.Remove(dELIVERY);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
