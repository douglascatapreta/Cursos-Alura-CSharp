﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1._1_SortedList
{
    class Program
    {
        static void Main(string[] args)
        {
            // Vamos criar um dicionário de alunos
            IDictionary<string, Aluno> alunos = new Dictionary<string, Aluno>();

            alunos.Add("VT", new Aluno("Vanessa", 34672));
            alunos.Add("AL", new Aluno("Ana", 5617));
            alunos.Add("RN", new Aluno("Rafael", 17645));
            alunos.Add("WM", new Aluno("Wanderson", 11287));

            // Imprimindo
            foreach (var aluno in alunos)
            {
                Console.WriteLine(aluno);
            }

            // Vamos remover: AL
            alunos.Remove("AL");
            
            // Vamos adicionar: MO
            alunos.Add("MO", new Aluno("Marcelo", 12345));

            Console.WriteLine();

            foreach (var aluno in alunos)
            {
                Console.WriteLine(aluno);
            }

            Console.WriteLine();

            // Apresentando nova coleção... SortedList
            IDictionary<string, Aluno> sorted = new SortedList<string, Aluno>();

            sorted.Add("VT", new Aluno("Vanessa", 34672));
            sorted.Add("AL", new Aluno("Ana", 5617));
            sorted.Add("RN", new Aluno("Rafael", 17645));
            sorted.Add("WM", new Aluno("Wanderson", 11287));

            // Imprimindo
            foreach (var aluno in sorted)
            {
                Console.WriteLine(aluno);
            }

            // Os elementos de uma SortedList são automaticamente ordenados pela chave
        }
    }
}
