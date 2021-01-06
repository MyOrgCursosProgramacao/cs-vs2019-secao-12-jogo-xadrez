using System;
using tabuleiro;
using xadrez;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tabuleiro = new Tabuleiro(8, 8);
            try
            {
                tabuleiro.ColocarPeca(new Torre(Cor.preto, tabuleiro), new Posicao(0, 0));
                tabuleiro.ColocarPeca(new Torre(Cor.preto, tabuleiro), new Posicao(1, 3));
                tabuleiro.ColocarPeca(new Rei(Cor.preto, tabuleiro), new Posicao(0, 0));
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine();
                Tela.ImprimirTabuleiro(tabuleiro);
            }


        }
    }
}
