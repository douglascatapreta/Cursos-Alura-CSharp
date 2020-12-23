using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6.R02
{
    class Programa
    {
        public void Main()
        {
            Console.WriteLine("2. Inicializadores De Propriedade Automática");

            Aluno aluno = new Aluno("Marty", "McFly");
            Console.WriteLine(aluno.Nome);
            Console.WriteLine(aluno.Sobrenome);

            Console.WriteLine(aluno.ToString());
        }
    }

    class Aluno
    {
        public string Nome { get; }

        public string Sobrenome { get; }

        public DateTime DataNascimento { get; } = new DateTime(1900, 1, 1);

        public Aluno(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }

        public Aluno(string nome, string sobrenome, DateTime dataNascimento) :
            this(nome, sobrenome)
        {
            this.DataNascimento = dataNascimento;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} - {2}", Nome, Sobrenome, DataNascimento);
        }
    }
}
