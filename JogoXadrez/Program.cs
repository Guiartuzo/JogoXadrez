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
                    try
                    {
                        Console.Clear();

                        Tela.ImprimirPartida(partida);

                        //Console.WriteLine();
                        //Console.WriteLine("Turno: " + partida.Turno);
                        //Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ConvertToPosicao();
                        partida.ValidarPosicaoOrigem(origem);

                        bool[,] posicoesPossiveis = partida.Tab.peca(origem).MovimentosPossiveis();


                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);


                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ConvertToPosicao();
                        partida.ValidarPosicaoDestino(origem, destino);

                        partida.RealizaJogada(origem, destino);
                    }
                    catch (TabuleiroException error)
                    {
                        Console.WriteLine(error.Message);
                        Console.ReadLine();
                    }
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
