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
    [Table("Aluno")]
    public class Aluno
    {
        public int AlunoID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        public int Idade { get; set; }
        [Required]
        public string Email { get; set; }

        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
