using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        public Peao(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {

        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao posicaoAux = new Posicao(0, 0);

            int sinal;
            if (Cor == Cor.branco)
            {
                sinal = -1;
            }
            else
            {
                sinal = 1;
            }

            posicaoAux.DefinirPosicao(Posicao.Linha + sinal * 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(posicaoAux) && Livre(posicaoAux))
            {
                mat[posicaoAux.Linha, posicaoAux.Coluna] = true;
            }

            posicaoAux.DefinirPosicao(Posicao.Linha + sinal * 2, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(posicaoAux) && Livre(posicaoAux) && QtdMovimentos == 0)
            {
                mat[posicaoAux.Linha, posicaoAux.Coluna] = true;
            }

            posicaoAux.DefinirPosicao(Posicao.Linha + sinal * 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(posicaoAux) && ExisteInimigo(posicaoAux))
            {
                mat[posicaoAux.Linha, posicaoAux.Coluna] = true;
            }

            posicaoAux.DefinirPosicao(Posicao.Linha + sinal * 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(posicaoAux) && ExisteInimigo(posicaoAux))
            {
                mat[posicaoAux.Linha, posicaoAux.Coluna] = true;
            }

            return mat;
        }

        private bool ExisteInimigo(Posicao posicao)
        {
            Peca peca = Tabuleiro.GetPeca(posicao);
            return peca != null && peca.Cor != Cor;
        }

        private bool Livre(Posicao posicao)
        {
            Peca peca = Tabuleiro.GetPeca(posicao);
            return peca == null;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
