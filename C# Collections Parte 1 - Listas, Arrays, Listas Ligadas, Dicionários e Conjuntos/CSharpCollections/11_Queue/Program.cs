using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Queue
{
    class Program
    {
        static Queue<string> pedagio = new Queue<string>();

        static void Main(string[] args)
        {
            //entrou: Van
            Enfileirar("Van");

            //entrou: Kombi
            Enfileirar("Kombi");

            //entrou: Guincho
            Enfileirar("Guincho");

            //entrou: Pickup
            Enfileirar("Pickup");

            //carro liberado
            Desenfileirar();

            //carro liberado
            Desenfileirar();

            //carro liberado
            Desenfileirar();

            //carro liberado
            Desenfileirar();

            Console.ReadKey();
        }

        private static void Desenfileirar()
        {
            if (pedagio.Any())
            {
                if (pedagio.Peek() == "Guincho")
                {
                    Console.WriteLine("Guincho fazendo o pagamento");
                }

                string veiculo = pedagio.Dequeue();
                Console.WriteLine($"Saiu da fila: {veiculo}");
                ImprimirFila();
            }
        }

        private static void Enfileirar(string veiculo)
        {
            Console.WriteLine($"Entrou na fila: {veiculo}");
            pedagio.Enqueue(veiculo);
            ImprimirFila();
        }

        private static void ImprimirFila()
        {
            Console.WriteLine();

            Console.WriteLine("FILA:");
            foreach (var v in pedagio)
            {
                Console.WriteLine(v);
            }

            Console.WriteLine();
        }
    }
}
