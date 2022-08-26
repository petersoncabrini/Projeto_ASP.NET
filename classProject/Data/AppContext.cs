using classProject.Models;
using System.Data.Entity;

namespace classProject.Data
{
    public class CursosContext : DbContext
    {
        public CursosContext() : base("CursosOnline") { }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<Matricula> Matriculas { get; set; }
        public virtual DbSet<Aluno> Alunos { get; set; }
    }
}
