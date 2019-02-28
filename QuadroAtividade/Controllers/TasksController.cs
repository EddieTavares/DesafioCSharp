using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuadroAtividade.Models;

namespace QuadroAtividade.Controllers
{
    public class TasksController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Tasks
        public ActionResult Index()
        {
            return View(db.Task.ToList());
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Anuncios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var task = db.Task.Find(id);
            if (task == null)
                return HttpNotFound();

            return View(task);
        }


        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "TaskId,Titulo,Descricao,Status,DataCriacao,DataEdicao,DataRemocao,DataConclusao")] Task task)
        public ActionResult Create([Bind(Include = "TaskId,Titulo,Descricao")] Task task)
        {
            if (ModelState.IsValid)
            {
                task.Status = 1;
                task.DataCriacao = DateTime.Today;
                task.DataConclusao = DateTime.MaxValue;
                task.DataEdicao = DateTime.MaxValue;
                task.DataRemocao = DateTime.MaxValue;

                db.Task.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return PartialView("Create", task);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Task.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaskId,Titulo,Descricao")] Task task)
        {
            if (ModelState.IsValid)
            {

                var _task = db.Task.Find(task.TaskId);

                _task.Titulo = task.Titulo;
                _task.Descricao = task.Descricao;
                _task.DataEdicao = DateTime.Today;

                db.Entry(_task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return PartialView("Edit", task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizaStatus(int TaskId, int Status)
        {
            try
            {
                var _task = db.Task.Find(TaskId);
                _task.Status = Status;

                if (Status == 3)
                    _task.DataConclusao = DateTime.Today;
                // _task.DataEdicao = DateTime.Today;

                db.Entry(_task).State = EntityState.Modified;
                db.SaveChanges();

                return Json(new {rc = 0,  message = string.Empty });
            }
            catch (Exception e)
            {
                return Json(new { rc = 9, message = e.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            try
            {
                var _task = db.Task.Find(id);
                _task.Status = 4;
                _task.DataRemocao = DateTime.Today;

                db.Entry(_task).State = EntityState.Modified;
                db.SaveChanges();

                // return Json(new {rc = 0,  message = string.Empty });
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return Json(new { rc = 9, message = e.Message });
            }
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
