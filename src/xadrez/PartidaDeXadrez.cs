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
        public HashSet<Peca> Pecas { get; private set; }
        public HashSet<Peca> Capturadas { get; private set; }

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.branco;
            terminada = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.RetiraPeca(origem);
            peca.IncrementarQtdMovimento();
            Peca PecaCapturada = Tabuleiro.RetiraPeca(destino);
            Tabuleiro.ColocarPeca(peca, destino);
            if (PecaCapturada != null)
            {
                Capturadas.Add(PecaCapturada);
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca obj in Capturadas)
            {
                if (obj.Cor == cor)
                {
                    aux.Add(obj);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca obj in Pecas)
            {
                if (obj.Cor == cor)
                {
                    aux.Add(obj);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
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

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('a', 1, new Torre(Cor.branco, Tabuleiro));
            ColocarNovaPeca('h', 1, new Torre(Cor.branco, Tabuleiro));
            ColocarNovaPeca('d', 1, new Torre(Cor.branco, Tabuleiro));
            ColocarNovaPeca('e', 2, new Torre(Cor.branco, Tabuleiro));
            ColocarNovaPeca('f', 1, new Torre(Cor.branco, Tabuleiro));
            ColocarNovaPeca('f', 2, new Torre(Cor.branco, Tabuleiro));
            ColocarNovaPeca('d', 2, new Torre(Cor.branco, Tabuleiro));
            ColocarNovaPeca('e', 1, new Rei(Cor.branco, Tabuleiro));

            ColocarNovaPeca('a', 8, new Torre(Cor.preto, Tabuleiro));
            ColocarNovaPeca('h', 8, new Torre(Cor.preto, Tabuleiro));
            ColocarNovaPeca('e', 8, new Rei(Cor.preto, Tabuleiro));
        }
    }
}
