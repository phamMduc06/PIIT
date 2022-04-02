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
    public class CoinMarketsController : Controller
    {
        private MyDBContext db = new MyDBContext();

        // GET: CoinMarkets
        public ActionResult Index()
        {
            return View(db.CoinMarket.ToList());
        }

        // GET: CoinMarkets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoinMarket coinMarket = db.CoinMarket.Find(id);
            if (coinMarket == null)
            {
                return HttpNotFound();
            }
            return View(coinMarket);
        }

        // GET: CoinMarkets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoinMarkets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,CreateAt,UpdateAt,Status")] CoinMarket coinMarket)
        {
            if (ModelState.IsValid)
            {
                db.CoinMarket.Add(coinMarket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coinMarket);
        }

        // GET: CoinMarkets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoinMarket coinMarket = db.CoinMarket.Find(id);
            if (coinMarket == null)
            {
                return HttpNotFound();
            }
            return View(coinMarket);
        }

        // POST: CoinMarkets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CreateAt,UpdateAt,Status")] CoinMarket coinMarket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coinMarket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coinMarket);
        }

        // GET: CoinMarkets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoinMarket coinMarket = db.CoinMarket.Find(id);
            if (coinMarket == null)
            {
                return HttpNotFound();
            }
            return View(coinMarket);
        }

        // POST: CoinMarkets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CoinMarket coinMarket = db.CoinMarket.Find(id);
            db.CoinMarket.Remove(coinMarket);
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
