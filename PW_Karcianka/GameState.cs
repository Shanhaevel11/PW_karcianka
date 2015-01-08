﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace PW_Karcianka
{
    [Serializable]
    class GameState
    {
        short hp;
        Card[] cardsInHand;
        Effect[] effectsOnPlayer;
        Player player;
        Player opponent;

        public GameState(Player p1, Player p2)
        {
            this.player = p1;
            this.opponent = p2;
            this.hp = p1.StartHp;
        }

    }
}
