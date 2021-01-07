using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {

        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicaoAux = new Posicao(0, 0);

            for (int i = 0; i < Tabuleiro.Linhas; i++)
            {
                for (int j = 0; j < Tabuleiro.Colunas; j++)
                {
                    posicaoAux.DefinirPosicao(i, j);
                    if (posicaoAux != Posicao)
                    {
                        if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
                        {
                            if ((System.Math.Abs(i - Posicao.Linha)) <= 1 && (System.Math.Abs(j - Posicao.Coluna) <= 1))
                            {
                                mat[i, j] = true;
                            }
                        }
                    }
                }
            }
            return mat;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
