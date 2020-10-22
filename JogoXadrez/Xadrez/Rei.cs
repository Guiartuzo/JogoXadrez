using tabuleiro;

namespace Xadrez
{
    class Rei : Peca
    {
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        private bool PodeMover(Posicao pos) 
        {
            Peca p = Tab.peca(pos);
            return p == null || p.CorPeca != CorPeca;
        }

        public override bool[,] MovimentosPossiveis() 
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            //Verifica posição acima da posição atual da peça
            pos.DefinirValores(PosicaoTabuleiro.Linha - 1, PosicaoTabuleiro.Coluna);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Verifica posição nordeste da posição atual da peça
            pos.DefinirValores(PosicaoTabuleiro.Linha - 1, PosicaoTabuleiro.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Verifica posição direita da posição atual da peça
            pos.DefinirValores(PosicaoTabuleiro.Linha, PosicaoTabuleiro.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Verifica posição sudeste da posição atual da peça
            pos.DefinirValores(PosicaoTabuleiro.Linha + 1, PosicaoTabuleiro.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Verifica posição abaixo da posição atual da peça
            pos.DefinirValores(PosicaoTabuleiro.Linha + 1, PosicaoTabuleiro.Coluna);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Verifica posição suldoeste da posição atual da peça
            pos.DefinirValores(PosicaoTabuleiro.Linha + 1, PosicaoTabuleiro.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Verifica posição esquerda da posição atual da peça
            pos.DefinirValores(PosicaoTabuleiro.Linha, PosicaoTabuleiro.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Verifica posição noroeste da posição atual da peça
            pos.DefinirValores(PosicaoTabuleiro.Linha - 1, PosicaoTabuleiro.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;
        }

    }
}
