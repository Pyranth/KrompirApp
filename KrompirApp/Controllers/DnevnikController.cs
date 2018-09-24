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
    public class DnevnikController : Controller
    {
        private KrompirDatabaseEntities db = new KrompirDatabaseEntities();

        // GET: Dnevnik
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var dNEVNIK_PARCELE = db.DNEVNIK_PARCELE.Where(d => d.PARCELAID == id).Where(m => m.DELTED == false); // DELTED typo :(
            return View(dNEVNIK_PARCELE.ToList());
        }

        // GET: Dnevnik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DNEVNIK_PARCELE dNEVNIK_PARCELE = db.DNEVNIK_PARCELE.Find(id);
            if (dNEVNIK_PARCELE == null)
            {
                return HttpNotFound();
            }
            return View(dNEVNIK_PARCELE);
        }

        // GET: Dnevnik/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.PARCELAID = new SelectList(db.PARCELA.Where(m => m.PARCELAID == id), "PARCELAID", "MJESTO");

            DNEVNIK_PARCELE model = new DNEVNIK_PARCELE();
            model.PARCELAID = id;
            model.PARCELA = db.PARCELA.Find(id);

            return View(model);
        }

        // POST: Dnevnik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DNEVNIKID,NAZIVRADNEOPERACIJE,DATUM,KORISCENOPOGONSKOSREDSTVOMEHANIZACIJE,KORISCENIPRIKLJUCAK,NAZIVKORISCENOGPOTROSNOGMATERIJALA,JEDINICAMJERE,KOLICINAUTROSENOGPOTROSNOGMATERIJALA,UTROSENOVRIJEMERADAMEHANIZACIJE,UTROSENOVRIJEMERADARADNIKA,PARCELAID")] DNEVNIK_PARCELE dNEVNIK_PARCELE)
        {
            if (ModelState.IsValid)
            {
                db.DNEVNIK_PARCELE.Add(dNEVNIK_PARCELE);
                db.SaveChanges();
                return RedirectToAction("Index", "Dnevnik", new { id = dNEVNIK_PARCELE.PARCELAID });
            }

            ViewBag.PARCELAID = new SelectList(db.PARCELA, "PARCELAID", "MJESTO", dNEVNIK_PARCELE.PARCELAID);
            return View(dNEVNIK_PARCELE);
        }

        // GET: Dnevnik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DNEVNIK_PARCELE dNEVNIK_PARCELE = db.DNEVNIK_PARCELE.Find(id);
            if (dNEVNIK_PARCELE == null)
            {
                return HttpNotFound();
            }
            ViewBag.PARCELAID = new SelectList(db.PARCELA, "PARCELAID", "MJESTO", dNEVNIK_PARCELE.PARCELAID);
            return View(dNEVNIK_PARCELE);
        }

        // POST: Dnevnik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DNEVNIKID,NAZIVRADNEOPERACIJE,DATUM,KORISCENOPOGONSKOSREDSTVOMEHANIZACIJE,KORISCENIPRIKLJUCAK,NAZIVKORISCENOGPOTROSNOGMATERIJALA,JEDINICAMJERE,KOLICINAUTROSENOGPOTROSNOGMATERIJALA,UTROSENOVRIJEMERADAMEHANIZACIJE,UTROSENOVRIJEMERADARADNIKA,PARCELAID")] DNEVNIK_PARCELE dNEVNIK_PARCELE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dNEVNIK_PARCELE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PARCELAID = new SelectList(db.PARCELA, "PARCELAID", "MJESTO", dNEVNIK_PARCELE.PARCELAID);
            return View(dNEVNIK_PARCELE);
        }

        // GET: Dnevnik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DNEVNIK_PARCELE dNEVNIK_PARCELE = db.DNEVNIK_PARCELE.Find(id);
            if (dNEVNIK_PARCELE == null)
            {
                return HttpNotFound();
            }
            return View(dNEVNIK_PARCELE);
        }

        // POST: Dnevnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DNEVNIK_PARCELE dNEVNIK_PARCELE = db.DNEVNIK_PARCELE.Find(id);
            dNEVNIK_PARCELE.DELTED = true;
            db.Entry(dNEVNIK_PARCELE).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Dnevnik", new { id = dNEVNIK_PARCELE.PARCELAID });
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
