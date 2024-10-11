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

        public override int TakePins(Board board1, int difficulty)
        {
            int pinstaken;

            
            switch (difficulty)
            {              
                case 1: //Easy mode (stupid mode)
                    pinstaken = rnd.Next(1, 3);
                    return pinstaken;
                
                case 2: //Medium mode
                    switch (board1.GetNoPins())
                {
                    case 1:
                        return 1;
                    case 2:
                        return 2;
                    case 4:
                        return 1;
                    default:
                        pinstaken = rnd.Next(1, 3);
                        return pinstaken;
                }
                case 3: //Hard mode

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
                        default:
                            pinstaken = rnd.Next(1, 3);
                            return pinstaken;
                    }
                    default:
                    pinstaken = rnd.Next(1, 3);
                    return pinstaken;
            }
        }
    }
}
