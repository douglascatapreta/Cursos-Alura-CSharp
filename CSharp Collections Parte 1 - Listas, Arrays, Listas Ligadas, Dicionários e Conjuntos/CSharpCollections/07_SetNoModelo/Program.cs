using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_SetNoModelo
{
    class Program
    {
        static void Main(string[] args)
        {
            //vamos declarar o curso
            Curso csharpColecoes = new Curso("C# Coleções", "Marcelo Oliveira");
            //... e adiciona 3 aulas a este curso

            csharpColecoes.Adiciona(new Aula("Trabalhando com Listas", 21));
            csharpColecoes.Adiciona(new Aula("Criando uma Aula", 20));
            csharpColecoes.Adiciona(new Aula("Modelando com Coleções", 24));

            //vamos adicionar um aluno
            //vamos criar a classe Aluno com Nome e NumeroMatricula

            //instanciando 3 alunos com suas matrículas
            Aluno a1 = new Aluno("Vanessa Tonini", 34672);
            Aluno a2 = new Aluno("Ana Losnak", 5617);
            Aluno a3 = new Aluno("Rafael Nercessian", 17645);

            //precisamos matricular os alunos no curso, criando um método
            csharpColecoes.Matricula(a1);
            csharpColecoes.Matricula(a2);
            csharpColecoes.Matricula(a3);

            //imprimindo os alunos matriculados
            Console.WriteLine("Imprimindo os alunos matriculados");
            foreach (var aluno in csharpColecoes.Alunos)
            {
                Console.WriteLine(aluno);
            }

            //imprimir: "O aluno está matriculado?"
            Console.Write($"O aluno {a1.Nome} está matriculado? ");
            //criar o método EstaMatriculado()
            Console.WriteLine(csharpColecoes.EstaMatriculado(a1));
            //vamos instanciar uma nova aluna com os mesmos dados
            Aluno a4 = new Aluno("Vanessa Tonini", 34672);
            //e verificar se está matriculada
            Console.WriteLine($"O aluno {a4.Nome} está matriculado? {csharpColecoes.EstaMatriculado(a4)}");

            //a1 é igual a4?
            Console.WriteLine($"a1 == a4? {a1 == a4}");

            //a1 equals a4?
            Console.WriteLine($"a1.equals(a4)? {a1.Equals(a4)}");

            Console.ReadKey();
        }
    }
}
