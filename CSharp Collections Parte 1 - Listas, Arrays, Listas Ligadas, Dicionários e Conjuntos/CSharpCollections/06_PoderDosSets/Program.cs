using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_PoderDosSets
{
    class Program
    {
        static void Main(string[] args)
        {
            //SETS = CONJUNTOS

            //Duas propriedades do Set:
            //1. não permite duplicidade
            //2. os elementos não são mantidos em ordem específica

            //Declarando set de alunos
            ISet<string> alunos = new HashSet<string>();
            //Adicionando: Vanessa, Ana, Rafael
            alunos.Add("Vanessa Tonini");
            alunos.Add("Ana Losnak");
            alunos.Add("Rafael Nercessian");

            //Imprimindo
            Console.WriteLine(alunos);
            Console.WriteLine(string.Join(",", alunos));

            //Qual a diferença para uma lista? vamos ver agora

            //Adicionando: Priscila, Rollo, Fabio
            alunos.Add("Priscila Stuani");
            alunos.Add("Rafael Rollo");
            alunos.Add("Fabio Gushiken");
            Console.WriteLine(string.Join(",", alunos));
            //E a ordem?

            //Removendo Ana, adicionando Marcelo
            alunos.Remove("Ana Losnak");
            alunos.Add("Marcelo Oliveira");
            //Imprimindo de novo
            Console.WriteLine(string.Join(",", alunos));
            //Adicionando
            alunos.Add("Fabio Gushiken");
            Console.WriteLine(string.Join(",", alunos));

            //Qual a vantagem do set sobre a lista? Look-up!

            //Desempenho HashSet x List: Escalabilidade x Memória

            //Ordenando: Sort
            //alunos.Sort();

            List<string> alunosEmLista = new List<string>(alunos);
            alunosEmLista.Sort();
            Console.WriteLine(string.Join(",", alunosEmLista));

            Console.ReadKey();
        }
    }
}
