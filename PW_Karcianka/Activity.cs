using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW_Karcianka
{
    [Serializable]
    class Activity
    {
        /*
         * -1 - trut or regeneration, check effect
         * 0 - damage
         * 1 - heal
         * 2 - defense up
         * 3 - defense down
         * 4 - attack up
         * 5 - attack down
         * 6 - remove all effects in game
         */
        short type;

        public short Type
        {
            get { return type; }
            set { type = value; }
        }
        Effect effect;
        public Effect Effect
        {
            get { return effect; }
            set { effect = value; }
        }
        //own - owner of spell, opp - opponent, all - all players
        String target;

        public String Target
        {
            get { return target; }
            set { target = value; }
        }
        short power;

        public short Power
        {
            get { return power; }
            set { power = value; }
        }

        public Activity(short type, Effect effect, String target, short power)
        {
            this.type = type;
            this.effect = effect;
            this.target = target;
            this.power = power;
        }
    }
}
