using System;
using tabuleiro;
using xadrez;

namespace src
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro Tabuleiro, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < Tabuleiro.Linhas; i++)
            {
                Console.Write("\t");
                Console.Write(Tabuleiro.Linhas - i);
                for (int j = 0; j < Tabuleiro.Colunas; j++)
                {
                    Console.Write(" ");
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    Tela.ImprimirPeca(Tabuleiro.GetPeca(i, j));
                   Console.BackgroundColor = fundoOriginal;
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

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("-");
            }
            else if (peca.Cor == Cor.branco)
            {
                Console.Write(peca);
            }
            else if (peca.Cor == Cor.preto)
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
    }
}

