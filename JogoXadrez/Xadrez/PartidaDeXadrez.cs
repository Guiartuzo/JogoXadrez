using System.Collections.Generic;
using tabuleiro;
namespace Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> PecasEmJogo;
        private HashSet<Peca> PecasCapturadas;

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            PecasEmJogo = new HashSet<Peca>();
            PecasCapturadas = new HashSet<Peca>();
            ColocarPeca();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino) 
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
            if (pecaCapturada != null)
                PecasCapturadas.Add(pecaCapturada);
        }

        public void RealizaJogada(Posicao origem, Posicao destino) 
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }

        public void ValidarPosicaoOrigem(Posicao pos) 
        {
            if (Tab.peca(pos) == null)
                throw new TabuleiroException("Não existe peça na posição de origem escolhida !");

            if (JogadorAtual != Tab.peca(pos).CorPeca)
                throw new TabuleiroException("A peça de origem escolhida não é sua !");

            if (!Tab.peca(pos).ExisteMovimentosPossiveis())
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida");
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino) 
        {
            if (!Tab.peca(origem).PodeMoverPara(destino))
                throw new TabuleiroException("Posicao invalida !");
        }

        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else 
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> GetPecasCapturadas(Cor cor) 
        {
            HashSet <Peca> aux = new HashSet<Peca>();
            foreach (Peca x in PecasCapturadas)
                if (x.CorPeca == cor)
                    aux.Add(x);

            return aux;
        }

        public HashSet<Peca> GetPecasEmJogo(Cor cor) 
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in PecasEmJogo)
                if (x.CorPeca == cor)
                    aux.Add(x);

            aux.ExceptWith(GetPecasCapturadas(cor));
            return aux;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca) 
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ConvertToPosicao());
            PecasEmJogo.Add(peca);
        }

        private void ColocarPeca() 
        {

            ColocarNovaPeca('c', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('c', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('d', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('e', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('e', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('d',1, new Rei(Tab, Cor.Branca));

            ColocarNovaPeca('c', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('c', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('d', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('e', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('e', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('d', 8, new Rei(Tab, Cor.Preta));
        }
    }
}
