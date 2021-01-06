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
            try
            {
                while (!partida.terminada)
                {
                    Console.Clear();
                    Console.WriteLine(partida.Turno + " turno");
                    Tela.ImprimirTabuleiro(partida.Tabuleiro);

                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                    partida.ExecutaMovimento(origem, destino);
                }
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Tela.ImprimirTabuleiro(partida.Tabuleiro);
                Console.WriteLine();
            }


        }
    }
}
