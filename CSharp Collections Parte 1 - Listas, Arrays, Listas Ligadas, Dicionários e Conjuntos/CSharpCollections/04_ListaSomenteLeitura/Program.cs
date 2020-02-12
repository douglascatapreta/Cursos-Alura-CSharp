using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_ListaSomenteLeitura
{
    class Program
    {
        static void Main(string[] args)
        {
            //desta vez criamos um curso para conter a coleção de aulas
            Curso cSharpColecoes = new Curso("C# Coleções", "Marcelo Oliveira");
            //O método Adiciona encapsula a adição de novas aulas
            cSharpColecoes.Adiciona(new Aula("Trabalhando com Listas", 21));
            
            Imprimir(cSharpColecoes.Aulas);

            Console.ReadKey();
        }

        private static void Imprimir(IList<Aula> aulas)
        {
            foreach (var aula in aulas)
            {
                Console.WriteLine(aula);
            }

            Console.WriteLine();
        }
    }
}
