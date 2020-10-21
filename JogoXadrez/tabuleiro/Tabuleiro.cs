﻿using System.Data.Common;

namespace tabuleiro
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca [,]Pecas { get; set; }

        public Tabuleiro(int linhas, int colunas) 
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[Linhas, Colunas];
        }

        public Peca ReturnPeca(int linha, int coluna) 
        {
            return Pecas[linha, coluna];
        }

        public Peca peca(Posicao pos) 
        {
            return Pecas[pos.Linha, pos.Coluna];
        }

        public bool ExistePeca(Posicao pos) 
        {
            ValidarPosicao(pos);
            return peca(pos) != null;
        }
        public void ColocarPeca(Peca p, Posicao pos) 
        {
            if (ExistePeca(pos))
                throw new TabuleiroException("Já existe uma peça nessa posição !");

            Pecas[pos.Linha, pos.Coluna] = p;
            p.PosicaoTabuleiro = pos;
        }

        public bool PosicaoValida(Posicao pos) 
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
                return false;

            return true;
        }

        public void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
                throw new TabuleiroException("Posicao inválida !");
        }
    }
}
