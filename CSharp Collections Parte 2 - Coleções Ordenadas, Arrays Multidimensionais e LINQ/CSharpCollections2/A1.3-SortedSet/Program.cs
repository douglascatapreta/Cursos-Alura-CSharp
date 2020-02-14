using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1._3_SortedSet
{
    class Program
    {
        static void Main(string[] args)
        {
            // Conjunto de alunos:
            ISet<string> alunos = new SortedSet<string>(new ComparadorMinusculo())
            {
                "Vanessa Tonini",
                "Ana Losnak",
                "Rafael Nercessian",
                "Priscila Stuani"
            };

            // Adicionar: Rafael Rollo
            alunos.Add("Rafael Rollo");
            // Adicionar: Fabio Gushiken
            alunos.Add("Fabio Gushiken");
            // Adicionar: Fabio Gushiken
            alunos.Add("Fabio Gushiken");
            // Adicionar: FABIO GUSHIKEN
            alunos.Add("FABIO GUSHIKEN");

            foreach (var aluno in alunos)
            {
                Console.WriteLine(aluno);
            }

            Console.WriteLine();

            ISet<string> outroConjunto = new HashSet<string>();

            // Este conjunto é subconjunto do outro? IsSubsetOf
            alunos.IsSubsetOf(outroConjunto);

            // Este conjunto é superconjunto do outro? IsSupersetOf
            alunos.IsSupersetOf(outroConjunto);

            // Os conjuntos contêm os mesmos elementos? SetEquals
            alunos.SetEquals(outroConjunto);

            // Subtrai os elementos da outra coleção que também estão neste conjunto: ExceptWith
            alunos.ExceptWith(outroConjunto);

            // Intersecção dos conjuntos: IntersectWith
            alunos.IntersectWith(outroConjunto);

            // Somente em um ou outro conjunto: SymmetricExceptWith
            alunos.SymmetricExceptWith(outroConjunto);

            // União de conjuntos: UnionWith
            alunos.UnionWith(outroConjunto);
        }
    }

    internal class ComparadorMinusculo : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, true);
        }
    }
}
