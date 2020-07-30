using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_OrdenandoESomando
{
    class Program
    {
        static void Main(string[] args)
        {
            //desta vez criamos um curso para conter a coleção de aulas
            Curso cSharpColecoes = new Curso("C# Collections", "Marcelo Oliveira");
            //O método Adiciona encapsula a adição de novas aulas
            cSharpColecoes.Adiciona(new Aula("Trabalhando com Listas", 21));
            
            Imprimir(cSharpColecoes.Aulas);

            //adicionando 2 aulas
            cSharpColecoes.Adiciona(new Aula("Criando uma Aula", 20));
            cSharpColecoes.Adiciona(new Aula("Modelando com Coleções", 19));

            Imprimir(cSharpColecoes.Aulas);

            //IList não dá suporte ao método Sort!
            //csharpColecoes.Aulas.Sort();

            //copiando a lista para outra lista
            List<Aula> aulasCopiadas = new List<Aula>(cSharpColecoes.Aulas);

            //ordenando a cópia
            aulasCopiadas.Sort();

            Imprimir(aulasCopiadas);

            Console.WriteLine();

            //imprimindo o tempo do curso
            Console.WriteLine($"Tempo total do curso: {cSharpColecoes.TempoTotal} minutos");

            Console.WriteLine();

            //imprimir detalhes do curso
            Console.WriteLine(cSharpColecoes);

            Console.ReadKey();
        }

        private static void Imprimir(IList<Aula> aulas)
        {
            Console.WriteLine();
            foreach (var aula in aulas)
            {
                Console.WriteLine(aula);
            }
        }
    }
}
