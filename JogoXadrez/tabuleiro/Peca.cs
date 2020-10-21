namespace tabuleiro
{
    class Peca
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
    }
}
