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
        public JsonResult Cadastrar(Curso curso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (curso.CursoID == 0)
                    {
                        db.Cursos.Add(curso);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(curso).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return Json(curso.CursoID);
        }

        public ActionResult Excluir(int id)
        {
            try
            {
                Curso curso = db.Cursos.Find(id);
                db.Cursos.Remove(curso);
                db.SaveChanges();
                return Json(new { resultado = true, curso = curso }, JsonRequestBehavior.AllowGet);
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                return Json(new { resultado = false }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Editar(int id)
        {
            try
            {
                Curso curso = db.Cursos.Find(id);
                return Json(new { resultado = true, curso = curso }, JsonRequestBehavior.AllowGet);
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                return Json(new { resultado = false }, JsonRequestBehavior.AllowGet);
            }
        }
    }

}