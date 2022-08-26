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
            var matriculas = (from s in db.Matriculas orderby s.MatriculaID select s).ToList<Matricula>();
            return View(matriculas);
        }

        public ActionResult Cadastrar()
        {
            //Armazena os registros do banco na ViewBag, para serem carregadas no droplist na view.
            ViewBag.Cursos = new SelectList(db.Cursos, "CursoID", "Nome");
            ViewBag.Alunos = new SelectList(db.Alunos, "AlunoID", "Nome");
            ViewBag.Titulo = "Cadastrar";
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Matricula matricula)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (matricula.MatriculaID == 0)
                    {
                        db.Matriculas.Add(matricula);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        db.Entry(matricula).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception)
            {
                ViewBag.Message = "Erro";
            }
            return View(matricula);
        }

        //Recebe como parametro o id do actionlink na index
        public ActionResult Editar(int id)
        {
            ViewBag.Cursos = new SelectList(db.Cursos, "CursoID", "Nome");
            ViewBag.Alunos = new SelectList(db.Alunos, "AlunoID", "Nome");
            ViewBag.Titulo = "Editar";

            //Faz uma consulta ao banco, selecionando na lista o id recebido como parametro
            var matricula = (from s in db.Matriculas where s.MatriculaID == id select s).FirstOrDefault();
            //Retorna o aluno encontrado com o respectivo id e exibe na view Editar
            return View("Cadastrar", matricula);
        }

        public ActionResult Deletar(int id)
        {
            try
            {
                Matricula matricula = db.Matriculas.Find(id);
                db.Matriculas.Remove(matricula);
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