using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemuppgift_Arv_Temp.Game
{
    public class SmartComputerPlayer : Player
    {
        public SmartComputerPlayer() : base("Smart Computer")
        {

        }

        Random rnd = new Random();
        public override int TakePins(Board board1)
        {
            int pinstaken;

            int noPins = board1.GetNoPins();

            if (noPins % 3 == 1) // 1, 4, 7, 10
            {
                return 1;
            }
            else if (noPins % 3 == 2) // 2, 5, 8, 11
            {
                return 2;
            }
            else //random between 1 and 2
            {
                pinstaken = rnd.Next(1, 3);
                return pinstaken;
            }
        }
    }
}

