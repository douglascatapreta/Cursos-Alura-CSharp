﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2._1_ArraysMultidimensionais
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[,] resultados = new string[3,3]
            //{
            //    {"Alemanha", "Espanha", "Itália"},
            //    {"Argentina", "Holanda", "França"},
            //    {"Holanda", "Alemanha", "Alemanha"}
            //};

            string[,] resultados = new string[4, 3];

            resultados[0, 0] = "Alemanha";
            resultados[1, 0] = "Espanha";
            resultados[2, 0] = "Itália";
            resultados[3, 0] = "Brasil";

            resultados[0, 1] = "Argentina";
            resultados[1, 1] = "Holanda";
            resultados[2, 1] = "França";
            resultados[3, 1] = "Uruguai";

            resultados[0, 2] = "Holanda";
            resultados[1, 2] = "Alemanha";
            resultados[2, 2] = "Alemanha";
            resultados[3, 2] = "Portugal";

            //foreach (var selecao in resultados)
            //{
            //    Console.WriteLine(selecao);
            //}

            for (int copa = 0; copa <= resultados.GetUpperBound(1); copa++)
            {
                int ano = 2014 - copa * 4;
                Console.Write(ano.ToString().PadRight(12));
            }
            Console.WriteLine();

            
            for (int posicao = 0; posicao <= resultados.GetUpperBound(0); posicao++)
            {
                for (int copa = 0; copa <= resultados.GetUpperBound(1); copa++)
                {
                    Console.Write(resultados[posicao, copa].PadRight(12));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
