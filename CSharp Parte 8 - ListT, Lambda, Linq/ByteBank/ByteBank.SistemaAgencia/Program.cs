using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using ByteBank.SistemaAgencia.Comparadores;
using ByteBank.SistemaAgencia.Extensoes;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestaMetodoDeExtensao();
            // TesteInferenciaDeTipoDeVariavel();
            // TestaSort();

            // TestaOrderByEWhere();

            Console.ReadLine();
        }

        static void TestaOrderByEWhere()
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(341, 57481),
                null,
                new ContaCorrente(342, 57487),
                new ContaCorrente(340, 57485),
                null,
                null,
                new ContaCorrente(290, 57480)
            };

            // contas.Sort(); ~~> Chamar a implementação dada em IComparable

            // contas.Sort(new ComparadorContaCorrentePorAgencia());

            // var contasOrdenadas = contas.OrderBy(conta => conta.Numero);

            // var contasOrdenadas = contas.OrderBy(conta => {
            //     if (conta == null)
            //     {
            //         return int.MaxValue;
            //     }

            //     return conta.Numero;
            // });

            // var contasNaoNulas = contas.Where(conta => conta != null);

            var contasNaoNulasOrdenadas = contas
                .Where(conta => conta != null)
                .OrderBy(conta => conta.Numero);

            foreach (var conta in contasNaoNulasOrdenadas)
            {
                if (conta != null)
                {
                    Console.WriteLine($"Conta número {conta.Numero}, agência {conta.Agencia}");
                }
            }
        }

        static void TestaSort()
        {
            var idades = new List<int>() { 1, 14, 5, 38, 25, 61, 89, 45, 12 };

            idades.Sort();

            for (int i = 0; i < idades.Count; i++)
            {
                Console.Write($"[{idades[i]}]");
            }

            Console.WriteLine();

            var nomes = new List<string>()
            {
                "Wellignton",
                "Guilherme",
                "Luana",
                "Ana"
            };

            nomes.Sort();

            foreach (var nome in nomes)
            {
                Console.Write($"{nome} ");
            }
        }

        static void TesteInferenciaDeTipoDeVariavel()
        {
            var conta = new ContaCorrente(344, 5645645);
            var gerenciador = new GerenciadorBonificacao();
            var gerenciadores = new List<GerenciadorBonificacao>();

            var resultado = SomarVarios(1, 5, 9);
        }

        static void TestaMetodoDeExtensao()
        {
            List<int> idades = new List<int>();

            idades.Add(1);
            idades.Add(5);
            idades.Add(14);
            idades.Add(25);
            idades.Add(38);
            idades.Add(61);

            // idades.Remove(5);

            // ListExtensoes.AdicionarVarios(idades, 1, 5687, 1987, 1567, 987);

            idades.AdicionarVarios(5, 448, 7898, 4564);

            for (int i = 0; i < idades.Count; i++)
            {
                Console.WriteLine(idades[i]);
            }

            List<string> nomes = new List<string>();
            nomes.AdicionarVarios("Adoniran", "Jimi Hendrix");
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
    }
}
