using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_SetNoModelo
{
    class Curso
    {
        public string Nome { get; set; }

        public string Instrutor { get; set; }

        private List<Aula> aulas;
        public IList<Aula> Aulas 
        { 
            get { return new ReadOnlyCollection<Aula>(aulas); }
        }

        private ISet<Aluno> alunos;
        public IList<Aluno> Alunos
        {
            get { return new ReadOnlyCollection<Aluno>(alunos.ToList()); }
        }

        public int TempoTotal
        {
            get
            {
                return aulas.Sum(aula => aula.Tempo);
            }
        }

        public Curso(string nome, string instrutor)
        {
            this.Nome = nome;
            this.Instrutor = instrutor;
            this.aulas = new List<Aula>();
            this.alunos = new HashSet<Aluno>();
        }

        public void Adiciona(Aula aula)
        {
            aulas.Add(aula);
        }

        public override string ToString()
        {
            return $"Curso: {this.Nome}, Tempo: {this.TempoTotal}, Aulas: {string.Join(",", this.aulas)}";
        }

        public void Matricula(Aluno aluno)
        {
            alunos.Add(aluno);
        }

        public bool EstaMatriculado(Aluno aluno)
        {
            return alunos.Contains(aluno);
        }
    }
}
