using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var navegador = new Navegador();

            Console.WriteLine();

            navegador.NavegarPara("http://www.google.com");
            navegador.NavegarPara("http://www.caelum.com.br");
            navegador.NavegarPara("http://www.alura.com.br");

            Console.WriteLine();

            navegador.Anterior();
            navegador.Anterior();
            navegador.Anterior();
            
            //não retorna nada pois a pilha está vazia
            navegador.Anterior();

            Console.WriteLine();

            navegador.Proximo();
            navegador.Proximo();
            navegador.Proximo();

            //não retorna nada pois a pilha está vazia
            navegador.Proximo();

            Console.ReadKey();
        }
    }

    internal class Navegador
    {
        private readonly Stack<string> historicoAnterior = new Stack<string>();
        private readonly Stack<string> historicoProximo = new Stack<string>();
        private string atual = "vazia";

        public Navegador()
        {
            Console.WriteLine($"Página atual: {atual}");
        }

        internal void Anterior()
        {
            if (historicoAnterior.Any())
            {
                historicoProximo.Push(atual);
                atual = historicoAnterior.Pop();
                Console.WriteLine($"Página atual: {atual}");
            }
        }

        internal void NavegarPara(string url)
        {
            historicoAnterior.Push(atual);
            atual = url;
            Console.WriteLine($"Página atual: {atual}");
        }

        internal void Proximo()
        {
            if (historicoProximo.Any())
            {
                historicoAnterior.Push(atual);
                atual = historicoProximo.Pop();
                Console.WriteLine($"Página atual: {atual}");
            }
        }
    }
}
