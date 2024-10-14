using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemuppgift_Arv_Temp.Game
{
    public class ComputerPlayer : Player
    {
        public ComputerPlayer() : base("Computer")
        {

        }

        Random rnd = new Random();

        public override int TakePins(Board board1)
        {
            int pinstaken;
   
            pinstaken = rnd.Next(1, 3);
            return pinstaken;

        }
    }
}
