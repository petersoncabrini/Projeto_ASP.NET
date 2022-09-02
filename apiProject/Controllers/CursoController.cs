using classProject.Data;
using classProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace apiProject.Controllers
{
    public class CursoController : ApiController
    {
        private CursosContext db = new CursosContext();

        public List<Curso> GetCursos()
        {
            var cursos = (from s in db.Cursos orderby s.Nome select s).ToList<Curso>();
            return (cursos);
        }

    }
}
