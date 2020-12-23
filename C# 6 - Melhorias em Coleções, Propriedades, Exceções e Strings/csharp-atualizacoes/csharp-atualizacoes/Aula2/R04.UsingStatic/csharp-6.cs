using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.String;
using static System.DateTime;

namespace CSharp6.R04
{
    class Programa
    {
        public void Main()
        {
            //Console.WriteLine("3. Membros Com Corpo De Expressão");
            WriteLine("4. Using Static");

            Aluno aluno = new Aluno("Marty", "McFly", new DateTime(1968, 6, 12))
            { 
                Endereco = "9303 Lyon Drive Hill Valley CA",
                Telefone = "555-4385"
            };
            //Console.WriteLine(aluno.Nome);
            WriteLine(aluno.Nome);
            //Console.WriteLine(aluno.Sobrenome);
            WriteLine(aluno.Sobrenome);

            //Console.WriteLine(aluno.NomeCompleto);
            WriteLine(aluno.NomeCompleto);
            //Console.WriteLine("Idade: {0}", aluno.GetIdade());
            WriteLine("Idade: {0}", aluno.GetIdade());

            //Console.WriteLine(aluno.DadosPessoais);
            WriteLine(aluno.DadosPessoais);
        }
    }

    class Aluno
    {
        public string Nome { get; }

        public string Sobrenome { get; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        //public string DadosPessoais => String.Format("{0}, {1}, {2}", NomeCompleto, Endereco, Telefone);
        public string DadosPessoais => Format("{0}, {1}, {2}", NomeCompleto, Endereco, Telefone);

        public DateTime DataNascimento { get; } = new DateTime(1990, 1, 1);

        public string NomeCompleto => Nome + " " + Sobrenome;

        //public int GetIdade()
        //    => (int)(((DateTime.Now - DataNascimento).TotalDays) / 365.242199);
        public int GetIdade()
            => (int)(((Now - DataNascimento).TotalDays) / 365.242199);

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
    }
}
