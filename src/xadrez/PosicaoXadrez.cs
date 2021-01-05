using System;
using System.Collections.Generic;
using System.Text;

namespace xadrez
{
    class PosicaoXadrez
    {
        
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public override string ToString()
        {
            return "" + Coluna + Linha;
        }
    }
}
