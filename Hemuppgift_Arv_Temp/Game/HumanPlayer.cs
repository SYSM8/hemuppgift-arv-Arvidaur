using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemuppgift_Arv_Temp.Game
{
    public class HumanPlayer : Player
    {
        public HumanPlayer() : base("HumanPlayer")
        {

        }

        public override int TakePins()
        {
            bool correctInput = false;
            int pins = 0;
            Console.WriteLine("How many pins do you want to take? 1 or 2.");
            
            while (!correctInput)   //Vi kör tills användaren har angett en korrekt inmatning
            {
                if (int.TryParse(Console.ReadLine(), out pins) && pins > 0 && pins <= 2)   //Kontrollerar att det är 1 eller 2 pins som tas
                {
                    correctInput = true;
                    return pins;
                }
                else
                {
                    Console.WriteLine("You may only take 1 or 2 pins, try again");
                }            
            }
            return pins;
        }
    }
}
