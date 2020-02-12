using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_ListaSomenteLeitura
{
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
