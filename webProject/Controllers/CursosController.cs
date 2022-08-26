using classProject.Data;
using classProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webProject.Controllers
{
    public class CursosController : Controller
    {

        private CursosContext db = new CursosContext();
        public ActionResult Index()
        {
            var cursos = (from s in db.Cursos orderby s.Nome select s).ToList<Curso>();
            return View(cursos);
        }

        public ActionResult Cadastrar()
        {
            ViewBag.Titulo = "Cadastrar";
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Curso curso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (curso.CursoID == 0)
                    {
                        db.Cursos.Add(curso);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        db.Entry(curso).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(curso);
        }

        public ActionResult Editar(int id)
        {

            ViewBag.Titulo = "Editar";
            var curso = (from s in db.Cursos where s.CursoID == id select s).FirstOrDefault();
            return View("Cadastrar", curso);
        }

        public ActionResult Deletar(int id)
        {
            try
            {
                Curso curso = db.Cursos.Find(id);
                db.Cursos.Remove(curso);
                db.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
    }

}