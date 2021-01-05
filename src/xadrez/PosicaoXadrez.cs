using System;
using System.Collections.Generic;
using System.Text;

namespace xadrez
{
    class PosicaoXadrez
    {
        public int Linha { get; set; }
        public char Coluna { get; set; }

        public PosicaoXadrez(int linha, char coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public override string ToString()
        {
            return "" + Linha + Coluna;
        }
    }
}
