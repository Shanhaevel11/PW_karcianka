using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW_Karcianka
{
    class Game
    {
        Player[] players;
        GameState state;
        Boolean finished;

        public Game(Player p1, Player p2){
            finished = false;
            players = new Player[2];
            players[0] = p1;
            players[1] = p2;
            state = new GameState(p1, p2);
        }
    }
}
