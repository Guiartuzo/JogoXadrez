using System;
using tabuleiro;
using Xadrez;

namespace JogoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada) 
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ConvertToPosicao();

                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ConvertToPosicao();

                    partida.ExecutaMovimento(origem, destino);
                }

                Tela.ImprimirTabuleiro(partida.Tab);

                Console.ReadLine();
            }

            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}
