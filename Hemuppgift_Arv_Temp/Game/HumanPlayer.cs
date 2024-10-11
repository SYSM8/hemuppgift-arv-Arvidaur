using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemuppgift_Arv_Temp.Game
{
    public class HumanPlayer : Player
    {
        public string name {  get; set; }
        public HumanPlayer(string name)
        {
            this.name = name;
        }

        public override int TakePins()
        {
            return 1;
        }
    }
}
