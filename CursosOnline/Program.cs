using classProject.Data;
using classProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursosOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CursosContext())
            {
                Console.WriteLine("Criando a base de dados...");

                Console.WriteLine("Consultado os alunos cadastrados...");
                //Consultando os alunos ordenados pelo nome
                var alunos = (from s in context.Alunos orderby s.Nome select s).ToList<Aluno>();

                Console.WriteLine("Lista de Alunos:");

                //Exibindo os alunos cadastrados
                foreach (var aluno in alunos)
                {
                    string name = aluno.Nome + " " + aluno.Sobrenome + ", " + aluno.Idade ;
                    Console.WriteLine(name);
                }

                Console.WriteLine("Aperte Enter para sair");
                Console.ReadKey();
            }
        }
    }
}
