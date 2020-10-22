using tabuleiro;

namespace Xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "T";
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
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).CorPeca != CorPeca)
                {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }

            //Verifica posição abaixo da posição atual da peça
            pos.DefinirValores(PosicaoTabuleiro.Linha + 1, PosicaoTabuleiro.Coluna);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).CorPeca != CorPeca)
                {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }

            //Verifica posição a direita da posição atual da peça
            pos.DefinirValores(PosicaoTabuleiro.Linha, PosicaoTabuleiro.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).CorPeca != CorPeca)
                {
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }

            //Verifica posição a esquerda da posição atual da peça
            pos.DefinirValores(PosicaoTabuleiro.Linha, PosicaoTabuleiro.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).CorPeca != CorPeca)
                {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }

            return mat;
        }
    }
}
