using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KrompirApp;

namespace KrompirApp.Controllers
{
    public class EtiketaController : Controller
    {
        private KrompirDatabaseEntities db = new KrompirDatabaseEntities();

        // GET: Etiketa
        public ActionResult Index()
        {
            var eTIKETA = db.ETIKETA.Include(e => e.PROIZVODJAC).Include(e => e.SIFRA_SORTE);
            return View(eTIKETA.ToList());
        }

        // GET: Etiketa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ETIKETA eTIKETA = db.ETIKETA.Find(id);
            if (eTIKETA == null)
            {
                return HttpNotFound();
            }
            return View(eTIKETA);
        }

        // GET: Etiketa/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.PROIZVODJACID = new SelectList(db.PROIZVODJAC.Where(m => m.PROIZVODJACID == id), "PROIZVODJACID", "IME");
            ViewBag.SORTAID = new SelectList(db.SIFRA_SORTE, "SORTAID", "NAZIV");
            return View();
        }

        // POST: Etiketa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ETIKETAID,PROIZVODJACID,SORTAID,SIFRAPAKOVANJA,REDNIBROJZAHTJEVAPROIZVODJACA,ZASTITA,DELETED")] ETIKETA eTIKETA)
        {
            if (ModelState.IsValid)
            {
                eTIKETA.ZASTITA = (new Random()).Next(100, 999).ToString();
                db.ETIKETA.Add(eTIKETA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PROIZVODJACID = new SelectList(db.PROIZVODJAC, "PROIZVODJACID", "IME", eTIKETA.PROIZVODJACID);
            ViewBag.SORTAID = new SelectList(db.SIFRA_SORTE, "SORTAID", "NAZIV", eTIKETA.SORTAID);
            return View(eTIKETA);
        }

        // GET: Etiketa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ETIKETA eTIKETA = db.ETIKETA.Find(id);
            if (eTIKETA == null)
            {
                return HttpNotFound();
            }
            ViewBag.PROIZVODJACID = new SelectList(db.PROIZVODJAC, "PROIZVODJACID", "IME", eTIKETA.PROIZVODJACID);
            ViewBag.SORTAID = new SelectList(db.SIFRA_SORTE, "SORTAID", "NAZIV", eTIKETA.SORTAID);
            return View(eTIKETA);
        }

        // POST: Etiketa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ETIKETAID,PROIZVODJACID,SORTAID,SIFRAPAKOVANJA,REDNIBROJZAHTJEVAPROIZVODJACA,ZASTITA,DELETED")] ETIKETA eTIKETA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eTIKETA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PROIZVODJACID = new SelectList(db.PROIZVODJAC, "PROIZVODJACID", "IME", eTIKETA.PROIZVODJACID);
            ViewBag.SORTAID = new SelectList(db.SIFRA_SORTE, "SORTAID", "NAZIV", eTIKETA.SORTAID);
            return View(eTIKETA);
        }

        // GET: Etiketa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ETIKETA eTIKETA = db.ETIKETA.Find(id);
            if (eTIKETA == null)
            {
                return HttpNotFound();
            }
            return View(eTIKETA);
        }

        // POST: Etiketa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ETIKETA eTIKETA = db.ETIKETA.Find(id);
            db.ETIKETA.Remove(eTIKETA);
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
