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
    public class ProizvodjacController : Controller
    {
        private KrompirDatabaseEntities db = new KrompirDatabaseEntities();

        // GET: Proizvodjac
        public ActionResult Index()
        {
            return View(db.PROIZVODJAC.Where(m => m.DELETED == false).ToList());
        }

        // GET: Proizvodjac/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROIZVODJAC pROIZVODJAC = db.PROIZVODJAC.Find(id);
            if (pROIZVODJAC == null)
            {
                return HttpNotFound();
            }
            return View(pROIZVODJAC);
        }

        // GET: Proizvodjac/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proizvodjac/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PROIZVODJACID,IME,PREZIME,DATUMRODJENJA,MJESTOSTANOVANJA,ADRESA,APIF,EMAIL,TELEFON")] PROIZVODJAC pROIZVODJAC)
        {
            if (ModelState.IsValid)
            {
                db.PROIZVODJAC.Add(pROIZVODJAC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pROIZVODJAC);
        }

        // GET: Proizvodjac/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROIZVODJAC pROIZVODJAC = db.PROIZVODJAC.Find(id);
            if (pROIZVODJAC == null)
            {
                return HttpNotFound();
            }
            return View(pROIZVODJAC);
        }

        // POST: Proizvodjac/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PROIZVODJACID,IME,PREZIME,DATUMRODJENJA,MJESTOSTANOVANJA,ADRESA,APIF,EMAIL,TELEFON")] PROIZVODJAC pROIZVODJAC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROIZVODJAC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pROIZVODJAC);
        }

        // GET: Proizvodjac/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROIZVODJAC pROIZVODJAC = db.PROIZVODJAC.Find(id);
            if (pROIZVODJAC == null)
            {
                return HttpNotFound();
            }
            return View(pROIZVODJAC);
        }

        // POST: Proizvodjac/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PROIZVODJAC pROIZVODJAC = db.PROIZVODJAC.Find(id);
            pROIZVODJAC.DELETED = true;
            db.Entry(pROIZVODJAC).State = EntityState.Modified;
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
