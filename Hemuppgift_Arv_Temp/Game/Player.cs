using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemuppgift_Arv_Temp.Game
{
    public abstract class Player 
    {
        //Properties
        public string userId {  get; set; }

        //Constructor
        public Player(string userId)
        {
            this.userId = userId;
        }

        public virtual string GetUserId()
        { 
            return userId; 
        }

        public abstract int TakePins(Board board1, int difficulty);
    }
}
