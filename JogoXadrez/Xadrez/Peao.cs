using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace JogoXadrez.Xadrez
{
    class Peao : Peca
    {
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExisteInimigo(Posicao pos) 
        {
            Peca p = Tab.peca(pos);
            return p != null && p.CorPeca != CorPeca;
        }

        private bool Livre(Posicao pos) 
        {
            return Tab.peca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis() 
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            if (CorPeca == Cor.Branca)
            {
                pos.DefinirValores(PosicaoTabuleiro.Linha - 1, PosicaoTabuleiro.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(PosicaoTabuleiro.Linha - 2, PosicaoTabuleiro.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && QtdMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(PosicaoTabuleiro.Linha - 1, PosicaoTabuleiro.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(PosicaoTabuleiro.Linha - 1, PosicaoTabuleiro.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
            }
            else 
            {
                pos.DefinirValores(PosicaoTabuleiro.Linha + 1, PosicaoTabuleiro.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(PosicaoTabuleiro.Linha + 2, PosicaoTabuleiro.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && QtdMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(PosicaoTabuleiro.Linha + 1, PosicaoTabuleiro.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(PosicaoTabuleiro.Linha + 1, PosicaoTabuleiro.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
            }

            return mat;
        }

    }
}
