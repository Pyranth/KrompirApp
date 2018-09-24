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
    public class ParcelaController : Controller
    {
        private KrompirDatabaseEntities db = new KrompirDatabaseEntities();

        // GET: Parcela
        /*
        public ActionResult Index()
        {
            var pARCELA = db.PARCELA.Include(p => p.PROIZVODJAC).Include(p => p.SIFRA_SORTE);
            return View(pARCELA.ToList());
        }
        */

        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var pARCELA = db.PARCELA.Where(p => p.PROIZVODJACID == id).Where(m => m.DELETED == false).Include(p => p.SIFRA_SORTE);
            return View(pARCELA.ToList());
        }

        // GET: Parcela/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARCELA pARCELA = db.PARCELA.Find(id);
            if (pARCELA == null)
            {
                return HttpNotFound();
            }
            return View(pARCELA);
        }

        // GET: Parcela/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.PROIZVODJACID = new SelectList(db.PROIZVODJAC.Where(m => m.PROIZVODJACID == id), "PROIZVODJACID", "APIF");
            ViewBag.SORTAID = new SelectList(db.SIFRA_SORTE, "SORTAID", "NAZIV");
            return View();
        }

        // POST: Parcela/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PARCELAID,PROIZVODJACID,MJESTO,KATASTARSKAOPSTINA,KCBROJ,POVRSINA,PREDUSJEV,SORTAID,POSADJENAKATEGORIJASADNOGMATERIJALA,DATUMSADNJE,POSADJENAKOLICINA")] PARCELA pARCELA)
        {
            if (ModelState.IsValid)
            {
                db.PARCELA.Add(pARCELA);
                db.SaveChanges();
                return RedirectToAction("Index", "Parcela", new { id = pARCELA.PROIZVODJACID });
            }

            ViewBag.PROIZVODJACID = new SelectList(db.PROIZVODJAC, "PROIZVODJACID", "IME", pARCELA.PROIZVODJACID);
            ViewBag.SORTAID = new SelectList(db.SIFRA_SORTE, "SORTAID", "NAZIV", pARCELA.SORTAID);
            return View(pARCELA);
        }

        // GET: Parcela/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARCELA pARCELA = db.PARCELA.Find(id);
            if (pARCELA == null)
            {
                return HttpNotFound();
            }
            ViewBag.PROIZVODJACID = new SelectList(db.PROIZVODJAC, "PROIZVODJACID", "IME", pARCELA.PROIZVODJACID);
            ViewBag.SORTAID = new SelectList(db.SIFRA_SORTE, "SORTAID", "NAZIV", pARCELA.SORTAID);
            return View(pARCELA);
        }

        // POST: Parcela/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PARCELAID,PROIZVODJACID,MJESTO,KATASTARSKAOPSTINA,KCBROJ,POVRSINA,PREDUSJEV,SORTAID,POSADJENAKATEGORIJASADNOGMATERIJALA,DATUMSADNJE,POSADJENAKOLICINA")] PARCELA pARCELA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pARCELA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PROIZVODJACID = new SelectList(db.PROIZVODJAC, "PROIZVODJACID", "IME", pARCELA.PROIZVODJACID);
            ViewBag.SORTAID = new SelectList(db.SIFRA_SORTE, "SORTAID", "NAZIV", pARCELA.SORTAID);
            return View(pARCELA);
        }

        // GET: Parcela/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARCELA pARCELA = db.PARCELA.Find(id);
            if (pARCELA == null)
            {
                return HttpNotFound();
            }
            return View(pARCELA);
        }

        // POST: Parcela/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PARCELA pARCELA = db.PARCELA.Find(id);
            pARCELA.DELETED = true;
            db.Entry(pARCELA).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Parcela", new { id = pARCELA.PROIZVODJACID });
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
