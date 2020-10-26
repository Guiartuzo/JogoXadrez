using System;
using tabuleiro;

namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao PosicaoTabuleiro { get; set; }
        public Cor CorPeca { get; protected set; }
        public int QtdMovimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor corPeca) 
        {
            PosicaoTabuleiro = null;
            CorPeca = corPeca;
            QtdMovimentos = 0;
            Tab = tab;
        }

        public void IncrementarQteMovimentos()
        {
            QtdMovimentos++;
        }

        public void DecrementarQteMovimentos() 
        {
            QtdMovimentos--;
        }

        public bool ExisteMovimentosPossiveis() 
        {
            bool[,] mat = MovimentosPossiveis();
            for (int i = 0; i < Tab.Linhas; i++)
                for (int j = 0; j < Tab.Colunas; j++)
                    if (mat[i,j])
                        return true;

            return false;
        }

        public bool MovimentoPossivel(Posicao pos) 
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}
