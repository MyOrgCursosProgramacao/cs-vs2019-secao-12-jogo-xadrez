using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public bool Xeque { get; private set; }

        public Rei(Cor cor, Tabuleiro tabuleiro, bool xeque) : base(cor, tabuleiro)
        {
            Xeque = xeque;
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

            //#Jogada especial
            if (QtdMovimentos == 0 && !Xeque)
            {
                // Roque pequeno
                Posicao PosicaoTorrePequena = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if (Tabuleiro.GetPeca(PosicaoTorrePequena).QtdMovimentos == 0)
                {
                    if (Tabuleiro.GetPeca(new Posicao(Posicao.Linha, Posicao.Coluna + 1)) == null && Tabuleiro.GetPeca(new Posicao(Posicao.Linha, Posicao.Coluna + 2)) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }

                // Roque grande
                Posicao PosicaoTorreGrande = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if (Tabuleiro.GetPeca(PosicaoTorreGrande).QtdMovimentos == 0)
                {
                    if (Tabuleiro.GetPeca(new Posicao(Posicao.Linha, Posicao.Coluna - 1)) == null
                        && Tabuleiro.GetPeca(new Posicao(Posicao.Linha, Posicao.Coluna - 2)) == null
                        && Tabuleiro.GetPeca(new Posicao(Posicao.Linha, Posicao.Coluna - 3)) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna - 2] = true;
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
