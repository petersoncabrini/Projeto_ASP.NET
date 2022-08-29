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
    public class MatriculasController : Controller
    {
        // Instancia o context
        private CursosContext db = new CursosContext();

        public ActionResult Index()
        {
            ViewBag.Cursos = new SelectList(db.Cursos, "CursoID", "Nome");
            ViewBag.Alunos = new SelectList(db.Alunos, "AlunoID", "Nome");
            var matriculas = (from s in db.Matriculas orderby s.MatriculaID select s).ToList<Matricula>();
            return View(matriculas);
        }

        [HttpPost]
        public JsonResult Cadastrar(Matricula matricula)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (matricula.MatriculaID == 0)
                    {
                        db.Matriculas.Add(matricula);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(matricula).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                ViewBag.Message = "Erro";
            }
            return Json(matricula.MatriculaID);
        }

        public JsonResult Editar(int id)
        {
            try
            {
                Matricula matricula = db.Matriculas.Find(id);
                return Json(new { resultado = true, matricula = matricula }, JsonRequestBehavior.AllowGet);
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                return Json(new { resultado = false }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Excluir(int id)
        {
            try
            {
                Matricula matricula = db.Matriculas.Find(id);
                db.Matriculas.Remove(matricula);
                db.SaveChanges();
                return Json(new { resultado = true, matricula = matricula }, JsonRequestBehavior.AllowGet);
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                return Json(new { resultado = false }, JsonRequestBehavior.AllowGet);
            }
        }

    }

}