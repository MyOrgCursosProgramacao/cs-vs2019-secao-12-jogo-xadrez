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
        public bool Terminada { get; private set; }
        public HashSet<Peca> Pecas { get; private set; }
        public HashSet<Peca> Capturadas { get; private set; }
        public bool Xeque { get; private set; }

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.branco;
            Terminada = false;
            Xeque = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = Tabuleiro.RetiraPeca(origem);
            peca.IncrementarQtdMovimento();
            Peca pecaCapturada = Tabuleiro.RetiraPeca(destino);
            Tabuleiro.ColocarPeca(peca, destino);
            if (pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }

            // #Jogada especial
            // roque pequeno
            if (peca is Rei && destino.Coluna == origem.Coluna + 2)
            {
                ExecutaMovimento(new Posicao(origem.Linha, origem.Coluna + 3), new Posicao(origem.Linha, origem.Coluna + 1));
            }
            // roque grande
            if (peca is Rei && destino.Coluna == origem.Coluna - 2)
            {
                ExecutaMovimento(new Posicao(origem.Linha, origem.Coluna - 4), new Posicao(origem.Linha, origem.Coluna - 1));
            }

            return pecaCapturada;
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca peca = Tabuleiro.RetiraPeca(destino);
            peca.DecrementarQtdMovimento();
            if (pecaCapturada != null)
            {
                Tabuleiro.ColocarPeca(pecaCapturada, destino);
                Capturadas.Remove(pecaCapturada);
            }
            Tabuleiro.ColocarPeca(peca, origem);
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

        public Cor Adversaria(Cor cor)
        {
            if (cor == Cor.branco)
            {
                return Cor.preto;
            }
            else
            {
                return Cor.branco;
            }
        }

        private Peca Rei(Cor cor)
        {
            foreach (Peca obj in PecasEmJogo(cor))
            {
                if (obj is Rei)
                {
                    return obj;
                }
            }
            return null;
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca rei = Rei(cor);
            if (rei == null)
            {
                throw new TabuleiroException("Não há um rei da cor " + cor + " no tabuleiro");
            }
            foreach (Peca obj in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = obj.MovimentosPossiveis();
                if (mat[rei.Posicao.Linha, rei.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public bool XequeMate(Cor cor)
        {
            if (!EstaEmXeque(cor))
            {
                return false;
            }
            foreach (Peca obj in PecasEmJogo(cor))
            {
                bool[,] mat = obj.MovimentosPossiveis();
                for (int i = 0; i < Tabuleiro.Linhas; i++)
                {
                    for (int j = 0; j < Tabuleiro.Colunas; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = obj.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(obj.Posicao, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);

            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se por em xeque");
            }

            if (EstaEmXeque(Adversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }

            if (XequeMate(Adversaria(JogadorAtual)))
            {
                Terminada = true;
                Console.WriteLine("Xequemate! O vencedor é o jogador " + JogadorAtual + ".");
            }
            else
            {
                Turno++;
                MudaJogador();
            }
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
            if (!Tabuleiro.GetPeca(origem).MovimentoPossivel(destino))
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
            //Peões brancos
            ColocarNovaPeca('a', 2, new Peao(Cor.branco, Tabuleiro));
            ColocarNovaPeca('b', 2, new Peao(Cor.branco, Tabuleiro));
            ColocarNovaPeca('c', 2, new Peao(Cor.branco, Tabuleiro));
            ColocarNovaPeca('d', 2, new Peao(Cor.branco, Tabuleiro));
            ColocarNovaPeca('e', 2, new Peao(Cor.branco, Tabuleiro));
            ColocarNovaPeca('f', 2, new Peao(Cor.branco, Tabuleiro));
            ColocarNovaPeca('g', 2, new Peao(Cor.branco, Tabuleiro));
            ColocarNovaPeca('h', 2, new Peao(Cor.branco, Tabuleiro));

            //Torres brancas
            ColocarNovaPeca('a', 1, new Torre(Cor.branco, Tabuleiro));
            ColocarNovaPeca('h', 1, new Torre(Cor.branco, Tabuleiro));

            //Cavalos branco
            //ColocarNovaPeca('b', 1, new Cavalo(Cor.branco, Tabuleiro));
            // ColocarNovaPeca('g', 1, new Cavalo(Cor.branco, Tabuleiro));

            //Bispos branco
            //ColocarNovaPeca('c', 1, new Bispo(Cor.branco, Tabuleiro));
            // ColocarNovaPeca('f', 1, new Bispo(Cor.branco, Tabuleiro));

            //Dama branca
            //ColocarNovaPeca('d', 1, new Dama(Cor.branco, Tabuleiro));

            //Rei branco
            ColocarNovaPeca('e', 1, new Rei(Cor.branco, Tabuleiro, Xeque));


            //Peões pretos
            ColocarNovaPeca('a', 7, new Peao(Cor.preto, Tabuleiro));
            ColocarNovaPeca('b', 7, new Peao(Cor.preto, Tabuleiro));
            ColocarNovaPeca('c', 7, new Peao(Cor.preto, Tabuleiro));
            ColocarNovaPeca('d', 7, new Peao(Cor.preto, Tabuleiro));
            ColocarNovaPeca('e', 7, new Peao(Cor.preto, Tabuleiro));
            ColocarNovaPeca('f', 7, new Peao(Cor.preto, Tabuleiro));
            ColocarNovaPeca('g', 7, new Peao(Cor.preto, Tabuleiro));
            ColocarNovaPeca('h', 7, new Peao(Cor.preto, Tabuleiro));

            //Torres pretas
            ColocarNovaPeca('a', 8, new Torre(Cor.preto, Tabuleiro));
            ColocarNovaPeca('h', 8, new Torre(Cor.preto, Tabuleiro));

            //Cavalos branco
            // ColocarNovaPeca('b', 8, new Cavalo(Cor.preto, Tabuleiro));
            ColocarNovaPeca('g', 8, new Cavalo(Cor.preto, Tabuleiro));

            //Bispos pretos
            //ColocarNovaPeca('c', 8, new Bispo(Cor.preto, Tabuleiro));
            ColocarNovaPeca('f', 8, new Bispo(Cor.preto, Tabuleiro));

            //Dama preta
            //ColocarNovaPeca('d', 8, new Dama(Cor.preto, Tabuleiro));


            //Rei preto
            ColocarNovaPeca('e', 8, new Rei(Cor.preto, Tabuleiro, Xeque));
        }
    }
}
