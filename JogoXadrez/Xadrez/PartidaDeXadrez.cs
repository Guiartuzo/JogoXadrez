using System;
using tabuleiro;
namespace Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        private int Turno;
        private Cor JogadorAtual;
        public bool Terminada { get; private set; }

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            ColocarPeca();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino) 
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
        }

        private void ColocarPeca() 
        {
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('c', 1).ConvertToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('c', 2).ConvertToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('d', 2).ConvertToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('e', 2).ConvertToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('e', 1).ConvertToPosicao());
            Tab.ColocarPeca(new Rei(Tab, Cor.Branca), new PosicaoXadrez('d', 1).ConvertToPosicao());

            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('c', 7).ConvertToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('c', 8).ConvertToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('d', 7).ConvertToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('e', 7).ConvertToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('e', 8).ConvertToPosicao());
            Tab.ColocarPeca(new Rei(Tab, Cor.Preta), new PosicaoXadrez('d', 8).ConvertToPosicao());
        }
    }
}
