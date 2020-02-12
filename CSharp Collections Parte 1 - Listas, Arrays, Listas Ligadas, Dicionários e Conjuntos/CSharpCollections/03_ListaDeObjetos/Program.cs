using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ListaDeObjetos
{
    class Program
    {
        static void Main(string[] args)
        {
            //os elementos que entrarão na lista
            var aulaIntro = new Aula("Introdução às Coleções", 20);
            var aulaModelando = new Aula("Modelando a Classe Aula", 18);
            var aulaSets = new Aula("Trabalhando com Conjuntos", 16);
            var aulaConclusao = new Aula("Conclusão", 5);

            //declarando uma lista vazia
            List<Aula> aulas = new List<Aula>();
            //alimentando a lista com método Add
            aulas.Add(aulaIntro);
            aulas.Add(aulaModelando);
            aulas.Add(aulaSets);
            aulas.Add(aulaConclusao);

            ////Você não pode adicionar uma string se a lista é de Aula!
            //aulas.Add("Conclusão");

            Imprimir(aulas);

            //Ordenando a lista pela ordem natural dos elementos (que não existe, a menos que Aula implemente IComparable!)
            aulas.Sort();
            Imprimir(aulas);

            //Ordenando a lista por uma ordem específica (por tempo) passando um Comparison como argumento
            aulas.Sort((este, outro) => este.Tempo.CompareTo(outro.Tempo));
            Imprimir(aulas);

            Console.ReadKey();
        }

        private static void Imprimir(List<Aula> aulas)
        {
            foreach (var aula in aulas)
            {
                Console.WriteLine(aula);
            }

            Console.WriteLine();
        }
    }

    class Aula : IComparable
    {
        public string Titulo { get; set; }
        public int Tempo { get; set; }

        public Aula(string titulo, int tempo)
        {
            Titulo = titulo;
            Tempo = tempo;
        }

        public override string ToString()
        {
            return $"[título: {Titulo}, tempo: {Tempo} minutos]";
        }

        public int CompareTo(object obj)
        {
            Aula that = obj as Aula;
            
            return this.Titulo.CompareTo(that.Titulo);
        }
    }
}
