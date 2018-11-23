using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Barbearia.Models;

namespace Barbearia.Views
{
    public class ESTOQUEsController : Controller
    {
        private Model1 db = new Model1();

        // GET: ESTOQUEs
        public ActionResult Index()
        {
            var eSTOQUE = db.ESTOQUE.Include(e => e.PRODUTO);
            return View(eSTOQUE.ToList());
        }

        // GET: ESTOQUEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTOQUE eSTOQUE = db.ESTOQUE.Find(id);
            if (eSTOQUE == null)
            {
                return HttpNotFound();
            }
            return View(eSTOQUE);
        }

        // GET: ESTOQUEs/Create
        public ActionResult Create()
        {
            ViewBag.ID_PRODUTO = new SelectList(db.PRODUTO, "ID", "NOME");
            return View();
        }

        // POST: ESTOQUEs/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,QUANTIDADE,VALIDADE,ID_PRODUTO")] ESTOQUE eSTOQUE)
        {
            if (ModelState.IsValid)
            {
                db.ESTOQUE.Add(eSTOQUE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PRODUTO = new SelectList(db.PRODUTO, "ID", "NOME", eSTOQUE.ID_PRODUTO);
            return View(eSTOQUE);
        }

        // GET: ESTOQUEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTOQUE eSTOQUE = db.ESTOQUE.Find(id);
            if (eSTOQUE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PRODUTO = new SelectList(db.PRODUTO, "ID", "NOME", eSTOQUE.ID_PRODUTO);
            return View(eSTOQUE);
        }

        // POST: ESTOQUEs/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,QUANTIDADE,VALIDADE,ID_PRODUTO")] ESTOQUE eSTOQUE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eSTOQUE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PRODUTO = new SelectList(db.PRODUTO, "ID", "NOME", eSTOQUE.ID_PRODUTO);
            return View(eSTOQUE);
        }

        // GET: ESTOQUEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTOQUE eSTOQUE = db.ESTOQUE.Find(id);
            if (eSTOQUE == null)
            {
                return HttpNotFound();
            }
            return View(eSTOQUE);
        }

        // POST: ESTOQUEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ESTOQUE eSTOQUE = db.ESTOQUE.Find(id);
            db.ESTOQUE.Remove(eSTOQUE);
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
