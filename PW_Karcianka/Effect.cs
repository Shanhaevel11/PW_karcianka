using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW_Karcianka
{
    class Effect
    {
        /*type of effect: 
        0 - poison/regeneration (difference in target and power)
        1 - more/less mana
        2 - counterattack
        */
        short type;
        //If target = null, it targets all players
        Player target;
        Player owner;
        short[] power;
        //if type!=2 variable below will be null
        Activity counterattack;
        short duration;

        public Effect(Player target, short type, short[] power, Activity counterattack, short duration){
            this.target = target;
            this.type = type;
            this.power = power;
            this.duration = duration;
            if (type == 3)
            {
                this.counterattack = counterattack;
            }
        }

    }
}
