using System;
using System.Net.NetworkInformation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hemuppgift_Arv_Temp.Game
{
    /*
    Svar på frågorna:
    F2.a) Basklass/superklass
    F2.b) 2, 3
    
    D4.a)  Vi kan skapa våra egna metoder för humanPlayer, ComputerPlayer och SmartComputerPlayer baserade på den abstrakta metoden i superklassen.
    D4.b) En abstrakt metod är en metod man deklarerar utan en kropp då tanken är att man skriver över den i ärvda/subklasser. I vårt fall har vi den där för att 
    vi vill ha samma metodnamn som nås från player klassen men vi vill att HumanPlayer, ComputerPlayer och SmartComputerPlayer gör olika saker men funktionen är
    i grunden likadan.
    */

    internal class TakePins
    {
        //Här är main klassen där koden ska testas, lägg in i mappen
        static void Main(string[] args)
        {
            int humanWin = 0;
            int computerWin = 0;
          
            Player computer = new ComputerPlayer();
            Player smartComputer = new SmartComputerPlayer();
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

            Console.WriteLine("What is you name?");
            //string playerName = Console.ReadLine();
            Player human = new HumanPlayer(Console.ReadLine()); //UserId för humanplayer blir vad användaren matar in

            //The game starts
            Console.WriteLine("Welcome to the pingame. Select difficulty. 1: Dumb Opponent ( randomized moves ). 2: Smart Opponent");
            int difficulty;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out difficulty) && difficulty > 0 && difficulty <= 2)   //Kontrollerar att det är korrekt inmatning och att difficulty är mellan 1-2
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Difficulty has to be in the range of 1-2");
                }
            }
            
            while (!donePlaying)
                {
                    bool gameOver = false;
                    Console.WriteLine("Select the number of pins to play with: Minimum is 10");
                    int pins = 0;

                    if(turn)
                    {
                        Console.WriteLine($"{human.GetUserId()} starts");
                    }
                    else
                    {
                        Console.WriteLine($"Computer starts");
                    }
                    if (int.TryParse(Console.ReadLine(), out pins) && pins >= 10)   //Kontrollerar att det är korrekt inmatning och att det är höre eller lika med 10
                    {
                    board1.SetUp(pins);
                    while (!gameOver)   //Matchen är igång
                    {
                        
                        if (turn)
                        {
                            int pinsTaken = human.TakePins(board1);
                            Console.WriteLine($"{human.GetUserId()} takes {pinsTaken} pins.");
                            board1.TakePins(pinsTaken);
                            turn = !turn;
                            
                            if (board1.GetNoPins() == 0)    //Someone is the winner if we enter either one of the two code blocks
                            {
                                humanWin++;
                                Console.WriteLine($"{human.GetUserId()} is the winner! {human.GetUserId()} wins: {humanWin} Computer Wins {computerWin}");

                                turn = false;   //Computer starts if the player wins
                                gameOver = true;
                            }
                            else if (board1.GetNoPins() <= 0)
                            {
                                computerWin++;
                                Console.WriteLine($"{human.GetUserId()} took to many pins and the computer is the winner! {human.GetUserId()} wins: {humanWin} Computer Wins {computerWin}");

                                turn = true;    //Player starts if computer wins
                                gameOver = true;                             
                            }
                            
                        }
                        else
                        {
                            int pinsTaken;
                            if (difficulty == 1)        //Nu använder jag en subklass för en smart opponent och en subklass för den vanliga opponenten
                            {
                                pinsTaken = computer.TakePins(board1);
                            }
                            else
                            {
                                pinsTaken = smartComputer.TakePins(board1);
                            }
                            
                            Console.WriteLine($"Computer player takes {pinsTaken} pins.");
                            board1.TakePins(pinsTaken);
                            turn = !turn;
                            
                            if (board1.GetNoPins() == 0)    //Someone is the winner if we enter either one of the two code blocks
                            {
                                computerWin++;
                                Console.WriteLine($"Computer is the winner! {human.GetUserId()} wins: {humanWin} Computer Wins {computerWin}");

                                turn = true;    //Player starts if computer wins
                                gameOver = true;  
                            } 
                            else if (board1.GetNoPins() <= 0)   
                            {
                                humanWin++;
                                Console.WriteLine($"The computer took to many pins and {human.GetUserId()} is the winner! {human.GetUserId()} wins: {humanWin} Computer Wins {computerWin}");

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
