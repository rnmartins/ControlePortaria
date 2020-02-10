using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Controle_Portaria.Models;

namespace Controle_Portaria.Controllers
{
    public class CadastroesController : Controller
    {
        private CADASTROEntities db = new CADASTROEntities();

        // GET: Cadastroes
        public ActionResult Index()
        {
            return View(db.Cadastro.ToList());
        }

        // GET: Cadastroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cadastro cadastro = db.Cadastro.Find(id);
            if (cadastro == null)
            {
                return HttpNotFound();
            }
            return View(cadastro);
        }

        // GET: Cadastroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cadastroes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOME,TELEFONE,EMAIL,AP,BLOCO,CARRO,PLACA")] Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                db.Cadastro.Add(cadastro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cadastro);
        }

        // GET: Cadastroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cadastro cadastro = db.Cadastro.Find(id);
            if (cadastro == null)
            {
                return HttpNotFound();
            }
            return View(cadastro);
        }

        // POST: Cadastroes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOME,TELEFONE,EMAIL,AP,BLOCO,CARRO,PLACA")] Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadastro);
        }

        // GET: Cadastroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cadastro cadastro = db.Cadastro.Find(id);
            if (cadastro == null)
            {
                return HttpNotFound();
            }
            return View(cadastro);
        }

        // POST: Cadastroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cadastro cadastro = db.Cadastro.Find(id);
            db.Cadastro.Remove(cadastro);
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
