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
    public class ProizvedenoController : Controller
    {
        private KrompirDatabaseEntities db = new KrompirDatabaseEntities();

        // GET: Proizvedeno
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var kOLICINA_PROIZVEDENOG_KROMPIRA = db.KOLICINA_PROIZVEDENOG_KROMPIRA.Where(k => k.PROIZVODJACID == id).Include(k => k.SIFRA_SORTE);
            return View(kOLICINA_PROIZVEDENOG_KROMPIRA.Where(m => m.DELETED == false).ToList());
        }

        // GET: Proizvedeno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KOLICINA_PROIZVEDENOG_KROMPIRA kOLICINA_PROIZVEDENOG_KROMPIRA = db.KOLICINA_PROIZVEDENOG_KROMPIRA.Find(id);
            if (kOLICINA_PROIZVEDENOG_KROMPIRA == null)
            {
                return HttpNotFound();
            }
            return View(kOLICINA_PROIZVEDENOG_KROMPIRA);
        }

        // GET: Proizvedeno/Create
        public ActionResult Create()
        {
            ViewBag.PROIZVODJACID = new SelectList(db.PROIZVODJAC, "PROIZVODJACID", "IME");
            ViewBag.SORTAID = new SelectList(db.SIFRA_SORTE, "SORTAID", "NAZIV");
            return View();
        }

        // POST: Proizvedeno/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KOLICINAPROIZVEDENOGKROMPIRAID,PROIZVODJACID,UKUPNAPROIZVEDENAKOLICINA,SORTAID")] KOLICINA_PROIZVEDENOG_KROMPIRA kOLICINA_PROIZVEDENOG_KROMPIRA)
        {
            if (ModelState.IsValid)
            {
                db.KOLICINA_PROIZVEDENOG_KROMPIRA.Add(kOLICINA_PROIZVEDENOG_KROMPIRA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PROIZVODJACID = new SelectList(db.PROIZVODJAC, "PROIZVODJACID", "IME", kOLICINA_PROIZVEDENOG_KROMPIRA.PROIZVODJACID);
            ViewBag.SORTAID = new SelectList(db.SIFRA_SORTE, "SORTAID", "NAZIV", kOLICINA_PROIZVEDENOG_KROMPIRA.SORTAID);
            return View(kOLICINA_PROIZVEDENOG_KROMPIRA);
        }

        // GET: Proizvedeno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KOLICINA_PROIZVEDENOG_KROMPIRA kOLICINA_PROIZVEDENOG_KROMPIRA = db.KOLICINA_PROIZVEDENOG_KROMPIRA.Find(id);
            if (kOLICINA_PROIZVEDENOG_KROMPIRA == null)
            {
                return HttpNotFound();
            }
            ViewBag.PROIZVODJACID = new SelectList(db.PROIZVODJAC, "PROIZVODJACID", "IME", kOLICINA_PROIZVEDENOG_KROMPIRA.PROIZVODJACID);
            ViewBag.SORTAID = new SelectList(db.SIFRA_SORTE, "SORTAID", "NAZIV", kOLICINA_PROIZVEDENOG_KROMPIRA.SORTAID);
            return View(kOLICINA_PROIZVEDENOG_KROMPIRA);
        }

        // POST: Proizvedeno/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KOLICINAPROIZVEDENOGKROMPIRAID,PROIZVODJACID,UKUPNAPROIZVEDENAKOLICINA,SORTAID")] KOLICINA_PROIZVEDENOG_KROMPIRA kOLICINA_PROIZVEDENOG_KROMPIRA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kOLICINA_PROIZVEDENOG_KROMPIRA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PROIZVODJACID = new SelectList(db.PROIZVODJAC, "PROIZVODJACID", "IME", kOLICINA_PROIZVEDENOG_KROMPIRA.PROIZVODJACID);
            ViewBag.SORTAID = new SelectList(db.SIFRA_SORTE, "SORTAID", "NAZIV", kOLICINA_PROIZVEDENOG_KROMPIRA.SORTAID);
            return View(kOLICINA_PROIZVEDENOG_KROMPIRA);
        }

        // GET: Proizvedeno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KOLICINA_PROIZVEDENOG_KROMPIRA kOLICINA_PROIZVEDENOG_KROMPIRA = db.KOLICINA_PROIZVEDENOG_KROMPIRA.Find(id);
            if (kOLICINA_PROIZVEDENOG_KROMPIRA == null)
            {
                return HttpNotFound();
            }
            return View(kOLICINA_PROIZVEDENOG_KROMPIRA);
        }

        // POST: Proizvedeno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KOLICINA_PROIZVEDENOG_KROMPIRA kOLICINA_PROIZVEDENOG_KROMPIRA = db.KOLICINA_PROIZVEDENOG_KROMPIRA.Find(id);
            kOLICINA_PROIZVEDENOG_KROMPIRA.DELETED = true;
            db.Entry(kOLICINA_PROIZVEDENOG_KROMPIRA).State = EntityState.Modified;
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
