using System;
using tabuleiro;

namespace src
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro Tabuleiro)
        {
            for (int i = 0; i < Tabuleiro.Linhas; i++)
            {
                Console.Write("\t");
                Console.Write(Tabuleiro.Linhas - i);
                for (int j = 0; j < Tabuleiro.Colunas; j++)
                {
                    Console.Write(" ");
                    if (Tabuleiro.GetPeca(i, j) == null)
                    {
                        Console.Write("-");
                    }
                    else
                    {
                        Console.Write(Tabuleiro.GetPeca(i, j));
                    }
                }
                Console.WriteLine();
            }
            Console.Write("\t");
            Console.Write("  ");
            for (int j = 0; j < Tabuleiro.Colunas; j++)
            {

                Console.Write((Char)(Convert.ToUInt16('a') + j) + " ");
            }
            Console.WriteLine();


        }
    }
}

