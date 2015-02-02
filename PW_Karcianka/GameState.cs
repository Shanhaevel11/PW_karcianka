using System;
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

        public Card[] CardsInHand
        {
            get { return cardsInHand; }
            set { cardsInHand = value; }
        }
        Effect[] effectsOnPlayer;

        public Effect[] EffectsOnPlayer
        {
            get { return effectsOnPlayer; }
            set { effectsOnPlayer = value; }
        }
        Player player;

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }
        Player player2;

        public Player Player2
        {
            get { return player2; }
            set { player2 = value; }
        }

        public GameState(Player p1, Player p2)
        {
            this.player = p1;
            this.player2 = p2;
            this.hp = p1.StartHp;
        }

    }
}
