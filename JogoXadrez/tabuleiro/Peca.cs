namespace tabuleiro
{
    class Peca
    {
        public Posicao PosicaoTabuleiro { get; set; }
        public Cor CorPeca { get; protected set; }
        public int QtdMovimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca(Cor corPeca, Tabuleiro tab) 
        {
            PosicaoTabuleiro = null;
            CorPeca = corPeca;
            QtdMovimentos = 0;
            Tab = tab;
        }
    }
}
