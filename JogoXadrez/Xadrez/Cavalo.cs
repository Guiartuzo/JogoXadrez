using tabuleiro;

namespace JogoXadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "C";
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

            pos.DefinirValores(PosicaoTabuleiro.Linha - 1, PosicaoTabuleiro.Coluna - 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Verifica posição nordeste da posição atual da peça
            pos.DefinirValores(PosicaoTabuleiro.Linha - 2, PosicaoTabuleiro.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Verifica posição direita da posição atual da peça
            pos.DefinirValores(PosicaoTabuleiro.Linha - 2, PosicaoTabuleiro.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Verifica posição sudeste da posição atual da peça
            pos.DefinirValores(PosicaoTabuleiro.Linha - 1, PosicaoTabuleiro.Coluna + 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Verifica posição abaixo da posição atual da peça
            pos.DefinirValores(PosicaoTabuleiro.Linha + 1, PosicaoTabuleiro.Coluna + 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Verifica posição suldoeste da posição atual da peça
            pos.DefinirValores(PosicaoTabuleiro.Linha + 2, PosicaoTabuleiro.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Verifica posição esquerda da posição atual da peça
            pos.DefinirValores(PosicaoTabuleiro.Linha + 2, PosicaoTabuleiro.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //Verifica posição noroeste da posição atual da peça
            pos.DefinirValores(PosicaoTabuleiro.Linha + 1, PosicaoTabuleiro.Coluna - 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;
        }
    }
}
