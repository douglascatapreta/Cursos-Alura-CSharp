using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void EscritaBinaria()
        {
            using (var fileStream = new FileStream("contaCorrete.txt", FileMode.Create))
            using (var writer = new BinaryWriter(fileStream))
            {
                writer.Write(456); // Número da Agência
                writer.Write(546544); // Número da Conta
                writer.Write(4000.50); // Saldo
                writer.Write("Gustavo Braga"); // Nome Titular
            }
        }

        static void LeituraBinaria()
        {
            using (var fileStream = new FileStream("contaCorrete.txt", FileMode.Open))
            using (var reader = new BinaryReader(fileStream))
            {
                var agencia = reader.ReadInt32();
                var numeroConta = reader.ReadInt32();
                var saldo = reader.ReadDouble();
                var titular = reader.ReadString();

                Console.WriteLine($"{agencia}/{numeroConta} {titular} {saldo}");
            }
        }
    }
}
