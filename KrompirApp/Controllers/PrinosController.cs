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
    public class PrinosController : Controller
    {
        private KrompirDatabaseEntities db = new KrompirDatabaseEntities();

        // GET: Prinos
        public ActionResult Index()
        {
            var pRINOS_PARCELE = db.PRINOS_PARCELE.Include(p => p.PARCELA);
            return View(pRINOS_PARCELE.Where(m => m.DELETED == false).ToList());
        }

        // GET: Prinos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRINOS_PARCELE pRINOS_PARCELE = db.PRINOS_PARCELE.Find(id);
            if (pRINOS_PARCELE == null)
            {
                return HttpNotFound();
            }
            return View(pRINOS_PARCELE);
        }

        // GET: Prinos/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PRINOS_PARCELE model = new PRINOS_PARCELE();
            model.PARCELA = db.PARCELA.Find(id);
            model.PARCELAID = id;

            ViewBag.PARCELAID = new SelectList(db.PARCELA.Where(m => m.PARCELAID == id), "PARCELAID", "MJESTO");
            return View(model);
        }

        // POST: Prinos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRINOSID,PROIZVEDENAKOLICINA,PARCELAID")] PRINOS_PARCELE pRINOS_PARCELE)
        {
            if (ModelState.IsValid)
            {
                pRINOS_PARCELE.PARCELA = db.PARCELA.Find(pRINOS_PARCELE.PARCELAID);

                KOLICINA_PROIZVEDENOG_KROMPIRA kolicina = db.KOLICINA_PROIZVEDENOG_KROMPIRA.Where(m => m.PROIZVODJACID == pRINOS_PARCELE.PARCELA.PROIZVODJACID && m.SORTAID == pRINOS_PARCELE.PARCELA.SORTAID).SingleOrDefault();
                if (kolicina == null)
                {
                    kolicina = new KOLICINA_PROIZVEDENOG_KROMPIRA();
                    kolicina.PROIZVODJACID = pRINOS_PARCELE.PARCELA.PROIZVODJACID;
                    kolicina.SIFRA_SORTE = pRINOS_PARCELE.PARCELA.SIFRA_SORTE;
                    kolicina.UKUPNAPROIZVEDENAKOLICINA = pRINOS_PARCELE.PROIZVEDENAKOLICINA;

                    db.KOLICINA_PROIZVEDENOG_KROMPIRA.Add(kolicina);
                }
                else
                {
                    kolicina.UKUPNAPROIZVEDENAKOLICINA += pRINOS_PARCELE.PROIZVEDENAKOLICINA;
                }

                db.PRINOS_PARCELE.Add(pRINOS_PARCELE);
                db.SaveChanges();
                return RedirectToAction("Index", "Parcela", new { id = db.PARCELA.Find(pRINOS_PARCELE.PARCELAID).PROIZVODJACID });
            }

            ViewBag.PARCELAID = new SelectList(db.PARCELA, "PARCELAID", "MJESTO", pRINOS_PARCELE.PARCELAID);
            return View(pRINOS_PARCELE);
        }

        // GET: Prinos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRINOS_PARCELE pRINOS_PARCELE = db.PRINOS_PARCELE.Find(id);
            if (pRINOS_PARCELE == null)
            {
                return HttpNotFound();
            }
            ViewBag.PARCELAID = new SelectList(db.PARCELA, "PARCELAID", "MJESTO", pRINOS_PARCELE.PARCELAID);
            return View(pRINOS_PARCELE);
        }

        // POST: Prinos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRINOSID,PROIZVEDENAKOLICINA,PARCELAID")] PRINOS_PARCELE pRINOS_PARCELE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRINOS_PARCELE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PARCELAID = new SelectList(db.PARCELA, "PARCELAID", "MJESTO", pRINOS_PARCELE.PARCELAID);
            return View(pRINOS_PARCELE);
        }

        // GET: Prinos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRINOS_PARCELE pRINOS_PARCELE = db.PRINOS_PARCELE.Find(id);
            if (pRINOS_PARCELE == null)
            {
                return HttpNotFound();
            }
            return View(pRINOS_PARCELE);
        }

        // POST: Prinos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRINOS_PARCELE pRINOS_PARCELE = db.PRINOS_PARCELE.Find(id);
            pRINOS_PARCELE.DELETED = true;
            db.Entry(pRINOS_PARCELE).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Parcela", new { id = db.PARCELA.Find(pRINOS_PARCELE.PARCELAID).PROIZVODJACID });
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
