using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5._1_Covariancia
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("string para object");
            string titulo = "meses";
            object obj = titulo;
            Console.WriteLine(obj);

            Console.WriteLine();

            Console.WriteLine("List<string> para List<object>");
            IList<string> listaMeses = new List<string>
            {
                "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"
            };
            //IList<object> listaObj = listaMeses;

            Console.WriteLine();

            Console.WriteLine("string[] para object[]");
            string[] arrayMeses = new string[]
            {
                "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"
            };
            object[] arrayObj = arrayMeses; // Covariância
            foreach (var item in arrayObj)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("List<string> para IEnumerable<object>");
            IEnumerable<object> enumObj = listaMeses; // Covariância
            foreach (var item in enumObj)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
