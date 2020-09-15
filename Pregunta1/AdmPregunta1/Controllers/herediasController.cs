using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdmPregunta1.Models;

namespace AdmPregunta1.Controllers
{
    public class herediasController : Controller
    {
        private DataContext db = new DataContext();

        // GET: heredias
        [Authorize]
        public ActionResult Index()
        {
            return View(db.heredias.ToList());
        }

        // GET: heredias/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            heredia heredia = db.heredias.Find(id);
            if (heredia == null)
            {
                return HttpNotFound();
            }
            return View(heredia);
        }

        // GET: heredias/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: heredias/Create
        [Authorize]
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "herediaID,Friendofheredia,Place,Email,Birthday")] heredia heredia)
        {
            if (ModelState.IsValid)
            {
                db.heredias.Add(heredia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(heredia);
        }

        // GET: heredias/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            heredia heredia = db.heredias.Find(id);
            if (heredia == null)
            {
                return HttpNotFound();
            }
            return View(heredia);
        }

        // POST: heredias/Edit/5
        [Authorize]
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "herediaID,Friendofheredia,Place,Email,Birthday")] heredia heredia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(heredia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(heredia);
        }

        // GET: heredias/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            heredia heredia = db.heredias.Find(id);
            if (heredia == null)
            {
                return HttpNotFound();
            }
            return View(heredia);
        }

        // POST: heredias/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            heredia heredia = db.heredias.Find(id);
            db.heredias.Remove(heredia);
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
