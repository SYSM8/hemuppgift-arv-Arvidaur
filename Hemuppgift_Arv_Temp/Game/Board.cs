using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemuppgift_Arv_Temp.Game
{
    public class Board 
    {
        //Properties
        public int NoPins { get; set; }

        //public Board(int NoPins) 
        //{ 
        //    this.NoPins = NoPins;
        //}

        public void SetUp(int pins)
        {
            NoPins = pins;
        }
        public void TakePins(int pinsTaken)
        {

            if ( pinsTaken > 0 && pinsTaken <= 2)
            {
                NoPins -= pinsTaken;

                ShowGameBoard();
            }
            else
            {
                Console.WriteLine("You only take 1 or 2 pins");
            }
        }

        public void ShowGameBoard() //Metod som printar spelplanen som den ser ut i nuläget
        {
            string output = "";
            for (int i = 0; i < NoPins; i++)
            {
                output += "|";
            }
            Console.WriteLine(output);
        }
        public int GetNoPins()
        {
            return NoPins;
        }
    }
}
