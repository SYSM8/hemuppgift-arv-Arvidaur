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

            switch (board1.GetNoPins())
            {
                case 1:
                    return 1;
                case 2:
                    return 2;
                case 4:
                    return 1;
                case 5:
                    return 2;
                case 7:
                    return 1;
                case 8:
                    return 2;
                case 10:
                    return 1;
                case 11:
                    return 2;
                default:
                    pinstaken = rnd.Next(1, 3);
                    return pinstaken;
            }
        }
    }
}
