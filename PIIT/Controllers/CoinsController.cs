using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PIIT.Data;
using PIIT.Models;

namespace PIIT.Controllers
{
    public class CoinsController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: Coins
        public ActionResult Index()
        {
            return View(db.Coin.ToList());
        }

        // GET: Coins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coin coin = db.Coin.Find(id);
            if (coin == null)
            {
                return HttpNotFound();
            }
            return View(coin);
        }
       

        // GET: Coins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,BaseAsset,QuoteAsset,LastPrice,Volumn24h,MarketID,CreateAt,UpdateAt,Status")] Coin coin)
        {
            if (ModelState.IsValid)
            {
                db.Coin.Add(coin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coin);
        }

        // GET: Coins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coin coin = db.Coin.Find(id);
            if (coin == null)
            {
                return HttpNotFound();
            }
            return View(coin);
        }

        // POST: Coins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,BaseAsset,QuoteAsset,LastPrice,Volumn24h,MarketID,CreateAt,UpdateAt,Status")] Coin coin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coin);
        }

        // GET: Coins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coin coin = db.Coin.Find(id);
            if (coin == null)
            {
                return HttpNotFound();
            }
            return View(coin);
        }

        // POST: Coins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coin coin = db.Coin.Find(id);
            db.Coin.Remove(coin);
            db.SaveChanges();
            return RedirectToAction("Index");
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
