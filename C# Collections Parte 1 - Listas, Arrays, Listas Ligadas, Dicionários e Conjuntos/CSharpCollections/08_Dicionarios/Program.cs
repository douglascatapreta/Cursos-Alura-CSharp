using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Dicionarios
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
            foreach (var a in csharpColecoes.Alunos)
            {
                Console.WriteLine(a);
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

            Console.Clear();

            //já temos o método para saber se o aluno está matriculado
            //mas agora precisamos buscar o aluno por número de matrícula

            //pergunta: "Quem é o aluno com matrícula 5617?"
            Console.WriteLine("Quem é o aluno com matrícula 5617?");
            //implementando Curso.BuscaMatriculada
            Aluno aluno5617 = csharpColecoes.BuscaMatriculada(5617);
            //imprimindo o aluno5617 encontrado
            Console.WriteLine($"aluno5617: {aluno5617}");
            //Funciona! Mas essa busca é eficiente?

            //introduzindo uma nova coleção: dicionário
            //um dicionário permite associar uma chave (no caso matrícula) a um valor (o aluno)
            //vamos implementar um dicionário de alunos em Curso

            //Quem é o aluno 5618?
            Console.WriteLine("Quem é o aluno com matrícula 5618?");
            Console.WriteLine(csharpColecoes.BuscaMatriculada(5618));

            //e se tentamos adicionar outro aluno com mesma chave 5617?
            Aluno fabio = new Aluno("Fabio Gushiken", 5617);
            //csharpColecoes.Matricula(fabio);
            //e se quisermos trocar o aluno qu tem a mesma chave?
            csharpColecoes.SubstituiAluno(fabio);
            //pergunta: "Quem é o aluno 5617 agora?"
            Console.WriteLine("Quem é o aluno 5617 agora?");
            Console.WriteLine(csharpColecoes.BuscaMatriculada(5617));

            Console.ReadKey();
        }
    }
}
