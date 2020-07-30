using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestaArrayInt();
            // TestaArrayContaCorrente();
            // TestaListaDeContaCorrente();

            // Console.WriteLine($"Soma de vários inteiros: {SomarVarios(1,2,3,4,5,6,7,8,9)}");

            // TestaListaDeObject();
            // TestaListaGenerica();

            Console.ReadLine();
        }

        static void TestaListaGenerica()
        {
            Lista<int> idades = new Lista<int>();
            idades.Adicionar(5);
            idades.AdicionarVarios(1, 5, 78);

            int idadeSoma = 0;
            for (int i = 0; i < idades.Tamanho; i++)
            {
                int idade = idades[i];
                idadeSoma += idade;

                Console.WriteLine($"Idade no índice {i}: {idade}");
            }

            Console.WriteLine($"A soma de das idades é {idadeSoma}");
        }

        static void TestaListaDeObject()
        {
            ListaDeObject listaDeIdades = new ListaDeObject();

            listaDeIdades.Adicionar(10);
            listaDeIdades.Adicionar(5);
            listaDeIdades.Adicionar(4);
            //listaDeIdades.Adicionar("um texto qualquer");
            listaDeIdades.AdicionarVarios(16, 23, 60);

            for (int i = 0; i < listaDeIdades.Tamanho; i++)
            {
                int idade = (int)listaDeIdades[i];

                Console.WriteLine($"Idade no índice {i}: {idade}");
            }
        }

        static int SomarVarios(params int[] numeros)
        {
            int acumulador = 0;

            foreach (int numero in numeros)
            {
                acumulador += numero;
            }

            return acumulador;
        }

        static void TestaListaDeContaCorrente()
        {
            ListaDeContaCorrente lista = new ListaDeContaCorrente();

            ContaCorrente contaDoGui = new ContaCorrente(101, 1000001);

            lista.Adicionar(contaDoGui);

            lista.Adicionar(new ContaCorrente(102, 1000002));
            lista.Adicionar(new ContaCorrente(103, 1000003));
            lista.Adicionar(new ContaCorrente(104, 1000004));

            ContaCorrente[] contas = new ContaCorrente[]
            {
                new ContaCorrente(105, 1000005),
                new ContaCorrente(106, 1000006),
                new ContaCorrente(107, 1000007)
            };

            lista.AdicionarVarios(contas);

            lista.AdicionarVarios(new ContaCorrente(108, 1000008), new ContaCorrente(109, 1000009), new ContaCorrente(110, 1000010));

            for (int i = 0; i < lista.Tamanho; i++)
            {
                ContaCorrente itemAtual = lista[i];
                Console.WriteLine($"Item na posição {i}: Conta {itemAtual.Numero}/{itemAtual.Agencia}");
            }

            lista.Remover(contaDoGui);
        }

        static void TestaArrayContaCorrente()
        {
            ContaCorrente[] contas = new ContaCorrente[]
            {
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 4456668),
                new ContaCorrente(874, 7781438)
            };


            for (int i = 0; i < contas.Length; i++)
            {
                ContaCorrente contaAtual = contas[i];
                Console.WriteLine($"Conta {i} {contaAtual.Numero}");
            }
        }

        static void TestaArrayInt()
        {
            // ARRAY de inteiros, com 5 posições!
            int[] idades = new int[5];

            idades[0] = 15;
            idades[1] = 28;
            idades[2] = 35;
            idades[3] = 50;
            idades[4] = 22;

            int acumulado = 0;
            for (int indice = 0; indice < idades.Length; indice++)
            {
                int idade = idades[indice];

                Console.WriteLine($"Acessando o array idades no índice {indice}");
                Console.WriteLine($"Valor de idades[{indice}] = {idade}");

                acumulado += idade;
            }

            int media = acumulado / idades.Length;
            Console.WriteLine($"Média de idades = {media}");
        }
    }
}
