using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool terminada { get; private set; }

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.branco;
            terminada = false;
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.RetiraPeca(origem);
            peca.IncrementarQtdMovimento();
            Peca PecaCapturada = Tabuleiro.RetiraPeca(destino);
            Tabuleiro.ColocarPeca(peca, destino);
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }

        public void ValidarPosicaoOrigem(Posicao origem)
        {
            if (Tabuleiro.GetPeca(origem) == null)
            {
                throw new TabuleiroException("Não existe peça na posição escolhida");
            }
            if (JogadorAtual != Tabuleiro.GetPeca(origem).Cor)
            {
                throw new TabuleiroException("A peça escolhida não é sua");
            }
            if (!Tabuleiro.GetPeca(origem).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para essa peça");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.GetPeca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida");
            }
        }

        private void MudaJogador()
        {
            if (JogadorAtual == Cor.branco)
            {
                JogadorAtual = Cor.preto;
            }
            else
            {
                JogadorAtual = Cor.branco;
            }
        }

        private void ColocarPecas()
        {
            Tabuleiro.ColocarPeca(new Torre(Cor.branco, Tabuleiro), new PosicaoXadrez('a', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.branco, Tabuleiro), new PosicaoXadrez('h', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.branco, Tabuleiro), new PosicaoXadrez('d', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.branco, Tabuleiro), new PosicaoXadrez('e', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.branco, Tabuleiro), new PosicaoXadrez('f', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.branco, Tabuleiro), new PosicaoXadrez('f', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.branco, Tabuleiro), new PosicaoXadrez('d', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Cor.branco, Tabuleiro), new PosicaoXadrez('e', 1).ToPosicao());

            Tabuleiro.ColocarPeca(new Torre(Cor.preto, Tabuleiro), new PosicaoXadrez('a', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.preto, Tabuleiro), new PosicaoXadrez('h', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Cor.preto, Tabuleiro), new PosicaoXadrez('e', 8).ToPosicao());
        }
    }
}
