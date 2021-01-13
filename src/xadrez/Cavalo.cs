using tabuleiro;

namespace xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {

        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicaoAux = new Posicao(0, 0);

            posicaoAux.DefinirPosicao(Posicao.Linha, Posicao.Coluna);
            posicaoAux.DefinirPosicao(posicaoAux.Linha - 2, posicaoAux.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
            {
                mat[posicaoAux.Linha, posicaoAux.Coluna] = true;
            }

            posicaoAux.DefinirPosicao(Posicao.Linha, Posicao.Coluna);
            posicaoAux.DefinirPosicao(posicaoAux.Linha - 2, posicaoAux.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
            {
                mat[posicaoAux.Linha, posicaoAux.Coluna] = true;
            }

            posicaoAux.DefinirPosicao(Posicao.Linha, Posicao.Coluna);
            posicaoAux.DefinirPosicao(posicaoAux.Linha + 2, posicaoAux.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
            {
                mat[posicaoAux.Linha, posicaoAux.Coluna] = true;
            }

            posicaoAux.DefinirPosicao(Posicao.Linha, Posicao.Coluna);
            posicaoAux.DefinirPosicao(posicaoAux.Linha + 2, posicaoAux.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
            {
                mat[posicaoAux.Linha, posicaoAux.Coluna] = true;
            }

            posicaoAux.DefinirPosicao(Posicao.Linha, Posicao.Coluna);
            posicaoAux.DefinirPosicao(posicaoAux.Linha + 1, posicaoAux.Coluna - 2);
            if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
            {
                mat[posicaoAux.Linha, posicaoAux.Coluna] = true;
            }

            posicaoAux.DefinirPosicao(Posicao.Linha, Posicao.Coluna);
            posicaoAux.DefinirPosicao(posicaoAux.Linha + 1, posicaoAux.Coluna + 2);
            if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
            {
                mat[posicaoAux.Linha, posicaoAux.Coluna] = true;
            }

            posicaoAux.DefinirPosicao(Posicao.Linha, Posicao.Coluna);
            posicaoAux.DefinirPosicao(posicaoAux.Linha - 1, posicaoAux.Coluna + 2);
            if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
            {
                mat[posicaoAux.Linha, posicaoAux.Coluna] = true;
            }

            posicaoAux.DefinirPosicao(Posicao.Linha, Posicao.Coluna);
            posicaoAux.DefinirPosicao(posicaoAux.Linha - 1, posicaoAux.Coluna - 2);
            if (Tabuleiro.PosicaoValida(posicaoAux) && PodeMover(posicaoAux))
            {
                mat[posicaoAux.Linha, posicaoAux.Coluna] = true;
            }

            return mat;
        }

        public override string ToString()
        {
            return "C";
        }
    }
}
