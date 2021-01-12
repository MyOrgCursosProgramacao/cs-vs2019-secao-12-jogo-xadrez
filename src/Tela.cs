using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace src
{
    class Tela
    {
        public static void ImprimirPartida(PartidaDeXadrez partida, bool[,] posicoesPossiveis)
        {
            ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);
            Console.WriteLine("Jogador " + partida.JogadorAtual);
            if (partida.Xeque)
            {
                Console.WriteLine($"O rei está em xeque");
            }
        }

        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.branco));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.preto));
            Console.WriteLine();
        }

        private static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[ ");
            foreach (Peca obj in conjunto)
            {
                ImprimirPeca(obj);
                Console.Write(" ");
            }
            Console.Write("]");
        }

        public static void ImprimirTabuleiro(Tabuleiro Tabuleiro, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < Tabuleiro.Linhas; i++)
            {
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

