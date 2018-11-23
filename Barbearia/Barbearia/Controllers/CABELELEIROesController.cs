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
    public class CABELELEIROesController : Controller
    {
        private Model1 db = new Model1();

        // GET: CABELELEIROes
        public ActionResult Index()
        {
            return View(db.CABELELEIRO.ToList());
        }

        // GET: CABELELEIROes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CABELELEIRO cABELELEIRO = db.CABELELEIRO.Find(id);
            if (cABELELEIRO == null)
            {
                return HttpNotFound();
            }
            return View(cABELELEIRO);
        }

        // GET: CABELELEIROes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CABELELEIROes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LOGIN,NOME,SENHA,EMAIL,CELULAR")] CABELELEIRO cABELELEIRO)
        {
            if (ModelState.IsValid)
            {
                db.CABELELEIRO.Add(cABELELEIRO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cABELELEIRO);
        }

        // GET: CABELELEIROes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CABELELEIRO cABELELEIRO = db.CABELELEIRO.Find(id);
            if (cABELELEIRO == null)
            {
                return HttpNotFound();
            }
            return View(cABELELEIRO);
        }

        // POST: CABELELEIROes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LOGIN,NOME,SENHA,EMAIL,CELULAR")] CABELELEIRO cABELELEIRO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cABELELEIRO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cABELELEIRO);
        }

        // GET: CABELELEIROes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CABELELEIRO cABELELEIRO = db.CABELELEIRO.Find(id);
            if (cABELELEIRO == null)
            {
                return HttpNotFound();
            }
            return View(cABELELEIRO);
        }

        // POST: CABELELEIROes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CABELELEIRO cABELELEIRO = db.CABELELEIRO.Find(id);
            db.CABELELEIRO.Remove(cABELELEIRO);
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
