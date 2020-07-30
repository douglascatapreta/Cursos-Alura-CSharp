using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_OrdenandoESomando
{
    class Curso
    {
        public string Nome { get; set; }
        public string Instrutor { get; set; }

        private List<Aula> aulas;
        public IList<Aula> Aulas 
        { 
            get
            {
                return new ReadOnlyCollection<Aula>(aulas);
            }
        }

        public int TempoTotal
        {
            get
            {
                //// somando o tempo total através de um acumulador
                //int total = 0;
                //foreach (var aula in aulas)
                //{
                //    total += aula.Tempo;
                //}
                //return total;

                // somando o tempo total com o método Sum(LINQ)
                // LINQ = Lenguage Integrated Query (Consulta Integrada à Linguagem)
                return aulas.Sum(aula => aula.Tempo);
            }
        }

        public Curso(string nome, string instrutor)
        {
            this.Nome = nome;
            this.Instrutor = instrutor;
            this.aulas = new List<Aula>();
        }

        public void Adiciona(Aula aula)
        {
            aulas.Add(aula);
        }

        public override string ToString()
        {
            return $"Curso: {this.Nome}, Tempo: {this.TempoTotal}, Aulas: {string.Join(",", this.aulas)}";
        }
    }
}
