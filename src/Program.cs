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

            while (!partida.terminada)
            {
                try
                {
                    Console.Clear();

                    Tela.ImprimirPartida(partida, posicoesPossiveis);
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                    partida.ValidarPosicaoOrigem(origem);

                    Console.Clear();
                    posicoesPossiveis = partida.Tabuleiro.GetPeca(origem).MovimentosPossiveis();
                    Tela.ImprimirPartida(partida, posicoesPossiveis);
                    Console.WriteLine("Origem: " + origem.ToPosicaoXadrez());

                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                    partida.ValidarPosicaoDestino(origem, destino);

                    for (int i = 0; i < posicoesPossiveis.GetLength(0); i++)
                    {
                        for (int j = 0; j < posicoesPossiveis.GetLength(1); j++)
                        {
                            posicoesPossiveis[i, j] = false;
                        }
                    }

                    partida.RealizaJogada(origem, destino);
                }
                catch (TabuleiroException e)
                {
                    Console.WriteLine(Environment.NewLine + e.Message + ". Pressione qualquer tecla para continuar.");
                    Console.ReadLine();
                }
            }
        }

    }
}
