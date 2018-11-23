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
    public class ATENDIMENTOesController : Controller
    {
        private Model1 db = new Model1();

        // GET: ATENDIMENTOes
        public ActionResult Index()
        {
            var aTENDIMENTO = db.ATENDIMENTO.Include(a => a.AGENDA);
            return View(aTENDIMENTO.ToList());
        }

        // GET: ATENDIMENTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATENDIMENTO aTENDIMENTO = db.ATENDIMENTO.Find(id);
            if (aTENDIMENTO == null)
            {
                return HttpNotFound();
            }
            return View(aTENDIMENTO);
        }

        // GET: ATENDIMENTOes/Create
        public ActionResult Create()
        {
            ViewBag.ID_AGENDA = new SelectList(db.AGENDA, "ID", "STATUS");
            return View();
        }

        // POST: ATENDIMENTOes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,STATUS,CHECKIN,CHECKOUT,VALOR,ID_AGENDA")] ATENDIMENTO aTENDIMENTO)
        {
            if (ModelState.IsValid)
            {
                db.ATENDIMENTO.Add(aTENDIMENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_AGENDA = new SelectList(db.AGENDA, "ID", "STATUS", aTENDIMENTO.ID_AGENDA);
            return View(aTENDIMENTO);
        }

        // GET: ATENDIMENTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATENDIMENTO aTENDIMENTO = db.ATENDIMENTO.Find(id);
            if (aTENDIMENTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_AGENDA = new SelectList(db.AGENDA, "ID", "STATUS", aTENDIMENTO.ID_AGENDA);
            return View(aTENDIMENTO);
        }

        // POST: ATENDIMENTOes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,STATUS,CHECKIN,CHECKOUT,VALOR,ID_PRODUTO,ID_SERVICO,ID_AGENDA,ID_CLIENTE")] ATENDIMENTO aTENDIMENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aTENDIMENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_AGENDA = new SelectList(db.AGENDA, "ID", "STATUS", aTENDIMENTO.ID_AGENDA);
            return View(aTENDIMENTO);
        }

        // GET: ATENDIMENTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATENDIMENTO aTENDIMENTO = db.ATENDIMENTO.Find(id);
            if (aTENDIMENTO == null)
            {
                return HttpNotFound();
            }
            return View(aTENDIMENTO);
        }

        // POST: ATENDIMENTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ATENDIMENTO aTENDIMENTO = db.ATENDIMENTO.Find(id);
            db.ATENDIMENTO.Remove(aTENDIMENTO);
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
