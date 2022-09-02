using Newtonsoft.Json;
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
    [Table("Curso")]
    public class Curso
    {
        public int CursoID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [DisplayName("Carga Horaria (horas)")]
        public int CargaHoraria { get; set; }

        [JsonIgnore]
        public virtual ICollection<Matricula> Matriculas { get; set; }
    }
}
