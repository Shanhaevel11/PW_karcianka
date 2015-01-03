using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW_Karcianka
{
    class Activity
    {
        /*
         * 0 - damage
         * 1 - heal
         * 2 - mana boom
         * 3 - remove trut
         * 4 - remove regeneration
         * 5 - remove mana effect
         * 6 - remove all effects
         */
        short type;
        Effect effect;
        //If target = null, it targets all players
        Player target;
        short[] power;

        public Activity(short type, Effect effect, Player target, short[] power)
        {
            this.type = type;
            this.effect = effect;
            this.target = target;
            this.power = power;
        }
    }
}
