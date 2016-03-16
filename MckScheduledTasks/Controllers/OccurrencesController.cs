using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MckScheduledTasks.Models;

namespace MckScheduledTasks.Controllers
{
    public class OccurrencesController : Controller
    {
        private TodosContext db = new TodosContext();

        // GET: Occurrences
        public ActionResult Index()
        {
            return View(db.Occurrences.ToList());
        }

        // GET: Occurrences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occurrence occurrence = db.Occurrences.Find(id);
            if (occurrence == null)
            {
                return HttpNotFound();
            }
            return View(occurrence);
        }

        // GET: Occurrences/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Occurrences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TodoId,CreatedOn")] Occurrence occurrence)
        {
            if (ModelState.IsValid)
            {
                db.Occurrences.Add(occurrence);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(occurrence);
        }

        // GET: Occurrences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occurrence occurrence = db.Occurrences.Find(id);
            if (occurrence == null)
            {
                return HttpNotFound();
            }
            return View(occurrence);
        }

        // POST: Occurrences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TodoId,CreatedOn")] Occurrence occurrence)
        {
            if (ModelState.IsValid)
            {
                db.Entry(occurrence).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(occurrence);
        }

        // GET: Occurrences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occurrence occurrence = db.Occurrences.Find(id);
            if (occurrence == null)
            {
                return HttpNotFound();
            }
            return View(occurrence);
        }

        // POST: Occurrences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Occurrence occurrence = db.Occurrences.Find(id);
            db.Occurrences.Remove(occurrence);
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
