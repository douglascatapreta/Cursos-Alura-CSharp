using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_ListaSomenteLeitura
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
    }
}
