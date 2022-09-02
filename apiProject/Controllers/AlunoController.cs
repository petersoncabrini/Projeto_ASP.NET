using classProject.Data;
using classProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace apiProject.Controllers
{
    public class AlunoController : ApiController
    {
        private CursosContext db = new CursosContext();

        public List<Aluno> GetAlunos()
        {
            var alunos = (from s in db.Alunos orderby s.Nome select s).ToList<Aluno>();
            return (alunos);
        }


        [HttpPost]
        public HttpResponseMessage Cadastrar(Aluno aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (aluno.AlunoID == 0)
                    {
                        db.Alunos.Add(aluno);
                        db.SaveChanges();
                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, aluno);
                        response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = aluno.AlunoID }));
                        return response;
                    }
                    else
                    {
                        db.Entry(aluno).State = EntityState.Modified;
                        db.SaveChanges();
                        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, aluno);
                        response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = aluno.AlunoID }));
                        return response;
                    }
                }

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
