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
    public class MatriculaController : ApiController
    {
        private CursosContext db = new CursosContext();

        public List<Matricula> GetMatriculas()
        {
            var matriculas = (from s in db.Matriculas orderby s.MatriculaID select s).ToList<Matricula>();
            return (matriculas);
        }
    }
}
