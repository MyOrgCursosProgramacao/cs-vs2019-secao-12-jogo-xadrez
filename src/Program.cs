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
