using System;
using System.Net.NetworkInformation;
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
            int whoStarts = rnd.Next(1, 3);

            bool turn;
            if (whoStarts == 1)//Slumpar vem som startar i början av första spelet
            {
                turn = true;
            }
            else
            {
                turn = false;
            }
            
            Board board1 = new Board(); //Skapar ett board objekt vi använder oss av i spelet

            //The game starts
            Console.WriteLine("Welcome to the pingame. Select difficulty. 1: Easy. 2: Medium. 3: Hard.");
            int difficulty;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out difficulty) && difficulty > 0 && difficulty <= 3)   //Kontrollerar att det är korrekt inmatning och att difficulty är mellan 1-3
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Difficulty has to be in the range of 1-3 and");
                }
            }
            while (!donePlaying)
                {
                    bool gameOver = false;
                    Console.WriteLine("Select the number of pins to play with:");
                    int pins = 0;

                    if(turn)
                    {
                        Console.WriteLine($"Player starts");
                    }
                    else
                    {
                        Console.WriteLine($"Computer starts");
                    }
                    if (int.TryParse(Console.ReadLine(), out pins) && pins > 0)   //Kontrollerar att det är korrekt inmatning och att pins är ett positivt tal
                    {
                    board1.SetUp(pins);
                    while (!gameOver)   //Matchen är igång
                    {
                        
                        if (turn)
                        {
                            int pinsTaken = human.TakePins(board1, difficulty);
                            Console.WriteLine($"Human player takes {pinsTaken} pins.");
                            board1.TakePins(pinsTaken);
                            turn = !turn;
                            if (board1.GetNoPins() == 0)
                            {
                                humanWin++;
                                Console.WriteLine($"Human is the winner! Human wins: {humanWin} Computer Wins {computerWin}");

                                turn = false;   //Computer starts if the player wins
                                gameOver = true;
                            }
                            else if (board1.GetNoPins() <= 0)
                            {
                                computerWin++;
                                Console.WriteLine($"Human took to many pins and the computer is the winner! Human wins: {humanWin} Computer Wins {computerWin}");

                                turn = true;    //Player starts if computer wins
                                gameOver = true;                             
                            }
                            
                        }
                        else
                        {
                            int pinsTaken = computer.TakePins(board1, difficulty);
                            Console.WriteLine($"Computer player takes {pinsTaken} pins.");
                            board1.TakePins(pinsTaken);
                            turn = !turn;
                            if (board1.GetNoPins() == 0)
                            {
                                computerWin++;
                                Console.WriteLine($"Computer is the winner! Human wins: {humanWin} Computer Wins {computerWin}");

                                turn = true;    //Player starts if computer wins
                                gameOver = true;  
                            } 
                            else if (board1.GetNoPins() <= 0)
                            {
                                humanWin++;
                                Console.WriteLine($"The computer took to many pins and human player is the winner! Human wins: {humanWin} Computer Wins {computerWin}");

                                turn = false;   //Computer starts if the player wins
                                gameOver = true;
                            }                           
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
