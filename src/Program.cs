using System;
using tabuleiro;
using xadrez;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {

            PosicaoXadrez px = new PosicaoXadrez('h', 8);
            Console.WriteLine(px.ToPosicao());
            

        }
    }
}
