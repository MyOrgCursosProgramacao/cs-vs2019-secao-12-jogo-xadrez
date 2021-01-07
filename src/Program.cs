using System;
using tabuleiro;
using xadrez;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            PartidaDeXadrez partida = new PartidaDeXadrez();
            bool[,] posicoesPossiveis = new bool[partida.Tabuleiro.Linhas, partida.Tabuleiro.Colunas];
            try
            {
                while (!partida.terminada)
                {
                    Console.Clear();
                    Console.WriteLine(partida.Turno + " turno");


                    Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);

                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

                    Console.Clear();
                    posicoesPossiveis = partida.Tabuleiro.GetPeca(origem).MovimentosPossiveis();
                    Console.WriteLine(partida.Turno + " turno");
                    Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);

                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                    for (int i = 0; i < posicoesPossiveis.GetLength(0); i++)
                    {
                        for (int j = 0; j < posicoesPossiveis.GetLength(1); j++)
                        {
                            posicoesPossiveis[i, j] = false;
                        }
                    }

                        partida.ExecutaMovimento(origem, destino);
                }
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveis);
                Console.WriteLine();
            }


        }
    }
}
