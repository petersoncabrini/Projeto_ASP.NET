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
    public class AlunosController : Controller
    {
        // Instancia o context
        private CursosContext db = new CursosContext();

        public ActionResult Index()
        {
            //Consulta o banco e faz uma lista de alunos ordenada pelo nome.
            var alunos = (from s in db.Alunos orderby s.Nome select s).ToList<Aluno>();
            //Passa a lista de alunos para a view.
            return View(alunos);
        }

        [HttpPost]
        public JsonResult Cadastrar(Aluno aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(aluno.AlunoID == 0)
                    {
                        db.Alunos.Add(aluno);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(aluno).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            catch (DataException)
            { 
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return Json(aluno.AlunoID);
        }


        public ActionResult Excluir(int id)
        {
            try
            {
                Aluno aluno = db.Alunos.Find(id);
                db.Alunos.Remove(aluno);
                db.SaveChanges();
                return Json(new { resultado = true, aluno = aluno }, JsonRequestBehavior.AllowGet);
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
                Aluno aluno = db.Alunos.Find(id);
                return Json(new {resultado=true, aluno=aluno}, JsonRequestBehavior.AllowGet);
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                return Json(new { resultado = false}, JsonRequestBehavior.AllowGet);
            }
        }

        public PartialViewResult AtualizarTabela()
        {
            return PartialView();
        }

    }

}