using System;
using tabuleiro;
using Xadrez;

namespace JogoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {

            PosicaoXadrez pos = new PosicaoXadrez('c', 7);

            Console.WriteLine(pos);

            Console.WriteLine(pos.ConvertToPosicao());

            //try
            //{
            //    Tabuleiro tab = new Tabuleiro(8, 8);

            //    tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
            //    tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 9));
            //    tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 2));

            //    Tela.ImprimirTabuleiro(tab);

            //    Console.ReadLine();
            //}

            //catch (Exception err)
            //{
            //    Console.WriteLine(err.Message);
            //}
        }
    }
}
