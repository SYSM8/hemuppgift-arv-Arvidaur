﻿using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hemuppgift_Arv_Temp.Game
{
    /*Svar på frågorna:
    F2.a) Basklass/superklass
    F2.b) 2, 3*/
    internal class TakePins
    {
        //Här är main klassen där koden ska testas, lägg in i mappen
        static void Main(string[] args)
        {
            int humanWin = 0;
            int computerWin = 0;
            Player human = new HumanPlayer();
            Player computer = new ComputerPlayer();
            Random rnd = new Random();
            bool donePlaying = false;
            bool turn = rnd.Next(2) == 0;   //Slumpar vem som startar i början av första spelet

            Board board1 = new Board(); //Skapar ett board objekt vi använder oss av i spelet

            //The game starts
            Console.WriteLine("Welcome to the pingame.");

            while (!donePlaying)
            {
                bool gameOver = false;
                Console.WriteLine("Select the number of pins to play with:");
                int pins = 0;

                if (int.TryParse(Console.ReadLine(), out pins) && pins > 0)   //Kontrollerar att det är korrekt inmatning och att pins är ett positivt tal
                {
                    board1.SetUp(pins);
                    while (!gameOver)   //Matchen är igång
                    {
                        if (turn)
                        {
                            int pinsTaken = human.TakePins();
                            Console.WriteLine($"Human player takes {pinsTaken} pins.");
                            board1.TakePins(pinsTaken);
                            if (board1.GetNoPins() == 0)
                            {
                                Console.WriteLine($"Human is the winner! Human wins: {humanWin} Computer Wins {computerWin}");
                                humanWin++;
                                gameOver = true;
                            }
                            else if (board1.GetNoPins() <= 0)
                            {
                                Console.WriteLine($"Human took to many pins and the computer is the winner! Human wins: {humanWin} Computer Wins {computerWin}");
                                computerWin++;
                                gameOver = true;
                            }
                            turn = false;
                        }
                        else
                        {
                            int pinsTaken = computer.TakePins();
                            Console.WriteLine($"Computer player takes {pinsTaken} pins.");
                            board1.TakePins(pinsTaken);
                            
                            if(board1.GetNoPins() == 0)
                            {
                                Console.WriteLine($"Computer is the winner! Human wins: {humanWin} Computer Wins {computerWin}");
                                computerWin++;
                                gameOver = true;
                            } 
                            else if (board1.GetNoPins() <= 0)
                            {
                                Console.WriteLine($"The computer took to many pins and human player is the winner! Human wins: {humanWin} Computer Wins {computerWin}");
                                humanWin++;
                                gameOver = true;
                            }
                            turn = true;
                        }
                    }
                }
                else if (pins < 1)
                {
                    Console.WriteLine("Cannot play the game with negative pins");
                }
                else
                {
                    Console.WriteLine("Number of pins has to be a number without decimals");
                }
            }            
        }
    }
}
