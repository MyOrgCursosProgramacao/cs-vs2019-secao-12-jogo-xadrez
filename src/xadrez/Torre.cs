using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {

        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicaoAux = new Posicao(0,0);

            //Acima
            bool loop = true;
            posicaoAux.DefinirPosicao(Posicao.Linha, Posicao.Coluna);
            while (loop)
            {
                posicaoAux.DefinirPosicao(posicaoAux.Linha - 1, posicaoAux.Coluna);
                if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
                {
                    mat[posicaoAux.Linha, posicaoAux.Coluna] = true;
                }
                else
                {
                    loop = false;
                }

            }

            //Abaixo
            loop = true;
            posicaoAux.DefinirPosicao(Posicao.Linha, Posicao.Coluna);
            while (loop)
            {
                posicaoAux.DefinirPosicao(posicaoAux.Linha + 1, posicaoAux.Coluna);
                if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
                {
                    mat[posicaoAux.Linha, posicaoAux.Coluna] = true;
                }
                else
                {
                    loop = false;
                }

            }

            //Esquerda
            loop = true;
            posicaoAux.DefinirPosicao(Posicao.Linha, Posicao.Coluna);
            while (loop)
            {
                posicaoAux.DefinirPosicao(posicaoAux.Linha, posicaoAux.Coluna - 1);
                if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
                {
                    mat[posicaoAux.Linha, posicaoAux.Coluna] = true;
                }
                else
                {
                    loop = false;
                }

            }

            //Direita
            loop = true;
            posicaoAux.DefinirPosicao(Posicao.Linha, Posicao.Coluna);
            while (loop)
            {
                posicaoAux.DefinirPosicao(posicaoAux.Linha, posicaoAux.Coluna + 1);
                if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
                {
                    mat[posicaoAux.Linha, posicaoAux.Coluna] = true;
                }
                else
                {
                    loop = false;
                }

            }

            return mat;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
