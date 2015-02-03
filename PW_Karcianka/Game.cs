using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW_Karcianka
{
    [Serializable]
    class Game
    {
        public Player[] players;
        //public Boolean finished;
        /**
         * -1 start game
         * 0 - no changes;
         * 1 - play card;
         * 2 - end turn;
         * 3 - disconnect/end game
         */
        public short typeOfChange;
        public String turn;
        public short animationType;

        public Game(Player p1, Player p2){
            //finished = false;
            players = new Player[2];
            players[0] = p1;
            players[1] = p2;
            //state = new GameState(p1, p2);
            typeOfChange = -1;
        }
    }
}
