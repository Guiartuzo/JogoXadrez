using tabuleiro;

namespace Xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez Partida;

        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            Partida = partida;
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

        private bool TesteTorreParaRoque(Posicao pos) 
        {
            Peca p = Tab.peca(pos);
            return p != null && p is Torre && p.CorPeca == CorPeca && p.QtdMovimentos == 0;
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

            // #jogadaEspecial roque
            if (QtdMovimentos == 0 && !Partida.Xeque)
            {
                // #jogadaEspecial Roque Pequeno
                Posicao posT1 = new Posicao(PosicaoTabuleiro.Linha, PosicaoTabuleiro.Coluna + 3);
                if (TesteTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(PosicaoTabuleiro.Linha, PosicaoTabuleiro.Coluna + 1);
                    Posicao p2 = new Posicao(PosicaoTabuleiro.Linha, PosicaoTabuleiro.Coluna + 2);
                    if (Tab.peca(p1) == null && Tab.peca(p2) == null)
                    {
                        mat[PosicaoTabuleiro.Linha, PosicaoTabuleiro.Coluna + 2] = true;
                    }
                }

                // #jogadaEspecial Roque Grande
                Posicao posT2 = new Posicao(PosicaoTabuleiro.Linha, PosicaoTabuleiro.Coluna - 4);
                if (TesteTorreParaRoque(posT2))
                {
                    Posicao p1 = new Posicao(PosicaoTabuleiro.Linha, PosicaoTabuleiro.Coluna - 1);
                    Posicao p2 = new Posicao(PosicaoTabuleiro.Linha, PosicaoTabuleiro.Coluna - 2);
                    Posicao p3 = new Posicao(PosicaoTabuleiro.Linha, PosicaoTabuleiro.Coluna - 3);
                    if (Tab.peca(p1) == null && Tab.peca(p2) == null && Tab.peca(p3) == null)
                    {
                        mat[PosicaoTabuleiro.Linha, PosicaoTabuleiro.Coluna - 2] = true;
                    }
                }
            }


            return mat;
        }

    }
}
