using System;
using System.Collections.Generic;
using System.Text;
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
                for (int j = 0; j < Tabuleiro.Colunas; j++)
                {
                    if (Tabuleiro.GetPeca(i, j) == null)
                    {
                        Console.Write("-");
                    }
                    else
                    {
                        Console.Write(Tabuleiro.GetPeca(i, j));
                    }
                    if (j < Tabuleiro.Colunas)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

        }
    }
}

