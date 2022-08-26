using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classProject.Models
{
    [Table("Matricula")]
    public class Matricula
    {
        public int MatriculaID { get; set; }
        public int CursoID { get; set; }
        public int AlunoID { get; set; }

        //DataAnnotation para formatar a data em dd/mm/yyyy.
        [DisplayName("Data da Matrícula")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataMatricula { get; set; }

        //FKs das tabelas Cursos e Alunos.
        public virtual Curso Curso { get; set; }
        public virtual Aluno Aluno { get; set; }
    }
}
