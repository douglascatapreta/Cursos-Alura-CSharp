using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Total de contas criadas: " + ContaCorrente.TotalDeContasCriadas);

            ContaCorrente conta = new ContaCorrente(867, 8671240);

            Console.WriteLine(conta.Agencia);
            Console.WriteLine(conta.Numero);
            Console.WriteLine("Total de contas criadas: " + ContaCorrente.TotalDeContasCriadas);

            ContaCorrente conta2 = new ContaCorrente(867, 8674582);

            Console.WriteLine(conta2.Agencia);
            Console.WriteLine(conta2.Numero);
            Console.WriteLine("Total de contas criadas: " + ContaCorrente.TotalDeContasCriadas);

            Console.ReadKey();
        }
    }
}
