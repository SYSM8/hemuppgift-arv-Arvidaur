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

        //"Contructor"
        public void SetUp(int pins)
        {
            NoPins = pins;
            ShowGameBoard();
        }
        public void TakePins(int pinsTaken)
        {

            
                NoPins -= pinsTaken;

                ShowGameBoard();
            
        }

        public void ShowGameBoard() //Metod som printar spelplanen som den ser ut i nuläget
        {
            string output = "";
            for (int i = 0; i < NoPins; i++)
            {
                output += "|";
            }
            Console.WriteLine(output + " " + NoPins + " pins left.");
        }
        public int GetNoPins()
        {
            return NoPins;
        }
    }
}
