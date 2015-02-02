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

        public short Power
        {
            get { return power; }
            set { power = value; }
        }
        short duration;

        public short Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public Effect(String target, short power, short duration){
            this.target = target;
            this.power = power;
            this.duration = duration;
        }

    }
}
