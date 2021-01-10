using xadrez;

namespace tabuleiro
{
    class Posicao
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public Posicao()
        {
        }

        public Posicao(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public void DefinirPosicao (int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        } 

        public PosicaoXadrez ToPosicaoXadrez()
        {
            return new PosicaoXadrez((char)(Coluna + 'a'), 8 - Linha);
  
        }

        public override string ToString()
        {
            return Linha
                + ", "
                + Coluna;
        }
    }
}
