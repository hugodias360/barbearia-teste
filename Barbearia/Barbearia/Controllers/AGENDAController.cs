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
    public class AGENDAController : Controller
    {
        private Model1 db = new Model1();

        // GET: AGENDA
        public ActionResult Index()
        {
            var aGENDA = db.AGENDA.Include(a => a.CABELELEIRO).Include(a => a.PRODUTO).Include(a => a.SERVICO);
            return View(aGENDA.ToList());
        }

        // GET: AGENDA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AGENDA aGENDA = db.AGENDA.Find(id);
            if (aGENDA == null)
            {
                return HttpNotFound();
            }
            return View(aGENDA);
        }

        // GET: AGENDA/Create
        public ActionResult Create()
        {
            ViewBag.ID_AGENDA = new SelectList(db.AGENDA, "ID", "STATUS");
            ViewBag.ID_CABELELEIRO = new SelectList(db.CABELELEIRO, "ID", "NOME");
            ViewBag.ID_PRODUTO = new SelectList(db.PRODUTO, "ID", "NOME");
            ViewBag.ID_SERVICO = new SelectList(db.SERVICO, "ID", "NOME");
            return View();
        }

        // POST: AGENDA/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STATUS,NOME,DATA_INICIO,DATA_FIM,VALOR,COMENTARIO,ID_CABELELEIRO,ID_PRODUTO,ID_SERVICO,ID_AGENDA")] AGENDA aGENDA)
        {
            if (ModelState.IsValid)
            {
                db.AGENDA.Add(aGENDA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_AGENDA = new SelectList(db.AGENDA, "ID", "STATUS", aGENDA.ID);
            ViewBag.ID_CABELELEIRO = new SelectList(db.CABELELEIRO, "ID", "NOME");
            ViewBag.ID_PRODUTO = new SelectList(db.PRODUTO, "ID", "NOME", aGENDA.ID_PRODUTO);
            ViewBag.ID_SERVICO = new SelectList(db.SERVICO, "ID", "NOME", aGENDA.ID_SERVICO);
            return View(aGENDA);
        }

        // GET: AGENDA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AGENDA aGENDA = db.AGENDA.Find(id);
            if (aGENDA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_AGENDA = new SelectList(db.AGENDA, "ID", "STATUS", aGENDA.ID);
            ViewBag.ID_CABELELEIRO = new SelectList(db.CABELELEIRO, "ID", "NOME");
            ViewBag.ID_PRODUTO = new SelectList(db.PRODUTO, "ID", "NOME", aGENDA.ID_PRODUTO);
            ViewBag.ID_SERVICO = new SelectList(db.SERVICO, "ID", "NOME", aGENDA.ID_SERVICO);
            return View(aGENDA);
        }

        // POST: AGENDA/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,STATUS,NOME,DATA_INICIO,DATA_FIM,VALOR,COMENTARIO,ID_CABELELEIRO,ID_PRODUTO,ID_SERVICO,ID_AGENDA")] AGENDA aGENDA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aGENDA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_AGENDA = new SelectList(db.AGENDA, "ID", "STATUS", aGENDA.ID);
            ViewBag.ID_CABELELEIRO = new SelectList(db.CABELELEIRO, "ID", "NOME");
            ViewBag.ID_PRODUTO = new SelectList(db.PRODUTO, "ID", "NOME", aGENDA.ID_PRODUTO);
            ViewBag.ID_SERVICO = new SelectList(db.SERVICO, "ID", "NOME", aGENDA.ID_SERVICO);
            return View(aGENDA);
        }

        // GET: AGENDA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AGENDA aGENDA = db.AGENDA.Find(id);
            if (aGENDA == null)
            {
                return HttpNotFound();
            }
            return View(aGENDA);
        }

        // POST: AGENDA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AGENDA aGENDA = db.AGENDA.Find(id);
            db.AGENDA.Remove(aGENDA);
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
