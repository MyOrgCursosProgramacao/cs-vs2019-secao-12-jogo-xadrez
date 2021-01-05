using System;
using tabuleiro;
using xadrez;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Tabuleiro tabuleiro = new Tabuleiro(8, 8);


                tabuleiro.ColocarPeca(new Torre(Cor.preto, tabuleiro), new Posicao(0, 0));
                tabuleiro.ColocarPeca(new Torre(Cor.preto, tabuleiro), new Posicao(1, 3));
                tabuleiro.ColocarPeca(new Rei(Cor.preto, tabuleiro), new Posicao(0, 0));

                Tela.ImprimirTabuleiro(tabuleiro);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
            

        }
    }
}
