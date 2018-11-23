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
    public class SERVICOesController : Controller
    {
        private Model1 db = new Model1();

        // GET: SERVICOes
        public ActionResult Index()
        {
            return View(db.SERVICO.ToList());
        }

        // GET: SERVICOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICO sERVICO = db.SERVICO.Find(id);
            if (sERVICO == null)
            {
                return HttpNotFound();
            }
            return View(sERVICO);
        }

        // GET: SERVICOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SERVICOes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NOME,VALOR")] SERVICO sERVICO)
        {
            if (ModelState.IsValid)
            {
                db.SERVICO.Add(sERVICO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sERVICO);
        }

        // GET: SERVICOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICO sERVICO = db.SERVICO.Find(id);
            if (sERVICO == null)
            {
                return HttpNotFound();
            }
            return View(sERVICO);
        }

        // POST: SERVICOes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOME,VALOR")] SERVICO sERVICO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sERVICO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sERVICO);
        }

        // GET: SERVICOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SERVICO sERVICO = db.SERVICO.Find(id);
            if (sERVICO == null)
            {
                return HttpNotFound();
            }
            return View(sERVICO);
        }

        // POST: SERVICOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SERVICO sERVICO = db.SERVICO.Find(id);
            db.SERVICO.Remove(sERVICO);
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
