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
        GameState[] states;
        Boolean finished;

        public Game(Player p1, Player p2){
            finished = false;
            states = new GameState[2];
            players = new Player[2];
            players[0] = p1;
            players[1] = p2;
            states[0] = new GameState(p1, p2);
            states[1] = new GameState(p2, p1);

        }
    }
}
