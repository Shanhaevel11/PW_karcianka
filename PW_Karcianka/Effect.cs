using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW_Karcianka
{
    [Serializable]
    class Effect
    {
        //own - player, opp - opponent
        String target;
        short power;
        short duration;

        public Effect(String target, short power, short duration){
            this.target = target;
            this.power = power;
            this.duration = duration;
        }

    }
}
