using ByteBank.Modelos;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            // testaString();

            Object conta = new ContaCorrente(456, 687876);

            Console.WriteLine(conta);

            Cliente carlos_1 = new Cliente();
            carlos_1.Nome = "Carlos";
            carlos_1.CPF = "458.623.120-03";
            carlos_1.Profissao = "Designer";

            Cliente carlos_2 = new Cliente();
            carlos_2.Nome = "Carlos";
            carlos_2.CPF = "458.623.120-03";
            carlos_2.Profissao = "Designer";

            if (carlos_1 == carlos_2)
            {
                Console.WriteLine("São iguais...");
            }
            else
            {
                Console.WriteLine("São diferentes...");
            }

            if (carlos_1.Equals(carlos_2))
            {
                Console.WriteLine("São iguais...");
            }
            else
            {
                Console.WriteLine("São diferentes...");
            }

            if (carlos_1.Equals(conta))
            {
                Console.WriteLine("São iguais...");
            }
            else
            {
                Console.WriteLine("São diferentes...");
            }

            Console.ReadLine();
        }

        static void testaString()
        {
            string urlParametros = "http://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";

            ExtratorValorDeArgumentosURL extrator = new ExtratorValorDeArgumentosURL(urlParametros);
            string moedaOrigem = extrator.GetValor("moedaOrigem");
            string moedaDestino = extrator.GetValor("moedaDestino");
            string valor = extrator.GetValor("valor");

            Console.WriteLine("Valor de 'moedaOrigem': " + moedaOrigem);
            Console.WriteLine("Valor de 'moedaDestino': " + moedaDestino);
            Console.WriteLine("Valor de 'valor': " + valor);

            Console.WriteLine(urlParametros.StartsWith("http://www.bytebank.com"));
            Console.WriteLine(urlParametros.EndsWith("cambio"));
            Console.WriteLine(urlParametros.Contains("bytebank"));

            //string padrao = "[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]";
            //string padrao = "[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]";
            //string padrao = "[0-9]{4}[-][0-9]{4}";
            //string padrao = "[0-9]{4,5}[-]{0,1}[0-9]{4}";
            //string padrao = "[0-9]{4,5}-{0,1}[0-9]{4}";
            string padrao = "[0-9]{4,5}-?[0-9]{4}";

            string textoDeTeste = "Meu nome é Guilherme, me ligue em 4784-4546.";

            Match resultado = Regex.Match(textoDeTeste, padrao);
            Console.WriteLine(resultado.Value);
        }
    }
}
